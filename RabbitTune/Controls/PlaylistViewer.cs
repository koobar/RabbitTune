using RabbitTune.AudioEngine;
using RabbitTune.Dialogs;
using RabbitTune.MediaLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public partial class PlaylistViewer : UserControl
    {
        // 非公開定数
        private const string COLUMN_HEADER_TEXT_TITLE = @"タイトル";
        private const string COLUMN_HEADER_TEXT_ALBUM = @"アルバム";
        private const string COLUMN_HEADER_TEXT_ARTIST = @"アーティスト";
        private const string COLUMN_HEADER_TEXT_ALBUMARTIST = @"アルバムアーティスト";
        private const string COLUMN_HEADER_TEXT_YEAR = @"年";
        private const string COLUMN_HEADER_TEXT_GENRE = @"ジャンル";
        private const string COLUMN_HEADER_TEXT_COMPOSER = @"作曲者";
        private const string COLUMN_HEADER_TEXT_TRACKNUM = @"トラック番号";
        private const string COLUMN_HEADER_TEXT_DURATION = @"演奏時間";
        private const string COLUMN_HEADER_TEXT_BITRATE = @"ビットレート";
        private const string COLUMN_HEADER_TEXT_SAMPLERATE = @"サンプルレート";
        private const string COLUMN_HEADER_TEXT_FILEFORMAT = @"ファイルの種類";

        // ビューワーの列のヘッダ一覧
        private readonly List<string> ColumnHeaders = new List<string>()
        {
            COLUMN_HEADER_TEXT_TITLE,
            COLUMN_HEADER_TEXT_ALBUM,
            COLUMN_HEADER_TEXT_ARTIST,
            COLUMN_HEADER_TEXT_ALBUMARTIST,
            COLUMN_HEADER_TEXT_YEAR,
            COLUMN_HEADER_TEXT_GENRE,
            COLUMN_HEADER_TEXT_COMPOSER,
            COLUMN_HEADER_TEXT_TRACKNUM,
            COLUMN_HEADER_TEXT_DURATION,
            COLUMN_HEADER_TEXT_BITRATE,
            COLUMN_HEADER_TEXT_SAMPLERATE,
            COLUMN_HEADER_TEXT_FILEFORMAT
        };

        // コンテキストメニュー
        private readonly ContextMenuStrip AudioTracksViewerContextMenu = new ContextMenuStrip();
        private readonly ToolStripMenuItem PlayContextMenu = new ToolStripMenuItem();
        private readonly ToolStripSeparator ContextMenuSeparator1 = new ToolStripSeparator();
        private readonly ToolStripMenuItem ReloadContextMenu = new ToolStripMenuItem();
        private readonly ToolStripSeparator ContextMenuSeparator2 = new ToolStripSeparator();
        private readonly ToolStripMenuItem MoveUpContextMenu = new ToolStripMenuItem();
        private readonly ToolStripMenuItem MoveDownContextMenu = new ToolStripMenuItem();
        private readonly ToolStripSeparator ContextMenuSeparator3 = new ToolStripSeparator();
        private readonly ToolStripMenuItem DeleteItemFromListMenu = new ToolStripMenuItem();
        private readonly ToolStripMenuItem DeleteItemFromListWithFileMenu = new ToolStripMenuItem();
        private readonly ToolStripSeparator ContextMenuSeparator4 = new ToolStripSeparator();
        private readonly ToolStripMenuItem OpenAudioTrackLocationMenu = new ToolStripMenuItem();

        // 非公開フィールド
        private ListViewColumnSorter AudioTracksViewerSorter;
        private string LatestSearchText;                        // 最後に検索したテキスト
        private int LatestSearchResultIndex;                    // 最後に検索した際の検索結果のインデックス

        // イベント
        public event EventHandler AudioTrackDoubleClicked;
        public event EventHandler SelectedAudioTrackChanged;
        public event EventHandler CurrentPlaylistChanged;
        public event EventHandler PlaylistChanged;
        public event EventHandler PlayCommandInvoked;

        // コンストラクタ
        public PlaylistViewer()
        {
            InitializeComponent();

            this.CurrentPlaylist = new Playlist();
            this.AudioTracksViewerSorter = new ListViewColumnSorter();
            this.AudioTracksViewer.ListViewItemSorter = this.AudioTracksViewerSorter;
            this.PlaylistChanged += delegate
            {
                this.IsChanged = true;
            };
            this.Font = SystemFonts.CaptionFont;

            // 後始末
            CreateContextMenu();
            ShowColumns();
            UpdatePlaylistName();
            UpdateColumnSize();
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public new void Dispose()
        {
            this.AudioTracksViewer.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// コンテキストメニューを作成する。
        /// </summary>
        private void CreateContextMenu()
        {
            // メニュー表示時のイベントを作成
            this.AudioTracksViewerContextMenu.Opening += delegate
            {
                bool anyItemSelected = this.SelectedAudioTrack != null;

                this.PlayContextMenu.Enabled = anyItemSelected;
                this.MoveUpContextMenu.Enabled = anyItemSelected;
                this.MoveDownContextMenu.Enabled = anyItemSelected;
                this.DeleteItemFromListMenu.Enabled = anyItemSelected;
                this.DeleteItemFromListWithFileMenu.Enabled = anyItemSelected;
                this.OpenAudioTrackLocationMenu.Enabled = anyItemSelected;
            };

            // メニュー項目の作成
            this.PlayContextMenu.Text = "再生";
            this.PlayContextMenu.Click += delegate
            {
                this.PlayCommandInvoked?.Invoke(null, null);
            };
            this.ReloadContextMenu.Text = "最新の状態に更新";
            this.ReloadContextMenu.ShortcutKeys = Keys.F5;
            this.ReloadContextMenu.Click += delegate
            {
                Reload();
            };
            this.MoveUpContextMenu.Text = "1つ上に移動";
            this.MoveUpContextMenu.Click += delegate
            {
                if (this.SelectedAudioTrack != null)
                {
                    MoveUp(this.SelectedAudioTrack);
                }
            };
            this.MoveDownContextMenu.Text = "1つ下に移動";
            this.MoveDownContextMenu.Click += delegate
            {
                if (this.SelectedAudioTrack != null)
                {
                    MoveDown(this.SelectedAudioTrack);
                }
            };
            this.DeleteItemFromListMenu.Text = "アイテムを一覧から削除";
            this.DeleteItemFromListMenu.Click += delegate
            {
                if(this.SelectedAudioTrack != null)
                {
                    DeleteItemFromList(this.SelectedAudioTrack);
                }
            };
            this.DeleteItemFromListWithFileMenu.Text = "アイテムをファイルごと削除";
            this.DeleteItemFromListWithFileMenu.Click += delegate
            {
                if(this.SelectedAudioTrack != null)
                {
                    DeleteItemFromListWithFile(this.SelectedAudioTrack);
                }
            };
            this.OpenAudioTrackLocationMenu.Text = "エクスプローラーで開く";
            this.OpenAudioTrackLocationMenu.Click += delegate
            {
                if (this.SelectedAudioTrack != null)
                {
                    Process.Start("explorer.exe", $"/e,/select,\"{this.SelectedAudioTrack.Location}\"");
                }
            };
            
            // メニュー項目の追加
            this.AudioTracksViewerContextMenu.Items.Add(this.PlayContextMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.ContextMenuSeparator1);
            this.AudioTracksViewerContextMenu.Items.Add(this.ReloadContextMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.ContextMenuSeparator2);
            this.AudioTracksViewerContextMenu.Items.Add(this.MoveUpContextMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.MoveDownContextMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.ContextMenuSeparator3);
            this.AudioTracksViewerContextMenu.Items.Add(this.DeleteItemFromListMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.DeleteItemFromListWithFileMenu);
            this.AudioTracksViewerContextMenu.Items.Add(this.ContextMenuSeparator4);
            this.AudioTracksViewerContextMenu.Items.Add(this.OpenAudioTrackLocationMenu);

            // コンテキストメニューを設定
            this.AudioTracksViewer.ContextMenuStrip = this.AudioTracksViewerContextMenu;
        }

        #region プロパティ

        /// <summary>
        /// プレイリスト
        /// </summary>
        public Playlist CurrentPlaylist { set; get; }

        /// <summary>
        /// 表示されるトラック数
        /// </summary>
        public int AudioTrackCount
        {
            get
            {
                return this.AudioTracksViewer.Items.Count;
            }
        }

        /// <summary>
        /// 選択されたトラック
        /// </summary>
        public AudioTrack SelectedAudioTrack
        {
            get
            {
                if (this.AudioTracksViewer.SelectedItems.Count > 0)
                {
                    var item = this.AudioTracksViewer.SelectedItems[0];

                    if (item.Tag != null)
                    {
                        return (AudioTrack)item.Tag;
                    }
                }

                return null;
            }
            set
            {
                foreach (ListViewItem item in this.AudioTracksViewer.Items)
                {
                    if (item.Tag != null && item.Tag.GetType() == typeof(AudioTrack))
                    {
                        if (item.Tag == value)
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }

                // 選択されたアイテムの位置までスクロールする。
                ScrollToSelectedItem();
            }
        }

        /// <summary>
        /// 選択されたトラックの一覧
        /// </summary>
        public AudioTrack[] SelectedAudioTracks
        {
            get
            {
                int cnt = this.AudioTracksViewer.SelectedItems.Count;

                if (cnt > 0)
                {
                    var tracks = new AudioTrack[cnt];

                    for (int i = 0; i < cnt; ++i)
                    {
                        tracks[i] = (AudioTrack)this.AudioTracksViewer.SelectedItems[i].Tag;
                    }

                    return tracks;
                }

                return null;
            }
            set
            {
                foreach (var track in value)
                {
                    foreach (ListViewItem item in this.AudioTracksViewer.Items)
                    {
                        if (item.Tag != null && item.Tag.GetType() == typeof(AudioTrack))
                        {
                            if (item.Tag == track)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }

                // 選択されたアイテムの位置までスクロールする。
                ScrollToSelectedItem();
            }
        }

        /// <summary>
        /// 選択されたインデックス
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                if(this.AudioTracksViewer.SelectedIndices.Count > 0)
                {
                    return this.AudioTracksViewer.SelectedIndices[0];
                }

                return -1;
            }
            set
            {
                var track = GetAudioTrack(value);

                if(track != null)
                {
                    this.SelectedAudioTrack = track;
                }
            }
        }

        /// <summary>
        /// 列のヘッダがクリックされた際に、その列の内容でソートするかどうか（既定はtrue）
        /// </summary>
        public bool SortWhenColumnHeaderClicked{ set; get; } = true;

        /// <summary>
        /// プレイリストに保存されていない変更点が存在するかどうか
        /// </summary>
        public bool IsChanged { private set; get; }

        /// <summary>
        /// プレイリスト名
        /// </summary>
        public string PlaylistName { set; get; }

        #endregion

        #region スクロール

        /// <summary>
        /// 選択されたアイテムの位置までスクロールする。
        /// </summary>
        public void ScrollToSelectedItem()
        {
            ScrollTo(this.SelectedIndex);
        }

        /// <summary>
        /// 指定されたインデックスのアイテムの位置までスクロールする。
        /// </summary>
        /// <param name="index"></param>
        public void ScrollTo(int index)
        {
            if (index > -1 && index < this.AudioTrackCount)
            {
                this.AudioTracksViewer.EnsureVisible(index);
            }
        }

        #endregion

        #region オーディオトラックの操作

        #region プレイリストに直接変更を加えるメソッド

        /// <summary>
        /// 現在のプレイリストにトラックを追加する
        /// </summary>
        /// <param name="track"></param>
        public void AddTrackToPlaylist(AudioTrack track)
        {
            this.CurrentPlaylist.Tracks.Add(track);

            // 更新処理
            UpdateView();
            this.PlaylistChanged?.Invoke(null, null);
        }

        /// <summary>
        /// 全てのトラックをプレイリストと表示から削除する。
        /// </summary>
        public void Clear()
        {
            // 全てのトラックを一覧から削除
            foreach(var track in GetAudioTracks())
            {
                DeleteItemFromList(track, false);
            }
            this.CurrentPlaylist.Tracks.Clear();

            // 表示を更新する。
            UpdateColumnSize();

            // イベントの実行
            this.PlaylistChanged?.Invoke(null, null);
        }

        /// <summary>
        /// 指定されたトラックをプレイリストと表示から削除する。
        /// </summary>
        /// <param name="track"></param>
        /// <param name="autoUpdate"></param>
        public void DeleteItemFromList(AudioTrack track, bool autoUpdate = true)
        {
            this.AudioTracksViewer.SuspendLayout();

            if (track != null)
            {
                this.CurrentPlaylist.Tracks.Remove(track);

                // 削除
                var item = GetListViewItem(track, out _);
                this.AudioTracksViewer.Items.Remove(item);
                this.CurrentPlaylist.Tracks.Remove(track);

                // 自動更新が有効か？
                if (autoUpdate)
                {
                    UpdateColumnSize();
                }

                // イベントの実行
                this.PlaylistChanged?.Invoke(null, null);
            }

            this.AudioTracksViewer.ResumeLayout();
        }

        /// <summary>
        /// 指定されたトラックをプレイリストと表示から削除し、さらにファイルも削除する。
        /// </summary>
        /// <param name="track"></param>
        /// <param name="autoUpdate"></param>
        public void DeleteItemFromListWithFile(AudioTrack track, bool autoUpdate = true)
        {
            this.AudioTracksViewer.SuspendLayout();

            if (track != null)
            {
                // 削除
                var item = GetListViewItem(track, out _);
                this.AudioTracksViewer.Items.Remove(item);
                this.CurrentPlaylist.Tracks.Remove(track);

                // ファイルを削除
                if (File.Exists(track.Location))
                {
                    File.Delete(track.Location);
                }

                // 自動更新が有効か？
                if (autoUpdate)
                {
                    UpdateColumnSize();
                }

                // イベントの実行
                this.PlaylistChanged?.Invoke(null, null);
            }

            // 後始末
            this.AudioTracksViewer.ResumeLayout();
        }

        #endregion

        #region メソッドを呼び出した時点でプレイリストそのものを変更しないが、保存する際に変更されるメソッド

        /// <summary>
        /// オーディオトラックを一覧に追加する。
        /// </summary>
        /// <param name="track"></param>
        private void AddAudioTrackToView(AudioTrack track, bool autoUpdate = true, bool invokeChangedEvent = true)
        {
            // 高速化の為、一時的に描画を停止する。
            this.AudioTracksViewer.BeginUpdate();

            // アイテムを追加
            var item = AudioTrackToListViewItem(track);
            this.AudioTracksViewer.Items.Add(item);

            // 自動更新が有効か？
            if (autoUpdate)
            {
                // 各列のサイズを調整
                UpdateColumnSize();
            }

            // 描画を再開
            this.AudioTracksViewer.EndUpdate();

            if (invokeChangedEvent)
            {
                // イベントの実行
                this.PlaylistChanged?.Invoke(null, null);
            }
        }

        /// <summary>
        /// 与えられたトラックをすべてビューに追加する。
        /// </summary>
        /// <param name="tracks"></param>
        /// <param name="autoUpdate"></param>
        private void AddAudioTracksToView(IList<AudioTrack> tracks, bool autoUpdate = true, bool invokeChangedEvent = true)
        {
            // 高速化の為、一時的に描画を停止する。
            this.AudioTracksViewer.BeginUpdate();

            // AudioTrackをListViewItemに変換する。
            var items = new ListViewItem[tracks.Count];
            for (int i = 0; i < tracks.Count; ++i)
            {
                items[i] = AudioTrackToListViewItem(tracks[i]);
            }

            // アイテムを追加する。
            this.AudioTracksViewer.Items.AddRange(items);

            // 自動更新が有効か？
            if (autoUpdate)
            {
                // 各列のサイズを調整
                UpdateColumnSize();
            }

            if (invokeChangedEvent)
            {
                // イベントの実行
                this.PlaylistChanged?.Invoke(null, null);
            }

            this.AudioTracksViewer.EndUpdate();
        }

        /// <summary>
        /// すべてのトラックを表示から削除する。<br/>
        /// プレイリストそのものからは削除せず、表示のみを削除する。
        /// </summary>
        public void ClearView()
        {
            this.AudioTracksViewer.Items.Clear();
        }

        /// <summary>
        /// 指定されたトラックのアイテムを1つ上に移動する。
        /// </summary>
        /// <param name="track"></param>
        public void MoveUp(AudioTrack track)
        {
            GetListViewItem(track, out var oldIndex);
            MoveItem(oldIndex, -1);
        }

        /// <summary>
        /// 指定されたトラックのアイテムを1つ下に移動する。
        /// </summary>
        /// <param name="track"></param>
        public void MoveDown(AudioTrack track)
        {
            GetListViewItem(track, out var oldIndex);
            MoveItem(oldIndex, 1);
        }

        /// <summary>
        /// 指定されたインデックスのアイテムを指定された方向へ移動する。
        /// </summary>
        /// <param name="oldIndex"></param>
        /// <param name="direction"></param>
        public void MoveItem(int oldIndex, int direction)
        {
            this.AudioTracksViewer.SuspendLayout();

            // 移動先のインデックスを計算
            int newIndex = oldIndex + direction;

            // 移動先のインデックスが有効な範囲内ではないか？
            if (newIndex < 0 || newIndex >= this.AudioTrackCount)
            {
                return;
            }

            var item = this.AudioTracksViewer.Items[oldIndex];

            // 移動前のアイテムを削除
            this.AudioTracksViewer.Items.Remove(item);

            // 移動先インデックスに移動前のアイテムを挿入
            this.AudioTracksViewer.Items.Insert(newIndex, item);

            if (item.Selected)
            {
                // 選択状態を復元
                this.SelectedIndex = newIndex;
            }

            // 後始末
            this.AudioTracksViewer.ResumeLayout();
            this.PlaylistChanged?.Invoke(null, null);
        }

        #endregion

        #region プレイリストそのものに影響しないメソッド

        /// <summary>
        /// プレイリストを最新の状態に更新する。
        /// </summary>
        public void Reload()
        {
            if (this.CurrentPlaylist != null)
            {
                Clear();
                OpenPlaylist(this.CurrentPlaylist.Location);
            }
        }

        /// <summary>
        /// 指定されたインデックスのオーディオトラックを取得する。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AudioTrack GetAudioTrack(int index)
        {
            if (index > -1 && index < this.AudioTrackCount)
            {
                return (AudioTrack)this.AudioTracksViewer.Items[index].Tag;
            }

            return null;
        }

        /// <summary>
        /// 指定されたパスのオーディオトラックを取得する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AudioTrack GetAudioTrack(string path)
        {
            foreach(ListViewItem item in this.AudioTracksViewer.Items)
            {
                var trk = (AudioTrack)item.Tag;

                if(trk.Location.ToLower() == path.ToLower())
                {
                    return trk;
                }
            }

            return null;
        }

        /// <summary>
        /// 現在のプレイリストに含まれるすべてのオーディオトラックを取得する。<br/>
        /// （保存されていない変更点も含むすべてのオーディオトラックを取得する。）
        /// </summary>
        /// <returns></returns>
        public List<AudioTrack> GetAudioTracks()
        {
            var tracks = new List<AudioTrack>();

            foreach (ListViewItem item in this.AudioTracksViewer.Items)
            {
                tracks.Add((AudioTrack)item.Tag);
            }

            return tracks;
        }

        /// <summary>
        /// 現在のトラックから1つ前のトラックを取得して返す。
        /// </summary>
        /// <returns></returns>
        public AudioTrack GetPreviousTrack()
        {
            int index = this.SelectedIndex - 1;

            if (index < 0)
            {
                index = this.AudioTrackCount - 1;
            }

            return GetAudioTrack(index);
        }

        /// <summary>
        /// 現在のトラックから1つ次のトラックを取得して返す。
        /// </summary>
        /// <returns></returns>
        public AudioTrack GetNextTrack()
        {
            int index = this.SelectedIndex + 1;

            if (index >= this.AudioTrackCount)
            {
                index = 0;
            }

            return GetAudioTrack(index);
        }

        /// <summary>
        /// ランダムにトラックを取得して返す。
        /// </summary>
        /// <returns></returns>
        public AudioTrack GetRandomTrack()
        {
            var rand = new Random(Environment.TickCount);
            var idx = rand.Next(0, this.AudioTrackCount - 1);

            return GetAudioTrack(idx);
        }

        /// <summary>
        /// 指定された検索語句と検索オプションに当てはまるトラックを取得する。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="judgeBiggerOrLower"></param>
        /// <param name="searchAllMatchOnly"></param>
        /// <returns></returns>
        public AudioTrack Search(string text, bool judgeBiggerOrLower, bool searchAllMatchOnly)
        {
            return SearchAudioTrack(text, judgeBiggerOrLower, searchAllMatchOnly, 0, this.AudioTrackCount);
        }

        /// <summary>
        /// 直前の検索時の検索語句と同じ検索語句の場合、直前の検索結果の位置を開始位置として検索を行う。<br/>
        /// 直前の検索時の検索語句と異なる検索語句が指定された場合、開始位置を0として（つまり、最初から）検索する。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="judgeBiggerOrLower"></param>
        /// <param name="searchAllMatchOnly"></param>
        /// <returns></returns>
        public AudioTrack SearchNext(string text, bool judgeBiggerOrLower, bool searchAllMatchOnly)
        {
            return SearchAudioTrack(text, judgeBiggerOrLower, searchAllMatchOnly, this.LatestSearchResultIndex + 1, this.AudioTrackCount);
        }

        /// <summary>
        /// 指定された検索語句と検索オプションに当てはまるトラックを取得する。
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private AudioTrack SearchAudioTrack(string titleSearchText, bool judgeBiggerOrLower, bool searchAllMatchOnly, int begin, int end)
        {
            if(this.LatestSearchText != titleSearchText)
            {
                this.LatestSearchText = titleSearchText;
                this.LatestSearchResultIndex = 0;
            }

            // 大文字と小文字を判別するオプションが無効か？
            if (!judgeBiggerOrLower)
            {
                titleSearchText = titleSearchText.ToLower();
            }

            int result = -1;
            var tracks = GetAudioTracks();

            for(int i = begin; i < end; ++i)
            {
                var track = tracks[i];

                if(track != null)
                {
                    string trackTitle = !judgeBiggerOrLower ? track.Title.ToLower() : track.Title;

                    // 完全一致のみ検索するオプションが有効か？
                    if (searchAllMatchOnly)
                    {
                        // タイトルと完全一致するか？
                        if(titleSearchText == trackTitle)
                        {
                            result = i;
                            break;
                        }
                    }
                    else
                    {
                        // キーワードのリストを取得。
                        // ex) 「米 品種」-> 「米」,「品種」の2つのキーワードとして扱う。
                        var words = titleSearchText.Split(' ', '　', '\t');

                        // キーワードリストのうちどれか1つでも含んでいるか？
                        foreach(string word in words)
                        {
                            if (trackTitle.IndexOf(word) != -1)
                            {
                                result = i;
                                break;
                            }
                        }
                    }
                }

                // 条件に一致するトラックが検出されたか？
                if (result != -1)
                {
                    break;
                }
            }

            if (result > -1)
            {
                this.LatestSearchText = titleSearchText;
                this.LatestSearchResultIndex = result;
                return GetAudioTrack(result);
            }

            return null;
        }

        #endregion

        #endregion

        #region プレイリストファイル出入力やファイルパス取得など、ファイルに関連する処理

        /// <summary>
        /// 現在開いているプレイリストのパスを取得する。<br/>
        /// プレイリストを開いていない場合や未保存の場合は、nullを返す。
        /// </summary>
        /// <returns></returns>
        public string GetPlaylistFilePath()
        {
            if(this.CurrentPlaylist == null)
            {
                return null;
            }

            return this.CurrentPlaylist.Location;
        }

        /// <summary>
        /// 指定された場所のプレイリストを開く
        /// </summary>
        /// <param name="path"></param>
        public void OpenPlaylist(string path)
        {
            var reader = new PlaylistReader(path, AudioReader.GetAllSupportedFormatExtensions());

            if (reader.Playlist != null)
            {
                // ファイル名等の設定
                this.CurrentPlaylist = reader.Playlist;
                UpdatePlaylistName();

                // 読み込んだトラックの一覧を表示に追加
                AddAudioTracksToView(this.CurrentPlaylist.Tracks, true, false);

                // 最近開いたプレイリストの一覧に追加
                PlaylistsDataBase.AddRecentPlaylist(path);

                // イベントの実行
                this.CurrentPlaylistChanged?.Invoke(null, null);

                // 読み込まれなかったファイルが存在するか？
                if (this.CurrentPlaylist.NotFoundFiles != null && this.CurrentPlaylist.NotFoundFiles.Count > 0)
                {
                    var mes = new StringBuilder();
                    mes.AppendLine($"{this.CurrentPlaylist.TrackCount} 個のファイルが、利用可能な場所に存在しなかったため、読み込まれませんでした。");
                    mes.AppendLine("読み込みがスキップされたファイルは、以下の通りです。");

                    foreach (string skipped in this.CurrentPlaylist.NotFoundFiles)
                    {
                        mes.AppendLine($"　{skipped}");
                    }

                    MessageBox.Show(mes.ToString(), $"{this.CurrentPlaylist.NotFoundFiles.Count} 個のファイルの読み込みに失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"プレイリスト '{Path.GetFileName(path)}' の読み込みに失敗しました。\n" +
                    $"ファイルが存在するか、または、破損していないかご確認ください。",
                    "プレイリストの読み込み失敗",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 指定された場所にプレイリストを保存する。
        /// </summary>
        /// <param name="path"></param>
        public void SavePlaylist(string path)
        {
            var writer = new PlaylistWriter(path);

            // 保存
            writer.Save(this.CurrentPlaylist);

            // プレイリスト名を更新する
            UpdatePlaylistName();

            // イベントの実行
            this.CurrentPlaylistChanged?.Invoke(null, null);
            this.IsChanged = false;
        }

        /// <summary>
        /// プレイリストを上書き保存する。
        /// </summary>
        public void SavePlaylist()
        {
            string path = GetPlaylistFilePath();

            if (string.IsNullOrEmpty(path))
            {
                // 名前を付けて保存
                SavePlaylistAs();
            }
            else
            {
                // 上書き保存
                SavePlaylist(path);
            }
        }

        /// <summary>
        /// 保存先を選択してプレイリストを保存
        /// </summary>
        public void SavePlaylistAs()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = GetDialogFilter();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePlaylist(dialog.FileName);
            }

            // 後始末
            dialog.Dispose();
        }

        /// <summary>
        /// 指定されたパスのフォルダをインポート
        /// </summary>
        /// <param name="path"></param>
        public void ImportFolder(string path)
        {
            if (Directory.Exists(path))
            {
                var tracks = AudioTrackReader.ReadFolder(path, AudioReader.GetAllSupportedFormatExtensions());
                AddAudioTracksToView(tracks);
            }
        }

        /// <summary>
        /// フォルダを選択してインポート
        /// </summary>
        public void ImportFolder()
        {
            var dialog = new FolderSelectDialog();
            dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            if(dialog.ShowDialog(null) == DialogResult.OK)
            {
                ImportFolder(dialog.SelectedPath);
            }
        }

        #endregion

        #region 列のヘッダに関連するメソッド

        /// <summary>
        /// 列のヘッダをすべて表示する。
        /// </summary>
        private void ShowColumns()
        {
            // 念のため
            this.AudioTracksViewer.Columns.Clear();

            // 一覧を追加
            foreach (var column in this.ColumnHeaders)
            {
                var ch = new ColumnHeader();
                ch.Text = column;

                // 追加
                this.AudioTracksViewer.Columns.Add(ch);
            }
        }

        /// <summary>
        /// 列のヘッダを並び替える。
        /// </summary>
        /// <param name="src">入れ替える列のヘッダのテキスト</param>
        /// <param name="dst">入れ替え先の列のヘッダのテキスト</param>
        /// <param name="autoUpdate"></param>
        public void ReOrderColumnHeader(string src, string dst, bool autoUpdate = true)
        {
            int index = this.ColumnHeaders.IndexOf(src);
            int newIndex = this.ColumnHeaders.IndexOf(dst);

            if (index != -1 && newIndex != -1)
            {
                ReOrderColumnHeader(index, newIndex, autoUpdate);
            }
        }

        /// <summary>
        /// 列のヘッダを並び替える。
        /// </summary>
        /// <param name="text">入れ替える列のヘッダのテキスト</param>
        /// <param name="newIndex">入れ替え先のインデックス</param>
        /// <param name="autoUpdate"></param>
        public void ReOrderColumnHeader(string text, int newIndex, bool autoUpdate = true)
        {
            int index = this.ColumnHeaders.IndexOf(text);

            if (index != -1)
            {
                ReOrderColumnHeader(index, newIndex, autoUpdate);
            }
        }

        /// <summary>
        /// 列のヘッダを並び替える。
        /// </summary>
        /// <param name="index">入れ替える列のインデックス</param>
        /// <param name="newIndex">入れ替え先のインデックス</param>
        /// <param name="autoUpdate"></param>
        public void ReOrderColumnHeader(int index, int newIndex, bool autoUpdate = true)
        {
            var tmp = this.ColumnHeaders[newIndex];

            // 入れ替え
            this.ColumnHeaders[newIndex] = this.ColumnHeaders[index];
            this.ColumnHeaders[index] = tmp;

            // 入れ替え処理毎に表示を更新するか？
            if (autoUpdate)
            {
                ShowColumns();
                UpdateColumnSize();
            }
        }

        #endregion

        #region 更新

        /// <summary>
        /// 表示の列のサイズを自動調節する。
        /// </summary>
        private void UpdateColumnSize()
        {
            // すべての列のサイズを自動調節する。
            foreach (ColumnHeader columnHeader in this.AudioTracksViewer.Columns)
            {
                columnHeader.Width = -2;
            }
        }

        /// <summary>
        /// プレイリスト名を更新する。
        /// </summary>
        /// <param name="isFile"></param>
        /// <param name="isDirectory"></param>
        /// <param name="isDiscDrive"></param>
        /// <param name="path"></param>
        /// <param name="driveInfo"></param>
        private void UpdatePlaylistName()
        {
            if (this.CurrentPlaylist != null)
            {
                if (this.CurrentPlaylist.IsNew)
                {
                    this.PlaylistName = "新規プレイリスト";
                }
                else if (this.CurrentPlaylist.IsFile || this.CurrentPlaylist.IsDirectory)
                {
                    this.PlaylistName = Path.GetFileName(this.CurrentPlaylist.Location);
                }
                else if (this.CurrentPlaylist.IsDiscDrive)
                {
                    if (string.IsNullOrEmpty(this.CurrentPlaylist.DriveInfo.VolumeLabel))
                    {
                        this.PlaylistName = this.CurrentPlaylist.DriveInfo.VolumeLabel;
                    }
                    else
                    {
                        this.PlaylistName = this.CurrentPlaylist.DriveInfo.Name;
                    }
                }
                else
                {
                    this.PlaylistName = string.Empty;
                }
            }
        }

        /// <summary>
        /// プレイリスト(Playlistプロパティなど)を介して、直接プレイリストに加えた変更を表示に反映する。
        /// </summary>
        public void UpdateView()
        {
            ClearView();
            AddAudioTracksToView(this.CurrentPlaylist.Tracks, false, false);

            UpdateColumnSize();
        }

        #endregion

        #region 裏方メソッド

        /// <summary>
        /// AudioTrackをListViewItemに変換して返す。
        /// </summary>
        /// <param name="audioTrack"></param>
        /// <returns></returns>
        private ListViewItem AudioTrackToListViewItem(AudioTrack audioTrack)
        {
            var contents = new List<string>();

            // 各列に表示する項目を表示順で取得。
            foreach (var column in this.ColumnHeaders)
            {
                switch (column)
                {
                    case COLUMN_HEADER_TEXT_TITLE:
                        contents.Add(stringContentToDisplayText(audioTrack.Title));
                        break;
                    case COLUMN_HEADER_TEXT_ALBUM:
                        contents.Add(stringContentToDisplayText(audioTrack.Album));
                        break;
                    case COLUMN_HEADER_TEXT_ARTIST:
                        contents.Add(stringContentToDisplayText(audioTrack.Artist));
                        break;
                    case COLUMN_HEADER_TEXT_ALBUMARTIST:
                        contents.Add(stringContentToDisplayText(audioTrack.AlbumArtist));
                        break;
                    case COLUMN_HEADER_TEXT_BITRATE:
                        contents.Add(bitRateContentToDisplayText(audioTrack.Bitrate));
                        break;
                    case COLUMN_HEADER_TEXT_COMPOSER:
                        contents.Add(stringContentToDisplayText(audioTrack.Composer));
                        break;
                    case COLUMN_HEADER_TEXT_DURATION:
                        contents.Add(timeSpanContentToDisplayText(audioTrack.Duration));
                        break;
                    case COLUMN_HEADER_TEXT_FILEFORMAT:
                        contents.Add(getFileFormatName());
                        break;
                    case COLUMN_HEADER_TEXT_GENRE:
                        contents.Add(genreContentToDisplayText(audioTrack.Genre));
                        break;
                    case COLUMN_HEADER_TEXT_SAMPLERATE:
                        contents.Add(sampleRateContentToDisplayText(audioTrack.SampleRate));
                        break;
                    case COLUMN_HEADER_TEXT_TRACKNUM:
                        contents.Add(intContentToDisplayText(audioTrack.TrackNumber));
                        break;
                    case COLUMN_HEADER_TEXT_YEAR:
                        contents.Add(intContentToDisplayText(audioTrack.Year));
                        break;
                }
            }

            // ListViewItemに変換して返す。
            var item = new ListViewItem(contents.ToArray());
            item.Tag = audioTrack;
            return item;

            string getFileFormatName()
            {
                return AudioReader.GetFormatName(audioTrack.Location);
            }

            string stringContentToDisplayText(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return "不明";
                }

                return text;
            }

            string genreContentToDisplayText(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return "ジャンル未設定";
                }

                return text;
            }

            string sampleRateContentToDisplayText(int value)
            {
                if (value == -1)
                {
                    return "不明";
                }

                return $"{value}Hz";
            }

            string bitRateContentToDisplayText(int value)
            {
                if (value == -1)
                {
                    return "不明";
                }

                return $"{value}kbps";
            }

            string intContentToDisplayText(int value)
            {
                if (value == -1)
                {
                    return "不明";
                }

                return value.ToString();
            }

            string timeSpanContentToDisplayText(TimeSpan time, int fmt = 0)
            {
                if (time != null && time.TotalMilliseconds > 0)
                {
                    switch (fmt)
                    {
                        case 0:
                            return $"{time.Hours.ToString("00")}:{time.Minutes.ToString("00")}:{time.Seconds.ToString("00")}";
                        case 1:
                            return $"{time.Hours.ToString("00")}時間{time.Minutes.ToString("00")}分{time.Seconds.ToString("00")}秒";
                        default:
                            goto case 0;
                    }
                }

                return "不明";
            }
        }

        /// <summary>
        /// 指定されたトラックのListViewItemを取得する。
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(AudioTrack track, out int index)
        {
            index = 0;

            foreach(ListViewItem item in this.AudioTracksViewer.Items)
            {
                if(item.Tag == track)
                {
                    return item;
                }

                index++;
            }

            return null;
        }

        /// <summary>
        /// ファイルダイアログのフィルタを作成する。
        /// </summary>
        /// <returns></returns>
        private string GetDialogFilter()
        {
            var formatList = new List<KeyValuePair<string, string[]>>();

            foreach (string fmtName in PlaylistProviderFactory.GetSupportedFormatNames())
            {
                var pair = new KeyValuePair<string, string[]>(fmtName, PlaylistProviderFactory.GetFormatExtensions(fmtName));
                formatList.Add(pair);
            }

            return FileDialogUtils.CreateFilterString(formatList, true, "対応するすべてのプレイリスト", false);
        }

        #endregion

        /// <summary>
        /// ビューワーの選択されたアイテムのインデックスが変更された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioTracksViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedAudioTrackChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// ビューワーがダブルクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioTracksViewer_DoubleClick(object sender, EventArgs e)
        {
            this.AudioTrackDoubleClicked?.Invoke(sender, e);
        }

        /// <summary>
        /// ビューワー内になんらかのアイテムがドラッグされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioTracksViewer_DragEnter(object sender, DragEventArgs e)
        {
            // コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// ビューワーにファイルがドロップされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioTracksViewer_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var path in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (File.Exists(path))
                {
                    var track = new AudioTrack(path);

                    AddAudioTrackToView(track);
                    this.CurrentPlaylist.Tracks.Add(track);
                }
            }
        }

        /// <summary>
        /// ビューワーの列のヘッダがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioTracksViewer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.SortWhenColumnHeaderClicked)
            {
                // クリックされた列が既にソート済みか？
                if (e.Column == this.AudioTracksViewerSorter.SortColumn)
                {
                    // 並び替え方向を逆に切り替える。（昇順->降順,降順->昇順)
                    if (this.AudioTracksViewerSorter.Order == SortOrder.Ascending)
                    {
                        this.AudioTracksViewerSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        this.AudioTracksViewerSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // ソートする列番号を設定する。デフォルトのソート順は昇順とする。
                    this.AudioTracksViewerSorter.SortColumn = e.Column;
                    this.AudioTracksViewerSorter.Order = SortOrder.Ascending;
                }

                // 指定された列の項目に基づいてソートする。
                this.AudioTracksViewer.Sort();

                // イベントの実行
                this.PlaylistChanged?.Invoke(null, null);
            }
        }
    }
}
