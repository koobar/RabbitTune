using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class PanSetter : ISampleProvider
    {
        // 非公開変数
        private readonly ISampleProvider src;
        private readonly PanningSampleProvider panningProvider;
        private readonly ISampleProvider dest;

        // コンストラクタ
        public PanSetter(ISampleProvider src)
        {
            this.src = src;

            if(this.src.WaveFormat.Channels > 2)
            {
                this.panningProvider = new PanningSampleProvider(this.src.ToMono());
                this.dest = this.panningProvider.ToStereo();
                this.WaveFormat = new WaveFormat(this.src.WaveFormat.SampleRate, this.src.WaveFormat.BitsPerSample, 2);
            }
            else if (this.src.WaveFormat.Channels == 2)
            {
                this.panningProvider = new PanningSampleProvider(this.src.ToMono());
                this.dest = this.panningProvider.ToStereo();
                this.WaveFormat = this.src.WaveFormat;
            }
            else
            {
                this.panningProvider = new PanningSampleProvider(this.src);
                this.dest = this.panningProvider;
                this.WaveFormat = this.src.WaveFormat;
            }
        }

        /// <summary>
        /// このオーディオプロセスを使用するかどうか
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (int)(this.Pan * 100) != 0;
            }
        }

        /// <summary>
        /// 定位
        /// </summary>
        public float Pan { set => this.panningProvider.Pan = value; get => this.panningProvider.Pan; }

        /// <summary>
        /// オーディオフォーマット
        /// </summary>
        public WaveFormat WaveFormat { private set; get; }

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
                return this.dest.Read(buffer, offset, count);
            }

            return this.src.Read(buffer, offset, count);
        }
    }
}
