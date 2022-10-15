using NAudio.CoreAudioApi;
using NAudio.Wave;
using RabbitTune.AudioEngine.AudioOutputApi;
using RabbitTune.AudioEngine.AudioProcess;
using System;

namespace RabbitTune.AudioEngine
{
    public class AudioPlayer
    {
        public const int WAVEFORMAT_NOCONV = -1;        // AudioSourceプロパティのWaveFormatをそのまま使用

        // 非公開変数
        private AudioReader inputAudioSource;
        private readonly Timer PlaybackTimer;
        private ISampleProvider audioProcessSampleProvider;
        private IWaveProvider outputAudioSource;
        private bool IsDisposed;
        private bool IsDeviceInitialized;
        private int volume = 80;
        private bool isStopped = true;

        // 公開イベント
        public event EventHandler PlaybackPositionChanged;
        public event EventHandler ReachEnd;
        public event EventHandler OutputFormatChanged;
        public event EventHandler StoppedByUser;

        // コンストラクタ
        public AudioPlayer(
            AudioOutputDeviceApiType audioOutputDeviceApi,
            string deviceName,
            int latency,
            bool useWasapiEventSync,
            bool useWasapiExclusiveMode,
            bool dwmEnableMMCSS)
        {
            Win32Api.DwmEnableMMCSS(dwmEnableMMCSS);

            // オーディオ出力デバイスのインスタンスを作成
            this.audioOutputDeviceApi = audioOutputDeviceApi;
            this.deviceName = deviceName;
            this.latency = latency;
            this.useWasapiEventSync = useWasapiEventSync;
            this.useWasapiExclusiveMode = useWasapiExclusiveMode;
            CreateDeviceOutput();

            this.Volume = this.volume;          // 再生開始前に設定された音量を反映
            this.IsDisposed = false;

            // 再生イベントタイマーを作成。
            this.PlaybackTimer = new Timer();
            this.PlaybackTimer.ShortInterval = 64;      // ShortTickイベントの発生間隔を64msに設定
            this.PlaybackTimer.LongInterval = 1000;     // LongTickイベントの発生間隔と1000msに設定

            // 再生位置が変更された際の処理をShortTickに設定
            this.PlaybackTimer.ShortTick += delegate
            {
                if(this.AudioSource != null && this.AudioOutputDevice != null)
                {
                    this.PlaybackPositionChanged?.Invoke(null, null);
                }
            };

            // 最後まで再生したかどうかの判定イベントをLongTickに設定
            // ※1000ms以下の間隔で終了判定を行うと、BASSを使う一部のコーデックで
            //   永遠に最後まで再生したと認識されない場合がある。
            this.PlaybackTimer.LongTick += delegate
            {
                if (this.AudioSource != null)
                {
                    var time = GetPosition();
                    var duration = GetLength();

                    if(time.TotalMilliseconds > -1 && duration.TotalMilliseconds > -1 && time >= duration && ((time - duration).TotalMilliseconds > -1))
                    {
                        if (!this.isStopped)
                        {
                            this.ReachEnd?.Invoke(null, null);
                        }
                    }
                }
            };
        }

        #region 標準プロパティ

        /// <summary>
        /// オーディオソース
        /// </summary>
        public AudioReader AudioSource
        {
            get
            {
                return this.inputAudioSource;
            }
            set
            {
                this.inputAudioSource = value;
                LoadAudioSource();
            }
        }

        /// <summary>
        /// 実際に再生されるオーディオソース
        /// </summary>
        public IWaveProvider OutputAudioSource
        {
            get
            {
                return this.outputAudioSource;
            }
        }

        /// <summary>
        /// 再生位置
        /// </summary>
        public long Position
        {
            get
            {
                return this.AudioSource.Position;
            }
            set
            {
                this.AudioSource.Position = value;
            }
        }

        /// <summary>
        /// 演奏時間
        /// </summary>
        public long Length
        {
            get
            {
                return this.AudioSource.Length;
            }
        }

        #endregion

        #region デバイス出力生成用メソッド群

        // デバイス出力関連の非公開変数
        private readonly AudioOutputDeviceApiType audioOutputDeviceApi;
        private readonly string deviceName;
        private readonly int latency;
        private readonly bool useWasapiEventSync;
        private readonly bool useWasapiExclusiveMode;
        private IWavePlayer AudioOutputDevice;

