using RabbitTune.MediaLibrary.PlaylistFormats;
using System.Collections.Generic;
using System.IO;

namespace RabbitTune.MediaLibrary
{
    public class Playlist
    {
        // 非公開変数
        protected readonly static Dictionary<string, string> SupportedPlaylistFormats = new Dictionary<string, string>()
        {
            { ".asx", "ASX形式" },
            { ".wax", "WAX形式" },
            { ".wvx", "WVX形式" },
            { ".b4s", "B4S形式" },
            { ".pls", "PLS形式" },
            { ".smil", "SMIL形式" },
            { ".sml", "SML形式" },
            { ".zpl", "ZPL形式" },
            { ".xspf", "XSPF形式" },
            { ".m3u", "M3U形式" },
            { ".m3u8", "M3U形式" },
            { ".wpl", "Windows Media Player プレイリスト" },
        };
        protected readonly IPlaylistFormatProvider playlistProvider;

        // コンストラクタ
        public Playlist(string path, IList<string> importFileExtensions)
        {
            this.playlistProvider = CreateProvider(path, importFileExtensions);
        }

        /// <summary>
        /// プレイリストに含まれるトラックの一覧
        /// </summary>
        public List<AudioTrack> Tracks { set => this.playlistProvider.Tracks = value; get => this.playlistProvider.Tracks; }

        /// <summary>
        /// 指定された場所のプレイリストファイルが読み込みに対応している形式であるか判定して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsSupportedPlaylistFormat(string path)
        {
            string extension = Path.GetExtension(path).ToLower();

            if (SupportedPlaylistFormats.ContainsKey(extension))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// サポートされるフォーマット名の一覧を返す。
        /// </summary>
        /// <returns></returns>
        public static string[] GetSupportedFormatNames()
        {
            var result = new List<string>();

            foreach (var key in SupportedPlaylistFormats.Keys)
            {
                string name = SupportedPlaylistFormats[key];

                if (result.Contains(name) == false)
                {
                    result.Add(name);
                }
            }

            result.Sort();
            return result.ToArray();
        }

        /// <summary>
        /// 指定されたフォーマット名の拡張子の一覧を返す。
        /// </summary>
        /// <param name="formatName"></param>
        /// <returns></returns>
        public static string[] GetFormatExtensions(string formatName)
        {
            var result = new List<string>();

            foreach (var key in SupportedPlaylistFormats.Keys)
            {
                if (SupportedPlaylistFormats[key] == formatName)
                {
                    result.Add(key);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 与えられたプレイリストファイルを読み込むためのフォーマットプロバイダのインスタンスを生成して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="importFileExtensions">インポートするオーディオファイルの拡張子一覧</param>
        /// <returns></returns>
        protected IPlaylistFormatProvider CreateProvider(string path, IList<string> importFileExtensions)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            string extension = Path.GetExtension(path).ToLower();
            IPlaylistFormatProvider provider;

            switch (extension)
            {
                case ".asx":
                case ".wax":
                case ".wvx":
                case ".b4s":
                case ".pls":
                case ".smil":
                case ".sml":
                case ".zpl":
                case ".m3u":
                case ".m3u8":
                case ".wpl":
                case ".xspf":
                    provider = new ATLPlaylistProvider(importFileExtensions);
                    break;
                default:
                    provider = null;
                    break;
            }

            return provider;
        }
    }
}
