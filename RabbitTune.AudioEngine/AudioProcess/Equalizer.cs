using NAudio.Extras;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace RabbitTune.AudioEngine.AudioProcess
{
    public class Equalizer : ISampleProvider
    {
        // 非公開変数
        private static readonly EqualizerBand[] EqualizerBands = new EqualizerBand[10]
        {
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 31 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 62 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 125 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 250 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 500 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 1000 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 2000 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 4000 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 8000 },
            new EqualizerBand() { Bandwidth = 0.8f, Frequency = 16000 },
        };
        private ISampleProvider source;
        private NAudio.Extras.Equalizer equalizer;
        private ISampleProvider dest;

        // コンストラクタ
        public Equalizer(ISampleProvider source)
        {
            this.source = source;

            CreateEqualizer();
        }

        /// <summary>
        /// イコライザを作成する。
        /// </summary>
        private void CreateEqualizer()
        {
            if(this.source != null)
            {
                // 32Khzにダウンサンプリングするオプションが有効、または処理対象のオーディオデータの
                // サンプリング周波数は32Khzに満たない場合は、処理前に32Khzにサンプリング周波数変換する。
                if (this.DownSampleTo32KBeforeProcess || this.source.WaveFormat.SampleRate < 32000)
                {
                    var tmp = new WdlResamplingSampleProvider(this.source, 32000);
                    this.equalizer = new NAudio.Extras.Equalizer(tmp, EqualizerBands);
                    this.dest = this.equalizer;
                }
                else
                {
                    this.equalizer = new NAudio.Extras.Equalizer(this.source, EqualizerBands);
                    this.dest = this.equalizer;
                }
            }
        }

        /// <summary>
        /// 指定されたイコライザのフィルタの平均GainDBを設定する。
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetAverageGainDB(int filterIndex, double value)
        {
            EqualizerBands[filterIndex].Gain = (float)value;

            CreateEqualizer();
        }

        /// <summary>
        /// 指定されたイコライザのフィルタの平均GainDBを取得する。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public double GetAverageGainDB(int filterIndex)
        {
            return EqualizerBands[filterIndex].Gain;
        }

        /// <summary>
        /// 指定されたイコライザのフィルタの平均周波数を取得する。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public double GetAverageFrequency(int filterIndex)
        {
            return EqualizerBands[filterIndex].Frequency;
        }

        /// <summary>
        /// 指定されたイコライザのデフォルトの平均周波数を取得する。
        /// </summary>
        /// <param name="filterIndex"></param>
        /// <returns></returns>
        public static double GetDefaultAverageFrequency(int filterIndex)
        {
            return EqualizerBands[filterIndex].Frequency;
        }

        /// <summary>
        /// イコライザの有効状態
        /// </summary>
        public bool Enabled { set; get; }

        /// <summary>
        /// イコライザ処理前に32khzにダウンサンプリングするかどうか
        /// </summary>
        public bool DownSampleTo32KBeforeProcess { set; get; }

        /// <summary>
        /// オーディオフォーマット
        /// </summary>
        public WaveFormat WaveFormat
        {
            get
            {
                if (this.Enabled)
                {
                    return this.dest.WaveFormat;
                }

                return this.source.WaveFormat;
            }
        }

        /// <summary>
        /// このオーディオソースから読み込む。
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

            return this.source.Read(buffer, offset, count);
        }
    }
}
