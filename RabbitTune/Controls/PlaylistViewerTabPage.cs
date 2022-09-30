using System;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    internal class PlaylistViewerTabPage : TabPage
    {
        // 非公開変数
        private PlaylistViewer playlistViewer;

        // 公開イベント
        public event EventHandler AudioTrackSelected;

        // コンストラクタ
        public PlaylistViewerTabPage()
        {
            InitComponents();

            this.playlistViewer.PlaylistChanged += delegate
            {
                string text = this.Text;

                if(text != null)
                {
                    if(text.EndsWith("*") == false)
                    {
                        text += "*";
                    }
                }

                this.Text = text;
            };
        }

        /// <summary>
        /// プレイリストビューワー
        /// </summary>
        public PlaylistViewer PlaylistViewer
        {
            get
            {
                return this.playlistViewer;
            }
        }

        /// <summary>
        /// このタブを閉じることができるかどうか
        /// </summary>
        public bool CanClose { set; get; } = true;

        /// <summary>
        /// コンポーネントを初期化する。
        /// </summary>
        private void InitComponents()
        {
            this.Text = "プレイリスト";

            // プレイリストビューワー
            this.playlistViewer = new PlaylistViewer();
            this.playlistViewer.Dock = DockStyle.Fill;
            this.playlistViewer.AudioTrackDoubleClicked += PlaylistViewer_AudioTrackDoubleClicked;
            this.playlistViewer.PlaylistFileChanged += PlaylistViewer_PlaylistFileChanged;
            base.Controls.Add(this.playlistViewer);
        }

        private void PlaylistViewer_PlaylistFileChanged(object sender, EventArgs e)
        {
            this.Text = Path.GetFileName(this.playlistViewer.GetPlaylistFilePath());
        }

        private void PlaylistViewer_AudioTrackDoubleClicked(object sender, EventArgs e)
        {
            this.AudioTrackSelected?.Invoke(sender, e);
        }
    }
}
