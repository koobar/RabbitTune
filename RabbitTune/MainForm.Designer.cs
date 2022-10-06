using RabbitTune.Controls;
using System.Windows.Forms;

namespace RabbitTune
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PlayingAudioFormatStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayingAudioWaveFormatText = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlaybackPositionStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.SeekBar = new System.Windows.Forms.HScrollBar();
            this.LeftToolPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlaylistBrowser = new RabbitTune.Controls.PlaylistBrowser();
            this.TrackPictureViewer = new System.Windows.Forms.PictureBox();
            this.LeftSideSplitter = new System.Windows.Forms.Splitter();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.CreateNewPlaylistMenu = new System.Windows.Forms.MenuItem();
            this.FileMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.OpenAnyFilesMenu = new System.Windows.Forms.MenuItem();
            this.FileMenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.SaveCurrentPlaylistAsMenu = new System.Windows.Forms.MenuItem();
            this.SaveCurrentPlaylistMenu = new System.Windows.Forms.MenuItem();
            this.SaveAllPlaylistsMenu = new System.Windows.Forms.MenuItem();
            this.FileMenuSeparator3 = new System.Windows.Forms.MenuItem();
            this.AddFolderToPlaylistMenu = new System.Windows.Forms.MenuItem();
            this.FileMenuSeparator4 = new System.Windows.Forms.MenuItem();
            this.ExitApplicationMenu = new System.Windows.Forms.MenuItem();
            this.EditMenu = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.FindAudioTrackMenu = new System.Windows.Forms.MenuItem();
            this.FindAudioTrackNextMenu = new System.Windows.Forms.MenuItem();
            this.EditMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.MoveUpSelectedItemMenu = new System.Windows.Forms.MenuItem();
            this.MoveDownSelectedItemMenu = new System.Windows.Forms.MenuItem();
            this.EditMenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.RemoveSelectedItemFromListMenu = new System.Windows.Forms.MenuItem();
            this.RemoveSelectedItemWithFileFromListMenu = new System.Windows.Forms.MenuItem();
            this.RemoveAllItemsMenu = new System.Windows.Forms.MenuItem();
            this.ViewMenu = new System.Windows.Forms.MenuItem();
            this.AlwaysOnTopMenu = new System.Windows.Forms.MenuItem();
            this.ViewMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.ShowLeftSideToolPanelMenu = new System.Windows.Forms.MenuItem();
            this.ShowAudioOutputInfoMenu = new System.Windows.Forms.MenuItem();
            this.AudioProcessMenu = new System.Windows.Forms.MenuItem();
            this.SampleRateConversionMenu = new System.Windows.Forms.MenuItem();
            this.EqualizerMenu = new System.Windows.Forms.MenuItem();
            this.AudioProcessMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeedsMenu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed025Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed050Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed075Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed090Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed100Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed110Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed125Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed150Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed175Menu = new System.Windows.Forms.MenuItem();
            this.PlaybackSpeed200Menu = new System.Windows.Forms.MenuItem();
            this.PitchMenu = new System.Windows.Forms.MenuItem();
            this.PitchM12SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM11SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM10SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM9SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM8SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM7SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM6SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM5SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM4SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM3SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM2SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchM1SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchPM0SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP1SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP2SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP3SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP4SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP5SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP6SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP7SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP8SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP9SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP10SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP11SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchP12SemitonesMenu = new System.Windows.Forms.MenuItem();
            this.PitchMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.FixPitchClipMenu = new System.Windows.Forms.MenuItem();
            this.SoundTouchPitchMenu = new System.Windows.Forms.MenuItem();
            this.STPitchM12Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM11Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM10Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM9Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM8Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM7Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM6Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM5Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM4Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM3Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM2Menu = new System.Windows.Forms.MenuItem();
            this.STPitchM1Menu = new System.Windows.Forms.MenuItem();
            this.STPitchZeroMenu = new System.Windows.Forms.MenuItem();
            this.STPitchP1Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP2Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP3Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP4Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP5Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP6Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP7Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP8Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP9Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP10Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP11Menu = new System.Windows.Forms.MenuItem();
            this.STPitchP12Menu = new System.Windows.Forms.MenuItem();
            this.STPitchMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.STPitchFixClipMenu = new System.Windows.Forms.MenuItem();
            this.PlayMenu = new System.Windows.Forms.MenuItem();
            this.StopMenu = new System.Windows.Forms.MenuItem();
            this.PauseOrResumeMenu = new System.Windows.Forms.MenuItem();
            this.PlaybackMenu = new System.Windows.Forms.MenuItem();
            this.PreviousMenu = new System.Windows.Forms.MenuItem();
            this.NextMenu = new System.Windows.Forms.MenuItem();
            this.RandomMenu = new System.Windows.Forms.MenuItem();
            this.PlayMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.PlaybackOrdersMenu = new System.Windows.Forms.MenuItem();
            this.NoRepeatMenu = new System.Windows.Forms.MenuItem();
            this.PlaybackOrderMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.RepeatSingleTrackMenu = new System.Windows.Forms.MenuItem();
            this.RepeatAllTracksMenu = new System.Windows.Forms.MenuItem();
            this.RandomRepeatMenu = new System.Windows.Forms.MenuItem();
            this.OptionMenu = new System.Windows.Forms.MenuItem();
            this.DetailOptionsMenu = new System.Windows.Forms.MenuItem();
            this.OptionMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.ResetAllOptionsMenu = new System.Windows.Forms.MenuItem();
            this.HelpMenu = new System.Windows.Forms.MenuItem();
            this.ShowReadMeMenu = new System.Windows.Forms.MenuItem();
            this.ShowHistoryMenu = new System.Windows.Forms.MenuItem();
            this.HelpMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.ShowVersionInfoMenu = new System.Windows.Forms.MenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateNewPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenAnyFileButton = new System.Windows.Forms.ToolStripButton();
            this.SaveCurrentPlaylistButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAllPlaylistsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StopButton = new System.Windows.Forms.ToolStripButton();
            this.PlayButton = new System.Windows.Forms.ToolStripButton();
            this.PauseOrResumeButton = new System.Windows.Forms.ToolStripButton();
            this.PreviousButton = new System.Windows.Forms.ToolStripButton();
            this.NextButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.QuickSearchbutton = new System.Windows.Forms.ToolStripButton();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.VolumeSlider = new RabbitTune.Controls.ToolStripSlider();
            this.MainTabControl = new RabbitTune.Controls.PlaylistsTabControl();
            this.statusStrip1.SuspendLayout();
            this.LeftToolPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackPictureViewer)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayingAudioFormatStatusText,
            this.PlayingAudioWaveFormatText,
            this.PlaybackPositionStatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PlayingAudioFormatStatusText
            // 
            this.PlayingAudioFormatStatusText.Name = "PlayingAudioFormatStatusText";
            this.PlayingAudioFormatStatusText.Size = new System.Drawing.Size(33, 19);
            this.PlayingAudioFormatStatusText.Text = "WAV";
            this.PlayingAudioFormatStatusText.Visible = false;
            // 
            // PlayingAudioWaveFormatText
            // 
            this.PlayingAudioWaveFormatText.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.PlayingAudioWaveFormatText.Name = "PlayingAudioWaveFormatText";
            this.PlayingAudioWaveFormatText.Size = new System.Drawing.Size(55, 19);
            this.PlayingAudioWaveFormatText.Text = "44100Hz";
            this.PlayingAudioWaveFormatText.Visible = false;
            // 
            // PlaybackPositionStatusText
            // 
            this.PlaybackPositionStatusText.Name = "PlaybackPositionStatusText";
            this.PlaybackPositionStatusText.Size = new System.Drawing.Size(719, 17);
            this.PlaybackPositionStatusText.Spring = true;
            this.PlaybackPositionStatusText.Text = "00:00";
            this.PlaybackPositionStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeekBar
            // 
            this.SeekBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.SeekBar.Location = new System.Drawing.Point(0, 25);
            this.SeekBar.Maximum = 10000;
            this.SeekBar.Name = "SeekBar";
            this.SeekBar.Size = new System.Drawing.Size(734, 17);
            this.SeekBar.TabIndex = 3;
            // 
            // LeftToolPanel
            // 
            this.LeftToolPanel.Controls.Add(this.tableLayoutPanel1);
            this.LeftToolPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolPanel.Location = new System.Drawing.Point(0, 42);
            this.LeftToolPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LeftToolPanel.Name = "LeftToolPanel";
            this.LeftToolPanel.Size = new System.Drawing.Size(180, 372);
            this.LeftToolPanel.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PlaylistBrowser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TrackPictureViewer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 372);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PlaylistBrowser
            // 
            this.PlaylistBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistBrowser.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.PlaylistBrowser.Location = new System.Drawing.Point(4, 2);
            this.PlaylistBrowser.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PlaylistBrowser.Name = "PlaylistBrowser";
            this.PlaylistBrowser.SelectedIndex = -1;
            this.PlaylistBrowser.Size = new System.Drawing.Size(172, 363);
            this.PlaylistBrowser.TabIndex = 4;
            this.PlaylistBrowser.PlaylistOpenRequested += new System.EventHandler(this.PlaylistBrowser_PlaylistOpenRequested);
            // 
            // TrackPictureViewer
            // 
            this.TrackPictureViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackPictureViewer.Location = new System.Drawing.Point(4, 369);
            this.TrackPictureViewer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.TrackPictureViewer.Name = "TrackPictureViewer";
            this.TrackPictureViewer.Size = new System.Drawing.Size(172, 1);
            this.TrackPictureViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrackPictureViewer.TabIndex = 3;
            this.TrackPictureViewer.TabStop = false;
            // 
            // LeftSideSplitter
            // 
            this.LeftSideSplitter.Location = new System.Drawing.Point(180, 42);
            this.LeftSideSplitter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LeftSideSplitter.Name = "LeftSideSplitter";
            this.LeftSideSplitter.Size = new System.Drawing.Size(4, 372);
            this.LeftSideSplitter.TabIndex = 5;
            this.LeftSideSplitter.TabStop = false;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ViewMenu,
            this.AudioProcessMenu,
            this.PlayMenu,
            this.OptionMenu,
            this.HelpMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.CreateNewPlaylistMenu,
            this.FileMenuSeparator1,
            this.OpenAnyFilesMenu,
            this.FileMenuSeparator2,
            this.SaveCurrentPlaylistAsMenu,
            this.SaveCurrentPlaylistMenu,
            this.SaveAllPlaylistsMenu,
            this.FileMenuSeparator3,
            this.AddFolderToPlaylistMenu,
            this.FileMenuSeparator4,
            this.ExitApplicationMenu});
            this.FileMenu.Text = "ファイル(&F)";
            // 
            // CreateNewPlaylistMenu
            // 
            this.CreateNewPlaylistMenu.Index = 0;
            this.CreateNewPlaylistMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.CreateNewPlaylistMenu.Text = "新規プレイリスト(&N)";
            this.CreateNewPlaylistMenu.Click += new System.EventHandler(this.CreateNewPlaylistMenu_Click);
            // 
            // FileMenuSeparator1
            // 
            this.FileMenuSeparator1.Index = 1;
            this.FileMenuSeparator1.Text = "-";
            // 
            // OpenAnyFilesMenu
            // 
            this.OpenAnyFilesMenu.Index = 2;
            this.OpenAnyFilesMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenAnyFilesMenu.Text = "開く(&O)";
            this.OpenAnyFilesMenu.Click += new System.EventHandler(this.OpenAnyFilesMenu_Click);
            // 
            // FileMenuSeparator2
            // 
            this.FileMenuSeparator2.Index = 3;
            this.FileMenuSeparator2.Text = "-";
            // 
            // SaveCurrentPlaylistAsMenu
            // 
            this.SaveCurrentPlaylistAsMenu.Index = 4;
            this.SaveCurrentPlaylistAsMenu.Text = "名前を付けて現在のプレイリストを保存";
            this.SaveCurrentPlaylistAsMenu.Click += new System.EventHandler(this.SaveCurrentPlaylistAsMenu_Click);
            // 
            // SaveCurrentPlaylistMenu
            // 
            this.SaveCurrentPlaylistMenu.Index = 5;
            this.SaveCurrentPlaylistMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.SaveCurrentPlaylistMenu.Text = "現在のプレイリストを保存";
            this.SaveCurrentPlaylistMenu.Click += new System.EventHandler(this.SaveCurrentPlaylistMenu_Click);
            // 
            // SaveAllPlaylistsMenu
            // 
            this.SaveAllPlaylistsMenu.Index = 6;
            this.SaveAllPlaylistsMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.SaveAllPlaylistsMenu.Text = "全てのプレイリストを保存";
            this.SaveAllPlaylistsMenu.Click += new System.EventHandler(this.SaveAllPlaylistsMenu_Click);
            // 
            // FileMenuSeparator3
            // 
            this.FileMenuSeparator3.Index = 7;
            this.FileMenuSeparator3.Text = "-";
            // 
            // AddFolderToPlaylistMenu
            // 
            this.AddFolderToPlaylistMenu.Index = 8;
            this.AddFolderToPlaylistMenu.Text = "プレイリストにフォルダを追加";
            this.AddFolderToPlaylistMenu.Click += new System.EventHandler(this.AddFolderToPlaylistMenu_Click);
            // 
            // FileMenuSeparator4
            // 
            this.FileMenuSeparator4.Index = 9;
            this.FileMenuSeparator4.Text = "-";
            // 
            // ExitApplicationMenu
            // 
            this.ExitApplicationMenu.Index = 10;
            this.ExitApplicationMenu.Text = "閉じる(&X)";
            this.ExitApplicationMenu.Click += new System.EventHandler(this.ExitApplicationMenu_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.Index = 1;
            this.EditMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.EditMenuSeparator1,
            this.MoveUpSelectedItemMenu,
            this.MoveDownSelectedItemMenu,
            this.EditMenuSeparator2,
            this.RemoveSelectedItemFromListMenu,
            this.RemoveSelectedItemWithFileFromListMenu,
            this.RemoveAllItemsMenu});
            this.EditMenu.Text = "編集(&E)";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FindAudioTrackMenu,
            this.FindAudioTrackNextMenu});
            this.menuItem2.Text = "検索";
            // 
            // FindAudioTrackMenu
            // 
            this.FindAudioTrackMenu.Index = 0;
            this.FindAudioTrackMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.FindAudioTrackMenu.Text = "トラックの検索(&F)";
            this.FindAudioTrackMenu.Click += new System.EventHandler(this.FindAudioTrackMenu_Click);
            // 
            // FindAudioTrackNextMenu
            // 
            this.FindAudioTrackNextMenu.Index = 1;
            this.FindAudioTrackNextMenu.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.FindAudioTrackNextMenu.Text = "次を検索";
            this.FindAudioTrackNextMenu.Click += new System.EventHandler(this.FindAudioTrackNextMenu_Click);
            // 
            // EditMenuSeparator1
            // 
            this.EditMenuSeparator1.Index = 1;
            this.EditMenuSeparator1.Text = "-";
            // 
            // MoveUpSelectedItemMenu
            // 
            this.MoveUpSelectedItemMenu.Index = 2;
            this.MoveUpSelectedItemMenu.Text = "選択中のアイテムを上へ移動";
            this.MoveUpSelectedItemMenu.Click += new System.EventHandler(this.MoveUpSelectedItemMenu_Click);
            // 
            // MoveDownSelectedItemMenu
            // 
            this.MoveDownSelectedItemMenu.Index = 3;
            this.MoveDownSelectedItemMenu.Text = "選択中のアイテムを下へ移動";
            this.MoveDownSelectedItemMenu.Click += new System.EventHandler(this.MoveDownSelectedItemMenu_Click);
            // 
            // EditMenuSeparator2
            // 
            this.EditMenuSeparator2.Index = 4;
            this.EditMenuSeparator2.Text = "-";
            // 
            // RemoveSelectedItemFromListMenu
            // 
            this.RemoveSelectedItemFromListMenu.Index = 5;
            this.RemoveSelectedItemFromListMenu.Text = "選択中のアイテムを一覧から削除";
            this.RemoveSelectedItemFromListMenu.Click += new System.EventHandler(this.RemoveSelectedItemFromListMenu_Click);
            // 
            // RemoveSelectedItemWithFileFromListMenu
            // 
            this.RemoveSelectedItemWithFileFromListMenu.Index = 6;
            this.RemoveSelectedItemWithFileFromListMenu.Text = "選択中のアイテムをファイルごと削除";
            this.RemoveSelectedItemWithFileFromListMenu.Click += new System.EventHandler(this.RemoveSelectedItemWithFileFromListMenu_Click);
            // 
            // RemoveAllItemsMenu
            // 
            this.RemoveAllItemsMenu.Index = 7;
            this.RemoveAllItemsMenu.Text = "アイテムをすべて削除";
            this.RemoveAllItemsMenu.Click += new System.EventHandler(this.RemoveAllItemsMenu_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.Index = 2;
            this.ViewMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AlwaysOnTopMenu,
            this.ViewMenuSeparator1,
            this.ShowLeftSideToolPanelMenu,
            this.ShowAudioOutputInfoMenu});
            this.ViewMenu.Text = "表示(&V)";
            // 
            // AlwaysOnTopMenu
            // 
            this.AlwaysOnTopMenu.Index = 0;
            this.AlwaysOnTopMenu.Text = "常に最前面に表示";
            this.AlwaysOnTopMenu.Click += new System.EventHandler(this.AlwaysOnTopMenu_Click);
            // 
            // ViewMenuSeparator1
            // 
            this.ViewMenuSeparator1.Index = 1;
            this.ViewMenuSeparator1.Text = "-";
            // 
            // ShowLeftSideToolPanelMenu
            // 
            this.ShowLeftSideToolPanelMenu.Checked = true;
            this.ShowLeftSideToolPanelMenu.Index = 2;
            this.ShowLeftSideToolPanelMenu.Text = "左側ツールパネルの表示";
            this.ShowLeftSideToolPanelMenu.Click += new System.EventHandler(this.ShowLeftSideToolPanelMenu_Click);
            // 
            // ShowAudioOutputInfoMenu
            // 
            this.ShowAudioOutputInfoMenu.Index = 3;
            this.ShowAudioOutputInfoMenu.Text = "オーディオの詳細情報";
            this.ShowAudioOutputInfoMenu.Click += new System.EventHandler(this.ShowAudioOutputInfoMenu_Click);
            // 
            // AudioProcessMenu
            // 
            this.AudioProcessMenu.Index = 3;
            this.AudioProcessMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SampleRateConversionMenu,
            this.EqualizerMenu,
            this.AudioProcessMenuSeparator1,
            this.PlaybackSpeedsMenu,
            this.PitchMenu,
            this.SoundTouchPitchMenu});
            this.AudioProcessMenu.Text = "音響(&A)";
            // 
            // SampleRateConversionMenu
            // 
            this.SampleRateConversionMenu.Index = 0;
            this.SampleRateConversionMenu.Text = "サンプリング周波数変換";
            this.SampleRateConversionMenu.Click += new System.EventHandler(this.SampleRateConversionMenu_Click);
            // 
            // EqualizerMenu
            // 
            this.EqualizerMenu.Index = 1;
            this.EqualizerMenu.Text = "イコライザ(&E)";
            this.EqualizerMenu.Click += new System.EventHandler(this.EqualizerMenu_Click);
            // 
            // AudioProcessMenuSeparator1
            // 
            this.AudioProcessMenuSeparator1.Index = 2;
            this.AudioProcessMenuSeparator1.Text = "-";
            // 
            // PlaybackSpeedsMenu
            // 
            this.PlaybackSpeedsMenu.Index = 3;
            this.PlaybackSpeedsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PlaybackSpeed025Menu,
            this.PlaybackSpeed050Menu,
            this.PlaybackSpeed075Menu,
            this.PlaybackSpeed090Menu,
            this.PlaybackSpeed100Menu,
            this.PlaybackSpeed110Menu,
            this.PlaybackSpeed125Menu,
            this.PlaybackSpeed150Menu,
            this.PlaybackSpeed175Menu,
            this.PlaybackSpeed200Menu});
            this.PlaybackSpeedsMenu.Text = "再生速度(&S)";
            // 
            // PlaybackSpeed025Menu
            // 
            this.PlaybackSpeed025Menu.Index = 0;
            this.PlaybackSpeed025Menu.Tag = "0.25";
            this.PlaybackSpeed025Menu.Text = "0.25倍速";
            this.PlaybackSpeed025Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed050Menu
            // 
            this.PlaybackSpeed050Menu.Index = 1;
            this.PlaybackSpeed050Menu.Tag = "0.50";
            this.PlaybackSpeed050Menu.Text = "0.50倍速";
            this.PlaybackSpeed050Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed075Menu
            // 
            this.PlaybackSpeed075Menu.Index = 2;
            this.PlaybackSpeed075Menu.Tag = "0.75";
            this.PlaybackSpeed075Menu.Text = "0.75倍速";
            this.PlaybackSpeed075Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed090Menu
            // 
            this.PlaybackSpeed090Menu.Index = 3;
            this.PlaybackSpeed090Menu.Tag = "0.90";
            this.PlaybackSpeed090Menu.Text = "0.90倍速";
            this.PlaybackSpeed090Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed100Menu
            // 
            this.PlaybackSpeed100Menu.Index = 4;
            this.PlaybackSpeed100Menu.Tag = "1.00";
            this.PlaybackSpeed100Menu.Text = "1.00倍速";
            this.PlaybackSpeed100Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed110Menu
            // 
            this.PlaybackSpeed110Menu.Index = 5;
            this.PlaybackSpeed110Menu.Tag = "1.10";
            this.PlaybackSpeed110Menu.Text = "1.10倍速";
            this.PlaybackSpeed110Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed125Menu
            // 
            this.PlaybackSpeed125Menu.Index = 6;
            this.PlaybackSpeed125Menu.Tag = "1.25";
            this.PlaybackSpeed125Menu.Text = "1.25倍速";
            this.PlaybackSpeed125Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed150Menu
            // 
            this.PlaybackSpeed150Menu.Index = 7;
            this.PlaybackSpeed150Menu.Tag = "1.50";
            this.PlaybackSpeed150Menu.Text = "1.50倍速";
            this.PlaybackSpeed150Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed175Menu
            // 
            this.PlaybackSpeed175Menu.Index = 8;
            this.PlaybackSpeed175Menu.Tag = "1.75";
            this.PlaybackSpeed175Menu.Text = "1.75倍速";
            this.PlaybackSpeed175Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed200Menu
            // 
            this.PlaybackSpeed200Menu.Index = 9;
            this.PlaybackSpeed200Menu.Tag = "2.00";
            this.PlaybackSpeed200Menu.Text = "2.00倍速";
            this.PlaybackSpeed200Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PitchMenu
            // 
            this.PitchMenu.Index = 4;
            this.PitchMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PitchM12SemitonesMenu,
            this.PitchM11SemitonesMenu,
            this.PitchM10SemitonesMenu,
            this.PitchM9SemitonesMenu,
            this.PitchM8SemitonesMenu,
            this.PitchM7SemitonesMenu,
            this.PitchM6SemitonesMenu,
            this.PitchM5SemitonesMenu,
            this.PitchM4SemitonesMenu,
            this.PitchM3SemitonesMenu,
            this.PitchM2SemitonesMenu,
            this.PitchM1SemitonesMenu,
            this.PitchPM0SemitonesMenu,
            this.PitchP1SemitonesMenu,
            this.PitchP2SemitonesMenu,
            this.PitchP3SemitonesMenu,
            this.PitchP4SemitonesMenu,
            this.PitchP5SemitonesMenu,
            this.PitchP6SemitonesMenu,
            this.PitchP7SemitonesMenu,
            this.PitchP8SemitonesMenu,
            this.PitchP9SemitonesMenu,
            this.PitchP10SemitonesMenu,
            this.PitchP11SemitonesMenu,
            this.PitchP12SemitonesMenu,
            this.PitchMenuSeparator1,
            this.FixPitchClipMenu});
            this.PitchMenu.Text = "ピッチ調整";
            // 
            // PitchM12SemitonesMenu
            // 
            this.PitchM12SemitonesMenu.Index = 0;
            this.PitchM12SemitonesMenu.Tag = "-12";
            this.PitchM12SemitonesMenu.Text = "-12半音";
            this.PitchM12SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM11SemitonesMenu
            // 
            this.PitchM11SemitonesMenu.Index = 1;
            this.PitchM11SemitonesMenu.Tag = "-11";
            this.PitchM11SemitonesMenu.Text = "-11半音";
            this.PitchM11SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM10SemitonesMenu
            // 
            this.PitchM10SemitonesMenu.Index = 2;
            this.PitchM10SemitonesMenu.Tag = "-10";
            this.PitchM10SemitonesMenu.Text = "-10半音";
            this.PitchM10SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM9SemitonesMenu
            // 
            this.PitchM9SemitonesMenu.Index = 3;
            this.PitchM9SemitonesMenu.Tag = "-9";
            this.PitchM9SemitonesMenu.Text = "-9半音";
            this.PitchM9SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM8SemitonesMenu
            // 
            this.PitchM8SemitonesMenu.Index = 4;
            this.PitchM8SemitonesMenu.Tag = "-8";
            this.PitchM8SemitonesMenu.Text = "-8半音";
            this.PitchM8SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM7SemitonesMenu
            // 
            this.PitchM7SemitonesMenu.Index = 5;
            this.PitchM7SemitonesMenu.Tag = "-7";
            this.PitchM7SemitonesMenu.Text = "-7半音";
            this.PitchM7SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM6SemitonesMenu
            // 
            this.PitchM6SemitonesMenu.Index = 6;
            this.PitchM6SemitonesMenu.Tag = "-6";
            this.PitchM6SemitonesMenu.Text = "-6半音";
            this.PitchM6SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM5SemitonesMenu
            // 
            this.PitchM5SemitonesMenu.Index = 7;
            this.PitchM5SemitonesMenu.Tag = "-5";
            this.PitchM5SemitonesMenu.Text = "-5半音";
            this.PitchM5SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM4SemitonesMenu
            // 
            this.PitchM4SemitonesMenu.Index = 8;
            this.PitchM4SemitonesMenu.Tag = "-4";
            this.PitchM4SemitonesMenu.Text = "-4半音";
            this.PitchM4SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM3SemitonesMenu
            // 
            this.PitchM3SemitonesMenu.Index = 9;
            this.PitchM3SemitonesMenu.Tag = "-3";
            this.PitchM3SemitonesMenu.Text = "-3半音";
            this.PitchM3SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM2SemitonesMenu
            // 
            this.PitchM2SemitonesMenu.Index = 10;
            this.PitchM2SemitonesMenu.Tag = "-2";
            this.PitchM2SemitonesMenu.Text = "-2半音";
            this.PitchM2SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM1SemitonesMenu
            // 
            this.PitchM1SemitonesMenu.Index = 11;
            this.PitchM1SemitonesMenu.Tag = "-1";
            this.PitchM1SemitonesMenu.Text = "-1半音";
            this.PitchM1SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchPM0SemitonesMenu
            // 
            this.PitchPM0SemitonesMenu.Index = 12;
            this.PitchPM0SemitonesMenu.Tag = "0";
            this.PitchPM0SemitonesMenu.Text = "±0";
            this.PitchPM0SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP1SemitonesMenu
            // 
            this.PitchP1SemitonesMenu.Index = 13;
            this.PitchP1SemitonesMenu.Tag = "1";
            this.PitchP1SemitonesMenu.Text = "+1半音";
            this.PitchP1SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP2SemitonesMenu
            // 
            this.PitchP2SemitonesMenu.Index = 14;
            this.PitchP2SemitonesMenu.Tag = "2";
            this.PitchP2SemitonesMenu.Text = "+2半音";
            this.PitchP2SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP3SemitonesMenu
            // 
            this.PitchP3SemitonesMenu.Index = 15;
            this.PitchP3SemitonesMenu.Tag = "3";
            this.PitchP3SemitonesMenu.Text = "+3半音";
            this.PitchP3SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP4SemitonesMenu
            // 
            this.PitchP4SemitonesMenu.Index = 16;
            this.PitchP4SemitonesMenu.Tag = "4";
            this.PitchP4SemitonesMenu.Text = "+4半音";
            this.PitchP4SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP5SemitonesMenu
            // 
            this.PitchP5SemitonesMenu.Index = 17;
            this.PitchP5SemitonesMenu.Tag = "5";
            this.PitchP5SemitonesMenu.Text = "+5半音";
            this.PitchP5SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP6SemitonesMenu
            // 
            this.PitchP6SemitonesMenu.Index = 18;
            this.PitchP6SemitonesMenu.Tag = "6";
            this.PitchP6SemitonesMenu.Text = "+6半音";
            this.PitchP6SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP7SemitonesMenu
            // 
            this.PitchP7SemitonesMenu.Index = 19;
            this.PitchP7SemitonesMenu.Tag = "7";
            this.PitchP7SemitonesMenu.Text = "+7半音";
            this.PitchP7SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP8SemitonesMenu
            // 
            this.PitchP8SemitonesMenu.Index = 20;
            this.PitchP8SemitonesMenu.Tag = "8";
            this.PitchP8SemitonesMenu.Text = "+8半音";
            this.PitchP8SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP9SemitonesMenu
            // 
            this.PitchP9SemitonesMenu.Index = 21;
            this.PitchP9SemitonesMenu.Tag = "9";
            this.PitchP9SemitonesMenu.Text = "+9半音";
            this.PitchP9SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP10SemitonesMenu
            // 
            this.PitchP10SemitonesMenu.Index = 22;
            this.PitchP10SemitonesMenu.Tag = "10";
            this.PitchP10SemitonesMenu.Text = "+10半音";
            this.PitchP10SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP11SemitonesMenu
            // 
            this.PitchP11SemitonesMenu.Index = 23;
            this.PitchP11SemitonesMenu.Tag = "11";
            this.PitchP11SemitonesMenu.Text = "+11半音";
            this.PitchP11SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP12SemitonesMenu
            // 
            this.PitchP12SemitonesMenu.Index = 24;
            this.PitchP12SemitonesMenu.Tag = "12";
            this.PitchP12SemitonesMenu.Text = "+12半音";
            this.PitchP12SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchMenuSeparator1
            // 
            this.PitchMenuSeparator1.Index = 25;
            this.PitchMenuSeparator1.Text = "-";
            // 
            // FixPitchClipMenu
            // 
            this.FixPitchClipMenu.Checked = true;
            this.FixPitchClipMenu.Index = 26;
            this.FixPitchClipMenu.Text = "音割れ防止";
            // 
            // SoundTouchPitchMenu
            // 
            this.SoundTouchPitchMenu.Index = 5;
            this.SoundTouchPitchMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.STPitchM12Menu,
            this.STPitchM11Menu,
            this.STPitchM10Menu,
            this.STPitchM9Menu,
            this.STPitchM8Menu,
            this.STPitchM7Menu,
            this.STPitchM6Menu,
            this.STPitchM5Menu,
            this.STPitchM4Menu,
            this.STPitchM3Menu,
            this.STPitchM2Menu,
            this.STPitchM1Menu,
            this.STPitchZeroMenu,
            this.STPitchP1Menu,
            this.STPitchP2Menu,
            this.STPitchP3Menu,
            this.STPitchP4Menu,
            this.STPitchP5Menu,
            this.STPitchP6Menu,
            this.STPitchP7Menu,
            this.STPitchP8Menu,
            this.STPitchP9Menu,
            this.STPitchP10Menu,
            this.STPitchP11Menu,
            this.STPitchP12Menu,
            this.STPitchMenuSeparator1,
            this.STPitchFixClipMenu});
            this.SoundTouchPitchMenu.Text = "ピッチ調整(SoundTouch)";
            // 
            // STPitchM12Menu
            // 
            this.STPitchM12Menu.Index = 0;
            this.STPitchM12Menu.Tag = "-12";
            this.STPitchM12Menu.Text = "-12半音";
            this.STPitchM12Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM11Menu
            // 
            this.STPitchM11Menu.Index = 1;
            this.STPitchM11Menu.Tag = "-11";
            this.STPitchM11Menu.Text = "-11半音";
            this.STPitchM11Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM10Menu
            // 
            this.STPitchM10Menu.Index = 2;
            this.STPitchM10Menu.Tag = "-10";
            this.STPitchM10Menu.Text = "-10半音";
            this.STPitchM10Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM9Menu
            // 
            this.STPitchM9Menu.Index = 3;
            this.STPitchM9Menu.Tag = "-9";
            this.STPitchM9Menu.Text = "-9半音";
            this.STPitchM9Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM8Menu
            // 
            this.STPitchM8Menu.Index = 4;
            this.STPitchM8Menu.Tag = "-8";
            this.STPitchM8Menu.Text = "-8半音";
            this.STPitchM8Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM7Menu
            // 
            this.STPitchM7Menu.Index = 5;
            this.STPitchM7Menu.Tag = "-7";
            this.STPitchM7Menu.Text = "-7半音";
            this.STPitchM7Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM6Menu
            // 
            this.STPitchM6Menu.Index = 6;
            this.STPitchM6Menu.Tag = "-6";
            this.STPitchM6Menu.Text = "-6半音";
            this.STPitchM6Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM5Menu
            // 
            this.STPitchM5Menu.Index = 7;
            this.STPitchM5Menu.Tag = "-5";
            this.STPitchM5Menu.Text = "-5半音";
            this.STPitchM5Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM4Menu
            // 
            this.STPitchM4Menu.Index = 8;
            this.STPitchM4Menu.Tag = "-4";
            this.STPitchM4Menu.Text = "-4半音";
            this.STPitchM4Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM3Menu
            // 
            this.STPitchM3Menu.Index = 9;
            this.STPitchM3Menu.Tag = "-3";
            this.STPitchM3Menu.Text = "-3半音";
            this.STPitchM3Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM2Menu
            // 
            this.STPitchM2Menu.Index = 10;
            this.STPitchM2Menu.Tag = "-2";
            this.STPitchM2Menu.Text = "-2半音";
            this.STPitchM2Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM1Menu
            // 
            this.STPitchM1Menu.Index = 11;
            this.STPitchM1Menu.Tag = "-1";
            this.STPitchM1Menu.Text = "-1半音";
            this.STPitchM1Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchZeroMenu
            // 
            this.STPitchZeroMenu.Index = 12;
            this.STPitchZeroMenu.Tag = "0";
            this.STPitchZeroMenu.Text = "±0";
            this.STPitchZeroMenu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP1Menu
            // 
            this.STPitchP1Menu.Index = 13;
            this.STPitchP1Menu.Tag = "1";
            this.STPitchP1Menu.Text = "+1半音";
            this.STPitchP1Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP2Menu
            // 
            this.STPitchP2Menu.Index = 14;
            this.STPitchP2Menu.Tag = "2";
            this.STPitchP2Menu.Text = "+2半音";
            this.STPitchP2Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP3Menu
            // 
            this.STPitchP3Menu.Index = 15;
            this.STPitchP3Menu.Tag = "3";
            this.STPitchP3Menu.Text = "+3半音";
            this.STPitchP3Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP4Menu
            // 
            this.STPitchP4Menu.Index = 16;
            this.STPitchP4Menu.Tag = "4";
            this.STPitchP4Menu.Text = "+4半音";
            this.STPitchP4Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP5Menu
            // 
            this.STPitchP5Menu.Index = 17;
            this.STPitchP5Menu.Tag = "5";
            this.STPitchP5Menu.Text = "+5半音";
            this.STPitchP5Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP6Menu
            // 
            this.STPitchP6Menu.Index = 18;
            this.STPitchP6Menu.Tag = "6";
            this.STPitchP6Menu.Text = "+6半音";
            this.STPitchP6Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP7Menu
            // 
            this.STPitchP7Menu.Index = 19;
            this.STPitchP7Menu.Tag = "7";
            this.STPitchP7Menu.Text = "+7半音";
            this.STPitchP7Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP8Menu
            // 
            this.STPitchP8Menu.Index = 20;
            this.STPitchP8Menu.Tag = "8";
            this.STPitchP8Menu.Text = "+8半音";
            this.STPitchP8Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP9Menu
            // 
            this.STPitchP9Menu.Index = 21;
            this.STPitchP9Menu.Tag = "9";
            this.STPitchP9Menu.Text = "+9半音";
            this.STPitchP9Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP10Menu
            // 
            this.STPitchP10Menu.Index = 22;
            this.STPitchP10Menu.Tag = "10";
            this.STPitchP10Menu.Text = "+10半音";
            this.STPitchP10Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP11Menu
            // 
            this.STPitchP11Menu.Index = 23;
            this.STPitchP11Menu.Tag = "11";
            this.STPitchP11Menu.Text = "+11半音";
            this.STPitchP11Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP12Menu
            // 
            this.STPitchP12Menu.Index = 24;
            this.STPitchP12Menu.Tag = "12";
            this.STPitchP12Menu.Text = "+12半音";
            this.STPitchP12Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchMenuSeparator1
            // 
            this.STPitchMenuSeparator1.Index = 25;
            this.STPitchMenuSeparator1.Text = "-";
            // 
            // STPitchFixClipMenu
            // 
            this.STPitchFixClipMenu.Checked = true;
            this.STPitchFixClipMenu.Index = 26;
            this.STPitchFixClipMenu.Text = "音割れ防止";
            // 
            // PlayMenu
            // 
            this.PlayMenu.Index = 4;
            this.PlayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StopMenu,
            this.PauseOrResumeMenu,
            this.PlaybackMenu,
            this.PreviousMenu,
            this.NextMenu,
            this.RandomMenu,
            this.PlayMenuSeparator1,
            this.PlaybackOrdersMenu});
            this.PlayMenu.Text = "再生(&P)";
            // 
            // StopMenu
            // 
            this.StopMenu.Index = 0;
            this.StopMenu.Text = "停止";
            this.StopMenu.Click += new System.EventHandler(this.StopMenu_Click);
            // 
            // PauseOrResumeMenu
            // 
            this.PauseOrResumeMenu.Index = 1;
            this.PauseOrResumeMenu.Text = "一時停止/再開";
            this.PauseOrResumeMenu.Click += new System.EventHandler(this.PauseOrResumeMenu_Click);
            // 
            // PlaybackMenu
            // 
            this.PlaybackMenu.Index = 2;
            this.PlaybackMenu.Text = "再生";
            this.PlaybackMenu.Click += new System.EventHandler(this.PlayMenu_Clicked);
            // 
            // PreviousMenu
            // 
            this.PreviousMenu.Index = 3;
            this.PreviousMenu.Text = "前のトラック";
            this.PreviousMenu.Click += new System.EventHandler(this.PreviousMenu_Click);
            // 
            // NextMenu
            // 
            this.NextMenu.Index = 4;
            this.NextMenu.Text = "次のトラック";
            this.NextMenu.Click += new System.EventHandler(this.NextMenu_Click);
            // 
            // RandomMenu
            // 
            this.RandomMenu.Index = 5;
            this.RandomMenu.Text = "ランダム";
            this.RandomMenu.Click += new System.EventHandler(this.RandomMenu_Click);
            // 
            // PlayMenuSeparator1
            // 
            this.PlayMenuSeparator1.Index = 6;
            this.PlayMenuSeparator1.Text = "-";
            // 
            // PlaybackOrdersMenu
            // 
            this.PlaybackOrdersMenu.Index = 7;
            this.PlaybackOrdersMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NoRepeatMenu,
            this.PlaybackOrderMenuSeparator1,
            this.RepeatSingleTrackMenu,
            this.RepeatAllTracksMenu,
            this.RandomRepeatMenu});
            this.PlaybackOrdersMenu.Text = "再生順";
            // 
            // NoRepeatMenu
            // 
            this.NoRepeatMenu.Checked = true;
            this.NoRepeatMenu.Index = 0;
            this.NoRepeatMenu.Text = "リピートしない";
            this.NoRepeatMenu.Click += new System.EventHandler(this.NoRepeatMenu_Click);
            // 
            // PlaybackOrderMenuSeparator1
            // 
            this.PlaybackOrderMenuSeparator1.Index = 1;
            this.PlaybackOrderMenuSeparator1.Text = "-";
            // 
            // RepeatSingleTrackMenu
            // 
            this.RepeatSingleTrackMenu.Index = 2;
            this.RepeatSingleTrackMenu.Text = "単曲リピート";
            this.RepeatSingleTrackMenu.Click += new System.EventHandler(this.RepeatSingleTrackMenu_Click);
            // 
            // RepeatAllTracksMenu
            // 
            this.RepeatAllTracksMenu.Index = 3;
            this.RepeatAllTracksMenu.Text = "全曲リピート";
            this.RepeatAllTracksMenu.Click += new System.EventHandler(this.RepeatAllTracksMenu_Click);
            // 
            // RandomRepeatMenu
            // 
            this.RandomRepeatMenu.Index = 4;
            this.RandomRepeatMenu.Text = "ランダム";
            this.RandomRepeatMenu.Click += new System.EventHandler(this.RandomRepeatMenu_Click);
            // 
            // OptionMenu
            // 
            this.OptionMenu.Index = 5;
            this.OptionMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.DetailOptionsMenu,
            this.OptionMenuSeparator1,
            this.ResetAllOptionsMenu});
            this.OptionMenu.Text = "設定(&O)";
            // 
            // DetailOptionsMenu
            // 
            this.DetailOptionsMenu.Index = 0;
            this.DetailOptionsMenu.Text = "詳細設定";
            this.DetailOptionsMenu.Click += new System.EventHandler(this.DetailOptionsMenu_Click);
            // 
            // OptionMenuSeparator1
            // 
            this.OptionMenuSeparator1.Index = 1;
            this.OptionMenuSeparator1.Text = "-";
            // 
            // ResetAllOptionsMenu
            // 
            this.ResetAllOptionsMenu.Index = 2;
            this.ResetAllOptionsMenu.Text = "設定のリセット";
            this.ResetAllOptionsMenu.Click += new System.EventHandler(this.ResetAllOptionsMenu_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Index = 6;
            this.HelpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ShowReadMeMenu,
            this.ShowHistoryMenu,
            this.HelpMenuSeparator1,
            this.ShowVersionInfoMenu});
            this.HelpMenu.Text = "ヘルプ(&H)";
            // 
            // ShowReadMeMenu
            // 
            this.ShowReadMeMenu.Index = 0;
            this.ShowReadMeMenu.Text = "ReadMeを表示";
            this.ShowReadMeMenu.Click += new System.EventHandler(this.ShowReadMeMenu_Click);
            // 
            // ShowHistoryMenu
            // 
            this.ShowHistoryMenu.Index = 1;
            this.ShowHistoryMenu.Text = "更新履歴を表示";
            this.ShowHistoryMenu.Click += new System.EventHandler(this.ShowHistoryMenu_Click);
            // 
            // HelpMenuSeparator1
            // 
            this.HelpMenuSeparator1.Index = 2;
            this.HelpMenuSeparator1.Text = "-";
            // 
            // ShowVersionInfoMenu
            // 
            this.ShowVersionInfoMenu.Index = 3;
            this.ShowVersionInfoMenu.Text = "バージョン情報";
            this.ShowVersionInfoMenu.Click += new System.EventHandler(this.ShowVersionInfoMenu_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewPlaylistButton,
            this.toolStripSeparator1,
            this.OpenAnyFileButton,
            this.SaveCurrentPlaylistButton,
            this.SaveAllPlaylistsButton,
            this.toolStripSeparator2,
            this.StopButton,
            this.PlayButton,
            this.PauseOrResumeButton,
            this.PreviousButton,
            this.NextButton,
            this.toolStripSeparator4,
            this.SearchBox,
            this.QuickSearchbutton,
            this.SearchButton,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.VolumeSlider});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 7;
            // 
            // CreateNewPlaylistButton
            // 
            this.CreateNewPlaylistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateNewPlaylistButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateNewPlaylistButton.Image")));
            this.CreateNewPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateNewPlaylistButton.Name = "CreateNewPlaylistButton";
            this.CreateNewPlaylistButton.Size = new System.Drawing.Size(23, 22);
            this.CreateNewPlaylistButton.Text = "新規プレイリスト";
            this.CreateNewPlaylistButton.Click += new System.EventHandler(this.CreateNewPlaylistMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // OpenAnyFileButton
            // 
            this.OpenAnyFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenAnyFileButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenAnyFileButton.Image")));
            this.OpenAnyFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenAnyFileButton.Name = "OpenAnyFileButton";
            this.OpenAnyFileButton.Size = new System.Drawing.Size(23, 22);
            this.OpenAnyFileButton.Text = "開く";
            this.OpenAnyFileButton.Click += new System.EventHandler(this.OpenAnyFilesMenu_Click);
            // 
            // SaveCurrentPlaylistButton
            // 
            this.SaveCurrentPlaylistButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveCurrentPlaylistButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveCurrentPlaylistButton.Image")));
            this.SaveCurrentPlaylistButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveCurrentPlaylistButton.Name = "SaveCurrentPlaylistButton";
            this.SaveCurrentPlaylistButton.Size = new System.Drawing.Size(23, 22);
            this.SaveCurrentPlaylistButton.Text = "現在のプレイリストを保存";
            this.SaveCurrentPlaylistButton.Click += new System.EventHandler(this.SaveCurrentPlaylistMenu_Click);
            // 
            // SaveAllPlaylistsButton
            // 
            this.SaveAllPlaylistsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAllPlaylistsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveAllPlaylistsButton.Image")));
            this.SaveAllPlaylistsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAllPlaylistsButton.Name = "SaveAllPlaylistsButton";
            this.SaveAllPlaylistsButton.Size = new System.Drawing.Size(23, 22);
            this.SaveAllPlaylistsButton.Text = "全てのプレイリストを保存";
            this.SaveAllPlaylistsButton.Click += new System.EventHandler(this.SaveAllPlaylistsMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // StopButton
            // 
            this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StopButton.Image = global::RabbitTune.Properties.Resources.control_stop_blue;
            this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(23, 22);
            this.StopButton.Text = "停止";
            this.StopButton.Click += new System.EventHandler(this.StopMenu_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayButton.Image = global::RabbitTune.Properties.Resources.control_play_blue;
            this.PlayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(23, 22);
            this.PlayButton.Text = "再生";
            this.PlayButton.Click += new System.EventHandler(this.PlayMenu_Clicked);
            // 
            // PauseOrResumeButton
            // 
            this.PauseOrResumeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PauseOrResumeButton.Image = global::RabbitTune.Properties.Resources.control_pause_blue;
            this.PauseOrResumeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PauseOrResumeButton.Name = "PauseOrResumeButton";
            this.PauseOrResumeButton.Size = new System.Drawing.Size(23, 22);
            this.PauseOrResumeButton.Text = "一時停止/再開";
            this.PauseOrResumeButton.Click += new System.EventHandler(this.PauseOrResumeMenu_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PreviousButton.Image = global::RabbitTune.Properties.Resources.control_start_blue;
            this.PreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(23, 22);
            this.PreviousButton.Text = "前のトラック";
            this.PreviousButton.Click += new System.EventHandler(this.PreviousMenu_Click);
            // 
            // NextButton
            // 
            this.NextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NextButton.Image = global::RabbitTune.Properties.Resources.control_end_blue;
            this.NextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(23, 22);
            this.NextButton.Text = "次のトラック";
            this.NextButton.Click += new System.EventHandler(this.NextMenu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(150, 25);
            // 
            // QuickSearchbutton
            // 
            this.QuickSearchbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuickSearchbutton.Image = global::RabbitTune.Properties.Resources.zoom;
            this.QuickSearchbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuickSearchbutton.Name = "QuickSearchbutton";
            this.QuickSearchbutton.Size = new System.Drawing.Size(23, 22);
            this.QuickSearchbutton.Text = "簡易検索";
            this.QuickSearchbutton.Click += new System.EventHandler(this.QuickSearchbutton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchButton.Image = global::RabbitTune.Properties.Resources.find;
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 22);
            this.SearchButton.Text = "検索";
            this.SearchButton.Click += new System.EventHandler(this.FindAudioTrackMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::RabbitTune.Properties.Resources.cog;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "詳細設定";
            this.toolStripButton1.Click += new System.EventHandler(this.DetailOptionsMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "音量：";
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.Minimum = 0;
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Size = new System.Drawing.Size(104, 22);
            this.VolumeSlider.Text = "toolStripTraceBarItem1";
            this.VolumeSlider.Value = 80;
            this.VolumeSlider.ValueChanged += new System.EventHandler(this.VolumeSlider_ValueChanged);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(184, 42);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(550, 372);
            this.MainTabControl.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(734, 436);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.LeftSideSplitter);
            this.Controls.Add(this.LeftToolPanel);
            this.Controls.Add(this.SeekBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RabbitTune";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.LeftToolPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrackPictureViewer)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip statusStrip1;
        private HScrollBar SeekBar;
        private Panel LeftToolPanel;
        private Splitter LeftSideSplitter;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox TrackPictureViewer;
        private PlaylistBrowser PlaylistBrowser;
        private MainMenu MainMenu;
        private MenuItem FileMenu;
        private MenuItem CreateNewPlaylistMenu;
        private MenuItem FileMenuSeparator1;
        private MenuItem OpenAnyFilesMenu;
        private MenuItem FileMenuSeparator2;
        private MenuItem SaveCurrentPlaylistAsMenu;
        private MenuItem SaveCurrentPlaylistMenu;
        private MenuItem SaveAllPlaylistsMenu;
        private MenuItem FileMenuSeparator3;
        private MenuItem AddFolderToPlaylistMenu;
        private MenuItem FileMenuSeparator4;
        private MenuItem ExitApplicationMenu;
        private MenuItem EditMenu;
        private MenuItem ViewMenu;
        private MenuItem AlwaysOnTopMenu;
        private MenuItem PlayMenu;
        private MenuItem HelpMenu;
        private MenuItem StopMenu;
        private MenuItem PauseOrResumeMenu;
        private MenuItem PlaybackMenu;
        private MenuItem PreviousMenu;
        private MenuItem NextMenu;
        private MenuItem RandomMenu;
        private MenuItem PlayMenuSeparator1;
        private MenuItem PlaybackOrdersMenu;
        private MenuItem RepeatSingleTrackMenu;
        private MenuItem RepeatAllTracksMenu;
        private MenuItem RandomRepeatMenu;
        private ToolStrip toolStrip1;
        private ToolStripButton CreateNewPlaylistButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton OpenAnyFileButton;
        private ToolStripButton SaveCurrentPlaylistButton;
        private ToolStripButton SaveAllPlaylistsButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton StopButton;
        private ToolStripButton PlayButton;
        private ToolStripButton PauseOrResumeButton;
        private ToolStripButton NextButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripTextBox SearchBox;
        private ToolStripButton SearchButton;
        private ToolStripButton PreviousButton;
        private MenuItem OptionMenu;
        private MenuItem NoRepeatMenu;
        private MenuItem PlaybackOrderMenuSeparator1;
        private MenuItem menuItem2;
        private MenuItem FindAudioTrackMenu;
        private MenuItem FindAudioTrackNextMenu;
        private MenuItem ShowVersionInfoMenu;
        private MenuItem ViewMenuSeparator1;
        private MenuItem ShowLeftSideToolPanelMenu;
        private MenuItem EditMenuSeparator1;
        private MenuItem MoveUpSelectedItemMenu;
        private MenuItem MoveDownSelectedItemMenu;
        private MenuItem EditMenuSeparator2;
        private MenuItem RemoveSelectedItemFromListMenu;
        private MenuItem RemoveSelectedItemWithFileFromListMenu;
        private MenuItem RemoveAllItemsMenu;
        private MenuItem DetailOptionsMenu;
        private MenuItem OptionMenuSeparator1;
        private MenuItem ResetAllOptionsMenu;
        private MenuItem ShowReadMeMenu;
        private MenuItem ShowHistoryMenu;
        private MenuItem HelpMenuSeparator1;
        private PlaylistsTabControl MainTabControl;
        private MenuItem AudioProcessMenu;
        private MenuItem SampleRateConversionMenu;
        private ToolStripButton QuickSearchbutton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton1;
        private ToolStripSlider VolumeSlider;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel1;
        private MenuItem EqualizerMenu;
        private ToolStripStatusLabel PlayingAudioFormatStatusText;
        private ToolStripStatusLabel PlaybackPositionStatusText;
        private ToolStripStatusLabel PlayingAudioWaveFormatText;
        private MenuItem AudioProcessMenuSeparator1;
        private MenuItem PlaybackSpeedsMenu;
        private MenuItem PlaybackSpeed025Menu;
        private MenuItem PlaybackSpeed050Menu;
        private MenuItem PlaybackSpeed075Menu;
        private MenuItem PlaybackSpeed100Menu;
        private MenuItem PlaybackSpeed110Menu;
        private MenuItem PlaybackSpeed125Menu;
        private MenuItem PlaybackSpeed150Menu;
        private MenuItem PlaybackSpeed175Menu;
        private MenuItem PlaybackSpeed200Menu;
        private MenuItem PlaybackSpeed090Menu;
        private MenuItem PitchMenu;
        private MenuItem PitchM12SemitonesMenu;
        private MenuItem PitchM11SemitonesMenu;
        private MenuItem PitchM10SemitonesMenu;
        private MenuItem PitchM9SemitonesMenu;
        private MenuItem PitchM8SemitonesMenu;
        private MenuItem PitchM7SemitonesMenu;
        private MenuItem PitchM6SemitonesMenu;
        private MenuItem PitchM5SemitonesMenu;
        private MenuItem PitchM4SemitonesMenu;
        private MenuItem PitchM3SemitonesMenu;
        private MenuItem PitchM2SemitonesMenu;
        private MenuItem PitchM1SemitonesMenu;
        private MenuItem PitchPM0SemitonesMenu;
        private MenuItem PitchP1SemitonesMenu;
        private MenuItem PitchP2SemitonesMenu;
        private MenuItem PitchP3SemitonesMenu;
        private MenuItem PitchP4SemitonesMenu;
        private MenuItem PitchP5SemitonesMenu;
        private MenuItem PitchP6SemitonesMenu;
        private MenuItem PitchP7SemitonesMenu;
        private MenuItem PitchP8SemitonesMenu;
        private MenuItem PitchP9SemitonesMenu;
        private MenuItem PitchP10SemitonesMenu;
        private MenuItem PitchP11SemitonesMenu;
        private MenuItem PitchP12SemitonesMenu;
        private MenuItem PitchMenuSeparator1;
        private MenuItem FixPitchClipMenu;
        private MenuItem ShowAudioOutputInfoMenu;
        private MenuItem SoundTouchPitchMenu;
        private MenuItem STPitchM12Menu;
        private MenuItem STPitchM11Menu;
        private MenuItem STPitchM10Menu;
        private MenuItem STPitchM9Menu;
        private MenuItem STPitchM8Menu;
        private MenuItem STPitchM7Menu;
        private MenuItem STPitchM6Menu;
        private MenuItem STPitchM5Menu;
        private MenuItem STPitchM4Menu;
        private MenuItem STPitchM3Menu;
        private MenuItem STPitchM2Menu;
        private MenuItem STPitchM1Menu;
        private MenuItem STPitchZeroMenu;
        private MenuItem STPitchP1Menu;
        private MenuItem STPitchP2Menu;
        private MenuItem STPitchP3Menu;
        private MenuItem STPitchP4Menu;
        private MenuItem STPitchP5Menu;
        private MenuItem STPitchP6Menu;
        private MenuItem STPitchP7Menu;
        private MenuItem STPitchP8Menu;
        private MenuItem STPitchP9Menu;
        private MenuItem STPitchP10Menu;
        private MenuItem STPitchP11Menu;
        private MenuItem STPitchP12Menu;
        private MenuItem STPitchMenuSeparator1;
        private MenuItem STPitchFixClipMenu;
    }
}