        /// <summary>
        /// デバイス出力のインスタンスを生成する。
        /// </summary>
        private void CreateDeviceOutput()
        {
            switch (this.audioOutputDeviceApi)
            {
                case AudioOutputDeviceApiType.WaveOut:
                    this.AudioOutputDevice = CreateWaveOut(deviceName, latency);
                    break;
                case AudioOutputDeviceApiType.WaveOutEvent:
                    this.AudioOutputDevice = CreateWaveOutEvent(deviceName, latency);
                    break;
                case AudioOutputDeviceApiType.DirectSound:
                    this.AudioOutputDevice = CreateDirectSoundOutput(deviceName, latency);
                    break;
                case AudioOutputDeviceApiType.Wasapi:
                    this.AudioOutputDevice = CreateWasapiOutput(deviceName, latency, useWasapiEventSync, useWasapiExclusiveMode);
                    break;
                case AudioOutputDeviceApiType.Asio:
                    this.AudioOutputDevice = CreateAsioOutput(deviceName);
                    break;
            }
        }

        /// <summary>
        /// WaveOutデバイス出力のインスタンスを生成する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="latency"></param>
        /// <returns></returns>
        private NAudio.Wave.WaveOut CreateWaveOut(string deviceName, int latency)
        {
            var output = new NAudio.Wave.WaveOut();
            output.DeviceNumber = AudioOutputApi.WaveOut.GetDevice(deviceName);
            output.DesiredLatency = latency;
            
            // 後始末
            return output;
        }

        /// <summary>
        /// WaveOutEventデバイス出力のインスタンスを生成する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="latency"></param>
        /// <returns></returns>
        private WaveOutEvent CreateWaveOutEvent(string deviceName, int latency)
        {
            var output = new WaveOutEvent();
            output.DeviceNumber = AudioOutputApi.WaveOut.GetDevice(deviceName);
            output.DesiredLatency = latency;

            // 後始末
            return output;
        }

        /// <summary>
        /// DirectSoundデバイス出力のインスタンスを生成する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="latency"></param>
        /// <param name="threadPriority"></param>
        /// <returns></returns>
        private DirectSoundOut CreateDirectSoundOutput(string deviceName, int latency)
        {
            var output = new DirectSoundOut(DirectSound.GetDevice(deviceName), latency);

            return output;
        }

        /// <summary>
        /// Wasapiデバイス出力のインスタンスを生成する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="latency"></param>
        /// <param name="eventSync"></param>
        /// <param name="exclusiveMode"></param>
        /// <returns></returns>
        private WasapiOut CreateWasapiOutput(string deviceName, int latency, bool eventSync, bool exclusiveMode)
        {
            if (exclusiveMode)
            {
                // 排他モード時は、一部のデバイスでレイテンシを500ms以上に設定すると
                // 正常に再生されない場合がある為、500ms以上なら500msに丸め込む。
                if(latency > 500)
                {
                    latency = 500;
                }
            }

            var output = new WasapiOut(Wasapi.GetDevice(deviceName), exclusiveMode ? AudioClientShareMode.Exclusive : AudioClientShareMode.Shared, eventSync, latency);

            return output;
        }

        /// <summary>
        /// ASIOデバイス出力のインスタンスを生成する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        private AsioOut CreateAsioOutput(string deviceName)
        {
            return new AsioOut(deviceName);
        }

        #endregion

        #region 音響処理総合設定

        // 音響処理総合設定に関連する非公開変数
        private bool useDeviceOutputWaveFormatConversion = false;
        private int deviceOutputSampleRate = WAVEFORMAT_NOCONV;
        private int deviceOutputBitsPerSample = WAVEFORMAT_NOCONV;
        private int deviceOutputChannels = WAVEFORMAT_NOCONV;
        private WaveFormatConversion deviceOutputFormatConversion;

