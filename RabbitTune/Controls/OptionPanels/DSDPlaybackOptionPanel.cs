using System.Windows.Forms;

namespace RabbitTune.Controls.OptionPanels
{
    public partial class DSDPlaybackOptionPanel : UserControl
    {
        // 非公開定数
        private const string DSDTOPCM_SAMPLERATE_44100HZ = "44100Hz";
        private const string DSDTOPCM_SAMPLERATE_48000HZ = "48000Hz";
        private const string DSDTOPCM_SAMPLERATE_88200HZ = "88200Hz";
        private const string DSDTOPCM_SAMPLERATE_96000HZ = "96000Hz";
        private const string DSDTOPCM_SAMPLERATE_176400HZ = "176400Hz";
        private const string DSDTOPCM_SAMPLERATE_192000HZ = "192000Hz";
        private const string DSDTOPCM_SAMPLERATE_352800HZ = "352800Hz";
        private const string DSDTOPCM_SAMPLERATE_384000HZ = "384000Hz";
        private const string DSDTOPCM_SAMPLERATE_705600HZ = "705600Hz";
        private const string DSDTOPCM_GAIN_ZERO = "0db";
        private const string DSDTOPCM_GAIN_1 = "+1db";
        private const string DSDTOPCM_GAIN_2 = "+2db";
        private const string DSDTOPCM_GAIN_3 = "+3db";
        private const string DSDTOPCM_GAIN_4 = "+4db";
        private const string DSDTOPCM_GAIN_5 = "+5db";
        private const string DSDTOPCM_GAIN_6 = "+6db";

        // コンストラクタ
        public DSDPlaybackOptionPanel()
        {
            InitializeComponent();
            this.DSDToPCMConvertSampleRateComboBox.Items.AddRange(new string[]
            {
                DSDTOPCM_SAMPLERATE_44100HZ,
                DSDTOPCM_SAMPLERATE_48000HZ,
                DSDTOPCM_SAMPLERATE_88200HZ,
                DSDTOPCM_SAMPLERATE_96000HZ,
                DSDTOPCM_SAMPLERATE_176400HZ,
                DSDTOPCM_SAMPLERATE_192000HZ,
                DSDTOPCM_SAMPLERATE_352800HZ,
                DSDTOPCM_SAMPLERATE_384000HZ,
                DSDTOPCM_SAMPLERATE_705600HZ
            });
            this.DSDToPCMConvertGainValueComboBox.Items.AddRange(new string[]
            {
                DSDTOPCM_GAIN_ZERO,
                DSDTOPCM_GAIN_1,
                DSDTOPCM_GAIN_2,
                DSDTOPCM_GAIN_3,
                DSDTOPCM_GAIN_4,
                DSDTOPCM_GAIN_5,
                DSDTOPCM_GAIN_6
            });

            LoadOptions();
        }

        /// <summary>
        /// 設定を保存する。
        /// </summary>
        public void SaveOptions()
        {
            AudioPlayerManager.DsdToPcmSampleRate = GetSelectedSampleRate();
            AudioPlayerManager.DsdToPcmGain = GetSelectedGainValue();
        }

        /// <summary>
        /// 設定を読み込んで表示に反映する。
        /// </summary>
        private void LoadOptions()
        {
            if (!ControlUtils.IsDesignMode())
            {
                SetSelectedSampleRate(AudioPlayerManager.DsdToPcmSampleRate);
                SetSelectedGainValue(AudioPlayerManager.DsdToPcmGain);
            }
        }

        /// <summary>
        /// DSD->PCM変換のサンプルレートを選択する。
        /// </summary>
        /// <param name="sampleRate"></param>
        private void SetSelectedSampleRate(int sampleRate)
        {
            switch(sampleRate)
            {
                case 44100:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_44100HZ;
                    break;
                case 48000:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_48000HZ;
                    break;
                case 88200:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_88200HZ;
                    break;
                case 96000:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_96000HZ;
                    break;
                case 176400:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_176400HZ;
                    break;
                case 192000:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_192000HZ;
                    break;
                case 352800:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_352800HZ;
                    break;
                case 384000:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_384000HZ;
                    break;
                case 705600:
                    this.DSDToPCMConvertSampleRateComboBox.Text = DSDTOPCM_SAMPLERATE_705600HZ;
                    break;
            }
        }

        /// <summary>
        /// 選択されたDSD->PCM変換のサンプルレートを取得する。
        /// </summary>
        /// <returns></returns>
        private int GetSelectedSampleRate()
        {
            switch (this.DSDToPCMConvertSampleRateComboBox.Text)
            {
                case DSDTOPCM_SAMPLERATE_44100HZ:
                    return 44100;
                case DSDTOPCM_SAMPLERATE_48000HZ:
                    return 48000;
                case DSDTOPCM_SAMPLERATE_88200HZ:
                    return 88200;
                case DSDTOPCM_SAMPLERATE_96000HZ:
                    return 96000;
                case DSDTOPCM_SAMPLERATE_176400HZ:
                    return 176400;
                case DSDTOPCM_SAMPLERATE_192000HZ:
                    return 192000;
                case DSDTOPCM_SAMPLERATE_352800HZ:
                    return 352800;
                case DSDTOPCM_SAMPLERATE_384000HZ:
                    return 384000;
                case DSDTOPCM_SAMPLERATE_705600HZ:
                    return 705600;
                default:
                    return 88200;
            }
        }

        private void SetSelectedGainValue(int gain)
        {
            switch (gain)
            {
                case 0:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_ZERO;
                    break;
                case 1:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_1;
                    break;
                case 2:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_2;
                    break;
                case 3:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_3;
                    break;
                case 4:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_4;
                    break;
                case 5:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_5;
                    break;
                case 6:
                    this.DSDToPCMConvertGainValueComboBox.Text = DSDTOPCM_GAIN_6;
                    break;
            }
        }

        private int GetSelectedGainValue()
        {
            switch (this.DSDToPCMConvertGainValueComboBox.Text)
            {
                case DSDTOPCM_GAIN_ZERO:
                    return 0;
                case DSDTOPCM_GAIN_1:
                    return 1;
                case DSDTOPCM_GAIN_2:
                    return 2;
                case DSDTOPCM_GAIN_3:
                    return 3;
                case DSDTOPCM_GAIN_4:
                    return 4;
                case DSDTOPCM_GAIN_5:
                    return 5;
                case DSDTOPCM_GAIN_6:
                    return 6;
                default:
                    return 3;
            }
        }
    }
}
