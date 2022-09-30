using RabbitTune.ConfigFile;
using RabbitTune.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class EqualizerDialog : Form
    {
        // 非公開変数
        private bool changeBeforeUseEqualizer;
        private double[] changeBeforeLevels = new double[10];
        private EqualizerOptionControl[] filterControls = new EqualizerOptionControl[10];

        // コンストラクタ
        public EqualizerDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
            this.filterControls[0] = this.EqualizerFilterControl1;
            this.filterControls[1] = this.EqualizerFilterControl2;
            this.filterControls[2] = this.EqualizerFilterControl3;
            this.filterControls[3] = this.EqualizerFilterControl4;
            this.filterControls[4] = this.EqualizerFilterControl5;
            this.filterControls[5] = this.EqualizerFilterControl6;
            this.filterControls[6] = this.EqualizerFilterControl7;
            this.filterControls[7] = this.EqualizerFilterControl8;
            this.filterControls[8] = this.EqualizerFilterControl9;
            this.filterControls[9] = this.EqualizerFilterControl10;
            UpdateControllersView();
        }

        /// <summary>
        /// イコライザの各フィルタのコントローラの表示を更新する。
        /// </summary>
        private void UpdateControllersView()
        {
            this.UseEqualizerCheckBox.Checked = AudioPlayerManager.UseEqualizer;
            this.EqualizerFilterControl1.SetEqualizerFilterIndex(0);
            this.EqualizerFilterControl2.SetEqualizerFilterIndex(1);
            this.EqualizerFilterControl3.SetEqualizerFilterIndex(2);
            this.EqualizerFilterControl4.SetEqualizerFilterIndex(3);
            this.EqualizerFilterControl5.SetEqualizerFilterIndex(4);
            this.EqualizerFilterControl6.SetEqualizerFilterIndex(5);
            this.EqualizerFilterControl7.SetEqualizerFilterIndex(6);
            this.EqualizerFilterControl8.SetEqualizerFilterIndex(7);
            this.EqualizerFilterControl9.SetEqualizerFilterIndex(8);
            this.EqualizerFilterControl10.SetEqualizerFilterIndex(9);

            UpdateControllersEnabled();
        }

        /// <summary>
        /// イコライザの各フィルタのコントローラの有効状態を更新する。
        /// </summary>
        private void UpdateControllersEnabled()
        {
            foreach (Control ctrl in this.EqualizerControllersPanel.Controls)
            {
                ctrl.Enabled = this.UseEqualizerCheckBox.Checked;
            }
        }

        /// <summary>
        /// モーダルダイアログボックスとして表示する。
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            // 設定変更前の状態を保持しておく。
            this.changeBeforeUseEqualizer = AudioPlayerManager.UseEqualizer;
            Array.Copy(AudioPlayerManager.EqualizerAverageGainDecibels, this.changeBeforeLevels, AudioPlayerManager.EqualizerAverageGainDecibels.Length);
            
            // 既定ではキャンセル扱いにする。
            this.DialogResult = DialogResult.Cancel;

            // コントローラーの表示を更新
            UpdateControllersView();

            // ダイアログを表示
            return base.ShowDialog();
        }

        /// <summary>
        /// 全てのフィルタをリセットする。
        /// </summary>
        private void ResetAllFilters()
        {
            for(int i = 0; i < 10; ++i)
            {
                ResetFilter(i);
            }
        }

        /// <summary>
        /// 指定されたフィルタをリセットする。
        /// </summary>
        /// <param name="filterIndex"></param>
        private void ResetFilter(int filterIndex)
        {
            this.filterControls[filterIndex].GainDB = 0;
        }

        /// <summary>
        /// イコライザを使用するチェックボックスのチェック状態が変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseEqualizerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControllersEnabled();
        }

        /// <summary>
        /// リセットボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ResetAllFilters();
        }

        private void EqualizerDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.DialogResult == DialogResult.Cancel)
            {
                // 設定を変更前の状態に復元
                AudioPlayerManager.UseEqualizer = this.changeBeforeUseEqualizer;
                AudioPlayerManager.EqualizerAverageGainDecibels = this.changeBeforeLevels;
                return;
            }

            AudioPlayerManager.UseEqualizer = this.UseEqualizerCheckBox.Checked;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveCurrentOptionButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "RabbitTune イコライザ設定(*.req)|*.req";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new EqualizerConfigFileWriter(dialog.FileName);
                writer.EqualizerGainDBs = AudioPlayerManager.EqualizerAverageGainDecibels;

                writer.Save();
            }
        }

        private void LoadOptionButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "RabbitTune イコライザ設定(*.req)|*.req|全てのファイル|**";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var reader = new EqualizerConfigFileReader(dialog.FileName);
                reader.Read();

                AudioPlayerManager.EqualizerAverageGainDecibels = reader.EqualizerGainDBs;
                UpdateControllersView();
            }
        }
    }
}
