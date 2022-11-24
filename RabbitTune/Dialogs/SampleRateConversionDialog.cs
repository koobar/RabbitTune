using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class SampleRateConversionDialog : Form
    {
        // コンストラクタ
        public SampleRateConversionDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
            this.UseSampleRateConversion = AudioPlayerManager.UseReSampler;
            this.SampleRate = AudioPlayerManager.ReSamplerSampleRate;
            this.BitsPerSample = AudioPlayerManager.ReSamplerBitsPerSample;
            this.Channels = AudioPlayerManager.ReSamplerChannels;
        }

        /// <summary>
        /// サンプルレート変換を使用するかどうかの設定値
        /// </summary>
        public bool UseSampleRateConversion
        {
            set
            {
                this.UseSampleRateConversionCheckBox.Checked = value;
            }
            get
            {
                return this.UseSampleRateConversionCheckBox.Checked;
            }
        }

        /// <summary>
        /// サンプルレート
        /// </summary>
        public int SampleRate
        {
            get
            {
                return this.SampleRateComboBox.SelectedSampleRate;
            }
            set
            {
                this.SampleRateComboBox.SelectedSampleRate = value;
            }
        }

        /// <summary>
        /// 量子化ビット数
        /// </summary>
        public int BitsPerSample
        {
            get
            {
                return this.BitsPerSampleComboBox.SelectedBitsPerSample;
            }
            set
            {
                this.BitsPerSampleComboBox.SelectedBitsPerSample = value;
            }
        }

        /// <summary>
        /// チャンネル数
        /// </summary>
        public int Channels
        {
            get
            {
                return this.ChannelsComboBox.SelectedChannels;
            }
            set
            {
                this.ChannelsComboBox.SelectedChannels = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// OKボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void UseSampleRateConversionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(this.UseSampleRateConversionCheckBox.Checked && AudioPlayerManager.IsTrackLoaded)
            {
                AudioPlayerManager.GetInputWaveFormat(out int _, out int bits, out int _);

                if (bits > 32)
                {
                    var selectedBtn = MessageBox.Show("現在のトラックに対してサンプルレート変換を有効化すると、量子化ビット数が低下する場合があります。\n" +
                        "サンプルレート変換を有効化しますか？",
                        "音質低下の可能性があります",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (selectedBtn == DialogResult.No)
                    {
                        this.UseSampleRateConversionCheckBox.Checked = false;
                    }
                }
            }
        }
    }
}
