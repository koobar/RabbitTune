using System;
using System.Collections.Generic;

namespace RabbitTune.MediaLibrary.PlaylistFormats
{
    internal class FolderProvider : IPlaylistFormatProvider
    {
        // 非公開変数
        private readonly IList<string> ImportFileExtensions;

        // コンストラクタ
        public FolderProvider() { }
        public FolderProvider(IList<string> importFileExtensions)
        {
            this.ImportFileExtensions = importFileExtensions;
        }

        /// <summary>
        /// 読み込み可能かどうか
        /// </summary>
        public bool CanRead { set; get; } = true;

        /// <summary>
        /// 書き込み可能かどうか
        /// </summary>
        public bool CanWrite { set; get; } = false;

        /// <summary>
        /// フォルダをプレイリストとして読み込む。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Playlist ReadPlaylist(string path)
        {
            var result = new Playlist();
            result.Location = path;
            result.Tracks = AudioTrackReader.ReadFolder(path, this.ImportFileExtensions);
            result.NotFoundFiles = new List<string>();

            return result;
        }

        public void SavePlaylist(string path, Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
