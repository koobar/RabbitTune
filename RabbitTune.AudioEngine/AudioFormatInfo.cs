using System;
using System.IO;

namespace RabbitTune.AudioEngine
{
    public class AudioFormatInfo
    {
        // コンストラクタ
        public AudioFormatInfo(string description, Type decoderType, bool isAdditionalFormat, params string[] extensions)
        {
            this.Extensions = extensions;
            this.Description = description;
            this.DecoderType = decoderType;
            this.IsAdditionalFormat = isAdditionalFormat;
        }

        /// <summary>
        /// このフォーマットの拡張子の一覧
        /// </summary>
        public string[] Extensions { private set; get; }

        /// <summary>
        /// フォーマット名などのフォーマットの説明
        /// </summary>
        public string Description { private set; get; }

        /// <summary>
        /// デコーダーの型
        /// </summary>
        public Type DecoderType { private set; get; }

        /// <summary>
        /// DecoderTypeで指定されたデコーダでしかデコードできないフォーマットかどうか
        /// </summary>
        public bool IsAdditionalFormat { private set; get; } = false;

        /// <summary>
        /// 指定されたファイルがこのフォーマットであるか判定して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsThisFormat(string path)
        {
            string extension = Path.GetExtension(path).ToLower();

            return Array.IndexOf(this.Extensions, extension) != -1;
        }
    }
}
