using NAudio.Wave;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class VolumeBalanceSetter : ISampleProvider
    {
        // 非公開フィールド
        private readonly ISampleProvider source;

        // コンストラクタ
        public VolumeBalanceSetter(ISampleProvider source)
        {
            this.source = source;
        }

        /// <summary>
        /// 左の音量
        /// </summary>
        public float LeftVolume { set; get; } = 1;

        /// <summary>
        /// 右の音量
        /// </summary>
        public float RightVolume { set; get; } = 1;

        /// <summary>
        /// 音声フォーマット
        /// </summary>
        public WaveFormat WaveFormat => this.source.WaveFormat;

        /// <summary>
        /// サンプルを読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);

            // ステレオ音声か？
            if (this.WaveFormat.Channels == 2)
            {
                for (int n = 0; n < count; n += 2)
                {
                    buffer[offset + n] *= this.LeftVolume;
                    buffer[offset + n + 1] *= this.RightVolume;
                }
            }

            return samplesRead;
        }
    }
}
