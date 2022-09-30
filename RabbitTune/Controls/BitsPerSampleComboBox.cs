using RabbitTune.AudioEngine;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public class BitsPerSampleComboBox : ComboBox
    {
        // 非公開定数
        private const string BITS_NOCONV = @"変換しない";
        private const string BITS_16 = @"16ビット";
        private const string BITS_24 = @"24ビット";
        private const string BITS_32 = @"32ビット";

        // コンストラクタ
        public BitsPerSampleComboBox()
        {
            this.Font = SystemFonts.CaptionFont;
            this.FlatStyle = FlatStyle.System;
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadItems();
        }

        private void LoadItems()
        {
            bool isInDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            if (!isInDesignMode)
            {
                this.Items.AddRange(new string[]
                {
                    BITS_NOCONV,
                    BITS_16,
                    BITS_24,
                    BITS_32
                });
            }
        }

        /// <summary>
        /// 選択された量子化ビット数
        /// </summary>
        public int SelectedBitsPerSample
        {
            get
            {
                return GetSelectedBitsPerSample();
            }
            set
            {
                SetSelectedBitsPerSample(value);
            }
        }

        private int GetSelectedBitsPerSample()
        {
            int bitsPerSample = AudioPlayer.WAVEFORMAT_NOCONV;

            if(this.SelectedItem != null)
            {
                switch (this.SelectedItem.ToString())
                {
                    case BITS_16:
                        bitsPerSample = 16;
                        break;
                    case BITS_24:
                        bitsPerSample = 24;
                        break;
                    case BITS_32:
                        bitsPerSample = 32;
                        break;
                    case BITS_NOCONV:
                        bitsPerSample = AudioPlayer.WAVEFORMAT_NOCONV;
                        break;
                }
            }

            return bitsPerSample;
        }

        private void SetSelectedBitsPerSample(int bitsPerSample)
        {
            string bitsPerSampleText = null;

            switch (bitsPerSample)
            {
                case 16:
                    bitsPerSampleText = BITS_16;
                    break;
                case 24:
                    bitsPerSampleText = BITS_24;
                    break;
                case 32:
                    bitsPerSampleText = BITS_32;
                    break;
                case AudioPlayer.WAVEFORMAT_NOCONV:
                    bitsPerSampleText = BITS_NOCONV;
                    break;
            }

            if(bitsPerSampleText != null)
            {
                this.Text = bitsPerSampleText;
            }
        }
    }
}
