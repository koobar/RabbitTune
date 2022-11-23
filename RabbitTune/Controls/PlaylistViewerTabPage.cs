using System;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    internal class PlaylistViewerTabPage : TabPage
    {
        // 公開イベント
        public event EventHandler AudioTrackSelected;

        // コンストラクタ
        public PlaylistViewerTabPage()
        {
            InitComponents();

            this.PlaylistViewer.PlaylistChanged += delegate
            {
                string text = this.PlaylistViewer.PlaylistName;

                if(text != null && text.EndsWith("*") == false)
                {
                    text += "*";
                }

                this.Text = text;
            };
            this.PlaylistViewer.CurrentPlaylistChanged += delegate
            {
                this.Text = this.PlaylistViewer.PlaylistName;
            };
        }

        /// <summary>
        /// プレイリストビューワー
        /// </summary>
        public PlaylistViewer PlaylistViewer { get; private set; }

        /// <summary>
        /// このタブを閉じることができるかどうか
        /// </summary>
        public bool CanClose { set; get; } = true;

        /// <summary>
        /// コンポーネントを初期化する。
        /// </summary>
        private void InitComponents()
        {
            // プレイリストビューワー
            this.PlaylistViewer = new PlaylistViewer();
            this.PlaylistViewer.Dock = DockStyle.Fill;
            this.PlaylistViewer.AudioTrackDoubleClicked += PlaylistViewer_AudioTrackDoubleClicked;
            this.PlaylistViewer.CurrentPlaylistChanged += PlaylistViewer_PlaylistFileChanged;
            base.Controls.Add(this.PlaylistViewer);
            this.Text = this.PlaylistViewer.PlaylistName;
        }

        private void PlaylistViewer_PlaylistFileChanged(object sender, EventArgs e)
        {
            this.Text = Path.GetFileName(this.PlaylistViewer.GetPlaylistFilePath());
        }

        private void PlaylistViewer_AudioTrackDoubleClicked(object sender, EventArgs e)
        {
            this.AudioTrackSelected?.Invoke(sender, e);
        }
    }
}
