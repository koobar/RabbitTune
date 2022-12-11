using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public partial class PlaylistBrowser : UserControl
    {
        // 公開変数
        public readonly ListViewGroup RecentGroup;
        public readonly ListViewGroup FavoriteGroup;

        // イベント
        public event EventHandler PlaylistOpenRequested;
        public event EventHandler SelectedPlaylistChanged;

        // コンストラクタ
        public PlaylistBrowser()
        {
            InitializeComponent();

            PlaylistsDataBase.RecentPlaylistsChanged += delegate
            {
                Update();
            };
            PlaylistsDataBase.FavoritePlaylistChanged += delegate
            {
                Update();
            };
            
            this.RecentGroup = new ListViewGroup();
            this.RecentGroup.Header = "最近開いたプレイリスト";
            this.FavoriteGroup = new ListViewGroup();
            this.FavoriteGroup.Header = "お気に入り";
            this.PlaylistBrowserListView.Groups.Add(this.RecentGroup);
            this.PlaylistBrowserListView.Groups.Add(this.FavoriteGroup);
            this.PlaylistBrowserListView.SelectedIndexChanged += delegate
            {
                this.SelectedPlaylistChanged?.Invoke(null, null);
            };
            this.PlaylistBrowserListView.DoubleClick += delegate
            {
                this.PlaylistOpenRequested?.Invoke(null, null);
            };

            // フォント設定
            this.Font = SystemFonts.CaptionFont;
        }

        /// <summary>
        /// 選択されたプレイリストの場所
        /// </summary>
        public string SelectedPlaylistLocation
        {
            get
            {
                if(this.PlaylistBrowserListView.SelectedItems.Count > 0)
                {
                    var item = this.PlaylistBrowserListView.SelectedItems[0];
                    return item.Tag.ToString();
                }

                return null;
            }
        }

        /// <summary>
        /// 選択されたアイテムのインデックス
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                if(this.PlaylistBrowserListView.SelectedIndices.Count > 0)
                {
                    return this.PlaylistBrowserListView.SelectedIndices[0];
                }

                return -1;
            }
            set
            {
                // 指定されたインデックスが有効範囲内か？
                if (value > -1 && value < this.PlaylistBrowserListView.Items.Count)
                {
                    // 指定されたインデックスのアイテムを選択状態に設定し、
                    // その他のインデックスのアイテムを非選択状態に設定する。
                    for (int i = 0; i < this.PlaylistBrowserListView.Items.Count; ++i)
                    {
                        if (i == value)
                        {
                            this.PlaylistBrowserListView.Items[i].Selected = true;
                        }
                        else
                        {
                            this.PlaylistBrowserListView.Items[i].Selected = false;
                        }
                    }

                    // 選択されたアイテムの場所までスクロールする。
                    this.PlaylistBrowserListView.EnsureVisible(value);
                }
            }
        }

        /// <summary>
        /// 最近開いたプレイリストに表示用アイテムを追加
        /// </summary>
        /// <param name="path"></param>
        private void AddPlaylistViewItemToRecentItemGroup(string path)
        {
            var item = CreateItem(path);

            item.Group = this.RecentGroup;
            this.PlaylistBrowserListView.Items.Add(item);

            // 後始末
            FixSize();
        }

        /// <summary>
        /// お気に入りプレイリストに表示用アイテムを追加
        /// </summary>
        /// <param name="path"></param>
        private void AddPlaylistViewItemToFavoriteItemGroup(string path)
        {
            var item = CreateItem(path);

            item.Group = this.FavoriteGroup;
            this.PlaylistBrowserListView.Items.Add(item);

            // 後始末
            FixSize();
        }

        /// <summary>
        /// 指定されたメニューを一覧から削除する。
        /// </summary>
        /// <param name="item"></param>
        public void DeleteItemFromView(ListViewItem item)
        {
            if (item.Group == this.RecentGroup)
            {
                PlaylistsDataBase.RemoveFromRecentPlaylist(this.SelectedPlaylistLocation);
            }
            else if (item.Group == this.FavoriteGroup)
            {
                PlaylistsDataBase.RemoveFromFavoritePlaylist(this.SelectedPlaylistLocation);
            }
        }

        /// <summary>
        /// アイテム一覧の表示を更新する。
        /// </summary>
        public new void Update()
        {
            this.PlaylistBrowserListView.Items.Clear();

            foreach(var playlist in PlaylistsDataBase.RecentPlaylists)
            {
                AddPlaylistViewItemToRecentItemGroup(playlist);
            }

            foreach(var playlist in PlaylistsDataBase.FavoritePlaylists)
            {
                AddPlaylistViewItemToFavoriteItemGroup(playlist);
            }

            base.Update();
        }

        /// <summary>
        /// 指定されたファイルをプレイリスト一覧へ追加するためのListViewItemを生成する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ListViewItem CreateItem(string path)
        {
            if (File.Exists(path))
            {
                var item = new ListViewItem(new string[] { Path.GetFileName(path) });
                item.Tag = path;

                return item;
            }
            else
            {
                string dirName = Path.GetDirectoryName(path);

                if (string.IsNullOrEmpty(dirName))
                {
                    dirName = $"{path[0]}:\\";
                }

                var item = new ListViewItem(new string[] { dirName } );
                item.Tag = path;

                return item;
            }
        }

        /// <summary>
        /// アイテムのサイズに合わせて各列をリサイズする。
        /// </summary>
        private void FixSize()
        {
            this.PlaylistBrowserListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// お気に入りに追加メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToFavoritePlaylistMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedIndex > -1)
            {
                PlaylistsDataBase.AddFavoritePlaylist(this.SelectedPlaylistLocation);
            }
        }

        /// <summary>
        /// 一覧から削除メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteFromViewMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedIndex > -1)
            {
                var item = this.PlaylistBrowserListView.SelectedItems[0];

                // 一覧から削除
                DeleteItemFromView(item);
            }
        }

        /// <summary>
        /// ファイルごと削除メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePlaylistWithFileMenu_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                "選択されたプレイリストを削除しますか？\n" +
                "（プレイリストファイルも削除されます。）",
                "削除の確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if(dialogResult == DialogResult.Yes)
            {
                var item = this.PlaylistBrowserListView.SelectedItems[0];
                var path = item.Tag.ToString();

                // 一覧から削除
                DeleteItemFromView(item);

                // ファイルも削除する。
                try
                {
                    File.Delete(path);
                }
                catch(IOException)
                {
                    MessageBox.Show(
                        "選択されたプレイリストを一覧から除外しましたが、ファイルの削除に失敗しました。\n" +
                        "ファイルを削除する権限が与えられていないか、別のアプリケーションにより、ファイルが\n" +
                        "使用中である可能性があります。",
                        "ファイルの削除失敗",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateToLatestStateMenu_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
