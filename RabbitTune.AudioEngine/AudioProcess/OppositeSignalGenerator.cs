using NAudio.Wave;

namespace RabbitTune.AudioEngine.AudioProcess
{
    namespace RabbitTune.AudioEngine.AudioProcess
    {
        internal class OppositeSignalGenerator : ISampleProvider
        {
            // 非公開フィールド
            private readonly ISampleProvider source;

            // コンストラクタ
            public OppositeSignalGenerator(ISampleProvider src)
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
                if (!this.Enabled)
                {
                    return this.source.Read(buffer, offset, count);
                }

                int samplesRead = source.Read(buffer, offset, count);

                for (int n = 0; n < count; ++n)
                {
                    buffer[offset + n] *= -1;
                }

                return samplesRead;
            }
        }
    }
}
