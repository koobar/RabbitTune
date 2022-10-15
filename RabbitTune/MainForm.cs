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
        // ���J�萔
        public const int DEFAULT_WINDOW_WIDTH = 750;
        public const int DEFAULT_WINDOW_HEIGHT = 500;

        // ����J�ϐ�
        private readonly string[] commandLineArguments;
        private readonly AudioOutputInfoDialog AudioOutputInfoDialog;
        private readonly FindDialog FindAudioTrackDialog;
        private readonly SampleRateConversionDialog SampleRateConversionDialog;
        private readonly EqualizerDialog EqualizerDialog;
        private readonly OptionDialog DetailOptionDialog;
        private readonly VersionDialog ApplicationVersionDialog;
        private bool showInTaskTray = false;                    // �^�X�N�g���C�֊i�[�����ǂ���
        private bool showAsMiniplayerMode = false;              // �~�j�v���[���[�\�����Ȃ�true, ����ȊO�Ȃ�false
        private int defaultViewHeight;                          // �W���\���̍ۂ̃E�B���h�E�̍����B�~�j�v���[���[�\������̐؂�ւ��p�B�~�j�v���[���[�\����L���������ۂɒl���o�b�N�A�b�v�����B

        // �R���X�g���N�^
        public MainForm(string[] commandLineArgs)
        {
            InitializeComponent();

            // �Đ��ʒu���X�V���ꂽ�ۂ̏���
            AudioPlayerManager.PlaybackPositionChanged += delegate
            {
                // �V�[�N���쒆�ł͂Ȃ����H
                if (!this.SeekBar.Capture)
                {
                    // �V�[�N���삪�I���������H
                    if(this.SeekBar.Tag != null && this.SeekBar.Tag.GetType() == typeof(bool))
                    {
                        var flag_seeking = (bool)this.SeekBar.Tag;

                        if (flag_seeking)
                        {
                            AudioPlayerManager.Position = this.SeekBar.Value;
                        }

                        // ��n��
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

                    // Monkey's Audio �Ȃǂ̓V�[�N���삪�d���ׁA�l���ύX����邽�т�
                    // �v���p�e�B��ύX����Ƃ܂Ƃ��ɓ����Ȃ��B
                    // AudioPlayerManager.Position = this.SeekBar.Value;
                }

                var time_pos = AudioPlayerManager.GetPosition();
                var time_len = AudioPlayerManager.GetDuration();

                // �Đ����Ԃ̕\�����X�V
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

            // �R�}���h���C��������ێ�
            this.commandLineArguments = commandLineArgs;

            // �t�H���g��ݒ�
            this.Font = SystemFonts.CaptionFont;

            // �e��_�C�A���O�̍쐬
            this.AudioOutputInfoDialog = new AudioOutputInfoDialog();
            this.FindAudioTrackDialog = new FindDialog();
            this.SampleRateConversionDialog = new SampleRateConversionDialog();
            this.EqualizerDialog = new EqualizerDialog();
            this.DetailOptionDialog = new OptionDialog();
            this.ApplicationVersionDialog = new VersionDialog();
        }

        // �f�t�H���g�R���X�g���N�^
        public MainForm() : this(null) { }

        /// <summary>
        /// �e��ݒ�l��\���ɔ��f����B
        /// </summary>
        private void ApplyFormOptions()
        {
            // �e��ݒ�l��\���ɔ��f
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
        /// �ʏ�̃E�B���h�E��Ԃɂ�����t�H�[���̃T�C�Y���擾����B<br/>
        /// �~�j�v���[���[�\���ł����Ă��A�W�����[�h���̃t�H�[���̃T�C�Y��Ԃ��B
        /// </summary>
        /// <returns></returns>
        public Size GetRestoreFormSize()
        {
            int width = this.RestoreBounds.Width;
            int height = this.RestoreBounds.Height;

            // �~�j�v���[���[���[�h���L�����H
            if (this.ShowAsMiniplayerMode)
            {
                // �W�����[�h�̏ꍇ�̃t�H�[���̍������擾�B
                height = this.defaultViewHeight;
            }

            return new Size(width, height);
        }

        #region �t�H�[���̕\���E�`��E�X�V

        /// <summary>
        /// �~�j�v���[���[���[�h�ƕW�����[�h��؂�ւ���B
        /// </summary>
        /// <param name="enabled"></param>
        public void SetMiniplayerMode(bool enabled)
        {
            this.ShowAsMiniplayerModeMenu.Checked = enabled;
            this.showAsMiniplayerMode = enabled;

            // �~�j�v���[���[�\���̗L�������H
            if (enabled)
            {
                if(this.WindowState == FormWindowState.Maximized)
                {
                    // �ő剻���Ƀ~�j�v���[���[���[�h�ɐ؂�ւ���ƕs����o��ꍇ������̂ŁA
                    // �؂�ւ��O�ɕW���T�C�Y�ɖ߂��B
                    this.WindowState = FormWindowState.Normal;
                }

                int height = this.Height - this.MainContentsPanel.Height;

                this.defaultViewHeight = this.Height;
                this.Height = height;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;     // �E�B���h�E�T�C�Y�̕ύX�������Ȃ�
                this.MaximizeBox = false;                               // �E�B���h�E�̍ő剻�{�^���𖳌���
            }
            else
            {
                this.Height = this.defaultViewHeight;
                this.FormBorderStyle = FormBorderStyle.Sizable;         // �E�B���h�E�T�C�Y�̕ύX��������
                this.MaximizeBox = true;                                // �E�B���h�E�̍ő剻�{�^����L����
            }
        }

        /// <summary>
        /// �w�肳�ꂽ���s�[�g���[�h�̃��j���[���ڂ��`�F�b�N����B
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
        /// �g���b�N�̉摜�̕\����Ԃ�ݒ肷��B
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
        /// �w�肳�ꂽ�g���b�N�Ɋ܂܂��摜���r���[�ɕ\������B
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
                    this.TrackPictureViewer.Image.Dispose();        // ���������[�N���
                    this.TrackPictureViewer.Image = null;
                }

                // �摜��\��
                this.TrackPictureViewer.Image = img;
                SetTrackImageViewerVisible(img != null);

                // ��n��
                worker.Dispose();
            };

            // �摜��񓯊��œǂݍ���ŕ\��
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�ɕ\������Đ����̃g���b�N�̃t�H�[�}�b�g�����X�V����B
        /// </summary>
        private void UpdateAudioWaveFormatStatusText()
        {
            string fmt = "�s���ȃt�H�[�}�b�g";

            if (this.CurrentPlaylistViewer.SelectedAudioTrack != null)
            {
                fmt = AudioReader.GetFormatName(this.CurrentPlaylistViewer.SelectedAudioTrack.Location);
            }

            // �t�@�C���̎�ށi�R�[�f�b�N���j�̕\�����X�V
            this.PlayingAudioFormatStatusText.Text = fmt;

            // �g�`�t�H�[�}�b�g�̕\�����X�V
            AudioPlayerManager.GetInputWaveFormat(out int isr, out int isb, out int isc);
            AudioPlayerManager.GetOutputWaveFormat(out int psr, out int psb, out int psc);
            string waveformat = $"INPUT: ({isr}Hz, {getChannelDescription(isc)}, {isb}bits), ";

            // ���T���v���[���L�����H
            if (AudioPlayerManager.UseReSampler)
            {
                // ���T���v���[�̃t�H�[�}�b�g���\���ɒǉ�
                waveformat += $"RESAMPLER: ({AudioPlayerManager.ReSamplerSampleRate}Hz, {getChannelDescription(AudioPlayerManager.ReSamplerChannels)}, {AudioPlayerManager.ReSamplerBitsPerSample}bits), ";
            }

            // �o�̓f�o�C�X�ɓn�����I�[�f�B�I�\�[�X(����������̃f�[�^)�̃t�H�[�}�b�g��ǉ�
            waveformat += $"OUTPUT: ({psr}Hz, {getChannelDescription(psc)}, {psb}bits)";

            // �\���ɔ��f
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
        /// ��~���i�ꎞ��~���������j�ɂ��̃��\�b�h���Ăяo���ƁA�g���b�N�̃t�H�[�}�b�g�����\�������A<br/>
        /// �Đ����ɂ��̃��\�b�h���Ăяo���ƁA�g���b�N�̃t�H�[�}�b�g����\������B
        /// </summary>
        private void UpdateAudioWaveFormatStatusTextVisible()
        {
            bool visible = AudioPlayerManager.IsPlaying || AudioPlayerManager.IsPausing;

            this.PlayingAudioFormatStatusText.Visible = visible;
            this.PlayingAudioWaveFormatText.Visible = visible;
        }

        /// <summary>
        /// �t�H�[���̃^�C�g�����X�V����B
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

        #region �v���p�e�B

        /// <summary>
        /// ��ɍőO�ʂɕ\�����邩�ǂ���
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
        /// �^�X�N�g���C�֊i�[���邩�ǂ���
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
        /// �~�j�v���[���[�\�������ǂ���
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
        /// ���ݑI�����Ă���^�u�̃v���C���X�g�r���[���̃C���X�^���X�B<br/>
        /// �y�[�W���I������Ă��Ȃ��A�܂��͑I�����ꂽ�y�[�W���v���C���X�g�̃y�[�W�łȂ��ꍇ�Anull��Ԃ��B
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
        /// �f�t�H���g�v���C���X�g�̃v���C���X�g�r���[���[���擾����B
        /// </summary>
        public PlaylistViewer DefaultPlaylistViewer
        {
            get
            {
                return ((PlaylistViewerTabPage)this.MainTabControl.TabPages[0]).PlaylistViewer;
            }
        }

        /// <summary>
        /// �����c�[���p�l���̉����
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

        #region �t�@�C���֘A�̏���

        /// <summary>
        /// �t�@�C���_�C�A���O�Ŏg�p����t�B���^�̕�����𐶐�����B
        /// </summary>
        /// <param name="withAudioFileFilter"></param>
        /// <param name="withPlaylistFileFilter"></param>
        /// <param name="withAnyFileFilter"></param>
        /// <returns></returns>
        private string GetFileDialogFilter(bool withAudioFileFilter, bool withPlaylistFileFilter, bool withAnyFileFilter)
        {
            string result = null;

            // �u�Ή����邷�ׂẴt�@�C���v�t�B���^�𐶐�����ׂ����H
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

                result += FileDialogUtils.GetAllFilterString(formatList, "�Ή����邷�ׂẴt�@�C��");
            }

            // �I�[�f�B�I�t�@�C���̃t�B���^�𐶐����邩�H
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

                result += FileDialogUtils.CreateFilterString(formatList, true, "�Ή����邷�ׂẴI�[�f�B�I�t�@�C��", false);
            }

            // �v���C���X�g�t�@�C���̃t�B���^�𐶐����邩�H
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

                result += FileDialogUtils.CreateFilterString(formatList, true, "�Ή����邷�ׂẴv���C���X�g", false);
            }

            // �u���ׂẴt�@�C���v�̃t�B���^�𐶐����邩�H
            if (withAnyFileFilter)
            {
                if(result != null)
                {
                    result += "|";
                }

                result += "�S�Ẵt�@�C��|**";
            }

            return result;
        }

        /// <summary>
        /// �t�@�C�����J��
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

        #region �v���C���X�g�̊Ǘ��Ɋ֘A���鏈��

        /// <summary>
        /// ���ۑ��̃v���C���X�g��\�����Ă���v���C���X�g�r���[���̈ꗗ���擾����B
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
        /// �V�����v���C���X�g�\���^�u���쐬���A���̃C���X�^���X��Ԃ��B
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private PlaylistViewerTabPage CreatePlaylistViewerTabPage(string path = null)
        {
            var page = new PlaylistViewerTabPage();

            if (path == null)
            {
                page.Text = "�V�K�v���C���X�g.m3u";
            }
            else
            {
                page.CanClose = path != ApplicationOptions.DefaultPlaylistPath;

                // �v���C���X�g���J��
                page.PlaylistViewer.OpenPlaylist(path);
            }

            page.AudioTrackSelected += PlayMenu_Clicked;
            page.PlaylistViewer.PlayCommandInvoked += PlayMenu_Clicked;
            return page;
        }

        /// <summary>
        /// �V�K�v���C���X�g���쐬
        /// </summary>
        private void CreateNewPlaylist()
        {
            var page = CreatePlaylistViewerTabPage();

            // �y�[�W��ǉ����đI��
            this.MainTabControl.TabPages.Add(page);
            this.MainTabControl.SelectedTab = page;
        }

        /// <summary>
        /// ���ݑI�𒆂̃v���C���X�g�Ƀt�@�C����ǉ�����B
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
        /// �f�t�H���g�v���C���X�g���J���B
        /// </summary>
        private void OpenDefaultPlaylist()
        {
            // �f�t�H���g�v���C���X�g���쐬����Ă��Ȃ���ΐV�����쐬����B
            if (!File.Exists(ApplicationOptions.DefaultPlaylistPath))
            {
                var writer = new PlaylistWriter(ApplicationOptions.DefaultPlaylistPath);
                writer.Save();
            }

            // �f�t�H���g�v���C���X�g���J���B
            OpenPlaylist(ApplicationOptions.DefaultPlaylistPath);
        }

        /// <summary>
        /// �w�肳�ꂽ�p�X�̃v���C���X�g���J���Ă���^�u�y�[�W�̃C���f�b�N�X���擾����B<br/>
        /// ���݂��Ȃ����-1��Ԃ��B
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
        /// �V�����^�u�Ńv���C���X�g���J���B<br/>
        /// �p�X�w����ȗ������ꍇ�A�J���t�@�C����I������B
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

                // ��n��
                dialog.Dispose();
            }

            int idx = GetPlaylistTabIndex(path);

            // �w�肳�ꂽ�p�X��\�����Ă���^�u�y�[�W�����݂��Ȃ����H
            if (idx == -1)
            {
                var page = CreatePlaylistViewerTabPage(path);

                // �y�[�W��ǉ����đI��
                this.MainTabControl.TabPages.Add(page);
                this.MainTabControl.SelectedTab = page;
            }
            else
            {
                // �y�[�W��I��
                this.MainTabControl.SelectedIndex = idx;
            }
        }

        /// <summary>
        /// �ۑ����I�����A�w�肳�ꂽ�v���C���X�g�r���[���[�̃v���C���X�g��ۑ�����B
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
        /// �w�肳�ꂽ�v���C���X�g�r���[���[�̃v���C���X�g��ۑ�����B
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
        /// �w�肳�ꂽ�^�u�y�[�W�C���f�b�N�X�̃v���C���X�g��ۑ�����B
        /// </summary>
        /// <param name="playlistPageIndex"></param>
        private void SavePlaylist(int playlistPageIndex)
        {
            var page = this.MainTabControl.TabPages[playlistPageIndex];

            // �w�肳�ꂽ�C���f�b�N�X�̃y�[�W���v���C���X�g�̃y�[�W���H
            if(page.GetType() == typeof(PlaylistViewerTabPage))
            {
                var viewer = ((PlaylistViewerTabPage)page).PlaylistViewer;
                SavePlaylist(viewer);
            }
        }

        /// <summary>
        /// �S�Ẵv���C���X�g��ۑ�����B
        /// </summary>
        private void SaveAllPlaylists()
        {
            for (int i = 0; i < this.MainTabControl.TabPages.Count; ++i)
            {
                SavePlaylist(i);
            }
        }

        /// <summary>
        /// �I�[�f�B�I�g���b�N�̌������s���B
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
        /// �I�[�f�B�I�g���b�N�̌������s���B
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
                    "�w�肳�ꂽ�������ƃI�v�V�����Ɉ�v����g���b�N�͌�����܂���ł����B",
                    "�g���b�N��������܂���ł���",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// ���O�̌������̈ʒu���J�n�ʒu�Ƃ��ăI�[�f�B�I�g���b�N�̌������s���B
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
                            "�w�肳�ꂽ�������ƃI�v�V�����Ɉ�v����g���b�N�͌�����܂���ł����B",
                            "�g���b�N��������܂���ł���",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        #region �Đ��R���g���[���ȂǍĐ��Ɋ֘A���鏈��

        /// <summary>
        /// �Đ����x��ݒ肷��B
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
        /// �s�b�`�V�t�^�[�̃s�b�`��ݒ肷��B
        /// </summary>
        /// <param name="freqOfA"></param>
        private void SetPitch(int semitones)
        {
            AudioPlayerManager.Pitch = semitones;

            // �`�F�b�N���ׂ����j���[���ڂ��擾����B
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
        /// SoundTouch�̃s�b�`�V�t�^�[�̃s�b�`�ω��ʂ�ݒ肷��B
        /// </summary>
        /// <param name="semitones"></param>
        private void SetSoundTouchPitch(int semitones)
        {
            AudioPlayerManager.SoundTouchPitchSemitones = semitones;

            // �`�F�b�N���ׂ����j���[���ڂ��擾����B
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
        /// �Đ�
        /// </summary>
        public void Play()
        {
            if(this.CurrentPlaylistViewer != null && this.CurrentPlaylistViewer.AudioTrackCount > 0)
            {
                if(this.CurrentPlaylistViewer.SelectedAudioTrack == null)
                {
                    this.CurrentPlaylistViewer.SelectedAudioTrack = this.CurrentPlaylistViewer.GetAudioTrack(0);
                }

                // �Đ�����g���b�N���擾���ĊJ���B
                var track = this.CurrentPlaylistViewer.SelectedAudioTrack;
                ShowTrackPicture(track);

                // �g���b�N���J���B
                AudioPlayerManager.SetTrack(track);

                // �V�[�N�o�[�̐ݒ�
                this.SeekBar.Maximum = (int)AudioPlayerManager.Duration;
                this.SeekBar.Value = 0;

                // �Đ�
                AudioPlayerManager.Play();

                // ��n��
                UpdateAudioWaveFormatStatusTextVisible();
                UpdateFormTitle();
            }
        }

        /// <summary>
        /// �O�̃g���b�N���Đ�
        /// </summary>
        public void PlayPreviousTrack()
        {
            if (this.CurrentPlaylistViewer != null)
            {
                // �O�̃g���b�N���擾���đI��
                var track = this.CurrentPlaylistViewer.GetPreviousTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // �Đ�
                Play();
            }
        }

        /// <summary>
        /// ���̃g���b�N���Đ�
        /// </summary>
        public void PlayNextTrack()
        {
            if (this.CurrentPlaylistViewer != null)
            {
                // ���̃g���b�N���擾���đI��
                var track = this.CurrentPlaylistViewer.GetNextTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // �Đ�
                Play();
            }
        }

        /// <summary>
        /// �����_���ȃg���b�N���Đ�����B
        /// </summary>
        public void PlayRandomTrack()
        {
            if(this.CurrentPlaylistViewer != null)
            {
                // �����_���ȃg���b�N���擾���đI��
                var track = this.CurrentPlaylistViewer.GetRandomTrack();
                this.CurrentPlaylistViewer.SelectedAudioTrack = track;

                // �Đ�
                Play();
            }
        }

        /// <summary>
        /// ��~
        /// </summary>
        public void Stop()
        {
            AudioPlayerManager.Stop();

            // �\�����X�V
            UpdateAudioWaveFormatStatusTextVisible();
            UpdateFormTitle();
            SetTrackImageViewerVisible(false);

            // ��n��
            this.SeekBar.Value = 0;
        }

        /// <summary>
        /// �ꎞ��~/�ĊJ
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

        #region �E�B���h�E�̃��\�b�h�̃I�[�o�[���C�h
        
        /// <summary>
        /// �ǂݍ��ݎ��̏���
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // MainForm.Designer.cs�Ń��C�����j���[��ݒ肷��ƁA
            // ���j���[�̍��������t�H�[���̃T�C�Y�������Ă��܂��A
            // �E�B���h�E�T�C�Y���R���t�B�O�t�@�C���ɕۑ�����ۂɕs�s����������B
            // �����ŁAMainForm.Designer.cs�Ń��C�����j���[��ݒ肷��̂ł͂Ȃ��A
            // �����ăt�H�[���̓ǂݍ��ݎ��ɐݒ肷��悤�ɂ��邱�ƂŁA���̖�������ł���B
            base.Menu = this.MainMenu;

            // ���X�̏��������s�B
            base.OnLoad(e);
        }

        #endregion

        /// <summary>
        /// ���C���t�H�[�����ǂݍ��܂ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // �e��ݒ�l��\���ɔ��f
            ApplyFormOptions();

            // �f�t�H���g�v���C���X�g���J��
            OpenDefaultPlaylist();

            if (this.commandLineArguments != null && this.commandLineArguments.Length > 0)
            {
                // �R�}���h���C�������œn���ꂽ�t�@�C����ǂݍ��ށB
                foreach (string arg in this.commandLineArguments)
                {
                    if (File.Exists(arg))
                    {
                        OpenAnyFile(arg);
                    }
                }
            }

            // �v���C���X�g�u���E�U���X�V
            this.PlaylistBrowser.Update();
        }

        /// <summary>
        /// �t�H�[��������Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��~���ĉ��
            AudioPlayerManager.Close();

            // �f�t�H���g�v���C���X�g��ۑ�����B
            SavePlaylist(this.DefaultPlaylistViewer);

            var unsavedPlaylists = GetUnsavedPlaylistViewers();
            if(unsavedPlaylists.Length > 0)
            {
                var result = MessageBox.Show(
                    $"{unsavedPlaylists.Length} �̖��ۑ��̃v���C���X�g������܂��B\n �����̃v���C���X�g�����ׂĕۑ����܂����H",
                    "�ۑ��m�F",
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
        /// �V�K�v���C���X�g�쐬���j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewPlaylistMenu_Click(object sender, EventArgs e)
        {
            CreateNewPlaylist();
        }

        /// <summary>
        /// �J�����j���[���N���b�N���ꂽ�ۂ̏���
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

            // ��n��
            dialog.Dispose();
        }

        /// <summary>
        /// ���݂̃v���C���X�g�ɖ��O��t���ĕۑ����郁�j���[���N���b�N���ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentPlaylistAsMenu_Click(object sender, EventArgs e)
        {
            SavePlaylistAs(this.CurrentPlaylistViewer);
        }

        /// <summary>
        /// ���݂̃v���C���X�g��ۑ����郁�j���[���N���b�N���ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentPlaylistMenu_Click(object sender, EventArgs e)
        {
            SavePlaylist(this.CurrentPlaylistViewer);
        }

        /// <summary>
        /// �S�Ẵv���C���X�g��ۑ����郁�j���[���N���b�N���ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllPlaylistsMenu_Click(object sender, EventArgs e)
        {
            SaveAllPlaylists();
        }

        /// <summary>
        /// �Đ����j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void PlayMenu_Clicked(object sender, EventArgs e)
        {
            Play();
        }

        /// <summary>
        /// ��~���j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMenu_Click(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// �ꎞ��~/�ĊJ���j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseOrResumeMenu_Click(object sender, EventArgs e)
        {
            PauseOrResume();
        }

        /// <summary>
        /// �O�̃g���b�N���j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousMenu_Click(object sender, EventArgs e)
        {
            PlayPreviousTrack();
        }

        /// <summary>
        /// ���̃g���b�N���j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextMenu_Click(object sender, EventArgs e)
        {
            PlayNextTrack();
        }

        /// <summary>
        /// �����_�����j���[�������ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomMenu_Click(object sender, EventArgs e)
        {
            PlayRandomTrack();
        }

        /// <summary>
        /// �v���C���X�g�u���E�U�Ńv���C���X�g���J��������s�����ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaylistBrowser_PlaylistOpenRequested(object sender, EventArgs e)
        {
            OpenPlaylist(this.PlaylistBrowser.SelectedPlaylistLocation);
        }

        /// <summary>
        /// ��ɍőO�ʂɕ\�����郁�j���[���N���b�N���ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlwaysOnTopMenu_Click(object sender, EventArgs e)
        {
            this.AlwaysOnTop = !this.AlwaysOnTopMenu.Checked;
        }

        /// <summary>
        /// ���s�[�g���@���j���[�̂����A���s�[�g���Ȃ����j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoRepeatMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.NoRepeat;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// ���s�[�g���@���j���[�̂����A�P�ȃ��s�[�g���j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatSingleTrackMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.Single;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// ���s�[�g���@���j���[�̂����A�S�ȃ��s�[�g���j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatAllTracksMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.AllTracks;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// ���s�[�g���@���j���[�̂����A�����_�����j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomRepeatMenu_Click(object sender, EventArgs e)
        {
            ApplicationOptions.RepeatMode = RepeatMode.RandomTrack;
            SetRepeatModeView(ApplicationOptions.RepeatMode);
        }

        /// <summary>
        /// �v���C���X�g�Ƀt�H���_��ǉ����郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �I�[�f�B�I�g���b�N�������j���[���N���b�N���ꂽ�A�܂��͂���Ɠ����̑��삪�s��ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAudioTrackMenu_Click(object sender, EventArgs e)
        {
            SearchAudioTrack();
        }

        /// <summary>
        /// �����������j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAudioTrackNextMenu_Click(object sender, EventArgs e)
        {
            SearchAudioTrackNext();
        }

        /// <summary>
        /// �o�[�W������񃁃j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowVersionInfoMenu_Click(object sender, EventArgs e)
        {
            this.ApplicationVersionDialog.ShowDialog();
        }

        /// <summary>
        /// �A�v���P�[�V�����I�����j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApplicationMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// �����c�[���p�l���̕\���ݒ��؂�ւ��鑀����s�����ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLeftSideToolPanelMenu_Click(object sender, EventArgs e)
        {
            bool state = this.ShowLeftSideToolPanelMenu.Checked;

            this.ShowLeftSideToolPanel = !state;
        }

        /// <summary>
        /// �I�����ꂽ�A�C�e����1��Ɉړ����郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �I�����ꂽ�A�C�e����1���Ɉړ����郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �ꗗ����I�����ꂽ�A�C�e�����������郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �ꗗ����I�����ꂽ�A�C�e�����������A�t�@�C�����폜���郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �A�C�e�������ׂĈꗗ���珜�����郁�j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �ڍאݒ胁�j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailOptionsMenu_Click(object sender, EventArgs e)
        {
            this.DetailOptionDialog.ShowDialog();
        }

        /// <summary>
        /// �ݒ胊�Z�b�g���j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAllOptionsMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("���̑�������s����ƁA�A�v���P�[�V�����̑S�Ă̐ݒ�ƁA\n" +
                "���C�ɓ���v���C���X�g�Ȃǂ�����������܂��B\n" +
                "�ݒ�����������܂����H",
                "�ݒ�̃��Z�b�g",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Program.ResetApplicationOptionRequested = true;

                MessageBox.Show("�A�v���P�[�V�������ċN������܂��B", "�ċN��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        /// <summary>
        /// �T���v�����[�g�ϊ����j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �N�C�b�N�����{�^�����N���b�N���ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickSearchbutton_Click(object sender, EventArgs e)
        {
            SearchAudioTrack(this.SearchBox.Text);
        }

        /// <summary>
        /// ���ʃX���C�_�̒l���ύX���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            AudioPlayerManager.Volume = this.VolumeSlider.Value;
        }

        /// <summary>
        /// ReadMe�\�����j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReadMeMenu_Click(object sender, EventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\ReadMe.txt");
        }

        /// <summary>
        /// �X�V����\�����j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHistoryMenu_Click(object sender, EventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\History.txt");
        }

        /// <summary>
        /// �C�R���C�U���j���[���N���b�N���ꂽ�ۂ̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualizerMenu_Click(object sender, EventArgs e)
        {
            this.EqualizerDialog.ShowDialog();
        }

        /// <summary>
        /// �Đ����x���j���[����n�{�����j���[���N���b�N���ꂽ�ۂ̏���
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
        /// �s�b�`�V�t�^�[�̃s�b�`�ω��ʃ��j���[���N���b�N���ꂽ���̏���
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
        /// �I�[�f�B�I�̏ڍ׏�񃁃j���[���N���b�N���ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAudioOutputInfoMenu_Click(object sender, EventArgs e)
        {
            this.AudioOutputInfoDialog.ShowDialog();
        }

        /// <summary>
        /// SoundTouch�ɂ��s�b�`�V�t�^�[�̃s�b�`�ω��ʃ��j���[���N���b�N���ꂽ���̏���
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