        /// <summary>
        /// デバイス出力のフォーマットを設定する。
        /// </summary>
        /// <param name="enableConversion"></param>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        /// <exception cref="Exception"></exception>
        public void SetOutputWaveFormat(bool enableConversion, int sampleRate = WAVEFORMAT_NOCONV, int bitsPerSample = WAVEFORMAT_NOCONV, int channels = WAVEFORMAT_NOCONV)
        {
            if(this.AudioSource == null)
            {
                // 設定を反映
                this.useDeviceOutputWaveFormatConversion = enableConversion;
                this.deviceOutputSampleRate = sampleRate;
                this.deviceOutputBitsPerSample = bitsPerSample;
                this.deviceOutputChannels = channels;
            }
            else
            {
                throw new Exception("AudioSourceプロパティの設定後にデバイス出力のフォーマットを変更することはできません。");
            }
        }

        #endregion

        #region リサンプラー関連

        // リサンプラー関連の非公開変数
        private WaveFormatConversion waveFormatConversion;

        /// <summary>
        /// リサンプラーを作成して出力用オーディオソースに反映する。
        /// </summary>
        private void CreateReSampler(bool enabled, int rate, int bits, int channels)
        {
            // NOCONVを変換
            GetInputAudioSourceWaveFormat(out int isr, out int isb, out int isc);
            rate = rate == WAVEFORMAT_NOCONV ? isr : rate;
            bits = bits == WAVEFORMAT_NOCONV ? isb : bits;
            channels = channels == WAVEFORMAT_NOCONV ? isc : channels;

            // リサンプラーを生成
            this.waveFormatConversion = new WaveFormatConversion(
                        this.audioProcessSampleProvider,
                        enabled,
                        60,
                        rate,
                        bits,
                        channels);
            this.audioProcessSampleProvider = this.waveFormatConversion;
        }

        /// <summary>
        /// リサンプラーの変換設定を行う。
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public void SetReSamplerOptions(
            bool useReSampler = false,
            int rate = WAVEFORMAT_NOCONV,
            int bitsPerSample = WAVEFORMAT_NOCONV,
            int channels = WAVEFORMAT_NOCONV,
            bool invokeChangedEvent = true)
        {
            // 設定変更前の状態をバックアップ
            var pos = this.AudioSource.Position;
            var state = this.AudioOutputDevice.PlaybackState;

            // NOCONVを変換
            GetInputAudioSourceWaveFormat(out int isr, out int isb, out int isc);
            rate = rate == WAVEFORMAT_NOCONV ? isr : rate;
            bitsPerSample = bitsPerSample == WAVEFORMAT_NOCONV ? isb : bitsPerSample;
            channels = channels == WAVEFORMAT_NOCONV ? isc : channels;

            // 停止中ではないか？
            if (state != PlaybackState.Stopped)
            {
                // 停止
                this.AudioOutputDevice.Stop();
                this.AudioOutputDevice.Dispose();

                // 出力デバイスを再生成
                CreateDeviceOutput();

                // 設定を反映
                this.waveFormatConversion.SetWaveFormat(new WaveFormat(rate, bitsPerSample, channels), 60);
                this.waveFormatConversion.Enabled = useReSampler;
                CreateOutputWaveProvider();

                // 設定変更前に再生中だったか？
                if(state == PlaybackState.Playing)
                {
                    this.AudioOutputDevice.Init(this.OutputAudioSource);
                    this.AudioOutputDevice.Play();
                }
            }
            else
            {
                // 設定を反映
                this.waveFormatConversion.SetWaveFormat(new WaveFormat(rate, bitsPerSample, channels), 60);
                this.waveFormatConversion.Enabled = useReSampler;
                CreateOutputWaveProvider();
            }

            if (invokeChangedEvent)
            {
                // イベントの実行
                this.OutputFormatChanged?.Invoke(null, null);
            }
        }

        #endregion

        #region イコライザ関連

        // イコライザ関連の非公開変数
        private Equalizer equalizer;
        private bool useEqualizer;
        private double[] equalizerAverageGainDecibels = new double[10]
        {
            0,0,0,0,0,0,0,0,0,0
        };

        /// <summary>
        /// イコライザを使用するかどうか
        /// </summary>
        public bool UseEqualizer
        {
            set
            {
                if (this.equalizer != null)
                {
                    ChangeEqualizerEnabled(value);
                }

                this.useEqualizer = value;
            }
            get
            {
                return this.useEqualizer;
            }
        }

