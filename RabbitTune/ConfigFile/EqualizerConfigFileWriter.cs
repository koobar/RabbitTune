using System.IO;

namespace RabbitTune.ConfigFile
{
    public class EqualizerConfigFileWriter
    {
        // 非公開変数
        private Stream OutputStream;

        // コンストラクタ
        public EqualizerConfigFileWriter(Stream outputStream)
        {
            this.OutputStream = outputStream;
        }

        // コンストラクタ
        public EqualizerConfigFileWriter(string path)
        {
            this.OutputStream = File.Create(path);
        }

        /// <summary>
        /// イコライザの各フィルタのレベル
        /// </summary>
        public double[] EqualizerGainDBs { set; get; }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            if(this.OutputStream != null)
            {
                var writer = new StreamWriter(this.OutputStream);

                foreach(var db in this.EqualizerGainDBs)
                {
                    writer.WriteLine(db.ToString());
                }

                // 後始末
                writer.Dispose();
            }
        }
    }
}
