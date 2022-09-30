using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using RabbitTune.AudioEngine;
using System.ComponentModel;
using System.Diagnostics;

namespace RabbitTune.Controls
{
    public class SampleRateComboBox : ComboBox
    {
        // 非公開定数
        private const string SAMPLERATE_NOCONV = @"変換しない";
        private const string SAMPLERATE_8000 = @"8000Hz";
        private const string SAMPLERATE_11025 = @"11025Hz";
        private const string SAMPLERATE_16000 = @"16000Hz";
        private const string SAMPLERATE_22050 = @"22050Hz";
        private const string SAMPLERATE_32000 = @"32000Hz";
        private const string SAMPLERATE_44100 = @"44100Hz";
        private const string SAMPLERATE_48000 = @"48000Hz";
        private const string SAMPLERATE_88200 = @"88200Hz";
        private const string SAMPLERATE_96000 = @"96000Hz";
        private const string SAMPLERATE_176400 = @"176400Hz";
        private const string SAMPLERATE_192000 = @"192000Hz";

        // コンストラクタ
        public SampleRateComboBox()
        {
            this.Font = SystemFonts.CaptionFont;
            this.FlatStyle = FlatStyle.System;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadItems();
        }

        /// <summary>
        /// アイテムを読み込む。
        /// </summary>
        private void LoadItems()
        {
            bool isInDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            if (!isInDesignMode)
            {
                this.Items.AddRange(new string[]
                {
                    SAMPLERATE_NOCONV,
                    SAMPLERATE_8000,
                    SAMPLERATE_11025,
                    SAMPLERATE_16000,
                    SAMPLERATE_22050,
                    SAMPLERATE_32000,
                    SAMPLERATE_44100,
                    SAMPLERATE_48000,
                    SAMPLERATE_88200,
                    SAMPLERATE_96000,
                    SAMPLERATE_176400,
                    SAMPLERATE_192000
                });
            }
        }

        /// <summary>
        /// 選択されたサンプルレート
        /// </summary>
        public int SelectedSampleRate
        {
            get
            {
                return GetSelectedSampleRate();
            }
            set
            {
                SetSelectedSampleRate(value);
            }
        }

        private int GetSelectedSampleRate()
        {
            int sampleRate = AudioPlayer.WAVEFORMAT_NOCONV;

            if (this.SelectedItem != null)
            {
                switch (this.SelectedItem.ToString())
                {
                    case SAMPLERATE_8000:
                        sampleRate = 8000;
                        break;
                    case SAMPLERATE_11025:
                        sampleRate = 11025;
                        break;
                    case SAMPLERATE_16000:
                        sampleRate = 16000;
                        break;
                    case SAMPLERATE_22050:
                        sampleRate = 22050;
                        break;
                    case SAMPLERATE_32000:
                        sampleRate = 32000;
                        break;
                    case SAMPLERATE_44100:
                        sampleRate = 44100;
                        break;
                    case SAMPLERATE_48000:
                        sampleRate = 48000;
                        break;
                    case SAMPLERATE_88200:
                        sampleRate = 88200;
                        break;
                    case SAMPLERATE_96000:
                        sampleRate = 96000;
                        break;
                    case SAMPLERATE_176400:
                        sampleRate = 176400;
                        break;
                    case SAMPLERATE_192000:
                        sampleRate = 192000;
                        break;
                    case SAMPLERATE_NOCONV:
                        sampleRate = AudioPlayer.WAVEFORMAT_NOCONV;
                        break;
                }
            }

            return sampleRate;
        }

        private void SetSelectedSampleRate(int sampleRate)
        {
            string sampleRateText = null;

            switch (sampleRate)
            {
                case 8000:
                    sampleRateText = SAMPLERATE_8000;
                    break;
                case 11025:
                    sampleRateText = SAMPLERATE_11025;
                    break;
                case 16000:
                    sampleRateText = SAMPLERATE_16000;
                    break;
                case 22050:
                    sampleRateText = SAMPLERATE_22050;
                    break;
                case 32000:
                    sampleRateText = SAMPLERATE_32000;
                    break;
                case 44100:
                    sampleRateText = SAMPLERATE_44100;
                    break;
                case 48000:
                    sampleRateText = SAMPLERATE_48000;
                    break;
                case 88200:
                    sampleRateText = SAMPLERATE_88200;
                    break;
                case 96000:
                    sampleRateText = SAMPLERATE_96000;
                    break;
                case 176400:
                    sampleRateText = SAMPLERATE_176400;
                    break;
                case 192000:
                    sampleRateText = SAMPLERATE_192000;
                    break;
                case AudioPlayer.WAVEFORMAT_NOCONV:
                    sampleRateText = SAMPLERATE_NOCONV;
                    break;
            }

            if(string.IsNullOrEmpty(sampleRateText) == false)
            {
                this.Text = sampleRateText;
            }
        }
    }
}
