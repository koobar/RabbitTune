using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RabbitTune.ConfigFile
{
    public class PropertyFileReader
    {
        // 非公開変数
        private readonly StreamReader reader;
        private readonly Dictionary<string, string> loadedProperties;
        private readonly string content;

        // コンストラクタ
        public PropertyFileReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                this.reader = new StreamReader(fileName, Encoding.UTF8);
                this.loadedProperties = ReadProperty(out this.content);

                this.reader.Dispose();
            }
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        public void Close() => this.reader.Close();

        /// <summary>
        /// 破棄する。
        /// </summary>
        public void Dispose() => this.reader.Dispose();

        /// <summary>
        /// 読み込んだすべてのプロパティ名を取得する。
        /// </summary>
        /// <returns></returns>
        public string[] GetAllPropertyKeys()
        {
            return this.loadedProperties.Keys.ToArray();
        }

        /// <summary>
        /// コンフィグファイルの内容を生文字列(Plain Text)で取得する。
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return this.content;
        }

        /// <summary>
        /// 文字列を真偽値に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ToBoolean(string value)
        {
            switch (value.ToLower())
            {
                case "true":
                case "1":
                    return true;
                case "false":
                case "0":
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 指定されたキーのプロパティ値を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key, string defaultValue)
        {
            string result = null;

            if (this.loadedProperties != null)
            {
                if (this.loadedProperties.ContainsKey(key))
                {
                    result = this.loadedProperties[key];
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                result = defaultValue;
            }

            return result;
        }

        /// <summary>
        /// 指定されたキーのプロパティ値を真偽値として読み込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetValueAsBoolean(string key, bool defaultValue = false)
        {
            var value = GetValue(key, defaultValue.ToString());

            if (string.IsNullOrEmpty(key) == false)
            {
                return ToBoolean(value);
            }

            return defaultValue;
        }

        /// <summary>
        /// 指定されたキーのプロパティ値を整数として読み込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int GetValueAsInt(string key, int defaultValue = -1)
        {
            var value = GetValue(key, defaultValue.ToString());

            if(string.IsNullOrEmpty(key) == false)
            {
                if(int.TryParse(value, out int i))
                {
                    return i;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// 指定されたキーのプロパティ値を浮動小数点数として読み込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public float GetValueAsFloat(string key, float defaultValue = 1.0f)
        {
            if (string.IsNullOrEmpty(key) == false)
            {
                var value = GetValue(key, (defaultValue * ushort.MaxValue).ToString());
                long q = long.Parse(value);
                double d = q / (double)ushort.MaxValue;         // 逆量子化

                return (float)d;
            }

            return defaultValue;
        }

        /// <summary>
        /// 指定されたキーのプロパティ値を倍精度浮動小数点数として読み込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public double GetValueAsDouble(string key, double defaultValue = 1.0f)
        {
            if (string.IsNullOrEmpty(key) == false)
            {
                var value = GetValue(key, (defaultValue * ushort.MaxValue) .ToString());
                long q = long.Parse(value);
                double d = q / (double)ushort.MaxValue;         // 逆量子化

                return d;
            }

            return defaultValue;
        }

        /// <summary>
        /// 指定されたキーのプロパティ値をEnumとして読み込む。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public Enum GetValueAsEnum(string key, Enum defaultValue, Type enumType)
        {
            string value = GetValue(key, defaultValue.ToString());

            return (Enum)Enum.Parse(enumType, value);
        }

        /// <summary>
        /// 指定されたキーの配列型のプロパティ値を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] GetStringArrayValue(string key, params string[] defaultValues)
        {
            List<string> values = new List<string>();

            if (this.loadedProperties != null)
            {
                int cnt = 0;
                bool found_anyItems = false;

                while (true)
                {
                    string akey = $"{key}[{cnt}]";

                    if (this.loadedProperties.ContainsKey(akey))
                    {
                        found_anyItems = true;
                        values.Add(this.loadedProperties[akey]);
                    }
                    else
                    {
                        break;
                    }

                    cnt++;
                }

                if (!found_anyItems)
                {
                    return defaultValues;
                }
            }

            return values.ToArray();
        }

        /// <summary>
        /// 指定されたキーの配列型のプロパティ値を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<int> GetIntArrayValue(string key, int defaultValue = 0, int defaultLength = 0, bool useDefaultIfLengthIsZero = true)
        {
            List<int> values = new List<int>();

            if (this.loadedProperties != null)
            {
                int cnt = 0;

                while (true)
                {
                    string akey = $"{key}[{cnt}](d)";

                    if (this.loadedProperties.ContainsKey(akey))
                    {
                        values.Add(GetValueAsInt(akey, 0));
                    }
                    else
                    {
                        break;
                    }

                    cnt++;
                }
            }

            if ((useDefaultIfLengthIsZero && values.Count == 0) || (this.loadedProperties == null))
            {
                for (int i = 0; i < defaultLength; i++)
                {
                    values.Add(defaultValue);
                }
            }

            return values;
        }

        /// <summary>
        /// 指定されたキーの配列型のプロパティ値を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<double> GetDoubleArrayValue(string key, double defaultValue = 0, int defaultLength = 0, bool useDefaultIfLengthIsZero = true)
        {
            List<double> values = new List<double>();

            if (this.loadedProperties != null)
            {
                int cnt = 0;

                while (true)
                {
                    string akey = $"{key}[{cnt}](d)";

                    if (this.loadedProperties.ContainsKey(akey))
                    {
                        values.Add(GetValueAsDouble(akey, 0.0));
                    }
                    else
                    {
                        break;
                    }

                    cnt++;
                }
            }

            if((useDefaultIfLengthIsZero && values.Count == 0) || (this.loadedProperties == null))
            {
                for (int i = 0; i < defaultLength; i++)
                {
                    values.Add(defaultValue);
                }
            }

            return values;
        }

        /// <summary>
        /// プロパティファイルを読み込む。
        /// </summary>
        /// <param name="fileName"></param>
        public Dictionary<string, string> ReadProperty(out string content)
        {
            if (this.reader != null)
            {
                var result = new Dictionary<string, string>();
                string tmp = null;

                // 読み込み開始
                while (this.reader.Peek() > -1)
                {
                    string source = this.reader.ReadLine();
                    tmp += source + "\n";

                    // コメント行ではないか？
                    if (source.StartsWith("//") == false)
                    {
                        bool iskey = true;
                        string key_name = "";

                        // 『名前=設定値』の書式のプロパティを解釈する。
                        foreach (string value in source.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (iskey)
                            {
                                key_name = value;
                                iskey = false;
                            }
                            else
                            {
                                iskey = true;
                                if (result.ContainsKey(key_name))
                                {
                                    result[key_name] = value;
                                }
                                else
                                {
                                    result.Add(key_name, value);
                                }
                            }
                        }
                    }
                }

                content = tmp;
                return result;
            }

            content = null;
            return null;
        }
    }
}
