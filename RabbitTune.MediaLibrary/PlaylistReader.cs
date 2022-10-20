using System.Collections.Generic;

namespace RabbitTune.MediaLibrary
{
    public class PlaylistReader : Playlist
    {
        // コンストラクタ
        public PlaylistReader(string path, IList<string> importFileExtensions) : base(path, importFileExtensions)
        {
            base.playlistProvider.ReadPlaylist(path, out List<string> notFoundFiles);

            this.NotFoundFiles = notFoundFiles;
        }

        /// <summary>
        /// プレイリストに含まれているものの、存在しなかったファイルの一覧
        /// </summary>
        public IList<string> NotFoundFiles { private set; get; }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            base.playlistProvider.Dispose();
        }
    }
}
