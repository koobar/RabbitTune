using System.Collections.Generic;
using System.Text;

namespace RabbitTune
{
    internal static class FileDialogUtils
    {
        /// <summary>
        /// 指定されたフォーマットリストのファイル全てを表示するフィルタを生成する。
        /// </summary>
        /// <param name="formatNameExtensionPairs">フォーマットリスト</param>
        /// <param name="allFilterDescription">フィルタの説明</param>
        /// <returns></returns>
        public static string GetAllFilterString(IList<KeyValuePair<string, string[]>> formatNameExtensionPairs, string allFilterDescription)
        {
            var result = new StringBuilder();
            string extensions_all = null;

            foreach (var pair in formatNameExtensionPairs)
            {
                foreach (var extension in pair.Value)
                {
                    if (extensions_all != null && extensions_all.Length > 0)
                    {
                        extensions_all += ";";
                    }

                    extensions_all += $"*{extension}";
                }
            }

            result.Append($"{allFilterDescription}|{extensions_all}");
            return result.ToString();
        }

        /// <summary>
        /// 指定されたフォーマットリストから、ファイルダイアログで使用されるフィルタの文字列を生成する。
        /// </summary>
        /// <param name="formatNameExtensionPairs">フォーマットリスト</param>
        /// <param name="createAllFilter">指定されたフォーマットリストの全てのファイルを表示するフィルタを生成するかどうか</param>
        /// <param name="allFilterDescription">指定されたフォーマットリストの全てのファイルを表示するフィルタの説明</param>
        /// <param name="createAnyFileFilter">フォーマットリストに与えられていないファイルを含むすべてのファイルを表示するフィルタを生成するかどうか</param>
        /// <returns></returns>
        public static string CreateFilterString(
            IList<KeyValuePair<string, string[]>> formatNameExtensionPairs,
            bool createAllFilter,
            string allFilterDescription,
            bool createAnyFileFilter)
        {
            var result = new StringBuilder();

            if (createAllFilter)
            {
                result.Append(GetAllFilterString(formatNameExtensionPairs, allFilterDescription));
            }

            // 各フォーマットのフィルタを作成
            foreach(var pair in formatNameExtensionPairs)
            {
                string extensions_regex = null;

                foreach(var extension in pair.Value)
                {
                    if(extensions_regex != null && extensions_regex.Length > 0)
                    {
                        extensions_regex += ";";
                    }

                    extensions_regex += $"*{extension}";
                }

                if(result.Length > 0)
                {
                    result.Append("|");
                }

                // フィルタの文字列を連結
                result.Append($"{pair.Key}({extensions_regex})|{extensions_regex}");
            }

            if (createAnyFileFilter)
            {
                if (result.Length > 0)
                {
                    result.Append("|");
                }

                result.Append("全てのファイル|**");
            }

            return result.ToString();
        }
    }
}
