using System.Collections.Generic;

namespace RabbitTune.MediaLibrary.PlaylistFormats
{
    public interface IPlaylistFormatProvider
    {
        /// <summary>
        /// プレイリストに含まれているトラックの一覧
        /// </summary>
        List<AudioTrack> Tracks { set; get; }

        /// <summary>
        /// 指定されたプレイリストファイルを読み込む。
        /// </summary>
        /// <param name="path"></param>
        void ReadPlaylist(string path);

        /// <summary>
        /// 指定されたパスにプレイリストを保存する。
        /// </summary>
        /// <param name="path"></param>
        void SavePlaylist(string path);
    }
}
