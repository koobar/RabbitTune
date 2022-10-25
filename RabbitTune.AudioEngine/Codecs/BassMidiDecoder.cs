using NAudio.Wave;
using RabbitTune.AudioEngine.BassWrapper;
using RabbitTune.AudioEngine.BassWrapper.Midi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabbitTune.AudioEngine.Codecs
{
    public class BassMidiDecoder : WaveStream, IWaveProvider
    {
        // 非公開定数
        private const int BASS_ERR_HANDLE = 0;

        // 非公開変数
        private readonly List<int> soundFontHandles;
        private int BassHandle;
        
        // コンストラクタ
        public BassMidiDecoder(string path)
        {
            this.soundFontHandles = new List<int>();

            // ファイルを読み込む。
            ReadAudioFile(path);
        }

        /// <summary>
        /// MIDIファイルの再生に使用するサウンドフォント一覧
        /// </summary>
        public static SoundFont[] SoundFonts { set; get; }

        /// <summary>
        /// 波形のミックスに線形補完の代わりにSinc補完を使用するかどうか<br/>
        /// Sinc補完は、線形補完よりも音質が向上する一方で、CPUに負荷がかかる。
        /// </summary>
        public static bool UseSincInterpolation { set; get; } = true;

        /// <summary>
        /// ハードウェアミキシングを優先的に使用するかどうか<br/>
        /// ハードウェアミキシングが無効な場合、ソフトウェアミキシングの使用を強制する。<br/>
        /// ※逆に、ハードウェアミキシングが有効に設定されていて、かつハードウェアミキシングに対応している<br/>
        /// 環境であれば、ハードウェアミキシングを優先的に使用する。
        /// </summary>
        public static bool UseHWMixing { set; get; } = true;

        /// <summary>
        /// BASSライブラリのフラグを取得する。
        /// </summary>
        /// <returns></returns>
        private static BassFlags GetBassFlags()
        {
            BassFlags flags = BassFlags.Decode | BassFlags.AsyncFile;

            if (UseSincInterpolation)
            {
                flags |= BassFlags.MidiSincInterpolation;
            }

            if (!UseHWMixing)
            {
                // ハードウェアミキシングが無効な場合、ソフトウェアミキシングの使用を強制する。
                // ※逆に、ハードウェアミキシングが有効に設定されていて、かつハードウェアミキシングに対応している
                // 　環境であれば、ハードウェアミキシングを優先的に使用する。
                flags |= BassFlags.SoftwareMixing;
            }

            return flags;
        }

        /// <summary>
        /// 指定されたファイルをBASS Audio Libraryで読み込み、チャンネルのハンドルを生成する。
        /// </summary>
        /// <param name="path"></param>
        private void ReadAudioFile(string path)
        {
            if (SoundFonts != null && SoundFonts.Length > 0)
            {
                BassMidi.SetAutoFont(2);
                int handle = BassMidi.CreateStreamFromFile(path, 0, 0, GetBassFlags());
                BassMidiNative.BASS_MIDI_StreamLoadSamples(handle);

                if (handle != 0)
                {
                    var fonts = new List<BassMidiSoundFont>();

                    // BASSライブラリのラッパーで使用する形式のサウンドフォント型に変換
                    // この際、音量設定などが自動的に行われる。
                    foreach (var font in SoundFonts)
                    {
                        if (font.Enabled)
                        {
                            var bassFont = font.ToBassSoundFont();

                            // サウンドフォントを読み込んで追加
                            LoadSoundFont(bassFont.Handle);
                            fonts.Add(bassFont);
                        }
                    }
                    
                    // サウンドフォントを設定
                    BassMidi.SetStreamSoundFont(handle, fonts);

                    // 後始末
                    this.BassHandle = handle;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Bass.LastError.ToString());
                }
            }
            else
            {
                throw new Exception("No Soundfonts.");
            }
        }

        /// <summary>
        /// サウンドフォントを読み込む。
        /// </summary>
        /// <param name="handle"></param>
        private void LoadSoundFont(int handle)
        {
            Task.Factory.StartNew(() => fontLoad());

            // 後始末
            this.soundFontHandles.Add(handle);

            // 非同期的にサウンドフォントを読み込む。
            void fontLoad()
            {
                BassMidiNative.BASS_MIDI_FontLoad(handle, -1, -1);
            }
        }

        /// <summary>
        /// このオーディオソースがシーク操作に対応しているかどうか
        /// </summary>
        public override bool CanSeek => true;

        /// <summary>
        /// このオーディオソースの波形フォーマット
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get
            {
                if (this.BassHandle != BASS_ERR_HANDLE)
                {
                    var fmt = Bass.GetChannelInfo(this.BassHandle);

                    return new WaveFormat(fmt.SampleRate, fmt.BitsPerSample, fmt.Channels);
                }

                return new WaveFormat(44100, 16, 2);
            }
        }

        /// <summary>
        /// 位置
        /// </summary>
        public override long Position
        {
            get
            {
                if (Bass.HandleCount == 0)
                {
                    return 0;
                }

                return Bass.GetChannelPosition(this.BassHandle);
            }
            set
            {
                Bass.SetChannelPosition(this.BassHandle, value);
            }
        }

        /// <summary>
        /// 長さ
        /// </summary>
        public override long Length => Bass.GetChannelLength(this.BassHandle);

        /// <summary>
        /// このオーディオソースを破棄する。
        /// </summary>
        public new void Dispose()
        {
            Bass.StreamFree(this.BassHandle);

            foreach (int handle in this.soundFontHandles)
            {
                BassMidiNative.BASS_MIDI_FontUnload(handle, -1, -1);
                BassMidi.Free(handle);
            }

            base.Dispose();
        }

        /// <summary>
        /// このオーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return Bass.ReadChannel(this.BassHandle, buffer, count);
        }
    }
}
