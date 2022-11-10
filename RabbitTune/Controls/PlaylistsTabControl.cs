using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public class PlaylistsTabControl : TabControl
    {
        // 非公開変数
        private readonly ContextMenuStrip TabHeaderContextMenu;
        private readonly ToolStripMenuItem AddToFavoritePlaylistsMenu;
        private readonly ToolStripSeparator ContextMenuSeparator1;
        private readonly ToolStripMenuItem TabCloseMenu;
        
        // コンストラクタ
        public PlaylistsTabControl()
        {
            this.TabHeaderContextMenu = new ContextMenuStrip();
            this.AddToFavoritePlaylistsMenu = new ToolStripMenuItem();
            this.AddToFavoritePlaylistsMenu.Text = "お気に入りに登録";
            this.AddToFavoritePlaylistsMenu.Click += delegate
            {
                if (this.TabHeaderContextMenu.Tag != null)
                {
                    var page = (PlaylistViewerTabPage)this.TabHeaderContextMenu.Tag;

                    PlaylistsDataBase.AddFavoritePlaylist(page.PlaylistViewer.GetPlaylistFilePath());
                }
            };
            this.ContextMenuSeparator1 = new ToolStripSeparator();
            this.TabCloseMenu = new ToolStripMenuItem();
            this.TabCloseMenu.Text = "閉じる(&C)";
            this.TabCloseMenu.Click += delegate
            {
                CloseTab();
            };

            // 後始末
            this.TabHeaderContextMenu.Items.Add(this.AddToFavoritePlaylistsMenu);
            this.TabHeaderContextMenu.Items.Add(this.ContextMenuSeparator1);
            this.TabHeaderContextMenu.Items.Add(this.TabCloseMenu);
        }

        /// <summary>
        /// タブを閉じる。
        /// </summary>
        private void CloseTab()
        {
            this.TabPages.Remove(this.SelectedTab);
        }
       
        /// <summary>
        /// タブヘッダ部分にマウスポインタが重なっている場合、そのタブページのインデックスを取得する。<br/>
        /// マウスポインタがタブヘッダ部分に重なっていない場合、-1を返す。
        /// </summary>
        /// <param name="mousePointerPosition"></param>
        /// <returns></returns>
        private int GetMouseHoveringTabIndex(Point mousePointerPosition)
        {
            for(int i = 0; i < this.TabCount; ++i)
            {
                var rect = GetTabRect(i);

                if (rect.Contains(mousePointerPosition))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// マウスのボタンが押された時の処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = GetMouseHoveringTabIndex(e.Location);

                if(index != -1)
                {
                    var page = (PlaylistViewerTabPage)this.TabPages[index];
                    this.TabCloseMenu.Enabled = page.CanClose;

                    // 右クリックされたタブを選択する。
                    this.TabHeaderContextMenu.Tag = page;       // タブヘッダのコンテキストメニューのタグに、対応付けられるページを保持する。
                    this.SelectedIndex = index;

                    // コンテキストメニューを表示する。
                    this.TabHeaderContextMenu.Show(this, e.Location);
                }
                else
                {
                    this.TabHeaderContextMenu.Tag = null;
                }
            }

            base.OnMouseUp(e);
        }
    }
}
