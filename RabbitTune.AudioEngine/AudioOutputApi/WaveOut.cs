using NWaveOut = NAudio.Wave.WaveOut;

namespace RabbitTune.AudioEngine.AudioOutputApi
{
    public static class WaveOut
    {
        /// <summary>
        /// 指定された名前のデバイスを取得する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static int GetDevice(string deviceName)
        {
            for(int i = 0; i < NWaveOut.DeviceCount; ++i)
            {
                var cap = NWaveOut.GetCapabilities(i);

                if(cap.ProductName == deviceName)
                {
                    return i;
                }
            }

            return GetDefaultDevice();
        }

        /// <summary>
        /// デフォルトデバイスを取得する。
        /// </summary>
        /// <returns></returns>
        private static int GetDefaultDevice()
        {
            return 0;
        }

        /// <summary>
        /// デフォルトデバイスのデバイス名を取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultDeviceName()
        {
            if (NWaveOut.DeviceCount > 0)
            {
                var cap = NWaveOut.GetCapabilities(GetDefaultDevice());

                return cap.ProductName;
            }

            return string.Empty;
        }

        /// <summary>
        /// 利用可能なすべてのデバイスの名前一覧を取得する。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllAvailableDeviceNames()
        {
            var devices = NWaveOut.DeviceCount;
            string[] result = new string[devices];

            for (int i = 0; i < devices; ++i)
            {
                result[i] = NWaveOut.GetCapabilities(i).ProductName;
            }

            return result;
        }
    }
}
