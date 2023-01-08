using NAudio.Wave;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class WaveFormatConversion : ISampleProvider
    {
        // 非公開変数
        private ISampleProvider source;
        private ISampleProvider converted;

        // コンストラクタ
        public WaveFormatConversion(ISampleProvider source, bool enabled, int quality, int sampleRate, int bitsPerSample, int channels)
        {
            this.source = source;
            this.Enabled = enabled;

            // 波形フォーマットを設定
            SetWaveFormat(new WaveFormat(sampleRate, bitsPerSample, channels), quality);
        }

        /// <summary>
        /// このオーディオエフェクトプロセスを使用するかどうか
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// 波形フォーマットを設定する。
        /// </summary>
        public void SetWaveFormat(WaveFormat format, int quality)
        {
            if(format.BitsPerSample > 32)
            {
                format = new WaveFormat(format.SampleRate, 32, format.Channels);
            }

            this.converted = new MediaFoundationResampler(new SampleToPcm(this.source, 32), format) { ResamplerQuality = quality }.ToSampleProvider();
        }

        /// <summary>
        /// 波形フォーマット
        /// </summary>
        public WaveFormat WaveFormat
        {
            get
            {
                if (this.Enabled)
                {
                    return this.converted.WaveFormat;
                }

                return this.source.WaveFormat;
            }
        }

        /// <summary>
        /// オーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(float[] buffer, int offset, int count)
        {
            if (this.Enabled)
            {
                return this.converted.Read(buffer, offset, count);
            }
            else
            {
                return this.source.Read(buffer, offset, count);
            }
        }
    }
}
