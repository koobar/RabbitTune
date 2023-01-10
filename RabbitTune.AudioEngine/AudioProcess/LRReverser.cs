using NAudio.Wave;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class LRReverser : ISampleProvider
    {
        // 非公開フィールド
        private readonly ISampleProvider source;

        // コンストラクタ
        public LRReverser(ISampleProvider src)
        {
            this.source = src;
        }

        /// <summary>
        /// このオーディオプロセスを使用するかどうか
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// オーディオフォーマット
        /// </summary>
        public WaveFormat WaveFormat => this.source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            if (!this.Enabled || this.WaveFormat.Channels != 2)
            {
                return this.source.Read(buffer, offset, count);
            }

            int samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < count; n += 2)
            {
                float left = buffer[offset + n];
                float right = buffer[offset + n + 1];

                buffer[offset + n] = right;             // L = R
                buffer[offset + n + 1] = left;          // R = L
            }

            return samplesRead;
        }
    }
}
