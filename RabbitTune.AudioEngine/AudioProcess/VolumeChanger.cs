using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace RabbitTune.AudioEngine.AudioProcess
{
    public class VolumeChanger : ISampleProvider
    {
        // 非公開変数
        private ISampleProvider src;
        private VolumeSampleProvider dest;
        private float volume = 1f;

        // コンストラクタ
        public VolumeChanger(ISampleProvider source)
        {
            this.src = source;
            this.dest = new VolumeSampleProvider(source);
        }

        /// <summary>
        /// このオーディオエフェクトプロセスを使用するかどうか
        /// </summary>
        public bool Enabled { set; get; } = true;

        /// <summary>
        /// 音量
        /// </summary>
        public float Volume
        {
            set
            {
                if(this.dest != null)
                {
                    this.dest.Volume = value;
                }

                this.volume = value;
            }
            get
            {
                return this.volume;
            }
        }

        /// <summary>
        /// 波形フォーマット
        /// </summary>
        public WaveFormat WaveFormat
        {
            get
            {
                return this.src.WaveFormat;
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
                return this.dest.Read(buffer, offset, count);
            }

            return this.src.Read(buffer, offset, count);
        }
    }
}
