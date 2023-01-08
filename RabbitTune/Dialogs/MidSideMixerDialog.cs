using System;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class MidSideMixerDialog : Form
    {
        // 非公開フィールド
        private bool BkupUseMidSideMixer;
        private float BkupMidSignalBoostLevel;
        private float BkupSideSignalBoostLevel;

        // コンストラクタ
        public MidSideMixerDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
            this.MidSignalBoostLevel = 1.0f;
            this.SideSignalBoostLevel = 1.0f;
        }

        /// <summary>
        /// Mid信号のブーストレベル
        /// </summary>
        private float MidSignalBoostLevel
        {
            get
            {
                return (this.MidSignalBoostLevelSlider.Value / (float)this.MidSignalBoostLevelSlider.Maximum) * 2;
            }
            set
            {
                this.MidSignalBoostLevelSlider.Value = (int)((value * 0.5) * this.MidSignalBoostLevelSlider.Maximum);
            }
        }

        /// <summary>
        /// Side信号のブーストレベル
        /// </summary>
        private float SideSignalBoostLevel
        {
            get
            {
                return (this.SideSignalBoostLevelSlider.Value / (float)this.SideSignalBoostLevelSlider.Maximum) * 2;
            }
            set
            {
                this.SideSignalBoostLevelSlider.Value = (int)((value * 0.5) * this.SideSignalBoostLevelSlider.Maximum);
            }
        }

        /// <summary>
        /// フォームをモーダル表示する。
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            BackupOptions();
            LoadOptions();

            return base.ShowDialog();
        }

        /// <summary>
        /// フォームを表示する。
        /// </summary>
        public new void Show()
        {
            BackupOptions();
            LoadOptions();

            base.Show();
        }

        /// <summary>
        /// 設定を読み込んでUIに反映する。
        /// </summary>
        private void LoadOptions()
        {
            this.MidSignalBoostLevel = AudioPlayerManager.MidSignalBoostLevel;
            this.SideSignalBoostLevel = AudioPlayerManager.SideSignalBoostLevel;
            this.UseMidSideMixerCheckBox.Checked = AudioPlayerManager.UseMidSideMixer;
        }

        /// <summary>
        /// 現在の設定をバックアップする。
        /// </summary>
        private void BackupOptions()
        {
            this.BkupUseMidSideMixer = AudioPlayerManager.UseMidSideMixer;
            this.BkupMidSignalBoostLevel = AudioPlayerManager.MidSignalBoostLevel;
            this.BkupSideSignalBoostLevel = AudioPlayerManager.SideSignalBoostLevel;
        }

        /// <summary>
        /// バックアップされた設定を復元する。
        /// </summary>
        private void RestoreOptions()
        {
            AudioPlayerManager.UseMidSideMixer = this.BkupUseMidSideMixer;
            AudioPlayerManager.MidSignalBoostLevel = this.BkupMidSignalBoostLevel;
            AudioPlayerManager.SideSignalBoostLevel = this.BkupSideSignalBoostLevel;
        }

        /// <summary>
        /// 設定を反映する。
        /// </summary>
        private void ApplyOptions()
        {
            AudioPlayerManager.UseMidSideMixer = this.UseMidSideMixerCheckBox.Checked;
            AudioPlayerManager.MidSignalBoostLevel = this.MidSignalBoostLevel;
            AudioPlayerManager.SideSignalBoostLevel = this.SideSignalBoostLevel;
        }

        /// <summary>
        /// プレビュー状態の更新処理
        /// </summary>
        private void UpdatePreviewOptions()
        {
            if (this.UsePreviewCheckBox.Checked)
            {
                ApplyOptions();
            }
            else
            {
                AudioPlayerManager.UseMidSideMixer = false;
            }
        }

        private void MidSignalBoostLevelSlider_ValueChanged(object sender, EventArgs e)
        {
            var level = Math.Round(this.MidSignalBoostLevel, 2);
            this.MidSignalLevelLabel.Text = $"x{level}";

            UpdatePreviewOptions();
        }

        private void SideSignalBoostLevelSlider_ValueChanged(object sender, EventArgs e)
        {
            var level = Math.Round(this.SideSignalBoostLevel, 2);
            this.SideSignalLevelLabel.Text = $"x{level}";

            UpdatePreviewOptions();
        }

        private void UseMidSideMixerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewOptions();
        }

        private void UsePreviewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewOptions();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            ApplyOptions();
            Close();
        }

        private void MidSideMixerDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                RestoreOptions();
            }
        }
    }
}
