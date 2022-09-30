using NAudio.Wave.Asio;

namespace RabbitTune.AudioEngine.AudioOutputApi
{
    public class Asio
    {
        /// <summary>
        /// 利用可能なデバイス名の一覧を取得して返す。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllAvailableDeviceNames()
        {
            return AsioDriver.GetAsioDriverNames();
        }

        /// <summary>
        /// ASIOが利用可能か判定して返す。
        /// </summary>
        /// <returns></returns>
        public static bool CheckAvailable()
        {
            return GetAllAvailableDeviceNames().Length != 0;
        }

        /// <summary>
        /// デフォルトデバイス名を取得して返す。<br/>
        /// ASIO非対応環境の場合、nullを返す。
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultDeviceName()
        {
            var devices = GetAllAvailableDeviceNames();

            if(devices.Length > 0)
            {
                return devices[0];
            }

            return null;
        }

        /// <summary>
        /// ASIOの設定パネルを表示する。
        /// </summary>
        /// <param name="deviceName"></param>
        public static void ShowControlPanel(string deviceName)
        {
            var driver = AsioDriver.GetAsioDriverByName(deviceName);
            var ex = new AsioDriverExt(driver);

            ex.ShowControlPanel();
        }
    }
}
