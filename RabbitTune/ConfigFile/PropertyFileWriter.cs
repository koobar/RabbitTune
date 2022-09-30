using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RabbitTune.ConfigFile
{
    public class PropertyFileWriter
    {
        // 非公開変数
        private StreamWriter writer;

        // 非公開定数
        private const int CONFIG_FORMAT_VER = 1;

        // コンストラクタ
        public PropertyFileWriter(string fileName)
        {
            string dir = Path.GetDirectoryName(fileName);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            this.writer = new StreamWriter(fileName, false, Encoding.UTF8);

            WriteComment($"RabbitTune config data file.");
            WriteComment($"Format version {CONFIG_FORMAT_VER}.");
            WriteComment($"This is the RabbitTune config file.");
            WriteComment($"If you change it carelessly, it may not work properly.");
        }

        /// <summary>
        /// 初期化する。
        /// </summary>
        public void Dispose()
        {
            this.writer.Flush();
            this.writer.Close();
            this.writer.Dispose();
        }

        /// <summary>
        /// プロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteProperty(string key, Enum value)
        {
            WriteProperty(key, value.ToString());
        }

        /// <summary>
        /// プロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteProperty(string key, short value)
        {
            WriteProperty(key, value.ToString());
        }

        /// <summary>
        /// プロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteProperty(string key, int value)
        {
            WriteProperty(key, value.ToString());
        }

        /// <summary>
        /// プロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void WriteProperty(string key, bool value)
        {
            WriteProperty(key, value.ToString());
        }

        /// <summary>
        /// プロパティを書き込む
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteProperty(string key, string value)
        {
            string content = key + "=" + value;
            this.writer.WriteLine(content);
        }

        /// <summary>
        /// プロパティを書き込む
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteProperty(string key, float value)
        {
            long q = (long)(value * ushort.MaxValue);     // 量子化

            WriteProperty(key, q.ToString());
        }

        /// <summary>
        /// プロパティを書き込む
        /// </summary>
        /// <param name="fileName"></param>
        public void WriteProperty(string key, double value)
        {
            long q = (long)(value * ushort.MaxValue);     // 量子化

            WriteProperty(key, q.ToString());
        }

        /// <summary>
        /// 配列型のプロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void WriteStringArrayProperty(string key, IList<string> values)
        {
            for (int i = 0; i < values.Count; ++i)
            {
                string akey = $"{key}[{i}]";
                WriteProperty(akey, values[i]);
            }
        }

        /// <summary>
        /// 配列型のプロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void WriteShortArrayProperty(string key, IList<short> values)
        {
            for (int i = 0; i < values.Count; ++i)
            {
                string akey = $"{key}[{i}](i16s)";

                WriteProperty(akey, values[i].ToString());
            }
        }

        /// <summary>
        /// 配列型のプロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void WriteIntArrayProperty(string key, IList<int> values)
        {
            for (int i = 0; i < values.Count; ++i)
            {
                string akey = $"{key}[{i}](i32s)";

                WriteProperty(akey, values[i].ToString());
            }
        }

        /// <summary>
        /// 配列型のプロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void WriteLongArrayProperty(string key, IList<long> values)
        {
            for (int i = 0; i < values.Count; ++i)
            {
                string akey = $"{key}[{i}](i64s)";

                WriteProperty(akey, values[i].ToString());
            }
        }

        /// <summary>
        /// 配列型のプロパティを書き込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void WriteDoubleArrayProperty(string key, IList<double> values)
        {
            for (int i = 0; i < values.Count; ++i)
            {
                WriteProperty($"{key}[{i}](d)", values[i]);

                // 普通にvalues[i]をToStringで文字列に変換して書き込むと、
                // 1.7976........E+??とかの、後からdouble.Parseメソッドで
                // double型に戻せない値を書き込み、後にそれを読み込むと
                // 例外が発生する。したがって、この方法の方が精度は高いのだが封印。
                //WriteProperty(akey, values[i].ToString());
            }
        }

        /// <summary>
        /// コメント文字列を書き込む。
        /// </summary>
        /// <param name="comment"></param>
        public void WriteComment(string comment)
        {
            if(comment.StartsWith("//") == false)
            {
                comment = $"//{comment}";
            }

            this.writer.WriteLine(comment);
        }

        /// <summary>
        /// 空行を書き込む。
        /// </summary>
        public void WriteEmptyLine()
        {
            this.writer.WriteLine();
        }
    }
}
