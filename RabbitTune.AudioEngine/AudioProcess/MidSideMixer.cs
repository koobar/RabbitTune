using NAudio.Wave;
using System;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class MidSideMixer : ISampleProvider
    {
        // 非公開フィールド
        private readonly ISampleProvider source;
        private float midBoostLevel = 1.0f;
        private float sideBoostLevel = 1.0f;

        // コンストラクタ
        public MidSideMixer(ISampleProvider src)
        {
            this.source = src;
        }

        /// <summary>
        /// このオーディオプロセスを使用するかどうか
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// Mid信号のブーストレベル
        /// </summary>
        public float MidLevel
        {
            set
            {
                if (value >= 0 && value <= 2.0f)
                {
                    this.midBoostLevel = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return this.midBoostLevel;
            }
        }

        /// <summary>
        /// Side信号のブーストレベル
        /// </summary>
        public float SideLevel
        {
            set
            {
                if (value >= 0 && value <= 2.0f)
                {
                    this.sideBoostLevel = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return this.sideBoostLevel;
            }
        }

        /// <summary>
        /// オーディオフォーマット
        /// </summary>
        public WaveFormat WaveFormat => this.source.WaveFormat;

        /// <summary>
        /// 第1引数に指定された浮動小数点数を、第2引数に指定された値以上から、第3引数に指定された値以下となるように丸め込む。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }

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
                float mid = (left + right) * 0.5f;
                float side = (left - right) * 0.5f;

                // ブーストレベルを反映
                mid *= this.midBoostLevel;
                side *= this.sideBoostLevel;

                // クリッピング防止
                mid = Clamp(mid, -1.0f, 1.0f);
                side = Clamp(side, -1.0f, 1.0f);

                // 再度LR信号に変換
                left = mid + side;
                right = mid - side;

                // クリッピング防止
                left = Clamp(left, -1.0f, 1.0f);
                right = Clamp(right, -1.0f, 1.0f);

                // 反映
                buffer[offset + n] = left;
                buffer[offset + n + 1] = right;
            }

            return samplesRead;
        }
    }
}
