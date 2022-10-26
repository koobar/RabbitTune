using RabbitTune.AudioEngine;
using RabbitTune.AudioEngine.AudioOutputApi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls.OptionPanels
{
    public partial class AudioOptionPanel : UserControl
    {
        // 非公開定数
        private const string DEVICEAPI_WAVEOUT = @"WaveOut";
        private const string DEVICEAPI_WAVEOUTEVENT = @"WaveOut(Event)";
        private const string DEVICEAPI_DSOUND = @"DirectSound";
        private const string DEVICEAPI_WASAPI = @"Windows Audio Session";
        private const string DEVICEAPI_ASIO = @"ASIO";
        private const string WASAPI_SYNCMODE_PUSH = @"Push";
        private const string WASAPI_SYNCMODE_EVENT = @"Event";
        private const string WAVEFORMATCONV_DESCRIPTION = @"出力フォーマットについて

出力フォーマットは、スピーカーなどのデバイスから出力される
オーディオのフォーマットです。このフォーマットを明示的に指定した場合、
各種エフェクトなどでフォーマットが異なるものに変換されている場合でも、
出力前にここで指定されたフォーマットに再変換してから出力します。

通常は「変換しない」を指定しておけば殆どの場合で動作しますが、
デバイスによっては、稀に動作しない場合があります。その場合、ここで
デバイスがサポートするフォーマットを設定することで、再生ができる
可能性があります。

なお、高音質化を目的としたフォーマット変換は、出力フォーマットを
「変換しない」、または無効化した状態で、「サンプリング周波数変換」を
使用していただくことを推奨します。";

        // コンストラクタ
        public AudioOptionPanel()
        {
            InitializeComponent();
            InitAudioOutputDeviceOptionComponents();
            LoadAudioOutputOptions();

            this.Font = SystemFonts.CaptionFont;
        }

        /// <summary>
        /// オーディオ出力設定のUIコンポーネントを初期化する。
        /// </summary>
        private void InitAudioOutputDeviceOptionComponents()
        {
            if (Asio.CheckAvailable())
            {
                this.AudioOutputAPIComboBox.Items.AddRange(new string[] { DEVICEAPI_WAVEOUT, DEVICEAPI_WAVEOUTEVENT, DEVICEAPI_DSOUND, DEVICEAPI_WASAPI, DEVICEAPI_ASIO });
            }
            else
            {
                this.AudioOutputAPIComboBox.Items.AddRange(new string[] { DEVICEAPI_WAVEOUT, DEVICEAPI_WAVEOUTEVENT, DEVICEAPI_DSOUND, DEVICEAPI_WASAPI});
            }
            this.WASAPISyncModesComboBox.Items.AddRange(new string[] { WASAPI_SYNCMODE_PUSH, WASAPI_SYNCMODE_EVENT });

            // 既定値の選択
            this.AudioOutputAPIComboBox.Text = DEVICEAPI_WAVEOUT;
            this.WaveFormatConversionSampleRateComboBox.SelectedSampleRate = AudioPlayer.WAVEFORMAT_NOCONV;
            this.WaveFormatConvertionBitsPerSampleComboBox.SelectedBitsPerSample = AudioPlayer.WAVEFORMAT_NOCONV;
        }

        /// <summary>
        /// このパネルで設定した項目を保存する。
        /// </summary>
        public void SaveOptions()
        {
            SaveAudioOutputOptions();
        }

        /// <summary>
        /// オーディオ出力設定を保存する。
        /// </summary>
        private void SaveAudioOutputOptions()
        {
            AudioPlayerManager.AudioOutputDevice = this.AudioOutputDevicesComboBox.Text;
            AudioPlayerManager.OutputDeviceApiType = GetAudioOutputDeviceApiType();
            AudioPlayerManager.UseWasapiEventSync = this.WASAPISyncModesComboBox.Text == WASAPI_SYNCMODE_EVENT;
            AudioPlayerManager.UseWasapiExclusiveMode = this.UseWASAPIExclusiveModeCheckBox.Checked;
            AudioPlayerManager.UseDeviceOutputWaveFormatConversion = this.UseOutputFmtConvCheckBox.Checked;
            AudioPlayerManager.DeviceOutputWaveFormatSampleRate = this.WaveFormatConversionSampleRateComboBox.SelectedSampleRate;
            AudioPlayerManager.DeviceOutputWaveFormatBitsPerSample = this.WaveFormatConvertionBitsPerSampleComboBox.SelectedBitsPerSample;
            AudioPlayerManager.PlaybackLatency = this.AudioOutputLatencyScroll.Value;
            AudioPlayerManager.EnableMMCSS = this.EnableMMCSSCheckBox.Checked;
        }

        /// <summary>
        /// オーディオ出力設定を読み込んで表示に反映する。
        /// </summary>
        private void LoadAudioOutputOptions()
        {
            if (!ControlUtils.IsDesignMode())
            {
                UpdateAudioOutputDeviceList();
                SelectCurrentOutputDevice();

                this.WASAPISyncModesComboBox.Text = AudioPlayerManager.UseWasapiEventSync ? WASAPI_SYNCMODE_EVENT : WASAPI_SYNCMODE_PUSH;
                this.UseWASAPIExclusiveModeCheckBox.Checked = AudioPlayerManager.UseWasapiExclusiveMode;
                this.UseOutputFmtConvCheckBox.Checked = AudioPlayerManager.UseDeviceOutputWaveFormatConversion;
                this.WaveFormatConversionSampleRateComboBox.SelectedSampleRate = AudioPlayerManager.DeviceOutputWaveFormatSampleRate;
                this.WaveFormatConvertionBitsPerSampleComboBox.SelectedBitsPerSample = AudioPlayerManager.DeviceOutputWaveFormatBitsPerSample;
                this.AudioOutputLatencyScroll.Value = AudioPlayerManager.PlaybackLatency;
                this.EnableMMCSSCheckBox.Checked = AudioPlayerManager.EnableMMCSS;

                // 後始末
                SetOutputFmtConvPanelEnabled(AudioPlayerManager.UseDeviceOutputWaveFormatConversion);
                SetSelectedAudioOutputDeviceApiType(AudioPlayerManager.OutputDeviceApiType);
            }
        }

        /// <summary>
        /// 現在設定されている出力デバイスを選択する。
        /// </summary>
        private void SelectCurrentOutputDevice()
        {
            string deviceName = AudioPlayerManager.AudioOutputDevice;

            if (string.IsNullOrEmpty(deviceName) || !this.AudioOutputAPIComboBox.Items.Contains(deviceName))
            {
                deviceName = GetDefaultDeviceName();
            }

            this.AudioOutputDevicesComboBox.Text = deviceName;
        }

        /// <summary>
        /// 利用可能なデバイスの一覧を更新する。
        /// </summary>
        private void UpdateAudioOutputDeviceList()
        {
            var devices = GetAvailableDevices();

            // 既存のアイテムを削除
            this.AudioOutputDevicesComboBox.Items.Clear();

            if (devices != null)
            {
                // 追加
                this.AudioOutputDevicesComboBox.Items.AddRange(devices);
            }
        }

        /// <summary>
        /// 選択されているAPIのデフォルトデバイスのデバイス名を取得する。
        /// </summary>
        /// <returns></returns>
        private string GetDefaultDeviceName()
        {
            switch (GetAudioOutputDeviceApiType())
            {
                case AudioOutputDeviceApiType.DirectSound:
                    return DirectSound.GetDefaultDeviceName();
                case AudioOutputDeviceApiType.Wasapi:
                    return Wasapi.GetDefaultDeviceName();
                case AudioOutputDeviceApiType.WaveOut:
                case AudioOutputDeviceApiType.WaveOutEvent:
                    return WaveOut.GetDefaultDeviceName();
                case AudioOutputDeviceApiType.Asio:
                    return Asio.GetDefaultDeviceName();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 選択されているAPIで利用可能なデバイスの一覧を取得する。
        /// </summary>
        /// <returns></returns>
        private string[] GetAvailableDevices()
        {
            var api = GetAudioOutputDeviceApiType();
            string[] devices = null;

            switch (api)
            {
                case AudioOutputDeviceApiType.WaveOut:
                case AudioOutputDeviceApiType.WaveOutEvent:
                    devices = WaveOut.GetAllAvailableDeviceNames();
                    break;
                case AudioOutputDeviceApiType.DirectSound:
                    devices = DirectSound.GetAllAvailableDeviceNames();
                    break;
                case AudioOutputDeviceApiType.Wasapi:
                    devices = Wasapi.GetAllAvailableDeviceNames();
                    break;
                case AudioOutputDeviceApiType.Asio:
                    devices = Asio.GetAllAvailableDeviceNames();
                    break;
            }

            return devices;
        }

        /// <summary>
        /// 選択されたオーディオ出力APIを取得する。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private AudioOutputDeviceApiType GetAudioOutputDeviceApiType()
        {
            if(this.AudioOutputAPIComboBox.SelectedItem != null)
            {
                switch (this.AudioOutputAPIComboBox.SelectedItem.ToString())
                {
                    case DEVICEAPI_DSOUND:
                        return AudioOutputDeviceApiType.DirectSound;
                    case DEVICEAPI_WAVEOUT:
                        return AudioOutputDeviceApiType.WaveOut;
                    case DEVICEAPI_WAVEOUTEVENT:
                        return AudioOutputDeviceApiType.WaveOutEvent;
                    case DEVICEAPI_WASAPI:
                        return AudioOutputDeviceApiType.Wasapi;
                    case DEVICEAPI_ASIO:
                        return AudioOutputDeviceApiType.Asio;
                    default:
                        throw new Exception("Unknown device api.");
                }
            }
            else
            {
                return AudioOutputDeviceApiType.WaveOut;
            }
        }

        /// <summary>
        /// 出力APIの選択を設定する。
        /// </summary>
        /// <param name="apiType"></param>
        private void SetSelectedAudioOutputDeviceApiType(AudioOutputDeviceApiType apiType)
        {
            string text = null;

            switch (apiType)
            {
                case AudioOutputDeviceApiType.WaveOut:
                    text = DEVICEAPI_WAVEOUT;
                    break;
                case AudioOutputDeviceApiType.WaveOutEvent:
                    text = DEVICEAPI_WAVEOUTEVENT;
                    break;
                case AudioOutputDeviceApiType.DirectSound:
                    text = DEVICEAPI_DSOUND;
                    break;
                case AudioOutputDeviceApiType.Wasapi:
                    text = DEVICEAPI_WASAPI;
                    break;
                case AudioOutputDeviceApiType.Asio:
                    text = DEVICEAPI_ASIO;
                    break;
            }

            if(text != null)
            {
                this.AudioOutputAPIComboBox.Text = text;
            }
        }

        /// <summary>
        /// 出力フォーマット設定部分の有効状態を設定する。
        /// </summary>
        /// <param name="enabled"></param>
        private void SetOutputFmtConvPanelEnabled(bool enabled)
        {
            this.label4.Enabled = enabled;
            this.WaveFormatConversionSampleRateComboBox.Enabled = enabled;
            this.label5.Enabled = enabled;
            this.WaveFormatConvertionBitsPerSampleComboBox.Enabled = enabled;
        }

        /// <summary>
        /// 出力デバイスリスト更新ボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAudioOutputDevicesButton_Click(object sender, EventArgs e)
        {
            UpdateAudioOutputDeviceList();
        }

        /// <summary>
        /// 出力デバイスAPIの選択が変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioOutputAPIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAudioOutputDeviceList();
            SelectCurrentOutputDevice();
        }

        /// <summary>
        /// 出力レイテンシの設定が変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AudioOutputLatencyTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.CurrentLatencyLabel.Text = $"レイテンシ:{this.AudioOutputLatencyScroll.Value}";
        }

        /// <summary>
        /// 出力フォーマット変換の使用チェックボックスのチェックが変更された際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseOutputFmtConvCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetOutputFmtConvPanelEnabled(this.UseOutputFmtConvCheckBox.Checked);
        }

        /// <summary>
        /// 出力フォーマットについてラベルがクリックされた際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveFormatDescriptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(WAVEFORMATCONV_DESCRIPTION, "出力フォーマットについて", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AudioOutputDevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowAsioControlPanelButton.Enabled =
                this.AudioOutputDevicesComboBox.Items.Count > 0 &&
                this.AudioOutputAPIComboBox.Text == DEVICEAPI_ASIO &&
                this.AudioOutputDevicesComboBox.SelectedIndex != -1;
        }

        private void ShowAsioControlPanelButton_Click(object sender, EventArgs e)
        {
            Asio.ShowControlPanel(this.AudioOutputDevicesComboBox.Text);
        }
    }
}
