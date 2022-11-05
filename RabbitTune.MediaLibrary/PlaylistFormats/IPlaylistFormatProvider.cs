namespace RabbitTune.MediaLibrary.PlaylistFormats
{
    public interface IPlaylistFormatProvider
    {
        /// <summary>
        /// 読み込み可能かどうか
        /// </summary>
        bool CanRead { set; get; }

        /// <summary>
        /// 書き込み可能かどうか
        /// </summary>
        bool CanWrite { set; get; }

        /// <summary>
        /// 指定されたプレイリストファイルを読み込む。
        /// </summary>
        /// <param name="path"></param>
        Playlist ReadPlaylist(string path);

        /// <summary>
        /// 指定されたパスにプレイリストを保存する。
        /// </summary>
        /// <param name="path"></param>
        void SavePlaylist(string path, Playlist playlist);
    }
}
