using System.Collections.Generic;
using System.IO;

namespace RabbitTune.ConfigFile
{
    public class EqualizerConfigFileReader
    {
        // 非公開変数
        private StreamReader reader;

        // コンストラクタ
        public EqualizerConfigFileReader(string path)
        {
            this.reader = new StreamReader(path);
        }

        /// <summary>
        /// イコライザの各フィルタのレベル
        /// </summary>
        public double[] EqualizerGainDBs { set; get; }

        /// <summary>
        /// 設定を読み込む。
        /// </summary>
        public void Read()
        {
            if (this.reader != null)
            {
                var result = new List<double>();

                while (this.reader.Peek() > -1)
                {
                    string line = this.reader.ReadLine();
                    double value = double.Parse(line);

                    result.Add(value);
                }

                // 後始末
                this.EqualizerGainDBs = result.ToArray();
                this.reader.Dispose();
            }
        }
    }
}
