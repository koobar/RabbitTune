using NAudio.Wave;
using RabbitTune.AudioEngine.Codecs.BassCompat;

namespace RabbitTune.AudioEngine.Codecs
{
    internal class WavDecoder : WaveStream
    {
        // 非公開変数
        private WaveStream source;

        // コンストラクタ
        public WavDecoder(string path)
        {
            this.source = CreateStream(path);
        }

        /// <summary>
        /// WAVEファイルをデコードするストリームを生成する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private WaveStream CreateStream(string path)
        {
            var naudioDec = new WaveFileReader(path);

            // PCMでもIeeeFloatでもないか？
            if (naudioDec.WaveFormat.Encoding != WaveFormatEncoding.Pcm && 
                naudioDec.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
            {
                naudioDec.Close();
                naudioDec.Dispose();

                // NAudioのデコーダではPCMとIeeeFloat以外は読み込めないので、BASS Audio Libraryで再読み込み。
                // なお、MediaFoundationReaderではIMA ADPCMやμ-lawをデコードできない。
                return new BassDecoder(path);
            }
            else
            {
                return naudioDec;
            }
        }

        /// <summary>
        /// 波形フォーマット
        /// </summary>
        public override WaveFormat WaveFormat => this.source.WaveFormat;

        /// <summary>
        /// 長さ
        /// </summary>
        public override long Length => this.source.Length;

        /// <summary>
        /// 位置
        /// </summary>
        public override long Position { get => this.source.Position; set => this.source.Position = value; }

        /// <summary>
        /// 破棄
        /// </summary>
        public new void Dispose() => this.source.Dispose();

        /// <summary>
        /// ストリームから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.source.Read(buffer, offset, count);
        }
    }
}
