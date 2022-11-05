using RabbitTune.MediaLibrary.PlaylistFormats;
using System.IO;

namespace RabbitTune.MediaLibrary
{
    public class PlaylistWriter
    {
        // 非公開フィールド
        private readonly string Location;

        // コンストラクタ
        public PlaylistWriter(string path)
        {
            this.Location = path;
            this.PlaylistProvider = PlaylistProviderFactory.CreateProvider(path, null);
        }

        /// <summary>
        /// フォーマットプロバイダ
        /// </summary>
        public IPlaylistFormatProvider PlaylistProvider { get; }

        /// <summary>
        /// プレイリストを保存する。
        /// </summary>
        public void Save(Playlist playlist)
        {
            if (this.PlaylistProvider != null && this.PlaylistProvider.CanWrite)
            {
                var dir = Path.GetDirectoryName(this.Location);

                if (string.IsNullOrEmpty(dir) == false)
                {
                    // 保存先のフォルダが存在しないと、例外が発生する可能性がある為、
                    // 念のため存在確認を行い、存在しない場合は保存前に作成する。
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                }

                // プレイリストを保存
                this.PlaylistProvider.SavePlaylist(this.Location, playlist);
            }
        }
    }
}
