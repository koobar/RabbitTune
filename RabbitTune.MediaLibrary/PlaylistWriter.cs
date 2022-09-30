using System.IO;

namespace RabbitTune.MediaLibrary
{
    public class PlaylistWriter : Playlist
    {
        // 非公開変数
        private string Location;

        // コンストラクタ
        public PlaylistWriter(string path) : base(path, null)
        {
            this.Location = path;
        }

        /// <summary>
        /// プレイリストを保存する。
        /// </summary>
        public void Save()
        {
            var dir = Path.GetDirectoryName(this.Location);

            // 保存先のフォルダが存在しないと、例外が発生する可能性がある為、
            // 念のため存在確認を行い、存在しない場合は保存前に作成する。
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // プレイリストを保存
            base.playlistProvider.SavePlaylist(this.Location);
        }
    }
}
