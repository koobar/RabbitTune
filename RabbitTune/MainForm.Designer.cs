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
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.PanSlider = new RabbitTune.Controls.ToolStripSlider();
            this.ResetPanButton = new System.Windows.Forms.ToolStripButton();
            this.TaskTrayContextMenu = new System.Windows.Forms.ContextMenu();
            this.StopTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.PauseOrResumeTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.PlayTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.PreviousTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.NextTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.RandomTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.TaskTrayMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.PlaybackOrderTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.NoRepeatTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.PlaybackOrderTaskTrayMenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.RepeatSingleTrackTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.RepeatAllTracksTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.RandomRepeatTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.TaskTrayMenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.ShowAsNormalWindowTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.TaskTrayMenuSeparator3 = new System.Windows.Forms.MenuItem();
            this.ExitApplicationTaskTrayMenu = new System.Windows.Forms.MenuItem();
            this.TaskTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainContentsPanel = new System.Windows.Forms.Panel();
            this.MainTabControl = new RabbitTune.Controls.PlaylistsTabControl();
            this.LeftSideSplitter = new System.Windows.Forms.Splitter();
            this.LeftToolPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlaylistBrowser = new RabbitTune.Controls.PlaylistBrowser();
            this.TrackPictureViewer = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuSeparator3 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewPlaylistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenAnyFilesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveCurrentPlaylistAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCurrentPlaylistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAllPlaylistsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.AddFolderToPlaylistMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitApplicationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FindMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FindTrackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveUpSelectedItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveDownSelectedItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveSelectedItemFromListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectedItemWithFileFromListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveAllItemsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AlwaysOnTopMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInTaskTrayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAsMiniplayerModeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLeftSideToolPanelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAudioOutputInfoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioProcessMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SampleRateConversionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EqualizerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioProcessMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PlaybackSpeedsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed025Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed050Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed075Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed090Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed100Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed110Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed125Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed150Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed175Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackSpeed200Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM12SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM11SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM10SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM9SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM8SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM7SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM6SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM5SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM4SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM3SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM2SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchM1SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchPM0SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP1SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP2SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP3SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP4SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP5SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP6SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP7SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP8SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP9SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP10emitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP11SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchP12SemitonesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PitchMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FixPitchClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SoundTouchPitchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM12Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM11Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM10Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM9Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM8Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM7Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM6Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM5Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM4Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM3Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM2Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchM1Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchZeroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP1Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP2Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP3Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP4Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP5Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP6Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP7Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP8Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP9Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP10Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP11Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchP12Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.STPitchMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.STPitchFixClipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StopMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseOrResumeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviousMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PlaybackOrdersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NoRepeatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaybackOrderMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RepeatSingleTrackMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RepeatAllTracksMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomRepeatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailOptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ResetAllOptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowReadMeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHistoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowVersionInfoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WriteToFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MainContentsPanel.SuspendLayout();
            this.LeftToolPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackPictureViewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.SeekBar.Location = new System.Drawing.Point(0, 49);
            this.SeekBar.Maximum = 10000;
            this.SeekBar.Name = "SeekBar";
            this.SeekBar.Size = new System.Drawing.Size(734, 17);
            this.SeekBar.TabIndex = 3;
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
            this.VolumeSlider,
            this.toolStripLabel2,
            this.PanSlider,
            this.ResetPanButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
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
            this.SearchBox.Size = new System.Drawing.Size(120, 25);
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
            this.VolumeSlider.LargeChange = 1;
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.Minimum = 0;
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.Size = new System.Drawing.Size(80, 22);
            this.VolumeSlider.SmallChange = 1;
            this.VolumeSlider.Text = "toolStripTraceBarItem1";
            this.VolumeSlider.Value = 80;
            this.VolumeSlider.ValueChanged += new System.EventHandler(this.VolumeSlider_ValueChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel2.Text = "左右バランス：";
            // 
            // PanSlider
            // 
            this.PanSlider.LargeChange = 1;
            this.PanSlider.Maximum = 100;
            this.PanSlider.Minimum = -100;
            this.PanSlider.Name = "PanSlider";
            this.PanSlider.Size = new System.Drawing.Size(80, 22);
            this.PanSlider.SmallChange = 1;
            this.PanSlider.Text = "toolStripSlider1";
            this.PanSlider.Value = 0;
            this.PanSlider.ValueChanged += new System.EventHandler(this.PanSlider_ValueChanged);
            // 
            // ResetPanButton
            // 
            this.ResetPanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetPanButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetPanButton.Image")));
            this.ResetPanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetPanButton.Name = "ResetPanButton";
            this.ResetPanButton.Size = new System.Drawing.Size(45, 19);
            this.ResetPanButton.Text = "リセット";
            this.ResetPanButton.Click += new System.EventHandler(this.ResetPanButton_Click);
            // 
            // TaskTrayContextMenu
            // 
            this.TaskTrayContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StopTaskTrayMenu,
            this.PauseOrResumeTaskTrayMenu,
            this.PlayTaskTrayMenu,
            this.PreviousTaskTrayMenu,
            this.NextTaskTrayMenu,
            this.RandomTaskTrayMenu,
            this.TaskTrayMenuSeparator1,
            this.PlaybackOrderTaskTrayMenu,
            this.TaskTrayMenuSeparator2,
            this.ShowAsNormalWindowTaskTrayMenu,
            this.TaskTrayMenuSeparator3,
            this.ExitApplicationTaskTrayMenu});
            // 
            // StopTaskTrayMenu
            // 
            this.StopTaskTrayMenu.Index = 0;
            this.StopTaskTrayMenu.Text = "停止";
            this.StopTaskTrayMenu.Click += new System.EventHandler(this.StopMenu_Click);
            // 
            // PauseOrResumeTaskTrayMenu
            // 
            this.PauseOrResumeTaskTrayMenu.Index = 1;
            this.PauseOrResumeTaskTrayMenu.Text = "一時停止/再開";
            this.PauseOrResumeTaskTrayMenu.Click += new System.EventHandler(this.PauseOrResumeMenu_Click);
            // 
            // PlayTaskTrayMenu
            // 
            this.PlayTaskTrayMenu.Index = 2;
            this.PlayTaskTrayMenu.Text = "再生";
            this.PlayTaskTrayMenu.Click += new System.EventHandler(this.PlayMenu_Clicked);
            // 
            // PreviousTaskTrayMenu
            // 
            this.PreviousTaskTrayMenu.Index = 3;
            this.PreviousTaskTrayMenu.Text = "前のトラック";
            this.PreviousTaskTrayMenu.Click += new System.EventHandler(this.PreviousMenu_Click);
            // 
            // NextTaskTrayMenu
            // 
            this.NextTaskTrayMenu.Index = 4;
            this.NextTaskTrayMenu.Text = "次のトラック";
            this.NextTaskTrayMenu.Click += new System.EventHandler(this.NextMenu_Click);
            // 
            // RandomTaskTrayMenu
            // 
            this.RandomTaskTrayMenu.Index = 5;
            this.RandomTaskTrayMenu.Text = "ランダム";
            this.RandomTaskTrayMenu.Click += new System.EventHandler(this.RandomMenu_Click);
            // 
            // TaskTrayMenuSeparator1
            // 
            this.TaskTrayMenuSeparator1.Index = 6;
            this.TaskTrayMenuSeparator1.Text = "-";
            // 
            // PlaybackOrderTaskTrayMenu
            // 
            this.PlaybackOrderTaskTrayMenu.Index = 7;
            this.PlaybackOrderTaskTrayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NoRepeatTaskTrayMenu,
            this.PlaybackOrderTaskTrayMenuSeparator1,
            this.RepeatSingleTrackTaskTrayMenu,
            this.RepeatAllTracksTaskTrayMenu,
            this.RandomRepeatTaskTrayMenu});
            this.PlaybackOrderTaskTrayMenu.Text = "再生順";
            // 
            // NoRepeatTaskTrayMenu
            // 
            this.NoRepeatTaskTrayMenu.Checked = true;
            this.NoRepeatTaskTrayMenu.Index = 0;
            this.NoRepeatTaskTrayMenu.Text = "リピートしない";
            this.NoRepeatTaskTrayMenu.Click += new System.EventHandler(this.NoRepeatMenu_Click);
            // 
            // PlaybackOrderTaskTrayMenuSeparator1
            // 
            this.PlaybackOrderTaskTrayMenuSeparator1.Index = 1;
            this.PlaybackOrderTaskTrayMenuSeparator1.Text = "-";
            // 
            // RepeatSingleTrackTaskTrayMenu
            // 
            this.RepeatSingleTrackTaskTrayMenu.Index = 2;
            this.RepeatSingleTrackTaskTrayMenu.Text = "単曲リピート";
            this.RepeatSingleTrackTaskTrayMenu.Click += new System.EventHandler(this.RepeatSingleTrackMenu_Click);
            // 
            // RepeatAllTracksTaskTrayMenu
            // 
            this.RepeatAllTracksTaskTrayMenu.Index = 3;
            this.RepeatAllTracksTaskTrayMenu.Text = "全曲リピート";
            this.RepeatAllTracksTaskTrayMenu.Click += new System.EventHandler(this.RepeatAllTracksMenu_Click);
            // 
            // RandomRepeatTaskTrayMenu
            // 
            this.RandomRepeatTaskTrayMenu.Index = 4;
            this.RandomRepeatTaskTrayMenu.Text = "ランダム";
            this.RandomRepeatTaskTrayMenu.Click += new System.EventHandler(this.RandomRepeatMenu_Click);
            // 
            // TaskTrayMenuSeparator2
            // 
            this.TaskTrayMenuSeparator2.Index = 8;
            this.TaskTrayMenuSeparator2.Text = "-";
            // 
            // ShowAsNormalWindowTaskTrayMenu
            // 
            this.ShowAsNormalWindowTaskTrayMenu.Index = 9;
            this.ShowAsNormalWindowTaskTrayMenu.Text = "ウィンドウを表示(&W)";
            this.ShowAsNormalWindowTaskTrayMenu.Click += new System.EventHandler(this.ShowAsNormalWindowTaskTrayMenu_Click);
            // 
            // TaskTrayMenuSeparator3
            // 
            this.TaskTrayMenuSeparator3.Index = 10;
            this.TaskTrayMenuSeparator3.Text = "-";
            // 
            // ExitApplicationTaskTrayMenu
            // 
            this.ExitApplicationTaskTrayMenu.Index = 11;
            this.ExitApplicationTaskTrayMenu.Text = "終了(&X)";
            this.ExitApplicationTaskTrayMenu.Click += new System.EventHandler(this.ExitApplicationMenu_Click);
            // 
            // TaskTrayNotifyIcon
            // 
            this.TaskTrayNotifyIcon.Visible = true;
            // 
            // MainContentsPanel
            // 
            this.MainContentsPanel.Controls.Add(this.MainTabControl);
            this.MainContentsPanel.Controls.Add(this.LeftSideSplitter);
            this.MainContentsPanel.Controls.Add(this.LeftToolPanel);
            this.MainContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContentsPanel.Location = new System.Drawing.Point(0, 66);
            this.MainContentsPanel.Name = "MainContentsPanel";
            this.MainContentsPanel.Size = new System.Drawing.Size(734, 348);
            this.MainContentsPanel.TabIndex = 12;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(184, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(550, 348);
            this.MainTabControl.TabIndex = 12;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // LeftSideSplitter
            // 
            this.LeftSideSplitter.Location = new System.Drawing.Point(180, 0);
            this.LeftSideSplitter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LeftSideSplitter.Name = "LeftSideSplitter";
            this.LeftSideSplitter.Size = new System.Drawing.Size(4, 348);
            this.LeftSideSplitter.TabIndex = 6;
            this.LeftSideSplitter.TabStop = false;
            // 
            // LeftToolPanel
            // 
            this.LeftToolPanel.Controls.Add(this.tableLayoutPanel1);
            this.LeftToolPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LeftToolPanel.Name = "LeftToolPanel";
            this.LeftToolPanel.Size = new System.Drawing.Size(180, 348);
            this.LeftToolPanel.TabIndex = 5;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 348);
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
            this.PlaylistBrowser.Size = new System.Drawing.Size(172, 339);
            this.PlaylistBrowser.TabIndex = 4;
            this.PlaylistBrowser.PlaylistOpenRequested += new System.EventHandler(this.PlaylistBrowser_PlaylistOpenRequested);
            // 
            // TrackPictureViewer
            // 
            this.TrackPictureViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackPictureViewer.Location = new System.Drawing.Point(4, 345);
            this.TrackPictureViewer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.TrackPictureViewer.Name = "TrackPictureViewer";
            this.TrackPictureViewer.Size = new System.Drawing.Size(172, 1);
            this.TrackPictureViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrackPictureViewer.TabIndex = 3;
            this.TrackPictureViewer.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuSeparator3,
            this.EditMenu,
            this.ViewMenu,
            this.AudioProcessMenu,
            this.PlayMenu,
            this.OptionsMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuSeparator3
            // 
            this.FileMenuSeparator3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewPlaylistMenu,
            this.FileMenuSeparator1,
            this.OpenAnyFilesMenu,
            this.OpenFolderMenu,
            this.FileMenuSeparator2,
            this.SaveCurrentPlaylistAsMenu,
            this.SaveCurrentPlaylistMenu,
            this.SaveAllPlaylistsMenu,
            this.toolStripMenuItem3,
            this.AddFolderToPlaylistMenu,
            this.FileMenuSeparator4,
            this.WriteToFileMenu,
            this.toolStripSeparator6,
            this.ExitApplicationMenu});
            this.FileMenuSeparator3.Name = "FileMenuSeparator3";
            this.FileMenuSeparator3.Size = new System.Drawing.Size(67, 20);
            this.FileMenuSeparator3.Text = "ファイル(&F)";
            // 
            // CreateNewPlaylistMenu
            // 
            this.CreateNewPlaylistMenu.Image = global::RabbitTune.Properties.Resources.page_white_star;
            this.CreateNewPlaylistMenu.Name = "CreateNewPlaylistMenu";
            this.CreateNewPlaylistMenu.Size = new System.Drawing.Size(256, 22);
            this.CreateNewPlaylistMenu.Text = "新規プレイリスト(&N)";
            this.CreateNewPlaylistMenu.Click += new System.EventHandler(this.CreateNewPlaylistMenu_Click);
            // 
            // FileMenuSeparator1
            // 
            this.FileMenuSeparator1.Name = "FileMenuSeparator1";
            this.FileMenuSeparator1.Size = new System.Drawing.Size(253, 6);
            // 
            // OpenAnyFilesMenu
            // 
            this.OpenAnyFilesMenu.Image = global::RabbitTune.Properties.Resources.folder_page;
            this.OpenAnyFilesMenu.Name = "OpenAnyFilesMenu";
            this.OpenAnyFilesMenu.Size = new System.Drawing.Size(256, 22);
            this.OpenAnyFilesMenu.Text = "開く(&O)...";
            this.OpenAnyFilesMenu.Click += new System.EventHandler(this.OpenAnyFilesMenu_Click);
            // 
            // OpenFolderMenu
            // 
            this.OpenFolderMenu.Name = "OpenFolderMenu";
            this.OpenFolderMenu.Size = new System.Drawing.Size(256, 22);
            this.OpenFolderMenu.Text = "フォルダを指定して開く...";
            this.OpenFolderMenu.Click += new System.EventHandler(this.OpenFolderMenu_Click);
            // 
            // FileMenuSeparator2
            // 
            this.FileMenuSeparator2.Name = "FileMenuSeparator2";
            this.FileMenuSeparator2.Size = new System.Drawing.Size(253, 6);
            // 
            // SaveCurrentPlaylistAsMenu
            // 
            this.SaveCurrentPlaylistAsMenu.Name = "SaveCurrentPlaylistAsMenu";
            this.SaveCurrentPlaylistAsMenu.Size = new System.Drawing.Size(256, 22);
            this.SaveCurrentPlaylistAsMenu.Text = "名前を付けて現在のプレイリストを保存";
            this.SaveCurrentPlaylistAsMenu.Click += new System.EventHandler(this.SaveCurrentPlaylistAsMenu_Click);
            // 
            // SaveCurrentPlaylistMenu
            // 
            this.SaveCurrentPlaylistMenu.Image = global::RabbitTune.Properties.Resources.disk;
            this.SaveCurrentPlaylistMenu.Name = "SaveCurrentPlaylistMenu";
            this.SaveCurrentPlaylistMenu.Size = new System.Drawing.Size(256, 22);
            this.SaveCurrentPlaylistMenu.Text = "現在のプレイリストを上書き保存";
            this.SaveCurrentPlaylistMenu.Click += new System.EventHandler(this.SaveCurrentPlaylistMenu_Click);
            // 
            // SaveAllPlaylistsMenu
            // 
            this.SaveAllPlaylistsMenu.Image = global::RabbitTune.Properties.Resources.disk_multiple;
            this.SaveAllPlaylistsMenu.Name = "SaveAllPlaylistsMenu";
            this.SaveAllPlaylistsMenu.Size = new System.Drawing.Size(256, 22);
            this.SaveAllPlaylistsMenu.Text = "すべてのプレイリストを保存";
            this.SaveAllPlaylistsMenu.Click += new System.EventHandler(this.SaveAllPlaylistsMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(253, 6);
            // 
            // AddFolderToPlaylistMenu
            // 
            this.AddFolderToPlaylistMenu.Name = "AddFolderToPlaylistMenu";
            this.AddFolderToPlaylistMenu.Size = new System.Drawing.Size(256, 22);
            this.AddFolderToPlaylistMenu.Text = "プレイリストにフォルダを追加";
            this.AddFolderToPlaylistMenu.Click += new System.EventHandler(this.AddFolderToPlaylistMenu_Click);
            // 
            // FileMenuSeparator4
            // 
            this.FileMenuSeparator4.Name = "FileMenuSeparator4";
            this.FileMenuSeparator4.Size = new System.Drawing.Size(253, 6);
            // 
            // ExitApplicationMenu
            // 
            this.ExitApplicationMenu.Name = "ExitApplicationMenu";
            this.ExitApplicationMenu.Size = new System.Drawing.Size(256, 22);
            this.ExitApplicationMenu.Text = "閉じる(&X)";
            this.ExitApplicationMenu.Click += new System.EventHandler(this.ExitApplicationMenu_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindMenu,
            this.EditMenuSeparator1,
            this.MoveUpSelectedItemMenu,
            this.MoveDownSelectedItemMenu,
            this.EditMenuSeparator2,
            this.RemoveSelectedItemFromListMenu,
            this.RemoveSelectedItemWithFileFromListMenu,
            this.RemoveAllItemsMenu});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(57, 20);
            this.EditMenu.Text = "編集(&E)";
            // 
            // FindMenu
            // 
            this.FindMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindTrackMenu,
            this.FindNextMenu});
            this.FindMenu.Name = "FindMenu";
            this.FindMenu.Size = new System.Drawing.Size(271, 22);
            this.FindMenu.Text = "検索";
            // 
            // FindTrackMenu
            // 
            this.FindTrackMenu.Image = global::RabbitTune.Properties.Resources.find;
            this.FindTrackMenu.Name = "FindTrackMenu";
            this.FindTrackMenu.Size = new System.Drawing.Size(155, 22);
            this.FindTrackMenu.Text = "トラックの検索(&F)";
            this.FindTrackMenu.Click += new System.EventHandler(this.FindAudioTrackMenu_Click);
            // 
            // FindNextMenu
            // 
            this.FindNextMenu.Name = "FindNextMenu";
            this.FindNextMenu.Size = new System.Drawing.Size(155, 22);
            this.FindNextMenu.Text = "次を検索";
            this.FindNextMenu.Click += new System.EventHandler(this.FindAudioTrackNextMenu_Click);
            // 
            // EditMenuSeparator1
            // 
            this.EditMenuSeparator1.Name = "EditMenuSeparator1";
            this.EditMenuSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // MoveUpSelectedItemMenu
            // 
            this.MoveUpSelectedItemMenu.Name = "MoveUpSelectedItemMenu";
            this.MoveUpSelectedItemMenu.Size = new System.Drawing.Size(271, 22);
            this.MoveUpSelectedItemMenu.Text = "選択中のトラックを上に移動";
            this.MoveUpSelectedItemMenu.Click += new System.EventHandler(this.MoveUpSelectedItemMenu_Click);
            // 
            // MoveDownSelectedItemMenu
            // 
            this.MoveDownSelectedItemMenu.Name = "MoveDownSelectedItemMenu";
            this.MoveDownSelectedItemMenu.Size = new System.Drawing.Size(271, 22);
            this.MoveDownSelectedItemMenu.Text = "選択中のトラックを下に移動";
            this.MoveDownSelectedItemMenu.Click += new System.EventHandler(this.MoveDownSelectedItemMenu_Click);
            // 
            // EditMenuSeparator2
            // 
            this.EditMenuSeparator2.Name = "EditMenuSeparator2";
            this.EditMenuSeparator2.Size = new System.Drawing.Size(268, 6);
            // 
            // RemoveSelectedItemFromListMenu
            // 
            this.RemoveSelectedItemFromListMenu.Name = "RemoveSelectedItemFromListMenu";
            this.RemoveSelectedItemFromListMenu.Size = new System.Drawing.Size(271, 22);
            this.RemoveSelectedItemFromListMenu.Text = "選択中のトラックをプレイリストから削除";
            this.RemoveSelectedItemFromListMenu.Click += new System.EventHandler(this.RemoveSelectedItemFromListMenu_Click);
            // 
            // RemoveSelectedItemWithFileFromListMenu
            // 
            this.RemoveSelectedItemWithFileFromListMenu.Name = "RemoveSelectedItemWithFileFromListMenu";
            this.RemoveSelectedItemWithFileFromListMenu.Size = new System.Drawing.Size(271, 22);
            this.RemoveSelectedItemWithFileFromListMenu.Text = "選択中のトラックをファイルごと削除";
            this.RemoveSelectedItemWithFileFromListMenu.Click += new System.EventHandler(this.RemoveSelectedItemWithFileFromListMenu_Click);
            // 
            // RemoveAllItemsMenu
            // 
            this.RemoveAllItemsMenu.Name = "RemoveAllItemsMenu";
            this.RemoveAllItemsMenu.Size = new System.Drawing.Size(271, 22);
            this.RemoveAllItemsMenu.Text = "プレイリストに含まれるトラックをすべて削除";
            this.RemoveAllItemsMenu.Click += new System.EventHandler(this.RemoveAllItemsMenu_Click);
            // 
            // ViewMenu
            // 
            this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlwaysOnTopMenu,
            this.ShowInTaskTrayMenu,
            this.ShowAsMiniplayerModeMenu,
            this.ViewMenuSeparator1,
            this.ShowLeftSideToolPanelMenu,
            this.ShowAudioOutputInfoMenu});
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(58, 20);
            this.ViewMenu.Text = "表示(&V)";
            // 
            // AlwaysOnTopMenu
            // 
            this.AlwaysOnTopMenu.Name = "AlwaysOnTopMenu";
            this.AlwaysOnTopMenu.Size = new System.Drawing.Size(198, 22);
            this.AlwaysOnTopMenu.Text = "常に最前面に表示";
            this.AlwaysOnTopMenu.Click += new System.EventHandler(this.AlwaysOnTopMenu_Click);
            // 
            // ShowInTaskTrayMenu
            // 
            this.ShowInTaskTrayMenu.Name = "ShowInTaskTrayMenu";
            this.ShowInTaskTrayMenu.Size = new System.Drawing.Size(198, 22);
            this.ShowInTaskTrayMenu.Text = "タスクトレイに格納";
            this.ShowInTaskTrayMenu.Click += new System.EventHandler(this.ShowInTaskTrayMenu_Click);
            // 
            // ShowAsMiniplayerModeMenu
            // 
            this.ShowAsMiniplayerModeMenu.Name = "ShowAsMiniplayerModeMenu";
            this.ShowAsMiniplayerModeMenu.Size = new System.Drawing.Size(198, 22);
            this.ShowAsMiniplayerModeMenu.Text = "ミニプレーヤーモード";
            this.ShowAsMiniplayerModeMenu.Click += new System.EventHandler(this.ShowAsMiniplayerModeMenu_Click);
            // 
            // ViewMenuSeparator1
            // 
            this.ViewMenuSeparator1.Name = "ViewMenuSeparator1";
            this.ViewMenuSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // ShowLeftSideToolPanelMenu
            // 
            this.ShowLeftSideToolPanelMenu.Checked = true;
            this.ShowLeftSideToolPanelMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowLeftSideToolPanelMenu.Name = "ShowLeftSideToolPanelMenu";
            this.ShowLeftSideToolPanelMenu.Size = new System.Drawing.Size(198, 22);
            this.ShowLeftSideToolPanelMenu.Text = "左側のツールパネルを表示";
            this.ShowLeftSideToolPanelMenu.Click += new System.EventHandler(this.ShowLeftSideToolPanelMenu_Click);
            // 
            // ShowAudioOutputInfoMenu
            // 
            this.ShowAudioOutputInfoMenu.Name = "ShowAudioOutputInfoMenu";
            this.ShowAudioOutputInfoMenu.Size = new System.Drawing.Size(198, 22);
            this.ShowAudioOutputInfoMenu.Text = "オーディオの詳細情報";
            this.ShowAudioOutputInfoMenu.Click += new System.EventHandler(this.ShowAudioOutputInfoMenu_Click);
            // 
            // AudioProcessMenu
            // 
            this.AudioProcessMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SampleRateConversionMenu,
            this.EqualizerMenu,
            this.AudioProcessMenuSeparator1,
            this.PlaybackSpeedsMenu,
            this.PitchMenu,
            this.SoundTouchPitchMenu});
            this.AudioProcessMenu.Name = "AudioProcessMenu";
            this.AudioProcessMenu.Size = new System.Drawing.Size(59, 20);
            this.AudioProcessMenu.Text = "音響(&A)";
            // 
            // SampleRateConversionMenu
            // 
            this.SampleRateConversionMenu.Name = "SampleRateConversionMenu";
            this.SampleRateConversionMenu.Size = new System.Drawing.Size(198, 22);
            this.SampleRateConversionMenu.Text = "サンプリング周波数変換";
            this.SampleRateConversionMenu.Click += new System.EventHandler(this.SampleRateConversionMenu_Click);
            // 
            // EqualizerMenu
            // 
            this.EqualizerMenu.Name = "EqualizerMenu";
            this.EqualizerMenu.Size = new System.Drawing.Size(198, 22);
            this.EqualizerMenu.Text = "イコライザ(&E)";
            this.EqualizerMenu.Click += new System.EventHandler(this.EqualizerMenu_Click);
            // 
            // AudioProcessMenuSeparator1
            // 
            this.AudioProcessMenuSeparator1.Name = "AudioProcessMenuSeparator1";
            this.AudioProcessMenuSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // PlaybackSpeedsMenu
            // 
            this.PlaybackSpeedsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.PlaybackSpeedsMenu.Name = "PlaybackSpeedsMenu";
            this.PlaybackSpeedsMenu.Size = new System.Drawing.Size(198, 22);
            this.PlaybackSpeedsMenu.Text = "再生速度(&S)";
            // 
            // PlaybackSpeed025Menu
            // 
            this.PlaybackSpeed025Menu.Name = "PlaybackSpeed025Menu";
            this.PlaybackSpeed025Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed025Menu.Tag = "0.25";
            this.PlaybackSpeed025Menu.Text = "0.25倍速";
            this.PlaybackSpeed025Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed050Menu
            // 
            this.PlaybackSpeed050Menu.Name = "PlaybackSpeed050Menu";
            this.PlaybackSpeed050Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed050Menu.Tag = "0.50";
            this.PlaybackSpeed050Menu.Text = "0.50倍速";
            this.PlaybackSpeed050Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed075Menu
            // 
            this.PlaybackSpeed075Menu.Name = "PlaybackSpeed075Menu";
            this.PlaybackSpeed075Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed075Menu.Tag = "0.75";
            this.PlaybackSpeed075Menu.Text = "0.75倍速";
            this.PlaybackSpeed075Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed090Menu
            // 
            this.PlaybackSpeed090Menu.Name = "PlaybackSpeed090Menu";
            this.PlaybackSpeed090Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed090Menu.Tag = "0.90";
            this.PlaybackSpeed090Menu.Text = "0.90倍速";
            this.PlaybackSpeed090Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed100Menu
            // 
            this.PlaybackSpeed100Menu.Name = "PlaybackSpeed100Menu";
            this.PlaybackSpeed100Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed100Menu.Tag = "1.00";
            this.PlaybackSpeed100Menu.Text = "1.00倍速";
            this.PlaybackSpeed100Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed110Menu
            // 
            this.PlaybackSpeed110Menu.Name = "PlaybackSpeed110Menu";
            this.PlaybackSpeed110Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed110Menu.Tag = "1.10";
            this.PlaybackSpeed110Menu.Text = "1.10倍速";
            this.PlaybackSpeed110Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed125Menu
            // 
            this.PlaybackSpeed125Menu.Name = "PlaybackSpeed125Menu";
            this.PlaybackSpeed125Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed125Menu.Tag = "1.25";
            this.PlaybackSpeed125Menu.Text = "1.25倍速";
            this.PlaybackSpeed125Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed150Menu
            // 
            this.PlaybackSpeed150Menu.Name = "PlaybackSpeed150Menu";
            this.PlaybackSpeed150Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed150Menu.Tag = "1.50";
            this.PlaybackSpeed150Menu.Text = "1.50倍速";
            this.PlaybackSpeed150Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed175Menu
            // 
            this.PlaybackSpeed175Menu.Name = "PlaybackSpeed175Menu";
            this.PlaybackSpeed175Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed175Menu.Tag = "1.75";
            this.PlaybackSpeed175Menu.Text = "1.75倍速";
            this.PlaybackSpeed175Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PlaybackSpeed200Menu
            // 
            this.PlaybackSpeed200Menu.Name = "PlaybackSpeed200Menu";
            this.PlaybackSpeed200Menu.Size = new System.Drawing.Size(119, 22);
            this.PlaybackSpeed200Menu.Tag = "2.00";
            this.PlaybackSpeed200Menu.Text = "2.00倍速";
            this.PlaybackSpeed200Menu.Click += new System.EventHandler(this.PlaybackSpeedMenu_Click);
            // 
            // PitchMenu
            // 
            this.PitchMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.PitchP10emitonesMenu,
            this.PitchP11SemitonesMenu,
            this.PitchP12SemitonesMenu,
            this.PitchMenuSeparator1,
            this.FixPitchClipMenu});
            this.PitchMenu.Name = "PitchMenu";
            this.PitchMenu.Size = new System.Drawing.Size(198, 22);
            this.PitchMenu.Text = "ピッチ調整";
            // 
            // PitchM12SemitonesMenu
            // 
            this.PitchM12SemitonesMenu.Name = "PitchM12SemitonesMenu";
            this.PitchM12SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM12SemitonesMenu.Tag = "-12";
            this.PitchM12SemitonesMenu.Text = "-12半音";
            this.PitchM12SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM11SemitonesMenu
            // 
            this.PitchM11SemitonesMenu.Name = "PitchM11SemitonesMenu";
            this.PitchM11SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM11SemitonesMenu.Tag = "-11";
            this.PitchM11SemitonesMenu.Text = "-11半音";
            this.PitchM11SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM10SemitonesMenu
            // 
            this.PitchM10SemitonesMenu.Name = "PitchM10SemitonesMenu";
            this.PitchM10SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM10SemitonesMenu.Tag = "-10";
            this.PitchM10SemitonesMenu.Text = "-10半音";
            this.PitchM10SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM9SemitonesMenu
            // 
            this.PitchM9SemitonesMenu.Name = "PitchM9SemitonesMenu";
            this.PitchM9SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM9SemitonesMenu.Tag = "-9";
            this.PitchM9SemitonesMenu.Text = "-9半音";
            this.PitchM9SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM8SemitonesMenu
            // 
            this.PitchM8SemitonesMenu.Name = "PitchM8SemitonesMenu";
            this.PitchM8SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM8SemitonesMenu.Tag = "-8";
            this.PitchM8SemitonesMenu.Text = "-8半音";
            this.PitchM8SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM7SemitonesMenu
            // 
            this.PitchM7SemitonesMenu.Name = "PitchM7SemitonesMenu";
            this.PitchM7SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM7SemitonesMenu.Tag = "-7";
            this.PitchM7SemitonesMenu.Text = "-7半音";
            this.PitchM7SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM6SemitonesMenu
            // 
            this.PitchM6SemitonesMenu.Name = "PitchM6SemitonesMenu";
            this.PitchM6SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM6SemitonesMenu.Tag = "-6";
            this.PitchM6SemitonesMenu.Text = "-6半音";
            this.PitchM6SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM5SemitonesMenu
            // 
            this.PitchM5SemitonesMenu.Name = "PitchM5SemitonesMenu";
            this.PitchM5SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM5SemitonesMenu.Tag = "-5";
            this.PitchM5SemitonesMenu.Text = "-5半音";
            this.PitchM5SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM4SemitonesMenu
            // 
            this.PitchM4SemitonesMenu.Name = "PitchM4SemitonesMenu";
            this.PitchM4SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM4SemitonesMenu.Tag = "-4";
            this.PitchM4SemitonesMenu.Text = "-4半音";
            this.PitchM4SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM3SemitonesMenu
            // 
            this.PitchM3SemitonesMenu.Name = "PitchM3SemitonesMenu";
            this.PitchM3SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM3SemitonesMenu.Tag = "-3";
            this.PitchM3SemitonesMenu.Text = "-3半音";
            this.PitchM3SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM2SemitonesMenu
            // 
            this.PitchM2SemitonesMenu.Name = "PitchM2SemitonesMenu";
            this.PitchM2SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM2SemitonesMenu.Tag = "-2";
            this.PitchM2SemitonesMenu.Text = "-2半音";
            this.PitchM2SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchM1SemitonesMenu
            // 
            this.PitchM1SemitonesMenu.Name = "PitchM1SemitonesMenu";
            this.PitchM1SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchM1SemitonesMenu.Tag = "-1";
            this.PitchM1SemitonesMenu.Text = "-1半音";
            this.PitchM1SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchPM0SemitonesMenu
            // 
            this.PitchPM0SemitonesMenu.Name = "PitchPM0SemitonesMenu";
            this.PitchPM0SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchPM0SemitonesMenu.Tag = "0";
            this.PitchPM0SemitonesMenu.Text = "±0";
            this.PitchPM0SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP1SemitonesMenu
            // 
            this.PitchP1SemitonesMenu.Name = "PitchP1SemitonesMenu";
            this.PitchP1SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP1SemitonesMenu.Tag = "1";
            this.PitchP1SemitonesMenu.Text = "+1半音";
            this.PitchP1SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP2SemitonesMenu
            // 
            this.PitchP2SemitonesMenu.Name = "PitchP2SemitonesMenu";
            this.PitchP2SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP2SemitonesMenu.Tag = "2";
            this.PitchP2SemitonesMenu.Text = "+2半音";
            this.PitchP2SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP3SemitonesMenu
            // 
            this.PitchP3SemitonesMenu.Name = "PitchP3SemitonesMenu";
            this.PitchP3SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP3SemitonesMenu.Tag = "3";
            this.PitchP3SemitonesMenu.Text = "+3半音";
            this.PitchP3SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP4SemitonesMenu
            // 
            this.PitchP4SemitonesMenu.Name = "PitchP4SemitonesMenu";
            this.PitchP4SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP4SemitonesMenu.Tag = "4";
            this.PitchP4SemitonesMenu.Text = "+4半音";
            this.PitchP4SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP5SemitonesMenu
            // 
            this.PitchP5SemitonesMenu.Name = "PitchP5SemitonesMenu";
            this.PitchP5SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP5SemitonesMenu.Tag = "5";
            this.PitchP5SemitonesMenu.Text = "+5半音";
            this.PitchP5SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP6SemitonesMenu
            // 
            this.PitchP6SemitonesMenu.Name = "PitchP6SemitonesMenu";
            this.PitchP6SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP6SemitonesMenu.Tag = "6";
            this.PitchP6SemitonesMenu.Text = "+6半音";
            this.PitchP6SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP7SemitonesMenu
            // 
            this.PitchP7SemitonesMenu.Name = "PitchP7SemitonesMenu";
            this.PitchP7SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP7SemitonesMenu.Tag = "7";
            this.PitchP7SemitonesMenu.Text = "+7半音";
            this.PitchP7SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP8SemitonesMenu
            // 
            this.PitchP8SemitonesMenu.Name = "PitchP8SemitonesMenu";
            this.PitchP8SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP8SemitonesMenu.Tag = "8";
            this.PitchP8SemitonesMenu.Text = "+8半音";
            this.PitchP8SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP9SemitonesMenu
            // 
            this.PitchP9SemitonesMenu.Name = "PitchP9SemitonesMenu";
            this.PitchP9SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP9SemitonesMenu.Tag = "9";
            this.PitchP9SemitonesMenu.Text = "+9半音";
            this.PitchP9SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP10emitonesMenu
            // 
            this.PitchP10emitonesMenu.Name = "PitchP10emitonesMenu";
            this.PitchP10emitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP10emitonesMenu.Tag = "10";
            this.PitchP10emitonesMenu.Text = "+10半音";
            this.PitchP10emitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP11SemitonesMenu
            // 
            this.PitchP11SemitonesMenu.Name = "PitchP11SemitonesMenu";
            this.PitchP11SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP11SemitonesMenu.Tag = "11";
            this.PitchP11SemitonesMenu.Text = "+11半音";
            this.PitchP11SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchP12SemitonesMenu
            // 
            this.PitchP12SemitonesMenu.Name = "PitchP12SemitonesMenu";
            this.PitchP12SemitonesMenu.Size = new System.Drawing.Size(133, 22);
            this.PitchP12SemitonesMenu.Tag = "12";
            this.PitchP12SemitonesMenu.Text = "+12半音";
            this.PitchP12SemitonesMenu.Click += new System.EventHandler(this.PitchMenu_Click);
            // 
            // PitchMenuSeparator1
            // 
            this.PitchMenuSeparator1.Name = "PitchMenuSeparator1";
            this.PitchMenuSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // FixPitchClipMenu
            // 
            this.FixPitchClipMenu.Checked = true;
            this.FixPitchClipMenu.CheckOnClick = true;
            this.FixPitchClipMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixPitchClipMenu.Name = "FixPitchClipMenu";
            this.FixPitchClipMenu.Size = new System.Drawing.Size(133, 22);
            this.FixPitchClipMenu.Text = "音割れ防止";
            this.FixPitchClipMenu.CheckedChanged += new System.EventHandler(this.FixPitchClipMenu_CheckedChanged);
            // 
            // SoundTouchPitchMenu
            // 
            this.SoundTouchPitchMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.SoundTouchPitchMenu.Name = "SoundTouchPitchMenu";
            this.SoundTouchPitchMenu.Size = new System.Drawing.Size(198, 22);
            this.SoundTouchPitchMenu.Text = "ピッチ調整(SoundTouch)";
            // 
            // STPitchM12Menu
            // 
            this.STPitchM12Menu.Name = "STPitchM12Menu";
            this.STPitchM12Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM12Menu.Tag = "-12";
            this.STPitchM12Menu.Text = "-12半音";
            this.STPitchM12Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM11Menu
            // 
            this.STPitchM11Menu.Name = "STPitchM11Menu";
            this.STPitchM11Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM11Menu.Tag = "-11";
            this.STPitchM11Menu.Text = "-11半音";
            this.STPitchM11Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM10Menu
            // 
            this.STPitchM10Menu.Name = "STPitchM10Menu";
            this.STPitchM10Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM10Menu.Tag = "-10";
            this.STPitchM10Menu.Text = "-10半音";
            this.STPitchM10Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM9Menu
            // 
            this.STPitchM9Menu.Name = "STPitchM9Menu";
            this.STPitchM9Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM9Menu.Tag = "-8";
            this.STPitchM9Menu.Text = "-9半音";
            this.STPitchM9Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM8Menu
            // 
            this.STPitchM8Menu.Name = "STPitchM8Menu";
            this.STPitchM8Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM8Menu.Tag = "-8";
            this.STPitchM8Menu.Text = "-8半音";
            this.STPitchM8Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM7Menu
            // 
            this.STPitchM7Menu.Name = "STPitchM7Menu";
            this.STPitchM7Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM7Menu.Tag = "-7";
            this.STPitchM7Menu.Text = "-7半音";
            this.STPitchM7Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM6Menu
            // 
            this.STPitchM6Menu.Name = "STPitchM6Menu";
            this.STPitchM6Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM6Menu.Tag = "-6";
            this.STPitchM6Menu.Text = "-6半音";
            this.STPitchM6Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM5Menu
            // 
            this.STPitchM5Menu.Name = "STPitchM5Menu";
            this.STPitchM5Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM5Menu.Tag = "-5";
            this.STPitchM5Menu.Text = "-5半音";
            this.STPitchM5Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM4Menu
            // 
            this.STPitchM4Menu.Name = "STPitchM4Menu";
            this.STPitchM4Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM4Menu.Tag = "-4";
            this.STPitchM4Menu.Text = "-4半音";
            this.STPitchM4Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM3Menu
            // 
            this.STPitchM3Menu.Name = "STPitchM3Menu";
            this.STPitchM3Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM3Menu.Tag = "-3";
            this.STPitchM3Menu.Text = "-3半音";
            this.STPitchM3Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM2Menu
            // 
            this.STPitchM2Menu.Name = "STPitchM2Menu";
            this.STPitchM2Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM2Menu.Tag = "-2";
            this.STPitchM2Menu.Text = "-2半音";
            this.STPitchM2Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchM1Menu
            // 
            this.STPitchM1Menu.Name = "STPitchM1Menu";
            this.STPitchM1Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchM1Menu.Tag = "-1";
            this.STPitchM1Menu.Text = "-1半音";
            this.STPitchM1Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchZeroMenu
            // 
            this.STPitchZeroMenu.Name = "STPitchZeroMenu";
            this.STPitchZeroMenu.Size = new System.Drawing.Size(133, 22);
            this.STPitchZeroMenu.Tag = "0";
            this.STPitchZeroMenu.Text = "±0";
            this.STPitchZeroMenu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP1Menu
            // 
            this.STPitchP1Menu.Name = "STPitchP1Menu";
            this.STPitchP1Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP1Menu.Tag = "1";
            this.STPitchP1Menu.Text = "+1半音";
            this.STPitchP1Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP2Menu
            // 
            this.STPitchP2Menu.Name = "STPitchP2Menu";
            this.STPitchP2Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP2Menu.Tag = "2";
            this.STPitchP2Menu.Text = "+2半音";
            this.STPitchP2Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP3Menu
            // 
            this.STPitchP3Menu.Name = "STPitchP3Menu";
            this.STPitchP3Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP3Menu.Tag = "3";
            this.STPitchP3Menu.Text = "+3半音";
            this.STPitchP3Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP4Menu
            // 
            this.STPitchP4Menu.Name = "STPitchP4Menu";
            this.STPitchP4Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP4Menu.Tag = "4";
            this.STPitchP4Menu.Text = "+4半音";
            this.STPitchP4Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP5Menu
            // 
            this.STPitchP5Menu.Name = "STPitchP5Menu";
            this.STPitchP5Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP5Menu.Tag = "5";
            this.STPitchP5Menu.Text = "+5半音";
            this.STPitchP5Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP6Menu
            // 
            this.STPitchP6Menu.Name = "STPitchP6Menu";
            this.STPitchP6Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP6Menu.Tag = "6";
            this.STPitchP6Menu.Text = "+6半音";
            this.STPitchP6Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP7Menu
            // 
            this.STPitchP7Menu.Name = "STPitchP7Menu";
            this.STPitchP7Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP7Menu.Tag = "7";
            this.STPitchP7Menu.Text = "+7半音";
            this.STPitchP7Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP8Menu
            // 
            this.STPitchP8Menu.Name = "STPitchP8Menu";
            this.STPitchP8Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP8Menu.Tag = "8";
            this.STPitchP8Menu.Text = "+8半音";
            this.STPitchP8Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP9Menu
            // 
            this.STPitchP9Menu.Name = "STPitchP9Menu";
            this.STPitchP9Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP9Menu.Tag = "9";
            this.STPitchP9Menu.Text = "+9半音";
            this.STPitchP9Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP10Menu
            // 
            this.STPitchP10Menu.Name = "STPitchP10Menu";
            this.STPitchP10Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP10Menu.Tag = "10";
            this.STPitchP10Menu.Text = "+10半音";
            this.STPitchP10Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP11Menu
            // 
            this.STPitchP11Menu.Name = "STPitchP11Menu";
            this.STPitchP11Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP11Menu.Tag = "11";
            this.STPitchP11Menu.Text = "+11半音";
            this.STPitchP11Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchP12Menu
            // 
            this.STPitchP12Menu.Name = "STPitchP12Menu";
            this.STPitchP12Menu.Size = new System.Drawing.Size(133, 22);
            this.STPitchP12Menu.Tag = "12";
            this.STPitchP12Menu.Text = "+12半音";
            this.STPitchP12Menu.Click += new System.EventHandler(this.SoundTouchPitchMenu_Click);
            // 
            // STPitchMenuSeparator1
            // 
            this.STPitchMenuSeparator1.Name = "STPitchMenuSeparator1";
            this.STPitchMenuSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // STPitchFixClipMenu
            // 
            this.STPitchFixClipMenu.Checked = true;
            this.STPitchFixClipMenu.CheckOnClick = true;
            this.STPitchFixClipMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.STPitchFixClipMenu.Name = "STPitchFixClipMenu";
            this.STPitchFixClipMenu.Size = new System.Drawing.Size(133, 22);
            this.STPitchFixClipMenu.Text = "音割れ防止";
            this.STPitchFixClipMenu.Click += new System.EventHandler(this.STPitchFixClipMenu_Click);
            // 
            // PlayMenu
            // 
            this.PlayMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StopMenu,
            this.PauseOrResumeMenu,
            this.PlaybackMenu,
            this.PreviousMenu,
            this.NextMenu,
            this.RandomMenu,
            this.PlayMenuSeparator1,
            this.PlaybackOrdersMenu});
            this.PlayMenu.Name = "PlayMenu";
            this.PlayMenu.Size = new System.Drawing.Size(58, 20);
            this.PlayMenu.Text = "再生(&P)";
            // 
            // StopMenu
            // 
            this.StopMenu.Name = "StopMenu";
            this.StopMenu.Size = new System.Drawing.Size(151, 22);
            this.StopMenu.Text = "停止";
            this.StopMenu.Click += new System.EventHandler(this.StopMenu_Click);
            // 
            // PauseOrResumeMenu
            // 
            this.PauseOrResumeMenu.Name = "PauseOrResumeMenu";
            this.PauseOrResumeMenu.Size = new System.Drawing.Size(151, 22);
            this.PauseOrResumeMenu.Text = "一時停止/再開";
            this.PauseOrResumeMenu.Click += new System.EventHandler(this.PauseOrResumeMenu_Click);
            // 
            // PlaybackMenu
            // 
            this.PlaybackMenu.Name = "PlaybackMenu";
            this.PlaybackMenu.Size = new System.Drawing.Size(151, 22);
            this.PlaybackMenu.Text = "再生";
            this.PlaybackMenu.Click += new System.EventHandler(this.PlayMenu_Clicked);
            // 
            // PreviousMenu
            // 
            this.PreviousMenu.Name = "PreviousMenu";
            this.PreviousMenu.Size = new System.Drawing.Size(151, 22);
            this.PreviousMenu.Text = "前のトラック";
            this.PreviousMenu.Click += new System.EventHandler(this.PreviousMenu_Click);
            // 
            // NextMenu
            // 
            this.NextMenu.Name = "NextMenu";
            this.NextMenu.Size = new System.Drawing.Size(151, 22);
            this.NextMenu.Text = "次のトラック";
            this.NextMenu.Click += new System.EventHandler(this.NextMenu_Click);
            // 
            // RandomMenu
            // 
            this.RandomMenu.Name = "RandomMenu";
            this.RandomMenu.Size = new System.Drawing.Size(151, 22);
            this.RandomMenu.Text = "ランダム";
            this.RandomMenu.Click += new System.EventHandler(this.RandomMenu_Click);
            // 
            // PlayMenuSeparator1
            // 
            this.PlayMenuSeparator1.Name = "PlayMenuSeparator1";
            this.PlayMenuSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // PlaybackOrdersMenu
            // 
            this.PlaybackOrdersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoRepeatMenu,
            this.PlaybackOrderMenuSeparator1,
            this.RepeatSingleTrackMenu,
            this.RepeatAllTracksMenu,
            this.RandomRepeatMenu});
            this.PlaybackOrdersMenu.Name = "PlaybackOrdersMenu";
            this.PlaybackOrdersMenu.Size = new System.Drawing.Size(151, 22);
            this.PlaybackOrdersMenu.Text = "再生順";
            // 
            // NoRepeatMenu
            // 
            this.NoRepeatMenu.Checked = true;
            this.NoRepeatMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoRepeatMenu.Name = "NoRepeatMenu";
            this.NoRepeatMenu.Size = new System.Drawing.Size(135, 22);
            this.NoRepeatMenu.Text = "リピートしない";
            this.NoRepeatMenu.Click += new System.EventHandler(this.NoRepeatMenu_Click);
            // 
            // PlaybackOrderMenuSeparator1
            // 
            this.PlaybackOrderMenuSeparator1.Name = "PlaybackOrderMenuSeparator1";
            this.PlaybackOrderMenuSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // RepeatSingleTrackMenu
            // 
            this.RepeatSingleTrackMenu.Name = "RepeatSingleTrackMenu";
            this.RepeatSingleTrackMenu.Size = new System.Drawing.Size(135, 22);
            this.RepeatSingleTrackMenu.Text = "単曲リピート";
            this.RepeatSingleTrackMenu.Click += new System.EventHandler(this.RepeatSingleTrackMenu_Click);
            // 
            // RepeatAllTracksMenu
            // 
            this.RepeatAllTracksMenu.Name = "RepeatAllTracksMenu";
            this.RepeatAllTracksMenu.Size = new System.Drawing.Size(135, 22);
            this.RepeatAllTracksMenu.Text = "全曲リピート";
            this.RepeatAllTracksMenu.Click += new System.EventHandler(this.RepeatAllTracksMenu_Click);
            // 
            // RandomRepeatMenu
            // 
            this.RandomRepeatMenu.Name = "RandomRepeatMenu";
            this.RandomRepeatMenu.Size = new System.Drawing.Size(135, 22);
            this.RandomRepeatMenu.Text = "ランダム";
            this.RandomRepeatMenu.Click += new System.EventHandler(this.RandomRepeatMenu_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailOptionsMenu,
            this.OptionsMenuSeparator1,
            this.ResetAllOptionsMenu});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(60, 20);
            this.OptionsMenu.Text = "設定(&O)";
            // 
            // DetailOptionsMenu
            // 
            this.DetailOptionsMenu.Image = global::RabbitTune.Properties.Resources.cog;
            this.DetailOptionsMenu.Name = "DetailOptionsMenu";
            this.DetailOptionsMenu.Size = new System.Drawing.Size(142, 22);
            this.DetailOptionsMenu.Text = "詳細設定";
            this.DetailOptionsMenu.Click += new System.EventHandler(this.DetailOptionsMenu_Click);
            // 
            // OptionsMenuSeparator1
            // 
            this.OptionsMenuSeparator1.Name = "OptionsMenuSeparator1";
            this.OptionsMenuSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // ResetAllOptionsMenu
            // 
            this.ResetAllOptionsMenu.Name = "ResetAllOptionsMenu";
            this.ResetAllOptionsMenu.Size = new System.Drawing.Size(142, 22);
            this.ResetAllOptionsMenu.Text = "設定のリセット";
            this.ResetAllOptionsMenu.Click += new System.EventHandler(this.ResetAllOptionsMenu_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowReadMeMenu,
            this.ShowHistoryMenu,
            this.VersionMenuSeparator1,
            this.ShowVersionInfoMenu});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(65, 20);
            this.HelpMenu.Text = "ヘルプ(&H)";
            // 
            // ShowReadMeMenu
            // 
            this.ShowReadMeMenu.Name = "ShowReadMeMenu";
            this.ShowReadMeMenu.Size = new System.Drawing.Size(155, 22);
            this.ShowReadMeMenu.Text = "ReadMeを表示";
            this.ShowReadMeMenu.Click += new System.EventHandler(this.ShowReadMeMenu_Click);
            // 
            // ShowHistoryMenu
            // 
            this.ShowHistoryMenu.Name = "ShowHistoryMenu";
            this.ShowHistoryMenu.Size = new System.Drawing.Size(155, 22);
            this.ShowHistoryMenu.Text = "更新履歴を表示";
            this.ShowHistoryMenu.Click += new System.EventHandler(this.ShowHistoryMenu_Click);
            // 
            // VersionMenuSeparator1
            // 
            this.VersionMenuSeparator1.Name = "VersionMenuSeparator1";
            this.VersionMenuSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // ShowVersionInfoMenu
            // 
            this.ShowVersionInfoMenu.Name = "ShowVersionInfoMenu";
            this.ShowVersionInfoMenu.Size = new System.Drawing.Size(155, 22);
            this.ShowVersionInfoMenu.Text = "バージョン情報";
            this.ShowVersionInfoMenu.Click += new System.EventHandler(this.ShowVersionInfoMenu_Click);
            // 
            // WriteToFileMenu
            // 
            this.WriteToFileMenu.Name = "WriteToFileMenu";
            this.WriteToFileMenu.Size = new System.Drawing.Size(256, 22);
            this.WriteToFileMenu.Text = "変換 / 保存(&R)...";
            this.WriteToFileMenu.Click += new System.EventHandler(this.WriteToFileMenu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(253, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(734, 436);
            this.Controls.Add(this.MainContentsPanel);
            this.Controls.Add(this.SeekBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RabbitTune";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MainContentsPanel.ResumeLayout(false);
            this.LeftToolPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrackPictureViewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip statusStrip1;
        private HScrollBar SeekBar;
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
        private ToolStripButton PreviousButton;
        private ToolStripButton QuickSearchbutton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton1;
        private ToolStripSlider VolumeSlider;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel1;
        private ToolStripStatusLabel PlayingAudioFormatStatusText;
        private ToolStripStatusLabel PlaybackPositionStatusText;
        private ToolStripStatusLabel PlayingAudioWaveFormatText;
        private ContextMenu TaskTrayContextMenu;
        private MenuItem StopTaskTrayMenu;
        private MenuItem PauseOrResumeTaskTrayMenu;
        private MenuItem PlayTaskTrayMenu;
        private MenuItem PreviousTaskTrayMenu;
        private MenuItem NextTaskTrayMenu;
        private MenuItem RandomTaskTrayMenu;
        private MenuItem TaskTrayMenuSeparator1;
        private MenuItem PlaybackOrderTaskTrayMenu;
        private MenuItem NoRepeatTaskTrayMenu;
        private MenuItem PlaybackOrderTaskTrayMenuSeparator1;
        private MenuItem RepeatSingleTrackTaskTrayMenu;
        private MenuItem RepeatAllTracksTaskTrayMenu;
        private MenuItem RandomRepeatTaskTrayMenu;
        private NotifyIcon TaskTrayNotifyIcon;
        private MenuItem TaskTrayMenuSeparator2;
        private MenuItem ShowAsNormalWindowTaskTrayMenu;
        private MenuItem TaskTrayMenuSeparator3;
        private MenuItem ExitApplicationTaskTrayMenu;
        private Panel MainContentsPanel;
        private PlaylistsTabControl MainTabControl;
        private Splitter LeftSideSplitter;
        private Panel LeftToolPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private PlaylistBrowser PlaylistBrowser;
        private PictureBox TrackPictureViewer;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSlider PanSlider;
        private ToolStripButton ResetPanButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileMenuSeparator3;
        private ToolStripMenuItem EditMenu;
        private ToolStripMenuItem ViewMenu;
        private ToolStripMenuItem AudioProcessMenu;
        private ToolStripMenuItem PlayMenu;
        private ToolStripMenuItem OptionsMenu;
        private ToolStripMenuItem HelpMenu;
        private ToolStripMenuItem CreateNewPlaylistMenu;
        private ToolStripSeparator FileMenuSeparator1;
        private ToolStripMenuItem OpenAnyFilesMenu;
        private ToolStripMenuItem OpenFolderMenu;
        private ToolStripSeparator FileMenuSeparator2;
        private ToolStripMenuItem SaveCurrentPlaylistAsMenu;
        private ToolStripMenuItem SaveCurrentPlaylistMenu;
        private ToolStripMenuItem SaveAllPlaylistsMenu;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem AddFolderToPlaylistMenu;
        private ToolStripSeparator FileMenuSeparator4;
        private ToolStripMenuItem ExitApplicationMenu;
        private ToolStripMenuItem FindMenu;
        private ToolStripMenuItem FindTrackMenu;
        private ToolStripMenuItem FindNextMenu;
        private ToolStripSeparator EditMenuSeparator1;
        private ToolStripMenuItem MoveUpSelectedItemMenu;
        private ToolStripMenuItem MoveDownSelectedItemMenu;
        private ToolStripSeparator EditMenuSeparator2;
        private ToolStripMenuItem RemoveSelectedItemFromListMenu;
        private ToolStripMenuItem RemoveSelectedItemWithFileFromListMenu;
        private ToolStripMenuItem RemoveAllItemsMenu;
        private ToolStripMenuItem AlwaysOnTopMenu;
        private ToolStripMenuItem ShowInTaskTrayMenu;
        private ToolStripMenuItem ShowAsMiniplayerModeMenu;
        private ToolStripSeparator ViewMenuSeparator1;
        private ToolStripMenuItem ShowLeftSideToolPanelMenu;
        private ToolStripMenuItem ShowAudioOutputInfoMenu;
        private ToolStripMenuItem SampleRateConversionMenu;
        private ToolStripMenuItem EqualizerMenu;
        private ToolStripSeparator AudioProcessMenuSeparator1;
        private ToolStripMenuItem PlaybackSpeedsMenu;
        private ToolStripMenuItem PlaybackSpeed025Menu;
        private ToolStripMenuItem PlaybackSpeed050Menu;
        private ToolStripMenuItem PlaybackSpeed075Menu;
        private ToolStripMenuItem PlaybackSpeed090Menu;
        private ToolStripMenuItem PlaybackSpeed100Menu;
        private ToolStripMenuItem PlaybackSpeed110Menu;
        private ToolStripMenuItem PlaybackSpeed125Menu;
        private ToolStripMenuItem PlaybackSpeed150Menu;
        private ToolStripMenuItem PlaybackSpeed175Menu;
        private ToolStripMenuItem PlaybackSpeed200Menu;
        private ToolStripMenuItem PitchMenu;
        private ToolStripMenuItem PitchM12SemitonesMenu;
        private ToolStripMenuItem PitchM11SemitonesMenu;
        private ToolStripMenuItem PitchM10SemitonesMenu;
        private ToolStripMenuItem PitchM9SemitonesMenu;
        private ToolStripMenuItem PitchM8SemitonesMenu;
        private ToolStripMenuItem PitchM7SemitonesMenu;
        private ToolStripMenuItem PitchM6SemitonesMenu;
        private ToolStripMenuItem PitchM5SemitonesMenu;
        private ToolStripMenuItem PitchM4SemitonesMenu;
        private ToolStripMenuItem PitchM3SemitonesMenu;
        private ToolStripMenuItem PitchM2SemitonesMenu;
        private ToolStripMenuItem PitchM1SemitonesMenu;
        private ToolStripMenuItem PitchPM0SemitonesMenu;
        private ToolStripMenuItem PitchP1SemitonesMenu;
        private ToolStripMenuItem PitchP2SemitonesMenu;
        private ToolStripMenuItem PitchP3SemitonesMenu;
        private ToolStripMenuItem PitchP4SemitonesMenu;
        private ToolStripMenuItem PitchP5SemitonesMenu;
        private ToolStripMenuItem PitchP6SemitonesMenu;
        private ToolStripMenuItem PitchP7SemitonesMenu;
        private ToolStripMenuItem PitchP8SemitonesMenu;
        private ToolStripMenuItem PitchP9SemitonesMenu;
        private ToolStripMenuItem PitchP10emitonesMenu;
        private ToolStripMenuItem PitchP11SemitonesMenu;
        private ToolStripMenuItem PitchP12SemitonesMenu;
        private ToolStripSeparator PitchMenuSeparator1;
        private ToolStripMenuItem FixPitchClipMenu;
        private ToolStripMenuItem SoundTouchPitchMenu;
        private ToolStripMenuItem STPitchM12Menu;
        private ToolStripMenuItem STPitchM11Menu;
        private ToolStripMenuItem STPitchM10Menu;
        private ToolStripMenuItem STPitchM9Menu;
        private ToolStripMenuItem STPitchM8Menu;
        private ToolStripMenuItem STPitchM7Menu;
        private ToolStripMenuItem STPitchM6Menu;
        private ToolStripMenuItem STPitchM5Menu;
        private ToolStripMenuItem STPitchM4Menu;
        private ToolStripMenuItem STPitchM3Menu;
        private ToolStripMenuItem STPitchM2Menu;
        private ToolStripMenuItem STPitchM1Menu;
        private ToolStripMenuItem STPitchZeroMenu;
        private ToolStripMenuItem STPitchP1Menu;
        private ToolStripMenuItem STPitchP2Menu;
        private ToolStripMenuItem STPitchP3Menu;
        private ToolStripMenuItem STPitchP4Menu;
        private ToolStripMenuItem STPitchP5Menu;
        private ToolStripMenuItem STPitchP6Menu;
        private ToolStripMenuItem STPitchP7Menu;
        private ToolStripMenuItem STPitchP8Menu;
        private ToolStripMenuItem STPitchP9Menu;
        private ToolStripMenuItem STPitchP10Menu;
        private ToolStripMenuItem STPitchP11Menu;
        private ToolStripMenuItem STPitchP12Menu;
        private ToolStripSeparator STPitchMenuSeparator1;
        private ToolStripMenuItem STPitchFixClipMenu;
        private ToolStripMenuItem StopMenu;
        private ToolStripMenuItem PauseOrResumeMenu;
        private ToolStripMenuItem PlaybackMenu;
        private ToolStripMenuItem PreviousMenu;
        private ToolStripMenuItem NextMenu;
        private ToolStripMenuItem RandomMenu;
        private ToolStripSeparator PlayMenuSeparator1;
        private ToolStripMenuItem PlaybackOrdersMenu;
        private ToolStripMenuItem NoRepeatMenu;
        private ToolStripSeparator PlaybackOrderMenuSeparator1;
        private ToolStripMenuItem RepeatSingleTrackMenu;
        private ToolStripMenuItem RepeatAllTracksMenu;
        private ToolStripMenuItem RandomRepeatMenu;
        private ToolStripMenuItem DetailOptionsMenu;
        private ToolStripSeparator OptionsMenuSeparator1;
        private ToolStripMenuItem ResetAllOptionsMenu;
        private ToolStripMenuItem ShowReadMeMenu;
        private ToolStripMenuItem ShowHistoryMenu;
        private ToolStripSeparator VersionMenuSeparator1;
        private ToolStripMenuItem ShowVersionInfoMenu;
        private ToolStripButton SearchButton;
        private ToolStripMenuItem WriteToFileMenu;
        private ToolStripSeparator toolStripSeparator6;
    }
}