        /// <summary>
        /// イコライザ処理前に32khzにダウンサンプリングするかどうか
        /// </summary>
        public bool DownSampleTo32KBeforeEqualizerProcess { set; get; }

        /// <summary>
        /// イコライザを作成する。
        /// </summary>
        private void CreateEqualizer()
        {
            this.equalizer = new Equalizer(this.audioProcessSampleProvider);
            this.equalizer.Enabled = this.UseEqualizer;
            this.equalizer.DownSampleTo32KBeforeProcess = this.DownSampleTo32KBeforeEqualizerProcess;
            this.audioProcessSampleProvider = this.equalizer;

            for (int i = 0; i < this.equalizerAverageGainDecibels.Length; ++i)
            {
                this.equalizer.SetAverageGainDB(i, this.equalizerAverageGainDecibels[i]);
            }
        }

        /// <summary>
        /// イコライザの使用可否を設定
        /// </summary>
        /// <param name="value"></param>
        private void ChangeEqualizerEnabled(bool value)
        {
            if (value != this.equalizer.Enabled)
            {
                // 設定変更前の状態をバックアップ
                var pos = this.AudioSource.Position;
                var state = this.AudioOutputDevice.PlaybackState;

                if (state != PlaybackState.Stopped)
                {
                    // 再生中に変更すると再生速度も変化するので、ここで一度停止する。
                    this.AudioOutputDevice.Stop();

                    // 設定を反映
                    this.equalizer.Enabled = value;

                    // 必要に応じて設定変更前の状態を復元
                    switch (state)
                    {
                        case PlaybackState.Playing:
                            this.AudioOutputDevice.Play();
                            break;
                        case PlaybackState.Paused:
                            this.AudioOutputDevice.Pause();
                            break;
                    }
                }
                else
                {
                    this.equalizer.Enabled = value;
                }
            }
        }

        /// <summary>
        /// イコライザの指定されたフィルタの平均GainDBを設定する。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <param name="value"></param>
        public void SetAverageGainDB(int filterIndex, double value)
        {
            if (this.equalizer != null)
            {
                this.equalizer.SetAverageGainDB(filterIndex, value);
            }

            this.equalizerAverageGainDecibels[filterIndex] = value;
        }

        /// <summary>
        /// イコライザの指定されたフィルタの平均GainDBを取得する。<br/>
        /// なお、イコライザが初期化されていない場合、とりあえず0（既定値）を返す。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public double GetAverageGainDB(int filterIndex)
        {
            if (this.equalizer != null)
            {
                return this.equalizer.GetAverageGainDB(filterIndex);
            }

            return 0;
        }

        /// <summary>
        /// イコライザの指定されたフィルタの平均周波数を取得する。<br/>
        /// なお、イコライザが初期化されていない場合、とりあえず既定値を返す。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public double GetAverageFrequency(int filterIndex)
        {
            if (this.equalizer != null)
            {
                return this.equalizer.GetAverageFrequency(filterIndex);
            }

            return Equalizer.GetDefaultAverageFrequency(filterIndex);
        }

        #endregion

        #region 再生速度関連

        // 再生速度関連の非公開変数
        private PlaybackSpeedSetter playbackSpeedSetter;
        private float playbackSpeed = 1.0f;

        /// <summary>
        /// 再生速度
        /// </summary>
        public float PlaybackSpeed
        {
            set
            {
                if (this.playbackSpeedSetter != null)
                {
                    this.playbackSpeedSetter.Speed = value;
                }

                this.playbackSpeed = value;
            }
            get
            {
                return this.playbackSpeed;
            }
        }

        /// <summary>
        /// 再生速度変更器を生成する。
        /// </summary>
        private void CreateSpeedSetter()
        {
            this.playbackSpeedSetter = new PlaybackSpeedSetter(this.audioProcessSampleProvider);
            this.playbackSpeedSetter.Speed = this.PlaybackSpeed;

            
            this.audioProcessSampleProvider = this.playbackSpeedSetter;
        }

        #endregion

        #region ピッチシフト(NAudio)

        // NAudioでのピッチシフト関連の非公開変数
        private PitchShifter pitchShifter;
        private int pitch = 0;

