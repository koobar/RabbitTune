using RabbitTune.MediaLibrary.PlaylistFormats;
using System.Collections.Generic;

namespace RabbitTune.MediaLibrary
{
    public class PlaylistReader
    {
        // コンストラクタ
        public PlaylistReader(string path, IList<string> importFileExtensions)
        {
            this.PlaylistProvider = PlaylistProviderFactory.CreateProvider(path, importFileExtensions);

            if (this.PlaylistProvider != null && this.PlaylistProvider.CanRead)
            {
                this.Playlist = this.PlaylistProvider.ReadPlaylist(path);
            }
        }

        /// <summary>
        /// フォーマットプロバイダ
        /// </summary>
        public IPlaylistFormatProvider PlaylistProvider { get; }

        /// <summary>
        /// 読み込まれたプレイリストのデータ
        /// </summary>
        public Playlist Playlist { private set; get; }
    }
}
