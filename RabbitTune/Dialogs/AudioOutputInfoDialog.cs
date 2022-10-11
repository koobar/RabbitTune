using RabbitTune.AudioEngine;
using RabbitTune.AudioEngine.AudioOutputApi;
using System;
using System.Drawing;
using System.Text;
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

                var strbuilder = new StringBuilder();
                strbuilder.AppendLine($"【ファイル情報】");
                strbuilder.AppendLine($"コーデック：{AudioReader.GetFormatName(AudioPlayerManager.GetCurrentTrack().Location)}");
                strbuilder.AppendLine();
                strbuilder.AppendLine($"【フォーマット】");
                strbuilder.AppendLine($"入力フォーマット：({isr}Hz, {isb}bits, {isc}ch)");
                strbuilder.AppendLine($"出力フォーマット：({osr}Hz, {osb}bits, {osc}ch)");
                strbuilder.AppendLine();
                strbuilder.AppendLine($"【デバイス】");
                strbuilder.AppendLine($"デバイス名：{AudioPlayerManager.AudioOutputDevice}");
                strbuilder.AppendLine($"デバイスAPI：{getApiDisplayText(AudioPlayerManager.OutputDeviceApiType)}");
                strbuilder.AppendLine($"WASAPI排他モード:{getBooleanDisplayText(AudioPlayerManager.UseWasapiExclusiveMode)}");
                strbuilder.AppendLine($"WASAPIデータ供給：{wasapi_data_mode}");
                strbuilder.AppendLine($"レイテンシ：{AudioPlayerManager.PlaybackLatency}");
                strbuilder.AppendLine($"MMCSS:{getBooleanDisplayText(AudioPlayerManager.EnableMMCSS)}");
                strbuilder.AppendLine($"出力可能フォーマット：({dsr}Hz, {dsb}bits, {dsc}ch)");

                return strbuilder.ToString();
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