        /// <summary>
        /// ピッチ
        /// </summary>
        public int Pitch
        {
            set
            {
                if (this.pitchShifter != null)
                {
                    this.pitchShifter.Pitch = value;
                }

                this.pitch = value;
            }
            get
            {
                return this.pitch;
            }
        }

        /// <summary>
        /// ピッチシフト時のクリッピング（音割れ）防止を使用するかどうか<br/>
        /// ※このプロパティは再生中の変更に対応していません。
        /// </summary>
        public bool PitchShifterFixClip { set; get; } = true;

        /// <summary>
        /// ピッチシフターを生成する。
        /// </summary>
        private void CreatePitchShifter()
        {
            this.pitchShifter = new PitchShifter(this.audioProcessSampleProvider, this.PitchShifterFixClip);
            this.pitchShifter.Pitch = this.Pitch;

            this.audioProcessSampleProvider = this.pitchShifter;
        }

        #endregion

        #region ピッチシフト(SoundTouch)

        // SoundTouchでのピッチシフト関連の非公開変数
        private SoundTouchPitchShifter soundTouchPitchShifter;
        private float soundTouchPitchSemitones;

        /// <summary>
        /// SoundTouchでのピッチシフト時の音割れを防止するかどうか
        /// </summary>
        public bool SoundTouchPitchShifterFixClip { set; get; } = true;

        /// <summary>
        /// SoundTouchでのピッチシフト時のピッチ変化量（半音単位）
        /// </summary>
        public float SoundTouchPitchShifterPitchSemitones
        {
            set
            {
                if(this.soundTouchPitchShifter != null)
                {
                    this.soundTouchPitchShifter.Pitch = value;
                }

                // 後始末
                this.soundTouchPitchSemitones = value;
            }
            get
            {
                return this.soundTouchPitchSemitones;
            }
        }

        /// <summary>
        /// SoundTouchによるピッチシフターを生成する。
        /// </summary>
        private void CreateSoundTouchPitchShifter()
        {
            this.soundTouchPitchShifter = new SoundTouchPitchShifter(this.audioProcessSampleProvider, this.SoundTouchPitchShifterFixClip);
            this.soundTouchPitchShifter.Pitch = this.soundTouchPitchSemitones;

            this.audioProcessSampleProvider = this.soundTouchPitchShifter;
        }

        #endregion

        #region 音量調節関連

        // 音量調節に関連する非公開変数
        private VolumeChanger volumeChanger;

        /// <summary>
        /// 音量
        /// </summary>
        public int Volume
        {
            set
            {
                // NAudioが受け付ける音量の値は0から1の浮動小数点数なので、
                // 0から100の整数を浮動小数点数に変換する。
                float volume = value / 100.0f;

                if (this.volumeChanger != null)
                {
                    this.volumeChanger.Volume = volume;
                }

                // 後始末
                this.volume = value;
            }
            get
            {
                return this.volume;
            }
        }

        /// <summary>
        /// 音量調節エフェクタを生成する。
        /// </summary>
        private void CreateVolumeChanger()
        {
            this.volumeChanger = new VolumeChanger(this.audioProcessSampleProvider);
            this.audioProcessSampleProvider = this.volumeChanger;
        }

        #endregion

        #region 定位（パン）

        // 定位設定に関連する非公開変数
        private PanSetter panSetter;
        private int _pan;
        private float _pan_f;

        /// <summary>
        /// 定位<br/>
        /// -100から100の範囲内の整数で指定。-100に近いほど左、100に近いほど右から音が聞こえる。<br/>
        /// 0を指定することで、左右均等（デフォルト）になる。
        /// </summary>
        public int Pan
        {
            set
            {
                float pan = value / 100.0f;
                
                if(this.panSetter != null)
                {
                    this.panSetter.Pan = pan;
                }

                this._pan = value;
                this._pan_f = pan;
            }
            get
            {
                return this._pan;
            }
        }

        /// <summary>
        /// 定位設定エフェクタを生成する。
        /// </summary>
        private void CreatePanSetter()
        {
            this.panSetter = new PanSetter(this.audioProcessSampleProvider);
            this.panSetter.Pan = this._pan_f;
            this.audioProcessSampleProvider = this.panSetter;
        }

