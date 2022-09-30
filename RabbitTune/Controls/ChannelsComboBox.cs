using RabbitTune.AudioEngine;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public class ChannelsComboBox : ComboBox
    {
        // 非公開定数
        private const string CHANNELS_NOCONV = @"変換しない";
        private const string CHANNELS_MONO =   @"1ch (Mono)";
        private const string CHANNELS_STEREO = @"2ch (Stereo)";

        // コンストラクタ
        public ChannelsComboBox()
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
                    CHANNELS_NOCONV,
                    CHANNELS_MONO,
                    CHANNELS_STEREO,
                });
            }
        }

        /// <summary>
        /// 選択されたチャンネル数
        /// </summary>
        public int SelectedChannels
        {
            get
            {
                return GetSelectedChannels();
            }
            set
            {
                SetSelectedChannels(value);
            }
        }

        private int GetSelectedChannels()
        {
            int channels = AudioPlayer.WAVEFORMAT_NOCONV;

            if (this.SelectedItem != null)
            {
                switch (this.SelectedItem.ToString())
                {
                    case CHANNELS_MONO:
                        channels = 1;
                        break;
                    case CHANNELS_STEREO:
                        channels = 2;
                        break;
                    case CHANNELS_NOCONV:
                        channels = AudioPlayer.WAVEFORMAT_NOCONV;
                        break;
                }
            }

            return channels;
        }

        private void SetSelectedChannels(int channels)
        {
            string channelsText = null;

            switch (channels)
            {
                case 1:
                    channelsText = CHANNELS_MONO;
                    break;
                case 2:
                    channelsText = CHANNELS_STEREO;
                    break;
                case AudioPlayer.WAVEFORMAT_NOCONV:
                    channelsText = CHANNELS_NOCONV;
                    break;
            }

            if (channelsText != null)
            {
                this.Text = channelsText;
            }
        }
    }
}
