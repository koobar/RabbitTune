using System.Collections.Generic;

namespace RabbitTune.MediaLibrary
{
    public class PlaylistReader : Playlist
    {
        // コンストラクタ
        public PlaylistReader(string path, IList<string> importFileExtensions) : base(path, importFileExtensions)
        {
            base.playlistProvider.ReadPlaylist(path);
        }
    }
}