        #endregion

        #region オーディオソースの読み込みなど、オーディオソース関連

        /// <summary>
        /// 出力デバイスに渡すためのWaveProviderを生成する。
        /// </summary>
        private void CreateOutputWaveProvider()
        {
            // 出力フォーマットの変換が有効か？
            if (this.useDeviceOutputWaveFormatConversion)
            {
                // NOCONVを変換
                // ※SetOutputWaveFormatメソッドが呼び出される時点では、AudioSourceやOutputAudioSourceが確定していない為、ここで処理を行う。
                GetInputAudioSourceWaveFormat(out int isr, out int isb, out int isc);
                this.deviceOutputSampleRate = this.deviceOutputSampleRate == WAVEFORMAT_NOCONV ? isr : this.deviceOutputSampleRate;
                this.deviceOutputBitsPerSample = this.deviceOutputBitsPerSample == WAVEFORMAT_NOCONV ? isb : this.deviceOutputBitsPerSample;
                this.deviceOutputChannels = this.deviceOutputChannels == WAVEFORMAT_NOCONV ? isc : this.deviceOutputChannels;

                // 出力デバイスに渡すデータのフォーマット変換の為のリサンプラーを生成
                this.deviceOutputFormatConversion = new WaveFormatConversion(
                    this.audioProcessSampleProvider,
                    true,
                    1,
                    this.deviceOutputSampleRate,
                    this.deviceOutputBitsPerSample,
                    this.deviceOutputChannels);
                this.audioProcessSampleProvider = this.deviceOutputFormatConversion;

                // 出力デバイスに渡すデータはIWaveProvider形式である必要がある為、
                // IWaveProvider形式に変換する。量子化ビット数は、SetOutputWaveFormatメソッドで
                // 設定された値を使用する。
                this.outputAudioSource = new SampleToPcm(this.audioProcessSampleProvider, this.deviceOutputBitsPerSample);
            }
            else
            {
                // 出力デバイスに渡すデータはIWaveProvider形式である必要がある為、
                // IWaveProvider形式に変換する。量子化ビット数は、AudioSourceプロパティに
                // 設定されたオーディオソースの量子化ビット数をそのまま使用する。
                GetInputAudioSourceWaveFormat(out _, out int isb, out int _);
                this.outputAudioSource = new SampleToPcm(this.audioProcessSampleProvider, isb);
            }
        }

        /// <summary>
        /// オーディオソースを読み込む。
        /// </summary>
        private void LoadAudioSource(
            bool useReSampler = false,
            int reSamplerSampleRate = WAVEFORMAT_NOCONV,
            int reSamplerBitsPerSample = WAVEFORMAT_NOCONV,
            int reSamplerChannels = WAVEFORMAT_NOCONV)
        {
            if (this.AudioSource != null)
            {
                this.audioProcessSampleProvider = new AudioReaderToWaveStream(this.AudioSource).ToSampleProvider();

                // イコライザの作成
                CreateEqualizer();

                // ピッチシフタの生成
                CreatePitchShifter();

                // SoundTouchを使用するピッチシフタの生成
                CreateSoundTouchPitchShifter();

                // 再生速度設定器の生成
                CreateSpeedSetter();

                // リサンプラーの生成
                CreateReSampler(useReSampler, reSamplerSampleRate, reSamplerBitsPerSample, reSamplerChannels);          // 一般設定用

                // 音量調節エフェクタの生成
                CreateVolumeChanger();

                // 定位調節エフェクタの生成
                CreatePanSetter();

                // 出力用WaveProviderを設定
                CreateOutputWaveProvider();

                // イベントの実行
                this.OutputFormatChanged?.Invoke(null, null);
            }
        }

        #endregion

        #region 一般メソッド(Play,Stop,Pause等)

        /// <summary>
        /// AudioSourceプロパティに設定されたオーディオソースのフォーマットを取得する。<br/>
        /// このメソッドで取得できる値は、各種音響処理やデバイス出力に合わせて変換されたフォーマットではなく、<br/>
        /// AudioSourceプロパティに設定されたオーディオソースの本来のフォーマットです。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public void GetInputAudioSourceWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if (this.AudioSource != null)
            {
                sampleRate = this.AudioSource.WaveFormat.SampleRate;
                bitsPerSample = this.AudioSource.WaveFormat.BitsPerSample;
                channels = this.AudioSource.WaveFormat.Channels;
            }
            else
            {
                throw new Exception("このメソッドを呼び出す前に、AudioSourceプロパティに任意のオーディオソースを設定してください。");
            }
        }

