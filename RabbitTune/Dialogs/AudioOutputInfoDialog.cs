using RabbitTune.AudioEngine;
using RabbitTune.AudioEngine.AudioOutputApi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class AudioOutputInfoDialog : Form
    {
        // コンストラクタ
        public AudioOutputInfoDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
        }

        /// <summary>
        /// プロパティを表示するための文字列を取得する。
        /// </summary>
        /// <returns></returns>
        private string GetPropertyDisplayText()
        {
            // 停止中ではないか？
            if(AudioPlayerManager.IsPlaying || AudioPlayerManager.IsPausing)
            {
                string wasapi_data_mode = AudioPlayerManager.UseWasapiEventSync ? "イベント" : "プッシュ";

                // 各種フォーマット情報を取得
                AudioPlayerManager.GetInputWaveFormat(out int isr, out int isb, out int isc);
                AudioPlayerManager.GetOutputWaveFormat(out int osr, out int osb, out int osc);
                AudioPlayerManager.GetDeviceOutputWaveFormat(out int dsr, out int dsb, out int dsc);

                return $@"【ファイル情報】
コーデック：{AudioReader.GetFormatName(AudioPlayerManager.GetCurrentTrack().Location)}

【フォーマット】
入力フォーマット：({isr}Hz, {isb}bits, {isc}ch)
出力フォーマット：({osr}Hz, {osb}bits, {osc}ch)

【デバイス】
デバイス名：{AudioPlayerManager.AudioOutputDevice}
デバイスAPI：{getApiDisplayText(AudioPlayerManager.OutputDeviceApiType)}
WASAPI排他モード:{getBooleanDisplayText(AudioPlayerManager.UseWasapiExclusiveMode)}
WASAPIデータ供給：{wasapi_data_mode}
レイテンシ：{AudioPlayerManager.PlaybackLatency}
MMCSS:{getBooleanDisplayText(AudioPlayerManager.EnableMMCSS)}
出力可能フォーマット：({dsr}Hz, {dsb}bits, {dsc}ch)";
            }

            string getApiDisplayText(AudioOutputDeviceApiType api)
            {
                switch (api)
                {
                    case AudioOutputDeviceApiType.Asio:
                        return "ASIO";
                    case AudioOutputDeviceApiType.WaveOutEvent:
                        return "WaveOut(Event Mode)";
                    case AudioOutputDeviceApiType.WaveOut:
                        return "WaveOut";
                    case AudioOutputDeviceApiType.Wasapi:
                        return "WASAPI";
                    case AudioOutputDeviceApiType.DirectSound:
                        return "DirectSound";
                    default:
                        return "Unknown";
                }
            }

            string getBooleanDisplayText(bool val)
            {
                if (val)
                {
                    return "有効";
                }

                return "無効";
            }

            return string.Empty;
        }

        /// <summary>
        /// フォームをモーダルダイアログとして表示する。
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            this.PropertyTextBox.Text = GetPropertyDisplayText();
            return base.ShowDialog();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
