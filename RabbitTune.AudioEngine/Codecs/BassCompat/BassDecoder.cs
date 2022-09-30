/* BASS Audio Libraryで読み込んだストリームのデータを
 * NAudioで扱うことのできる形式で渡すための橋渡し的なクラス*/
using NAudio.Wave;
using RabbitTune.AudioEngine.BassWrapper;
using System.Windows.Forms;

namespace RabbitTune.AudioEngine.Codecs.BassCompat
{
    internal class BassDecoder : WaveStream, IWaveProvider
    {
        // 非公開定数
        private const int BASS_ERR_HANDLE = 0;

        // 非公開変数
        private int BassHandle;

        // コンストラクタ
        public BassDecoder(string path)
        {
            // ファイルを読み込む。
            ReadAudioFile(path);
        }

        /// <summary>
        /// 指定されたファイルをBASS Audio Libraryで読み込み、チャンネルのハンドルを生成する。
        /// </summary>
        /// <param name="path"></param>
        private void ReadAudioFile(string path)
        {
            int handle = Bass.CreateStreamFromFile(path, 0, 0, BassFlags.Decode);

            if (handle != 0)
            {
                this.BassHandle = handle;
            }
            else
            {
                MessageBox.Show(Bass.LastError.ToString());
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
                if(Bass.HandleCount == 0)
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

        public long FilePosition
        {
            get
            {
                return Bass.StreamGetFilePosition(this.BassHandle);
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
            base.Dispose();
            Bass.StreamFree(this.BassHandle);
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
