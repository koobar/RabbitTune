using RabbitTune.AudioEngine.Codecs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls.OptionPanels
{
    public partial class MidiOptionPanel : UserControl
    {
        // 非公開変数
        private List<SoundFont> soundFonts;
        
        // コンストラクタ
        public MidiOptionPanel()
        {
            InitializeComponent();
            LoadOptions();

            this.Font = SystemFonts.CaptionFont;
        }

        /// <summary>
        /// 設定を読み込む。
        /// </summary>
        private void LoadOptions()
        {
            this.soundFonts = new List<SoundFont>();

            if (!ControlUtils.IsDesignMode())
            {
                this.UseHWMixingCheckBox.Checked = AudioPlayerManager.MidiUseHardwareMixing;
                this.UseSincInterpolationCheckBox.Checked = AudioPlayerManager.MidiUseSincInterpolation;

                foreach (var font in AudioPlayerManager.SoundFonts)
                {
                    var f = new SoundFont(font.Path, font.UseXGDrumMode);
                    f.Volume = font.Volume;
                    f.Bank = font.Bank;
                    f.Preset = font.Preset;
                    f.Enabled = font.Enabled;

                    this.soundFonts.Add(f);
                }
            }

            UpdateSoundFontList();
        }

        /// <summary>
        /// 設定を保存する。
        /// </summary>
        public void SaveOptions()
        {
            AudioPlayerManager.MidiUseHardwareMixing = this.UseHWMixingCheckBox.Checked;
            AudioPlayerManager.MidiUseSincInterpolation = this.UseSincInterpolationCheckBox.Checked;

            for(int i = 0; i < this.soundFonts.Count; ++i)
            {
                this.soundFonts[i].Enabled = true;
            }

            AudioPlayerManager.SoundFonts = this.soundFonts.ToArray();
        }

        /// <summary>
        /// サウンドフォントリストのチェック状態を更新する。
        /// </summary>
        private void UpdateSoundFontList()
        {
            // 一度すべて削除する。（これがないと何故か消したはずのアイテムが表示に残る）
            this.soundFontBindingSource.Clear();

            // 新しく追加する。
            for (int i = 0; i < this.soundFonts.Count; ++i)
            {
                this.soundFontBindingSource.Add(this.soundFonts[i]);
            }
        }

        /// <summary>
        /// 指定されたサウンドフォントを、指定されたリストに追加する。<br/>
        /// 但し、リスト内に同じファイルを示すサウンドフォントがあれば追加しない。
        /// </summary>
        /// <param name="newFont"></param>
        private void AddFont(SoundFont newFont)
        {
            bool contains = false;

            foreach (var font in this.soundFonts)
            {
                if (font.Path == newFont.Path)
                {
                    contains = true;
                }
            }

            if (!contains)
            {
                this.soundFonts.Add(newFont);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (this.Visible)
            {
                //LoadOptions();
            }

            base.OnVisibleChanged(e);
        }

        /// <summary>
        /// フォント追加ボタンが押された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFontButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "サウンドフォント(*.sf2)|*.sf2";
            dialog.Multiselect = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                // 選択されたサウンドフォントを追加する。
                foreach(string path in dialog.FileNames)
                {
                    AddFont(new SoundFont(path, false));
                }

                UpdateSoundFontList();
            }
        }

        /// <summary>
        /// フォント削除ボタンが押された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFontButton_Click(object sender, EventArgs e)
        {
            if(this.SoundFontsListBox.SelectedIndex > -1)
            {
                this.soundFonts.RemoveAt(this.SoundFontsListBox.SelectedIndex);
                UpdateSoundFontList();
            }
        }
        
        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (this.SoundFontsListBox.SelectedIndex > -1)
            {
                int oldIndex = this.SoundFontsListBox.SelectedIndex;
                int newIndex = oldIndex - 1;

                if(newIndex > -1)
                {
                    var t = this.soundFonts[oldIndex];

                    // 入れ替える
                    this.soundFonts.RemoveAt(oldIndex);
                    this.soundFonts.Insert(newIndex, t);

                    // 表示を更新する。
                    UpdateSoundFontList();

                    // 入れ替え先を選択
                    this.SoundFontsListBox.SelectedIndex = newIndex;
                }
            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (this.SoundFontsListBox.SelectedIndex > -1)
            {
                int oldIndex = this.SoundFontsListBox.SelectedIndex;
                int newIndex = oldIndex + 1;

                if (newIndex < this.soundFonts.Count)
                {
                    var t = this.soundFonts[oldIndex];

                    // 入れ替える
                    this.soundFonts.RemoveAt(oldIndex);
                    this.soundFonts.Insert(newIndex, t);

                    // 表示を更新する。
                    UpdateSoundFontList();

                    // 入れ替え先を選択
                    this.SoundFontsListBox.SelectedIndex = newIndex;
                }
            }
        }

        private void SoundFontsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.SoundFontsListBox.SelectedIndex > -1)
            {
                var font = this.soundFonts[this.SoundFontsListBox.SelectedIndex];

                this.VolumeSlider.Value = font.Volume;
                this.UseXGCompatModeCheckBox.Checked = font.UseXGDrumMode;
            }
        }

        private void VolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if(this.SoundFontsListBox.SelectedIndex > -1)
            {
                var font = this.soundFonts[this.SoundFontsListBox.SelectedIndex];
                font.Volume = this.VolumeSlider.Value;
            }
        }
    }
}
