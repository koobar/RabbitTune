using System;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public partial class EqualizerOptionControl : UserControl
    {
        // 非公開変数
        private int FilterIndex;

        // コンストラクタ
        public EqualizerOptionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GainDB
        /// </summary>
        public double GainDB
        {
            get
            {
                return ToDb(this.LevelTrackBar.Value);
            }
            set
            {
                this.LevelTrackBar.Value = ToTrackBarValue(value);
            }
        }

        /// <summary>
        /// このコントローラーが設定するイコライザのフィルタを設定する。
        /// </summary>
        /// <param name="filterIndex"></param>
        public void SetEqualizerFilterIndex(int filterIndex)
        {
            this.FilterIndex = filterIndex;
            this.GainDB = AudioPlayerManager.GetAverageGainDB(filterIndex);

            UpdateLevelText();
            UpdateFreqText(filterIndex);
        }

        /// <summary>
        /// 周波数のテキストを更新する。
        /// </summary>
        /// <param name="filterIndex"></param>
        private void UpdateFreqText(int filterIndex)
        {
            this.AverageFreqLabel.Text = toDisplayText(AudioPlayerManager.GetAverageFrequency(filterIndex));

            string toDisplayText(double hz)
            {
                if(hz >= 10000)
                {
                    return $"{hz / 1000}khz";
                }

                return $"{hz}hz";
            }
        }

        /// <summary>
        /// レベルのテキストを更新する。
        /// </summary>
        private void UpdateLevelText()
        {
            string c = null;
            var value = ToDb(this.LevelTrackBar.Value);

            if (value > 0)
            {
                c = "+";
            }

            this.LevelLabel.Text = $"{c}{value}db";
        }

        /// <summary>
        /// レベルトラックバーの値をデシベル単位に変換して返す。
        /// </summary>
        /// <param name="trackBarValue"></param>
        /// <returns></returns>
        private double ToDb(double trackBarValue)
        {
            double perc = trackBarValue / this.LevelTrackBar.Maximum;
            return perc * 20;
        }

        /// <summary>
        /// デシベル単位の値をレベルトラックバーの値に変換して返す。
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private int ToTrackBarValue(double db)
        {
            double value = db / 20;
            return (int)(value * this.LevelTrackBar.Maximum);
        }

        /// <summary>
        /// レベルの値が変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // 設定を反映する。
            AudioPlayerManager.SetAverageGainDB(this.FilterIndex, ToDb(this.LevelTrackBar.Value));

            // 表示を更新する。
            UpdateLevelText();
        }
    }
}
