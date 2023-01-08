using RabbitTune.AudioEngine;
using RabbitTune.AudioEngine.AudioOutputApi;
using RabbitTune.AudioEngine.AudioProcess;
using RabbitTune.AudioEngine.BassWrapper.Dsd;
using RabbitTune.AudioEngine.Codecs;
using RabbitTune.MediaLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune
{
    internal static class AudioPlayerManager
    {
        // 非公開変数
        private static AudioPlayer AudioPlayer;
        private static AudioTrack currentTrack;
        private static int volume = 80;
        private static bool useEqualizer = true;
        private static double[] equalizerAverageGainDecibels = 
        {
            0,0,0,0,0,0,0,0,0,0
        };

        // 公開定数
        public const string KEY_AUDIO_OUTPUT_DEVICE_API = @"AudioOutputDeviceApiType";
        public const string KEY_AUDIO_OUTPUT_DEVICE_NAME = @"AudioOutputDevice";
        public const string KEY_USE_WASAPI_EXCLUSIVE_MODE = @"UseWasapiExclusiveMode";
        public const string KEY_USE_WASAPI_EVENTSYNC = @"UseWasapiEventSync";
        public const string KEY_PLAYBACK_LATENCY = @"PlaybackLatency";
        public const string KEY_USE_OUTFMTCONV = @"UseOutputFormatConversion";
        public const string KEY_OUTFMTCONV_SAMPLERATE = @"OutputFormatSampleRate";
        public const string KEY_OUTFMT_BITSPERSAMPLE = @"OutputFormatBitsPerSample";
        public const string KEY_USE_RESAMPLER = @"UseResampler";
        public const string KEY_RESAMPLER_SAMPLERATE = @"ReSamplerSampleRate";
        public const string KEY_RESAMPLER_BITSPERSAMPLE = @"ReSamplerBitsPerSample";
        public const string KEY_RESAMPLER_CHANNELS = @"ReSamplerChannels";
        public const string KEY_AUDIO_OUTPUT_VOLUME = @"AudioOutputVolume";
        public const string KEY_AUDIO_OUTPUT_PANNING = @"AudioOutputPanning";
        public const string KEY_USE_EQUALIZER = @"UseEqualuzer";
        public const string KEY_EQUALIZER_DOWNSAMPLE_TO_32K = @"EqualizerDownSampleTo32K";
        public const string KEY_EQUALIZER_GAINDECIBELS = @"EqualizerGainDecibels";
        public const string KEY_PLAYBACK_SPEED = @"PlaybackSpeed";
        public const string KEY_PITCHSHIFTER_FIX_CLIP = @"PitchShifterFixClip";
        public const string KEY_PLAYBACK_PITCH = @"PlaybackPitch";
        public const string KEY_SOUNDTOUCH_PITCHSHIFTER_PITCHSEMITONES = @"STPitchSemitones";
        public const string KEY_SOUNDTOUCH_PITCHSHIFTER_FIX_CLIP = @"STPitchShifterFixClip";
        public const string KEY_SOUNDFONTS = @"SoundFonts";
        public const string KEY_MIDI_USE_HWMIXING = @"UseHWMixing";
        public const string KEY_MIDI_USE_SINC_INTERPOLATION = @"UseSincInterpolation";
        public const string KEY_ENABLE_MMCSS = @"EnableMMCSS";
        public const string KEY_DSDTOPCM_SAMPLERATE = @"DSDToPCMSampleRate";
        public const string KEY_DSDTOPCM_GAIN = @"DSDToPCMGain";
        public const string KEY_USE_MIDSIDEMIXER = @"UseMSMixer";
        public const string KEY_MID_SIGNAL_BOOST_LEVEL = @"MSMixerMidSignalBoostLevel";
        public const string KEY_SIDE_SIGNAL_BOOST_LEVEL = @"MSMixerSideSignalBoostLevel";

        // 公開イベント
        public static event EventHandler PlaybackPositionChanged;
        public static event EventHandler ReachEnd;
        public static event EventHandler StoppedByUser;
        public static event EventHandler OutputFormatChanged;

        #region 標準プロパティ

        /// <summary>
        /// トラックが読み込み済みであるかどうか
        /// </summary>
        public static bool IsTrackLoaded { private set; get; } = false;

        /// <summary>
        /// 一時停止中であるかどうか
        /// </summary>
        public static bool IsPausing { private set; get; } = false;

        /// <summary>
        /// 再生中であるかどうか
        /// </summary>
        public static bool IsPlaying { private set; get; } = false;

        /// <summary>
        /// 音量
        /// </summary>
        public static int Volume
        {
            set
            {
                if(AudioPlayer != null)
                {
                    AudioPlayer.Volume = volume;
                }

                volume = value;
            }
            get
            {
                return volume;
            }
        }

        /// <summary>
        /// 演奏時間
        /// </summary>
        public static long Duration
        {
            get
            {
                if(AudioPlayer != null)
                {
                    return AudioPlayer.Length;
                }

                return 0;
            }
        }

        /// <summary>
        /// 再生位置
        /// </summary>
        public static long Position
        {
            get
            {
                if(AudioPlayer != null)
                {
                    return AudioPlayer.Position;
                }

                return 0;
            }
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.Position = value;
                }
            }
        }

        #endregion

        #region オーディオ出力関連（出力デバイス,レイテンシなど)

        /// <summary>
        /// オーディオ出力デバイスの種類(API)
        /// </summary>
        public static AudioOutputDeviceApiType OutputDeviceApiType { set; get; } = AudioOutputDeviceApiType.DirectSound;

        /// <summary>
        /// オーディオ出力デバイスの名前
        /// </summary>
        public static string AudioOutputDevice { set; get; } = null;

        /// <summary>
        /// Windows Audio Session(WASAPI)を使用する際に排他モードを使用するかどうか
        /// </summary>
        public static bool UseWasapiExclusiveMode { set; get; } = true;

        /// <summary>
        /// Windows Audio Session(WASAPI)使用時にイベントモードを使用するかどうか（高負荷）
        /// </summary>
        public static bool UseWasapiEventSync { set; get; } = false;

        /// <summary>
        /// レイテンシー
        /// </summary>
        public static int PlaybackLatency { set; get; } = 128;

        /// <summary>
        /// MMCSSを使用するかどうか
        /// </summary>
        public static bool EnableMMCSS { set; get; } = false;

        #endregion

        #region イコライザ関連

        /// <summary>
        /// イコライザを使用するかどうか
        /// </summary>
        public static bool UseEqualizer
        {
            set
            {
                if (AudioPlayer != null)
                {
                    ApplyEqualizerOptions(value, EqualizerAverageGainDecibels);
                }

                useEqualizer = value;
            }
            get
            {
                return useEqualizer;
            }
        }

        /// <summary>
        /// イコライザ処理前に32khzにダウンサンプリングするかどうか<br/>
        /// ※この設定値は再生中に変更できません。（変更しても反映されません）
        /// </summary>
        public static bool DownSampleTo32KBeforeEqualizerProcess { set; get; } = true;

        /// <summary>
        /// イコライザの各フィルタの平均GainDB
        /// </summary>
        public static double[] EqualizerAverageGainDecibels
        {
            set
            {
                if (AudioPlayer != null)
                {
                    ApplyEqualizerOptions(UseEqualizer, value);
                }

                equalizerAverageGainDecibels = value;
            }
            get
            {
                return equalizerAverageGainDecibels;
            }
        }

        /// <summary>
        /// イコライザの設定を反映する。
        /// </summary>
        private static void ApplyEqualizerOptions(bool enabled, double[] levels)
        {
            if (AudioPlayer != null)
            {
                for (int filterIndex = 0; filterIndex < levels.Length; ++filterIndex)
                {
                    AudioPlayer.SetAverageGainDB(filterIndex, levels[filterIndex]);
                }

                AudioPlayer.UseEqualizer = enabled;
            }
        }

        /// <summary>
        /// イコライザの指定されたフィルタの平均GainDBを取得する。<br/>
        /// なお、イコライザが初期化されていない場合、とりあえず0（既定値）を返す。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public static double GetAverageGainDB(int filterIndex)
        {
            if (AudioPlayer != null)
            {
                return AudioPlayer.GetAverageGainDB(filterIndex);
            }

            if(EqualizerAverageGainDecibels.Length <= filterIndex)
            {
                return 0;
            }

            return EqualizerAverageGainDecibels[filterIndex];
        }

        /// <summary>
        /// 指定されたインデックスのイコライザの値を設定する。<br/>
        /// 再生中ならプレーヤーにも反映する。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <param name="value"></param>
        public static void SetAverageGainDB(int filterIndex, double value)
        {
            EqualizerAverageGainDecibels[filterIndex] = value;
            ApplyEqualizerOptions(UseEqualizer, EqualizerAverageGainDecibels);
        }

        /// <summary>
        /// イコライザの指定されたフィルタの平均周波数を取得する。<br/>
        /// なお、イコライザが初期化されていない場合、とりあえず既定値を返す。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public static double GetAverageFrequency(int filterIndex)
        {
            if (AudioPlayer != null)
            {
                return AudioPlayer.GetAverageFrequency(filterIndex);
            }

            return Equalizer.GetDefaultAverageFrequency(filterIndex);
        }

        #endregion

        #region リサンプラー関連

        /// <summary>
        /// リサンプラーを使用するかどうか
        /// </summary>
        public static bool UseReSampler { private set; get; }

        /// <summary>
        /// リサンプラーの変換先サンプルレート
        /// </summary>
        public static int ReSamplerSampleRate { private set; get; }

        /// <summary>
        /// リサンプラーの変換先量子化ビット数
        /// </summary>
        public static int ReSamplerBitsPerSample { private set; get; }

        /// <summary>
        /// リサンプラーの変換先チャンネル数
        /// </summary>
        public static int ReSamplerChannels { private set; get; }

        /// <summary>
        /// リサンプラーの設定を変更する。
        /// </summary>
        /// <param name="useReSampler"></param>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public static void SetReSamplerOptions(
            bool useReSampler = false,
            int sampleRate = AudioPlayer.WAVEFORMAT_NOCONV,
            int bitsPerSample = AudioPlayer.WAVEFORMAT_NOCONV,
            int channels = AudioPlayer.WAVEFORMAT_NOCONV)
        {
            // プロパティに保持
            UseReSampler = useReSampler;
            ReSamplerSampleRate = sampleRate;
            ReSamplerBitsPerSample = bitsPerSample;
            ReSamplerChannels = channels;

            // 設定
            if(AudioPlayer != null)
            {
                AudioPlayer.SetReSamplerOptions(UseReSampler, ReSamplerSampleRate, ReSamplerBitsPerSample, ReSamplerChannels, true);
            }
        }

        #endregion

        #region 再生速度変更関連

        // 再生速度変更関連の非公開変数
        private static float playbackSpeed;

        /// <summary>
        /// 再生速度
        /// </summary>
        public static float PlaybackSpeed
        {
            set
            {
                if(AudioPlayer != null)
                {
                    AudioPlayer.PlaybackSpeed = value;
                }

                playbackSpeed = value;
            }
            get
            {
                return playbackSpeed;
            }
        }

        #endregion

        #region ピッチシフト(NAudio)関連

        // ピッチシフト関連の非公開変数
        private static int pitch = 0;
        private static bool pitchShifterFixClip = true;

        /// <summary>
        /// ピッチ
        /// </summary>
        public static int Pitch
        {
            set
            {
                if(AudioPlayer != null)
                {
                    AudioPlayer.Pitch = value;
                }

                pitch = value;
            }
            get
            {
                return pitch;
            }
        }

        /// <summary>
        /// ピッチシフト時のクリッピング（音割れ）防止を使用するかどうか<br/>
        /// ※このプロパティは再生中の変更に対応していません。
        /// </summary>
        public static bool PitchShifterFixClip
        {
            set
            {
                if(AudioPlayer != null)
                {
                    AudioPlayer.PitchShifterFixClip = value;
                }

                pitchShifterFixClip = value;
            }
            get
            {
                return pitchShifterFixClip;
            }
        }

        #endregion

        #region ピッチシフト(SoundTouch)関連

        // ピッチシフト(SoundTouch)関連の非公開変数
        private static int pitchSemitones = 0;
        private static bool soundTouchPitchShifterFixClip = false;

        /// <summary>
        /// SoundTouchのピッチシフターのピッチ変化量（半音単位）
        /// </summary>
        public static int SoundTouchPitchSemitones
        {
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.SoundTouchPitchShifterPitchSemitones = value;
                }

                pitchSemitones = value;
            }
            get
            {
                return pitchSemitones;
            }
        }

        /// <summary>
        /// SoundTouchによるピッチシフト時のクリッピング（音割れ）防止を使用するかどうか<br/>
        /// ※このプロパティは再生中の変更に対応していません。
        /// </summary>
        public static bool SoundTouchPitchShifterFixClip
        {
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.SoundTouchPitchShifterFixClip = value;
                }

                soundTouchPitchShifterFixClip = value;
            }
            get
            {
                return soundTouchPitchShifterFixClip;
            }
        }

        #endregion

        #region 左右音量バランス関連

        // 音量バランス関連の非公開フィールド
        private static int _balance = 0;

        /// <summary>
        /// 左右バランス<br/>
        /// -100から100の範囲内の整数で指定。-100に近いほど左、100に近いほど右から音が聞こえる。<br/>
        /// 0を指定することで、左右均等（デフォルト）になる。
        /// </summary>
        public static int Balance
        {
            set
            {
                if(AudioPlayer != null)
                {
                    AudioPlayer.Balance = value;
                }

                // 後始末
                _balance = value;
            }
            get
            {
                return _balance;
            }
        }

        #endregion

        #region ミッドサイドミキサー関連

        // ミッドサイドミキサー関連の非公開フィールド
        private static bool useMidSideMixer;
        private static float midSignalBoostLevel = 1.0f;
        private static float sideSignalBoostLevel = 1.0f;

        /// <summary>
        /// ミッドサイドミキサーを使用するかどうか
        /// </summary>
        public static bool UseMidSideMixer
        {
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.UseMidSideMixer = value;
                }

                useMidSideMixer = value;
            }
            get
            {
                return useMidSideMixer;
            }
        }

        /// <summary>
        /// Mid信号のブーストレベル
        /// </summary>
        public static float MidSignalBoostLevel
        {
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.MidSignalBoostLevel = value;
                }

                midSignalBoostLevel = value;
            }
            get
            {
                return midSignalBoostLevel;
            }
        }

        /// <summary>
        /// Side信号のブーストレベル
        /// </summary>
        public static float SideSignalBoostLevel
        {
            set
            {
                if (AudioPlayer != null)
                {
                    AudioPlayer.SideSignalBoostLevel = value;
                }

                sideSignalBoostLevel = value;
            }
            get
            {
                return sideSignalBoostLevel;
            }
        }

        #endregion

        #region デバイス出力フォーマットのプロパティ

        /// <summary>
        /// デバイス出力のフォーマットをユーザ指定値に変換するかどうか
        /// </summary>
        public static bool UseDeviceOutputWaveFormatConversion { set; get; }

        /// <summary>
        /// デバイス出力のサンプルレート
        /// </summary>
        public static int DeviceOutputWaveFormatSampleRate { set; get; } = AudioPlayer.WAVEFORMAT_NOCONV;

        /// <summary>
        /// デバイス出力の量子化ビット数
        /// </summary>
        public static int DeviceOutputWaveFormatBitsPerSample { set; get; } = AudioPlayer.WAVEFORMAT_NOCONV;

        #endregion

        #region MIDI・サウンドフォント関連

        /// <summary>
        /// MIDIの再生に使用するサウンドフォントの一覧
        /// </summary>
        public static SoundFont[] SoundFonts
        {
            set
            {
                MidiDecoder.SoundFonts = value;
            }
            get
            {
                return MidiDecoder.SoundFonts;
            }
        }

        /// <summary>
        /// 波形のミックスに線形補完の代わりにSinc補完を使用するかどうか<br/>
        /// Sinc補完は、線形補完よりも音質が向上する一方で、CPUに負荷がかかる。
        /// </summary>
        public static bool MidiUseSincInterpolation
        {
            set
            {
                MidiDecoder.UseSincInterpolation = value;
            }
            get
            {
                return MidiDecoder.UseSincInterpolation;
            }
        }

        /// <summary>
        /// ハードウェアミキシングを使用するかどうか<br/>
        /// ハードウェアミキシングが無効の場合、ソフトウェアミキシングを使用します。
        /// </summary>
        public static bool MidiUseHardwareMixing
        {
            set
            {
                MidiDecoder.UseHWMixing = value;
            }
            get
            {
                return MidiDecoder.UseHWMixing;
            }
        }

        #endregion

        #region DSD関連

        public static int DsdToPcmSampleRate
        {
            set
            {
                BassDsd.SetDSDToPCMFrequency(value);
            }
            get
            {
                return BassDsd.GetDSDToPCMFrequency();
            }
        }

        public static int DsdToPcmGain
        {
            set
            {
                BassDsd.SetDSDToPCMGain(value);
            }
            get
            {
                return BassDsd.GetDSDToPCMGain();
            }
        }

        #endregion

        /// <summary>
        /// 現在の再生位置をTimeSpanとして取得する。
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetPosition()
        {
            if(AudioPlayer != null)
            {
                return AudioPlayer.GetPosition();
            }

            return TimeSpan.FromSeconds(0);
        }

        /// <summary>
        /// 開かれているオーディオソースの長さをTimeSpanとして取得する。
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetDuration()
        {
            if(AudioPlayer != null)
            {
                return AudioPlayer.GetLength();
            }

            return TimeSpan.FromSeconds(0);
        }

        /// <summary>
        /// AudioSourceプロパティに設定されたオーディオソースのフォーマットを取得する。<br/>
        /// このメソッドで取得できる値は、各種音響処理やデバイス出力に合わせて変換されたフォーマットではなく、<br/>
        /// AudioSourceプロパティに設定されたオーディオソースの本来のフォーマットです。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public static void GetInputWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if (AudioPlayer != null)
            {
                AudioPlayer.GetInputAudioSourceWaveFormat(out sampleRate, out bitsPerSample, out channels);
            }
            else
            {
                throw new Exception("SetTrackメソッドの呼び出し前にこのメソッドを呼び出すことはできません。");
            }
        }

        /// <summary>
        /// 各種音響処理後のオーディオソースのフォーマットを取得する。<br/>
        /// ※音響処理前のフォーマットの取得には、GetInputWaveFormatメソッドを使用してください。<br/>
        /// 　また、出力デバイスが実際に出力するフォーマットを取得するには、GetDeviceOutputFormatメソッドを使用してください。<br/>
        /// 　なお、このメソッドが返すフォーマットがデバイスでサポートされていない場合、GetDeviceOutputWaveFormatメソッドが返す<br/>
        /// 　フォーマットが使用されます。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        /// <exception cref="Exception"></exception>
        public static void GetOutputWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if(AudioPlayer != null)
            {
                AudioPlayer.GetOutputAudioSourceWaveFormat(out sampleRate, out bitsPerSample, out channels);
            }
            else
            {
                throw new Exception("SetTrackメソッドの呼び出し前にこのメソッドを呼び出すことはできません。");
            }
        }

        /// <summary>
        /// 現在のオーディオ出力デバイスが使用するフォーマットを取得する。<br/>
        /// ※このメソッドで取得される値は、使用中の出力デバイスで実際に出力されるフォーマットです。<br/>
        /// 　そのため、GetOutputWaveFormatが返すフォーマットがデバイスで対応していないものである場合などには、<br/>
        /// 　このメソッドとGetOutputWaveFormatメソッドの値が異なる場合がありますが、このメソッドが返す値が<br/>
        /// 　実際に出力されるフォーマットであり、GetOutputWaveFormatメソッドの値は、音響処理が終了した時点での<br/>
        /// 　フォーマットです。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public static void GetDeviceOutputWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if (AudioPlayer != null)
            {
                AudioPlayer.GetDeviceOutputWaveFormat(out sampleRate, out bitsPerSample, out channels);
            }
            else
            {
                throw new Exception("SetTrackメソッドの呼び出し前にこのメソッドを呼び出すことはできません。");
            }
        }

        /// <summary>
        /// オーディオプレーヤーを閉じる。
        /// </summary>
        public static void Close()
        {
            if(AudioPlayer != null)
            {
                AudioPlayer.Dispose();

                // 後始末
                IsTrackLoaded = false;
                IsPausing = false;
                IsPlaying = false;
                AudioPlayer = null;
                GC.Collect();
            }
        }

        /// <summary>
        /// オーディオ出力デバイスを取得してプレーヤーを初期化する。
        /// </summary>
        private static void Init(AudioTrack track)
        {
            // オーディオ出力デバイスを取得してプレーヤーを初期化。
            AudioPlayer = new AudioPlayer(
                OutputDeviceApiType,
                AudioOutputDevice,
                PlaybackLatency,
                UseWasapiEventSync,
                UseWasapiExclusiveMode,
                EnableMMCSS);

            // 各種イベントの設定
            AudioPlayer.PlaybackPositionChanged += delegate
            {
                PlaybackPositionChanged?.Invoke(null, null);
            };
            AudioPlayer.ReachEnd += delegate
            {
                ReachEnd?.Invoke(null, null);
            };
            AudioPlayer.StoppedByUser += delegate
            {
                StoppedByUser?.Invoke(null, null);
            };
            AudioPlayer.OutputFormatChanged += delegate
            {
                OutputFormatChanged?.Invoke(null, null);
            };

            // 音響処理設定
            // ※必ずAudioSourceプロパティの設定前に行う。
            AudioPlayer.SetOutputWaveFormat(UseDeviceOutputWaveFormatConversion, DeviceOutputWaveFormatSampleRate, DeviceOutputWaveFormatBitsPerSample);

            // オーディオソースを設定
            AudioPlayer.AudioSource = ReadAudioTrack(track);
            currentTrack = track;

            // イコライザの設定
            AudioPlayer.DownSampleTo32KBeforeEqualizerProcess = DownSampleTo32KBeforeEqualizerProcess;
            ApplyEqualizerOptions(UseEqualizer, EqualizerAverageGainDecibels);

            // リサンプラーの設定
            AudioPlayer.SetReSamplerOptions(UseReSampler, ReSamplerSampleRate, ReSamplerBitsPerSample, ReSamplerChannels, false);

            // 再生速度の設定
            AudioPlayer.PlaybackSpeed = PlaybackSpeed;

            // ピッチの設定
            AudioPlayer.PitchShifterFixClip = PitchShifterFixClip;
            AudioPlayer.Pitch = Pitch;

            // SoundTouchによるピッチの設定
            AudioPlayer.SoundTouchPitchShifterPitchSemitones = SoundTouchPitchSemitones;
            AudioPlayer.SoundTouchPitchShifterFixClip = SoundTouchPitchShifterFixClip;

            // 再生前に設定された音量を反映
            AudioPlayer.Volume = Volume;

            // 再生前に設定された定位を反映
            AudioPlayer.Balance = Balance;

            // 再生前に設定されたミッドサイドミキサーのオプションを反映
            AudioPlayer.UseMidSideMixer = UseMidSideMixer;
            AudioPlayer.MidSignalBoostLevel = MidSignalBoostLevel;
            AudioPlayer.SideSignalBoostLevel = SideSignalBoostLevel;

            // 後始末
            IsTrackLoaded = true;
        }

        /// <summary>
        /// 再生するトラックを設定する。
        /// </summary>
        /// <param name="track"></param>
        public static void SetTrack(AudioTrack track)
        {
            if (track.Location.ToLower().EndsWith(".mid"))
            {
                if (SoundFonts == null || SoundFonts.Length == 0)
                {
                    MessageBox.Show("MIDIファイルの再生には、最低1つ以上のサウンドフォントが必要ですが、\n" +
                        "再生に使用するサウンドフォントが設定されていません。\n" +
                        "設定画面から再生に使用するサウンドフォントを追加してください。",
                        "サウンドフォントが未設定です",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            // 初期化処理
            Close();
            Init(track);
        }

        /// <summary>
        /// 現在のトラックを取得する。
        /// </summary>
        /// <returns></returns>
        public static AudioTrack GetCurrentTrack()
        {
            if(AudioPlayer != null)
            {
                return currentTrack;
            }

            return null;
        }

        /// <summary>
        /// 再生
        /// </summary>
        public static void Play()
        {
            // 再生
            AudioPlayer.AudioSource.Seek(0, SeekOrigin.Begin);
            AudioPlayer.Play();

            // 後始末
            IsPausing = false;
            IsPlaying = true;
        }

        /// <summary>
        /// 停止
        /// </summary>
        public static void Stop()
        {
            if (AudioPlayer != null)
            {
                AudioPlayer.Stop();
                Close();

                // 後始末
                IsPausing = false;
                IsPlaying = false;
            }
        }

        /// <summary>
        /// 一時停止
        /// </summary>
        public static void Pause()
        {
            if(AudioPlayer != null)
            {
                AudioPlayer.Pause();

                // 後始末
                IsPausing = true;
                IsPlaying = false;
            }
        }

        /// <summary>
        /// 一時停止解除
        /// </summary>
        public static void Resume()
        {
            if(AudioPlayer != null)
            {
                AudioPlayer.Resume();

                // 後始末
                IsPausing = false;
                IsPlaying = true;
            }
        }

        /// <summary>
        /// 指定されたオーディオトラックを読み込む。
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        private static AudioReader ReadAudioTrack(AudioTrack track)
        {
            if (File.Exists(track.Location))
            {
                return new AudioReader(track.Location);
            }

            return null;
        }
    }
}
