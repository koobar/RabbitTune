namespace RabbitTune.Controls
{
    partial class PlaylistBrowser
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.PlaylistBrowserListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlaylistBrowserContextMenu = new System.Windows.Forms.ContextMenu();
            this.UpdateToLatestStateMenu = new System.Windows.Forms.MenuItem();
            this.ContextMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.RegistToFacoritePlaylistsMenu = new System.Windows.Forms.MenuItem();
            this.ContextMenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.DeleteFromListMenu = new System.Windows.Forms.MenuItem();
            this.DeletePlaylistWithFileMenu = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // PlaylistBrowserListView
            // 
            this.PlaylistBrowserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.PlaylistBrowserListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistBrowserListView.FullRowSelect = true;
            this.PlaylistBrowserListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PlaylistBrowserListView.HideSelection = false;
            this.PlaylistBrowserListView.Location = new System.Drawing.Point(0, 0);
            this.PlaylistBrowserListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlaylistBrowserListView.MultiSelect = false;
            this.PlaylistBrowserListView.Name = "PlaylistBrowserListView";
            this.PlaylistBrowserListView.Size = new System.Drawing.Size(129, 160);
            this.PlaylistBrowserListView.TabIndex = 2;
            this.PlaylistBrowserListView.UseCompatibleStateImageBehavior = false;
            this.PlaylistBrowserListView.View = System.Windows.Forms.View.Details;
            // 
            // PlaylistBrowserContextMenu
            // 
            this.PlaylistBrowserContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.UpdateToLatestStateMenu,
            this.ContextMenuSeparator1,
            this.RegistToFacoritePlaylistsMenu,
            this.ContextMenuSeparator2,
            this.DeleteFromListMenu,
            this.DeletePlaylistWithFileMenu});
            // 
            // UpdateToLatestStateMenu
            // 
            this.UpdateToLatestStateMenu.Index = 0;
            this.UpdateToLatestStateMenu.Text = "最新の状態に更新";
            this.UpdateToLatestStateMenu.Click += new System.EventHandler(this.UpdateToLatestStateMenu_Click);
            // 
            // ContextMenuSeparator1
            // 
            this.ContextMenuSeparator1.Index = 1;
            this.ContextMenuSeparator1.Text = "-";
            // 
            // RegistToFacoritePlaylistsMenu
            // 
            this.RegistToFacoritePlaylistsMenu.Index = 2;
            this.RegistToFacoritePlaylistsMenu.Text = "お気に入りに登録";
            this.RegistToFacoritePlaylistsMenu.Click += new System.EventHandler(this.AddToFavoritePlaylistMenu_Click);
            // 
            // ContextMenuSeparator2
            // 
            this.ContextMenuSeparator2.Index = 3;
            this.ContextMenuSeparator2.Text = "-";
            // 
            // DeleteFromListMenu
            // 
            this.DeleteFromListMenu.Index = 4;
            this.DeleteFromListMenu.Text = "一覧から除去";
            this.DeleteFromListMenu.Click += new System.EventHandler(this.DeleteFromViewMenu_Click);
            // 
            // DeletePlaylistWithFileMenu
            // 
            this.DeletePlaylistWithFileMenu.Index = 5;
            this.DeletePlaylistWithFileMenu.Text = "ファイルごと削除";
            this.DeletePlaylistWithFileMenu.Click += new System.EventHandler(this.DeletePlaylistWithFileMenu_Click);
            // 
            // PlaylistBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.PlaylistBrowserListView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlaylistBrowser";
            this.Size = new System.Drawing.Size(129, 160);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PlaylistBrowserListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenu PlaylistBrowserContextMenu;
        private System.Windows.Forms.MenuItem RegistToFacoritePlaylistsMenu;
        private System.Windows.Forms.MenuItem ContextMenuSeparator2;
        private System.Windows.Forms.MenuItem DeleteFromListMenu;
        private System.Windows.Forms.MenuItem DeletePlaylistWithFileMenu;
        private System.Windows.Forms.MenuItem UpdateToLatestStateMenu;
        private System.Windows.Forms.MenuItem ContextMenuSeparator1;
    }
}