        /// <summary>
        /// 各種音響処理後のオーディオソースのフォーマットを取得する。<br/>
        /// ※音響処理前のフォーマットの取得には、GetInputAudioSourceWaveFormatメソッドを使用してください。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        /// <exception cref="Exception"></exception>
        public void GetOutputAudioSourceWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if (this.OutputAudioSource != null)
            {
                sampleRate = this.OutputAudioSource.WaveFormat.SampleRate;
                bitsPerSample = this.OutputAudioSource.WaveFormat.BitsPerSample;
                channels = this.OutputAudioSource.WaveFormat.Channels;
            }
            else
            {
                throw new Exception("このメソッドを呼び出す前に、AudioSourceプロパティに任意のオーディオソースを設定してください。");
            }
        }

        /// <summary>
        /// 現在のオーディオ出力デバイスの出力フォーマットを取得する。
        /// </summary>
        /// <param name="sampleRate"></param>
        /// <param name="bitsPerSample"></param>
        /// <param name="channels"></param>
        public void GetDeviceOutputWaveFormat(out int sampleRate, out int bitsPerSample, out int channels)
        {
            if (this.AudioOutputDevice != null)
            {
                sampleRate = this.AudioOutputDevice.OutputWaveFormat.SampleRate;
                bitsPerSample = this.AudioOutputDevice.OutputWaveFormat.BitsPerSample;
                channels = this.AudioOutputDevice.OutputWaveFormat.Channels;
            }
            else
            {
                throw new Exception("このメソッドを呼び出す前に、AudioSourceプロパティに任意のオーディオソースを設定してください。");
            }
        }

        /// <summary>
        /// 現在の再生位置をTimeSpanとして取得する。
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetPosition()
        {
            return TimeSpan.FromSeconds(this.Position / (double)this.AudioSource.WaveFormat.AverageBytesPerSecond);
        }

        /// <summary>
        /// 開かれているオーディオソースの長さをTimeSpanとして取得する。
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetLength()
        {
            return TimeSpan.FromSeconds(this.Length / (double)this.AudioSource.WaveFormat.AverageBytesPerSecond);
        }

        /// <summary>
        /// プレイヤーを破棄する。
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (this.AudioOutputDevice.PlaybackState != PlaybackState.Stopped)
            {
                this.PlaybackTimer.Stop();
                this.AudioOutputDevice.Stop();
            }

            // 破棄
            this.inputAudioSource.Dispose();
            this.AudioOutputDevice.Dispose();
            this.PlaybackTimer.Dispose();

            // 後始末
            this.IsDisposed = true;
            this.IsDeviceInitialized = false;
        }

        /// <summary>
        /// 再生
        /// </summary>
        public void Play()
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (this.IsDeviceInitialized == false)
            {
                // デバイスを初期化
                this.AudioOutputDevice.Init(this.OutputAudioSource);
                this.IsDeviceInitialized = true;
            }
            else
            {
                Stop();
            }

            // 再生
            this.AudioOutputDevice.Play();

            // 後始末
            this.isStopped = false;
            this.PlaybackTimer.Start();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 状態を設定
            this.isStopped = true;

            // 後始末
            this.AudioOutputDevice.Stop();
            this.PlaybackTimer.Stop();
            this.StoppedByUser?.Invoke(null, null);
        }

        /// <summary>
        /// 一時停止
        /// </summary>
        public void Pause()
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 状態を設定
            this.isStopped = false;

            // 一時停止
            this.AudioOutputDevice.Stop();

            // 後始末
            this.PlaybackTimer.Stop();
        }

        /// <summary>
        /// 一時停止解除(再開)
        /// </summary>
        public void Resume()
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 状態を設定
            this.isStopped = false;

            // 一時停止解除
            this.AudioOutputDevice.Play();

            // 後始末
            this.PlaybackTimer.Start();
        }

        #endregion
    }
}