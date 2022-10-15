using RabbitTune.AudioEngine;
using RabbitTune.Controls;
using RabbitTune.Dialogs;
using RabbitTune.MediaLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune
{
    public partial class MainForm : Form
    {
        // 公開定数
        public const int DEFAULT_WINDOW_WIDTH = 750;
        public const int DEFAULT_WINDOW_HEIGHT = 500;

        // 非公開変数
        private readonly string[] commandLineArguments;
        private readonly AudioOutputInfoDialog AudioOutputInfoDialog;
        private readonly FindDialog FindAudioTrackDialog;
        private readonly SampleRateConversionDialog SampleRateConversionDialog;
        private readonly EqualizerDialog EqualizerDialog;
        private readonly OptionDialog DetailOptionDialog;
        private readonly VersionDialog ApplicationVersionDialog;
        private bool showInTaskTray = false;                    // タスクトレイへ格納中かどうか
        private bool showAsMiniplayerMode = false;              // ミニプレーヤー表示中ならtrue, それ以外ならfalse
        private int defaultViewHeight;                          // 標準表示の際のウィンドウの高さ。ミニプレーヤー表示からの切り替え用。ミニプレーヤー表示を有効化した際に値がバックアップされる。

        // コンストラクタ
        public MainForm(string[] commandLineArgs)
        {
            InitializeComponent();

            // 再生位置が更新された際の処理
            AudioPlayerManager.PlaybackPositionChanged += delegate
            {
                // シーク操作中ではないか？
                if (!this.SeekBar.Capture)
                {
                    // シーク操作が終了したか？
                    if(this.SeekBar.Tag != null && this.SeekBar.Tag.GetType() == typeof(bool))
                    {
                        var flag_seeking = (bool)this.SeekBar.Tag;

                        if (flag_seeking)
                        {
                            AudioPlayerManager.Position = this.SeekBar.Value;
                        }

                        // 後始末
                        this.SeekBar.Tag = null;
                        return;
                    }

                    int value = (int)AudioPlayerManager.Position;

                    if(value < this.SeekBar.Minimum)
                    {
                        value = this.SeekBar.Minimum;
                    }
                    else if (value > this.SeekBar.Maximum)
                    {
                        value = this.SeekBar.Maximum;
                    }

                    this.SeekBar.Value = value;
                }
                else
                {
                    this.SeekBar.Tag = true;

                    // Monkey's Audio などはシーク操作が重い為、値が変更されるたびに
                    // プロパティを変更するとまともに動かない。
                    // AudioPlayerManager.Position = this.SeekBar.Value;
                }

                var time_pos = AudioPlayerManager.GetPosition();
                var time_len = AudioPlayerManager.GetDuration();

                // 再生時間の表示を更新
                this.PlaybackPositionStatusText.Text = $"{time_pos.Minutes.ToString("00")}:{time_pos.Seconds.ToString("00")}/" +
                $"{time_len.Minutes.ToString("00")}:{time_len.Seconds.ToString("00")}";
            };
            AudioPlayerManager.ReachEnd += delegate
            {
                if (!this.SeekBar.Capture)
                {
                    this.PlaybackPositionStatusText.Text = "00:00";

                    switch (ApplicationOptions.RepeatMode)
                    {
                        case RepeatMode.NoRepeat:
                            Stop();
                            break;
                        case RepeatMode.Single:
                            var track = AudioPlayerManager.GetCurrentTrack();
                            AudioPlayerManager.Close();
                            AudioPlayerManager.SetTrack(track);
                            AudioPlayerManager.Play();
                            break;
                        case RepeatMode.AllTracks:
                            PlayNextTrack();
                            break;
                        case RepeatMode.RandomTrack:
                            PlayRandomTrack();
                            break;
                        default:
                            goto case 0;
                    }
                }
            };
            AudioPlayerManager.StoppedByUser += delegate
            {
                this.PlaybackPositionStatusText.Text = "00:00";
            };
            AudioPlayerManager.OutputFormatChanged += delegate
            {
                UpdateAudioWaveFormatStatusText();
            };

            // コマンドライン引数を保持
            this.commandLineArguments = commandLineArgs;

            // フォントを設定
            this.Font = SystemFonts.CaptionFont;

            // 各種ダイアログの作成
            this.AudioOutputInfoDialog = new AudioOutputInfoDialog();
            this.FindAudioTrackDialog = new FindDialog();
            this.SampleRateConversionDialog = new SampleRateConversionDialog();
            this.EqualizerDialog = new EqualizerDialog();
            this.DetailOptionDialog = new OptionDialog();
            this.ApplicationVersionDialog = new VersionDialog();
        }

        // デフォルトコンストラクタ
        public MainForm() : this(null) { }

        /// <summary>
        /// 各種設定値を表示に反映する。
        /// </summary>
        private void ApplyFormOptions()
        {
            // 各種設定値を表示に反映
            this.VolumeSlider.Value = AudioPlayerManager.Volume;
            this.AlwaysOnTop = ApplicationOptions.AlwaysOnTop;
            this.WindowState = ApplicationOptions.MainFormWindowState;
            this.Size = ApplicationOptions.MainFormSize;
            this.defaultViewHeight = this.Size.Height;
            this.ShowLeftSideToolPanel = ApplicationOptions.ShowMainFormLeftSideToolPanel;
            this.ShowAsMiniplayerMode = ApplicationOptions.ShowMainFormAsMiniplayerMode;
            this.VolumeSlider.Value = AudioPlayerManager.Volume;
            this.PanSlider.Value = AudioPlayerManager.Pan;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
            SetPlaybackSpeed(AudioPlayerManager.PlaybackSpeed);
            SetPitch(AudioPlayerManager.Pitch);
            SetSoundTouchPitch(AudioPlayerManager.SoundTouchPitchSemitones);
        }

        /// <summary>
        /// 通常のウィンドウ状態におけるフォームのサイズを取得する。<br/>
        /// ミニプレーヤー表示であっても、標準モード時のフォームのサイズを返す。
        /// </summary>
        /// <returns></returns>
        public Size GetRestoreFormSize()
        {
            int width = this.RestoreBounds.Width;
            int height = this.RestoreBounds.Height;

            // ミニプレーヤーモードが有効か？
            if (this.ShowAsMiniplayerMode)
            {
                // 標準モードの場合のフォームの高さを取得。
                height = this.defaultViewHeight;
            }

            return new Size(width, height);
        }

        #region フォームの表示・描画・更新

        /// <summary>
        /// ミニプレーヤーモードと標準モードを切り替える。
        /// </summary>
        /// <param name="enabled"></param>
        public void SetMiniplayerMode(bool enabled)
        {
            this.ShowAsMiniplayerModeMenu.Checked = enabled;
            this.showAsMiniplayerMode = enabled;

            // ミニプレーヤー表示の有効化か？
            if (enabled)
            {
                if(this.WindowState == FormWindowState.Maximized)
                {
                    // 最大化中にミニプレーヤーモードに切り替えると不具合が出る場合があるので、
                    // 切り替え前に標準サイズに戻す。
                    this.WindowState = FormWindowState.Normal;
                }

                int height = this.Height - this.MainContentsPanel.Height;

                this.defaultViewHeight = this.Height;
                this.Height = height;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;     // ウィンドウサイズの変更を許可しない
                this.MaximizeBox = false;                               // ウィンドウの最大化ボタンを無効化
            }
            else
            {
                this.Height = this.defaultViewHeight;
                this.FormBorderStyle = FormBorderStyle.Sizable;         // ウィンドウサイズの変更を許可する
                this.MaximizeBox = true;                                // ウィンドウの最大化ボタンを有効化
            }
        }

        /// <summary>
        /// 指定されたリピートモードのメニュー項目をチェックする。
        /// </summary>
        /// <param name="repeatMode"></param>
        private void SetRepeatModeView(RepeatMode repeatMode)
        {
            switch (repeatMode)
            {
                case RepeatMode.NoRepeat:
                    this.NoRepeatMenu.Checked = this.NoRepeatTaskTrayMenu.Checked = true;
                    this.RepeatSingleTrackMenu.Checked = this.RepeatAllTracksMenu.Checked = this.RandomRepeatMenu.Checked = false;
                    this.RepeatSingleTrackMenu.Checked = this.RepeatAllTracksTaskTrayMenu.Checked = this.RandomRepeatTaskTrayMenu.Checked = false;
                    break;
                case RepeatMode.Single:
                    this.RepeatSingleTrackMenu.Checked = this.RepeatAllTracksTaskTrayMenu.Checked = true;
                    this.NoRepeatMenu.Checked = this.RepeatAllTracksMenu.Checked = this.RandomRepeatMenu.Checked = false;
                    this.NoRepeatTaskTrayMenu.Checked = this.RepeatAllTracksTaskTrayMenu.Checked = this.RandomRepeatTaskTrayMenu.Checked = false;
                    break;
                case RepeatMode.AllTracks:
                    this.RepeatAllTracksMenu.Checked = this.RepeatAllTracksTaskTrayMenu.Checked = true;
                    this.NoRepeatMenu.Checked = this.RepeatSingleTrackMenu.Checked = this.RandomRepeatMenu.Checked = false;
                    this.NoRepeatTaskTrayMenu.Checked = this.RepeatSingleTrackMenu.Checked = this.RandomRepeatTaskTrayMenu.Checked = false;
                    break;
                case RepeatMode.RandomTrack:
                    this.RandomRepeatMenu.Checked = this.RandomRepeatTaskTrayMenu.Checked = true;
                    this.NoRepeatMenu.Checked = this.RepeatSingleTrackMenu.Checked = this.RepeatAllTracksMenu.Checked = false;
                    this.NoRepeatTaskTrayMenu.Checked = this.RepeatSingleTrackMenu.Checked = this.RepeatAllTracksTaskTrayMenu.Checked = false;
                    break;
            }
        }

        /// <summary>
        /// トラックの画像の表示状態を設定する。
        /// </summary>
        /// <param name="visible"></param>
        private void SetTrackImageViewerVisible(bool visible)
        {
            if (visible)
            {
                int size = this.LeftToolPanel.Width;
                this.TrackPictureViewer.Width = size;
                this.TrackPictureViewer.Height = size;
                this.TrackPictureViewer.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                this.TrackPictureViewer.Width = 0;
                this.TrackPictureViewer.Height = 0;
                this.TrackPictureViewer.BorderStyle = BorderStyle.None;
            }
        }

        /// <summary>
        /// 指定されたトラックに含まれる画像をビューに表示する。
        /// </summary>
        /// <param name="track"></param>
        private void ShowTrackPicture(AudioTrack track)
        {
            Image img = null;
            var worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                img = track.GetTrackPicture();
            };
            worker.RunWorkerCompleted += delegate
            {
                if (this.TrackPictureViewer.Image != null)
                {
                    this.TrackPictureViewer.Image.Dispose();        // メモリリーク回避
                    this.TrackPictureViewer.Image = null;
                }

                // 画像を表示
                this.TrackPictureViewer.Image = img;
                SetTrackImageViewerVisible(img != null);

                // 後始末
                worker.Dispose();
            };

            // 画像を非同期で読み込んで表示
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// ステータスバーに表示する再生中のトラックのフォーマット情報を更新する。
        /// </summary>
        private void UpdateAudioWaveFormatStatusText()
        {
            string fmt = "不明なフォーマット";

            if (this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                fmt = AudioReader.GetFormatName(this.CurrentPlaylistViewer.SelectedAudioTrack.Location);
            }

            // ファイルの種類（コーデック名）の表示を更新
            this.PlayingAudioFormatStatusText.Text = fmt;

            // 波形フォーマットの表示を更新
            AudioPlayerManager.GetInputWaveFormat(out int isr, out int isb, out int isc);
            AudioPlayerManager.GetOutputWaveFormat(out int psr, out int psb, out int psc);
            string waveformat = $"INPUT: ({isr}Hz, {getChannelDescription(isc)}, {isb}bits), ";

            // リサンプラーが有効か？
            if (AudioPlayerManager.UseReSampler)
            {
                // リサンプラーのフォーマットも表示に追加
                waveformat += $"RESAMPLER: ({AudioPlayerManager.ReSamplerSampleRate}Hz, {getChannelDescription(AudioPlayerManager.ReSamplerChannels)}, {AudioPlayerManager.ReSamplerBitsPerSample}bits), ";
            }

            // 出力デバイスに渡されるオーディオソース(音響処理後のデータ)のフォーマットを追加
            waveformat += $"OUTPUT: ({psr}Hz, {getChannelDescription(psc)}, {psb}bits)";

            // 表示に反映
            this.PlayingAudioWaveFormatText.Text = waveformat;

            string getChannelDescription(int channels)
            {
                switch (channels)
                {
                    case 1:
                        return "mono";
                    case 2:
                        return "stereo";
                    default:
                        return channels.ToString();
                }
            }
        }

        /// <summary>
        /// 停止中（一時停止中を除く）にこのメソッドを呼び出すと、トラックのフォーマット情報を非表示化し、<br/>
        /// 再生中にこのメソッドを呼び出すと、トラックのフォーマット情報を表示する。
        /// </summary>
        private void UpdateAudioWaveFormatStatusTextVisible()
        {
            bool visible = AudioPlayerManager.IsPlaying || AudioPlayerManager.IsPausing;

            this.PlayingAudioFormatStatusText.Visible = visible;
            this.PlayingAudioWaveFormatText.Visible = visible;
        }

        /// <summary>
        /// フォームのタイトルを更新する。
        /// </summary>
        private void UpdateFormTitle()
        {
            if(AudioPlayerManager.IsPlaying || AudioPlayerManager.IsPausing)
            {
                this.Text = $"{Program.ApplicationName} - {AudioPlayerManager.GetCurrentTrack().Title}";
            }
            else
            {
                this.Text = Program.ApplicationName;
            }
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 常に最前面に表示するかどうか
        /// </summary>
        public bool AlwaysOnTop
        {
            get
            {
                return this.TopMost;
            }
            set
            {
                this.TopMost = value;
                this.AlwaysOnTopMenu.Checked = value;
            }
        }

        /// <summary>
        /// タスクトレイへ格納するかどうか
        /// </summary>
        public bool ShowInTaskTray
        {
            set
            {
                this.TaskTrayNotifyIcon.ContextMenu = this.TaskTrayContextMenu;
                this.TaskTrayNotifyIcon.Icon = this.Icon;
                this.TaskTrayNotifyIcon.Visible = value;
                this.Visible = !value;
            }
            get
            {
                return this.showInTaskTray;
            }
        }

        /// <summary>
        /// ミニプレーヤー表示中かどうか
        /// </summary>
        public bool ShowAsMiniplayerMode
        {
            set
            {
                SetMiniplayerMode(value);
            }
            get
            {
                return this.showAsMiniplayerMode;
            }
        }

        /// <summary>
        /// 現在選択しているタブのプレイリストビューワのインスタンス。<br/>
        /// ページが選択されていない、または選択されたページがプレイリストのページでない場合、nullを返す。
        /// </summary>
        public PlaylistViewer CurrentPlaylistViewer
        {
            get
            {
                var page = this.MainTabControl.SelectedTab;

                if (page != null && page.GetType() == typeof(PlaylistViewerTabPage))
                {
                    return ((PlaylistViewerTabPage)page).PlaylistViewer;
                }

                return null;
            }
        }

        /// <summary>
        /// デフォルトプレイリストのプレイリストビューワーを取得する。
        /// </summary>
        public PlaylistViewer DefaultPlaylistViewer
        {
            get
            {
                return ((PlaylistViewerTabPage)this.MainTabControl.TabPages[0]).PlaylistViewer;
            }
        }

        /// <summary>
        /// 左側ツールパネルの可視状態
        /// </summary>
        public bool ShowLeftSideToolPanel
        {
            set
            {
                this.LeftToolPanel.Visible = value;
                this.LeftSideSplitter.Visible = value;
                this.ShowLeftSideToolPanelMenu.Checked = value;
            }
            get
            {
                return this.LeftToolPanel.Visible;
            }
        }

        #endregion

        #region ファイル関連の処理

        /// <summary>
        /// ファイルダイアログで使用するフィルタの文字列を生成する。
        /// </summary>
        /// <param name="withAudioFileFilter"></param>
        /// <param name="withPlaylistFileFilter"></param>
        /// <param name="withAnyFileFilter"></param>
        /// <returns></returns>
        private string GetFileDialogFilter(bool withAudioFileFilter, bool withPlaylistFileFilter, bool withAnyFileFilter)
        {
            string result = null;

            // 「対応するすべてのファイル」フィルタを生成するべきか？
            if(withAudioFileFilter && withPlaylistFileFilter)
            {
                var formatList = new List<KeyValuePair<string, string[]>>();

                foreach (string fmtName in AudioReader.GetSupportedFormatNames())
                {
                    var pair = new KeyValuePair<string, string[]>(fmtName, AudioReader.GetFormatExtensions(fmtName));
                    formatList.Add(pair);
                }

                foreach (string fmtName in Playlist.GetSupportedFormatNames())
                {
                    var pair = new KeyValuePair<string, string[]>(fmtName, Playlist.GetFormatExtensions(fmtName));
                    formatList.Add(pair);
                }

                if (result != null)
                {
                    result += "|";
                }

                result += FileDialogUtils.GetAllFilterString(formatList, "対応するすべてのファイル");
            }

            // オーディオファイルのフィルタを生成するか？
            if (withAudioFileFilter)
            {
                var formatList = new List<KeyValuePair<string, string[]>>();

                foreach (string fmtName in AudioReader.GetSupportedFormatNames())
                {
                    var pair = new KeyValuePair<string, string[]>(fmtName, AudioReader.GetFormatExtensions(fmtName));
                    formatList.Add(pair);
                }

                if (result != null)
                {
                    result += "|";
                }

                result += FileDialogUtils.CreateFilterString(formatList, true, "対応するすべてのオーディオファイル", false);
            }

            // プレイリストファイルのフィルタを生成するか？
            if (withPlaylistFileFilter)
            {
                var formatList = new List<KeyValuePair<string, string[]>>();

                foreach (string fmtName in Playlist.GetSupportedFormatNames())
                {
                    var pair = new KeyValuePair<string, string[]>(fmtName, Playlist.GetFormatExtensions(fmtName));
                    formatList.Add(pair);
                }

                if (result != null)
                {
                    result += "|";
                }

                result += FileDialogUtils.CreateFilterString(formatList, true, "対応するすべてのプレイリスト", false);
            }

            // 「すべてのファイル」のフィルタを生成するか？
            if (withAnyFileFilter)
            {
                if(result != null)
                {
                    result += "|";
                }

                result += "全てのファイル|**";
            }

            return result;
        }

        /// <summary>
        /// ファイルを開く
        /// </summary>
        /// <param name="path"></param>
        private void OpenAnyFile(string path)
        {
            if (AudioReader.IsSupportedFormat(path))
            {
                AddFileToPlaylist(path);
            }
            else if (Playlist.IsSupportedPlaylistFormat(path))
            {
                OpenPlaylist(path);
            }
        }

        #endregion

        #region プレイリストの管理に関連する処理

        /// <summary>
        /// 未保存のプレイリストを表示しているプレイリストビューワの一覧を取得する。
        /// </summary>
        /// <returns></returns>
        private PlaylistViewer[] GetUnsavedPlaylistViewers()
        {
            List<PlaylistViewer> viewers = new List<PlaylistViewer>();

            foreach(PlaylistViewerTabPage tp in this.MainTabControl.TabPages)
            {
                if (tp.PlaylistViewer.IsChanged)
                {
                    viewers.Add(tp.PlaylistViewer);
                }
            }

            return viewers.ToArray();
        }

        /// <summary>
        /// 新しいプレイリスト表示タブを作成し、そのインスタンスを返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private PlaylistViewerTabPage CreatePlaylistViewerTabPage(string path = null)
        {
            var page = new PlaylistViewerTabPage();

            if (path == null)
            {
                page.Text = "新規プレイリスト.m3u";
            }
            else
            {
                page.CanClose = path != ApplicationOptions.DefaultPlaylistPath;

                // プレイリストを開く
                page.PlaylistViewer.OpenPlaylist(path);
            }

            page.AudioTrackSelected += PlayMenu_Clicked;
            page.PlaylistViewer.PlayCommandInvoked += PlayMenu_Clicked;
            return page;
        }

        /// <summary>
        /// 新規プレイリストを作成
        /// </summary>
        private void CreateNewPlaylist()
        {
            var page = CreatePlaylistViewerTabPage();

            // ページを追加して選択
            this.MainTabControl.TabPages.Add(page);
            this.MainTabControl.SelectedTab = page;
        }

        /// <summary>
        /// 現在選択中のプレイリストにファイルを追加する。
        /// </summary>
        /// <param name="path"></param>
        private void AddFileToPlaylist(string path)
        {
            if(this.CurrentPlaylistViewer != null)
            {
                var track = new AudioTrack(path);

                this.CurrentPlaylistViewer.AddAudioTrack(track);
            }
        }

        /// <summary>
        /// デフォルトプレイリストを開く。
        /// </summary>
        private void OpenDefaultPlaylist()
        {
            // デフォルトプレイリストが作成されていなければ新しく作成する。
            if (!File.Exists(ApplicationOptions.DefaultPlaylistPath))
            {
                var writer = new PlaylistWriter(ApplicationOptions.DefaultPlaylistPath);
                writer.Save();
            }

            // デフォルトプレイリストを開く。
            OpenPlaylist(ApplicationOptions.DefaultPlaylistPath);
        }

        /// <summary>
        /// 指定されたパスのプレイリストを開いているタブページのインデックスを取得する。<br/>
        /// 存在しなければ-1を返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int GetPlaylistTabIndex(string path)
        {
            for(int i = 0; i < this.MainTabControl.TabCount; ++i)
            {
                var page = this.MainTabControl.TabPages[i];

                if(page.GetType() == typeof(PlaylistViewerTabPage))
                {
                    if(((PlaylistViewerTabPage)page).PlaylistViewer.GetPlaylistFilePath() == path)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 新しいタブでプレイリストを開く。<br/>
        /// パス指定を省略した場合、開くファイルを選択する。
        /// </summary>
        /// <param name="path"></param>
        private void OpenPlaylist(string path = null)
        {
            if(string.IsNullOrEmpty(path))
            {
                var dialog = new OpenFileDialog();

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                }

                // 後始末
                dialog.Dispose();
            }

            int idx = GetPlaylistTabIndex(path);

            // 指定されたパスを表示しているタブページが存在しないか？
            if (idx == -1)
            {
                var page = CreatePlaylistViewerTabPage(path);

                // ページを追加して選択
                this.MainTabControl.TabPages.Add(page);
                this.MainTabControl.SelectedTab = page;
            }
            else
            {
                // ページを選択
                this.MainTabControl.SelectedIndex = idx;
            }
        }

        /// <summary>
        /// 保存先を選択し、指定されたプレイリストビューワーのプレイリストを保存する。
        /// </summary>
        /// <param name="viewer"></param>
        private void SavePlaylistAs(PlaylistViewer viewer)
        {
            if(viewer != null)
            {
                viewer.SavePlaylistAs();
            }
        }

        /// <summary>
        /// 指定されたプレイリストビューワーのプレイリストを保存する。
        /// </summary>
        /// <param name="viewer"></param>
        private void SavePlaylist(PlaylistViewer viewer)
        {
            if (viewer != null)
            {
                viewer.SavePlaylist();
            }
        }

        /// <summary>
        /// 指定されたタブページインデックスのプレイリストを保存する。
        /// </summary>
        /// <param name="playlistPageIndex"></param>
        private void SavePlaylist(int playlistPageIndex)
        {
            var page = this.MainTabControl.TabPages[playlistPageIndex];

            // 指定されたインデックスのページがプレイリストのページか？
            if(page.GetType() == typeof(PlaylistViewerTabPage))
            {
                var viewer = ((PlaylistViewerTabPage)page).PlaylistViewer;
                SavePlaylist(viewer);
            }
        }

        /// <summary>
        /// 全てのプレイリストを保存する。
        /// </summary>
        private void SaveAllPlaylists()
        {
            for (int i = 0; i < this.MainTabControl.TabPages.Count; ++i)
            {
                SavePlaylist(i);
            }
        }

        /// <summary>
        /// オーディオトラックの検索を行う。
        /// </summary>
        private void SearchAudioTrack()
        {
            if (this.CurrentPlaylistViewer != null && this.FindAudioTrackDialog != null)
            {
                if (this.FindAudioTrackDialog.ShowDialog() == DialogResult.OK)
                {
                    SearchAudioTrack(this.FindAudioTrackDialog.SearchText);
                }
            }
        }

        /// <summary>
        /// オーディオトラックの検索を行う。
        /// </summary>
        /// <param name="searchText"></param>
        private void SearchAudioTrack(string searchText)
        {
            var track = this.CurrentPlaylistViewer.Search(
                        searchText,
                        this.FindAudioTrackDialog.JudgeBiggerOrLower,
                        this.FindAudioTrackDialog.SearchAllMatchOnly);

            if (track != null)
            {
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;
            }
            else
            {
                MessageBox.Show(
                    "指定された検索語句とオプションに一致するトラックは見つかりませんでした。",
                    "トラックが見つかりませんでした",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 直前の検索時の位置を開始位置としてオーディオトラックの検索を行う。
        /// </summary>
        private void SearchAudioTrackNext()
        {
            if (this.CurrentPlaylistViewer != null && this.FindAudioTrackDialog != null)
            {
                if (string.IsNullOrEmpty(this.FindAudioTrackDialog.SearchText))
                {
                    SearchAudioTrack();
                }
                else
                {
                    var track = this.CurrentPlaylistViewer.SearchNext(
                        this.FindAudioTrackDialog.SearchText,
                        this.FindAudioTrackDialog.JudgeBiggerOrLower,
                        this.FindAudioTrackDialog.SearchAllMatchOnly);

                    if (track != null)
                    {
                        this.CurrentPlaylistViewer.SelectedAudioTrack = track;
                    }
                    else
                    {
                        MessageBox.Show(
                            "指定された検索語句とオプションに一致するトラックは見つかりませんでした。",
                            "トラックが見つかりませんでした",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        #region 再生コントロールなど再生に関連する処理

        /// <summary>
        /// 再生速度を設定する。
        /// </summary>
        /// <param name="speed"></param>
        private void SetPlaybackSpeed(float speed)
        {
            speed = (float)Math.Round(speed, 2, MidpointRounding.AwayFromZero);
            AudioPlayerManager.PlaybackSpeed = speed;

            MenuItem checkItem;

            if(speed <= 0.25)
            {
                checkItem = this.PlaybackSpeed025Menu;
            }
            else if (speed <= 0.50)
            {
                checkItem = this.PlaybackSpeed050Menu;
            }
            else if (speed <= 0.75)
            {
                checkItem = this.PlaybackSpeed075Menu;
            }
            else if (speed <= 0.90)
            {
                checkItem = this.PlaybackSpeed090Menu;
            }
            else if (speed <= 1.00)
            {
                checkItem = this.PlaybackSpeed100Menu;
            }
            else if (speed <= 1.10)
            {
                checkItem = this.PlaybackSpeed110Menu;
            }
            else if (speed <= 1.25)
            {
                checkItem = this.PlaybackSpeed125Menu;
            }
            else if (speed <= 1.50)
            {
                checkItem = this.PlaybackSpeed150Menu;
            }
            else if (speed <= 1.75)
            {
                checkItem = this.PlaybackSpeed175Menu;
            }
            else
            {
                checkItem = this.PlaybackSpeed200Menu;
            }

            foreach(MenuItem menuItem in this.PlaybackSpeedsMenu.MenuItems)
            {
                menuItem.Checked = false;
            }
            checkItem.Checked = true;
        }

        /// <summary>
        /// ピッチシフターのピッチを設定する。
        /// </summary>
        /// <param name="freqOfA"></param>
        private void SetPitch(int semitones)
        {
            AudioPlayerManager.Pitch = semitones;

            // チェックすべきメニュー項目を取得する。
            MenuItem checkItem = null;
            foreach (MenuItem menuItem in this.PitchMenu.MenuItems)
            {
                if(menuItem.Tag != null)
                {
                    string text = semitones.ToString();

                    if(menuItem.Tag.ToString() == text)
                    {
                        checkItem = menuItem;
                        break;
                    }
                }
            }

            if(checkItem != null)
            {
                foreach(MenuItem menuItem in this.PitchMenu.MenuItems)
                {
                    if(menuItem != this.PitchMenuSeparator1 && menuItem != this.FixPitchClipMenu)
                    {
                        menuItem.Checked = false;
                    }
                }

                checkItem.Checked = true;
            }
        }

        /// <summary>
        /// SoundTouchのピッチシフターのピッチ変化量を設定する。
        /// </summary>
        /// <param name="semitones"></param>
        private void SetSoundTouchPitch(int semitones)
        {
            AudioPlayerManager.SoundTouchPitchSemitones = semitones;

            // チェックすべきメニュー項目を取得する。
            MenuItem checkItem = null;
            foreach (MenuItem menuItem in this.SoundTouchPitchMenu.MenuItems)
            {
                if (menuItem.Tag != null)
                {
                    string text = semitones.ToString();

                    if (menuItem.Tag.ToString() == text)
                    {
                        checkItem = menuItem;
                        break;
                    }
                }
            }

            if (checkItem != null)
            {
                foreach (MenuItem menuItem in this.SoundTouchPitchMenu.MenuItems)
                {
                    if (menuItem != this.STPitchMenuSeparator1 && menuItem != this.STPitchFixClipMenu)
                    {
                        menuItem.Checked = false;
                    }
                }

                checkItem.Checked = true;
            }
        }

        /// <summary>
        /// 再生
        /// </summary>
        public void Play()
        {
            if(this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.AudioTrackCount > 0)
            {
                if(this.CurrentPlaylistViewer.SelectedAudioTrack == null)
                {
                    this.CurrentPlaylistViewer.SelectedAudioTrack = this.CurrentPlaylistViewer.GetAudioTrack(0);
                }

                // 再生するトラックを取得して開く。
                var track = this.CurrentPlaylistViewer.SelectedAudioTrack;
                ShowTrackPicture(track);

                // トラックを開く。
                AudioPlayerManager.SetTrack(track);

                // シークバーの設定
                this.SeekBar.Maximum = (int)AudioPlayerManager.Duration;
                this.SeekBar.Value = 0;

                // 再生
                AudioPlayerManager.Play();

                // 後始末
                UpdateAudioWaveFormatStatusTextVisible();
                UpdateFormTitle();
            }
        }

        /// <summary>
        /// 前のトラックを再生
        /// </summary>
        public void PlayPreviousTrack()
        {
            if (this.CurrentPlaylistViewer != null)
            {
                // 前のトラックを取得して選択
                var track = this.CurrentPlaylistViewer.GetPreviousTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // 再生
                Play();
            }
        }

        /// <summary>
        /// 次のトラックを再生
        /// </summary>
        public void PlayNextTrack()
        {
            if (this.CurrentPlaylistViewer != null)
            {
                // 次のトラックを取得して選択
                var track = this.CurrentPlaylistViewer.GetNextTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // 再生
                Play();
            }
        }

        /// <summary>
        /// ランダムなトラックを再生する。
        /// </summary>
        public void PlayRandomTrack()
        {
            if(this.CurrentPlaylistViewer != null)
            {
                // ランダムなトラックを取得して選択
                var track = this.CurrentPlaylistViewer.GetRandomTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // 再生
                Play();
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            AudioPlayerManager.Stop();

            // 表示を更新
            UpdateAudioWaveFormatStatusTextVisible();
            UpdateFormTitle();
            SetTrackImageViewerVisible(false);

            // 後始末
            this.SeekBar.Value = 0;
        }

        /// <summary>
        /// 一時停止/再開
        /// </summary>
        public void PauseOrResume()
        {
            if (AudioPlayerManager.IsPausing)
            {
                AudioPlayerManager.Resume();
            }
            else
            {
                AudioPlayerManager.Pause();
            }
        }

        #endregion

        #region ウィンドウのメソッドのオーバーライド
        
        /// <summary>
        /// 読み込み時の処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // MainForm.Designer.csでメインメニューを設定すると、
            // メニューの高さだけフォーものサイズが増えてしまい、
            // ウィンドウサイズをコンフィグファイルに保存する際に不都合が生じる。
            // そこで、MainForm.Designer.csでメインメニューを設定するのではなく、
            // 敢えてフォームの読み込み時に設定するようにすることで、この問題を回避できる。
            base.Menu = this.MainMenu;

            // 元々の処理を実行。
            base.OnLoad(e);
        }

        #endregion

        /// <summary>
        /// メインフォームが読み込まれた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 各種設定値を表示に反映
            ApplyFormOptions();

            // デフォルトプレイリストを開く
            OpenDefaultPlaylist();

            if (this.commandLineArguments != null && this.commandLineArguments.Length > 0)
            {
                // コマンドライン引数で渡されたファイルを読み込む。
                foreach (string arg in this.commandLineArguments)
                {
                    if (File.Exists(arg))
                    {
                        OpenAnyFile(arg);
                    }
                }
            }

            // プレイリストブラウザを更新
            this.PlaylistBrowser.Update();
        }

        /// <summary>
        /// フォームを閉じたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 停止して解放
            AudioPlayerManager.Close();

            // デフォルトプレイリストを保存する。
            SavePlaylist(this.DefaultPlaylistViewer);

            var unsavedPlaylists = GetUnsavedPlaylistViewers();
            if(unsavedPlaylists.Length > 0)
            {
                var result = MessageBox.Show(
                    $"{unsavedPlaylists.Length} 個の未保存のプレイリストがあります。\n これらのプレイリストをすべて保存しますか？",
                    "保存確認",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    foreach(var playlist in unsavedPlaylists)
                    {
                        SavePlaylist(playlist);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 新規プレイリスト作成メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewPlaylistMenu_Click(object sender, EventArgs e)
        {
            CreateNewPlaylist();
        }

        /// <summary>
        /// 開くメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAnyFilesMenu_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = GetFileDialogFilter(true, true, true);

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                foreach(var path in dialog.FileNames)
                {
                    OpenAnyFile(path);
                }
            }

            // 後始末
            dialog.Dispose();
        }

        /// <summary>
        /// 現在のプレイリストに名前を付けて保存するメニューがクリックされた、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentPlaylistAsMenu_Click(object sender, EventArgs e)
        {
            SavePlaylistAs(this.CurrentPlaylistViewer);
        }

        /// <summary>
        /// 現在のプレイリストを保存するメニューがクリックされた、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentPlaylistMenu_Click(object sender, EventArgs e)
        {
            SavePlaylist(this.CurrentPlaylistViewer);
        }

        /// <summary>
        /// 全てのプレイリストを保存するメニューがクリックされた、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllPlaylistsMenu_Click(object sender, EventArgs e)
        {
            SaveAllPlaylists();
        }

        /// <summary>
        /// 再生メニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void PlayMenu_Clicked(object sender, EventArgs e)
        {
            Play();
        }

        /// <summary>
        /// 停止メニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMenu_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// 一時停止/再開メニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseOrResumeMenu_Click(object sender, EventArgs e)
        {
            PauseOrResume();
        }

        /// <summary>
        /// 前のトラックメニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousMenu_Click(object sender, EventArgs e)
        {
            PlayPreviousTrack();
        }

        /// <summary>
        /// 次のトラックメニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextMenu_Click(object sender, EventArgs e)
        {
            PlayNextTrack();
        }

        /// <summary>
        /// ランダムメニューが押された、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomMenu_Click(object sender, EventArgs e)
        {
            PlayRandomTrack();
        }

        /// <summary>
        /// プレイリストブラウザでプレイリストを開く操作を行った際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaylistBrowser_PlaylistOpenRequested(object sender, EventArgs e)
        {
            OpenPlaylist(this.PlaylistBrowser.SelectedPlaylistLocation);
        }

        /// <summary>
        /// 常に最前面に表示するメニューがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlwaysOnTopMenu_Click(object sender, EventArgs e)
        {
            this.AlwaysOnTop = !this.AlwaysOnTopMenu.Checked;
        }

        /// <summary>
        /// リピート方法メニューのうち、リピートしないメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoRepeatMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.NoRepeat;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// リピート方法メニューのうち、単曲リピートメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatSingleTrackMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.Single;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// リピート方法メニューのうち、全曲リピートメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatAllTracksMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.AllTracks;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// リピート方法メニューのうち、ランダムメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomRepeatMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.RandomTrack;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// プレイリストにフォルダを追加するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFolderToPlaylistMenu_Click(object sender, EventArgs e)
        {
            if(this.CurrentPlaylistViewer != null)
            {
                this.CurrentPlaylistViewer.ImportFolder();
            }
        }

        /// <summary>
        /// オーディオトラック検索メニューがクリックされた、またはそれと同等の操作が行われた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAudioTrackMenu_Click(object sender, EventArgs e)
        {
            SearchAudioTrack();
        }

        /// <summary>
        /// 次を検索メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAudioTrackNextMenu_Click(object sender, EventArgs e)
        {
            SearchAudioTrackNext();
        }

        /// <summary>
        /// バージョン情報メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowVersionInfoMenu_Click(object sender, EventArgs e)
        {
            this.ApplicationVersionDialog.ShowDialog();
        }

        /// <summary>
        /// アプリケーション終了メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApplicationMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 左側ツールパネルの表示設定を切り替える操作を行った際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLeftSideToolPanelMenu_Click(object sender, EventArgs e)
        {
            bool state = this.ShowLeftSideToolPanelMenu.Checked;

            this.ShowLeftSideToolPanel = !state;
        }

        /// <summary>
        /// 選択されたアイテムを1つ上に移動するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveUpSelectedItemMenu_Click(object sender, EventArgs e)
        {
            if(this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                this.CurrentPlaylistViewer.MoveUp(this.CurrentPlaylistViewer.SelectedAudioTrack);
            }
        }

        /// <summary>
        /// 選択されたアイテムを1つ下に移動するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveDownSelectedItemMenu_Click(object sender, EventArgs e)
        {
            if (this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                this.CurrentPlaylistViewer.MoveDown(this.CurrentPlaylistViewer.SelectedAudioTrack);
            }
        }

        /// <summary>
        /// 一覧から選択されたアイテムを除去するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSelectedItemFromListMenu_Click(object sender, EventArgs e)
        {
            if(this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                this.CurrentPlaylistViewer.DeleteItemFromList(this.CurrentPlaylistViewer.SelectedAudioTrack);
            }
        }

        /// <summary>
        /// 一覧から選択されたアイテムを除去し、ファイルも削除するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSelectedItemWithFileFromListMenu_Click(object sender, EventArgs e)
        {
            if (this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                this.CurrentPlaylistViewer.DeleteItemFromListWithFile(this.CurrentPlaylistViewer.SelectedAudioTrack);
            }
        }

        /// <summary>
        /// アイテムをすべて一覧から除去するメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAllItemsMenu_Click(object sender, EventArgs e)
        {
            if(this.CurrentPlaylistViewer != null)
            {
                this.CurrentPlaylistViewer.Clear();
            }
        }

        /// <summary>
        /// 詳細設定メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOptionsMenu_Click(object sender, EventArgs e)
        {
            this.DetailOptionDialog.ShowDialog();
        }

        /// <summary>
        /// 設定リセットメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAllOptionsMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("この操作を実行すると、アプリケーションの全ての設定と、\n" +
                "お気に入りプレイリストなどが初期化されます。\n" +
                "設定を初期化しますか？",
                "設定のリセット",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Program.ResetApplicationOptionRequested = true;

                MessageBox.Show("アプリケーションが再起動されます。", "再起動", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        /// <summary>
        /// サンプルレート変換メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SampleRateConversionMenu_Click(object sender, EventArgs e)
        {
            var result = this.SampleRateConversionDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                AudioPlayerManager.SetReSamplerOptions(
                    this.SampleRateConversionDialog.UseSampleRateConversion,
                    this.SampleRateConversionDialog.SampleRate,
                    this.SampleRateConversionDialog.BitsPerSample,
                    this.SampleRateConversionDialog.Channels);
            }
        }

        /// <summary>
        /// クイック検索ボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickSearchbutton_Click(object sender, EventArgs e)
        {
            SearchAudioTrack(this.SearchBox.Text);
        }

        /// <summary>
        /// 音量スライダの値が変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            AudioPlayerManager.Volume = this.VolumeSlider.Value;
        }

        /// <summary>
        /// ReadMe表示メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReadMeMenu_Click(object sender, EventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\ReadMe.txt");
        }

        /// <summary>
        /// 更新履歴表示メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHistoryMenu_Click(object sender, EventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\History.txt");
        }

        /// <summary>
        /// イコライザメニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualizerMenu_Click(object sender, EventArgs e)
        {
            this.EqualizerDialog.ShowDialog();
        }

        /// <summary>
        /// 再生速度メニュー内のn倍速メニューがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackSpeedMenu_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var rate = float.Parse(menuItem.Tag.ToString());

            SetPlaybackSpeed(rate);
        }

        /// <summary>
        /// ピッチシフターのピッチ変化量メニューがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PitchMenu_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var pitch = int.Parse(menuItem.Tag.ToString());

            SetPitch(pitch);
        }

        /// <summary>
        /// オーディオの詳細情報メニューがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAudioOutputInfoMenu_Click(object sender, EventArgs e)
        {
            this.AudioOutputInfoDialog.ShowDialog();
        }

        /// <summary>
        /// SoundTouchによるピッチシフターのピッチ変化量メニューがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoundTouchPitchMenu_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var pitch = int.Parse(menuItem.Tag.ToString());

            SetSoundTouchPitch(pitch);
        }

        private void ShowInTaskTrayMenu_Click(object sender, EventArgs e)
        {
            this.ShowInTaskTrayMenu.Checked = !this.ShowInTaskTrayMenu.Checked;
            this.ShowInTaskTray = this.ShowInTaskTrayMenu.Checked;
        }

        private void ShowAsNormalWindowTaskTrayMenu_Click(object sender, EventArgs e)
        {
            this.ShowInTaskTrayMenu.Checked = false;
            this.ShowInTaskTray = false;
        }

        private void ShowAsMiniplayerModeMenu_Click(object sender, EventArgs e)
        {
            this.ShowAsMiniplayerModeMenu.Checked = !this.ShowAsMiniplayerModeMenu.Checked;
            this.ShowAsMiniplayerMode = this.ShowAsMiniplayerModeMenu.Checked;
        }

        private void PanSlider_ValueChanged(object sender, EventArgs e)
        {
            AudioPlayerManager.Pan = this.PanSlider.Value;
        }

        private void ResetPanButton_Click(object sender, EventArgs e)
        {
            this.PanSlider.Value = 0;
        }
    }
}