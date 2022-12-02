using NAudio.CoreAudioApi;
using System.Collections.Generic;

namespace RabbitTune.AudioEngine.AudioOutputApi
{
    public static class Wasapi
    {
        /// <summary>
        /// 指定された名前のデバイスを取得する。存在しなければデフォルトのものを返す。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static MMDevice GetDevice(string deviceName)
        {
            var devices = GetAllAvailableDevices();

            foreach (var device in devices)
            {
                if(device.FriendlyName == deviceName)
                {
                    return device;
                }
            }

            return GetDefaultDevice();
        }

        /// <summary>
        /// デフォルトデバイスを取得する。
        /// </summary>
        /// <returns></returns>
        private static MMDevice GetDefaultDevice()
        {
            var enumerator = new MMDeviceEnumerator();

            if (enumerator.HasDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia))
            {
                return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            }

            return null;
        }

        /// <summary>
        /// デフォルトデバイスデバイス名を取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultDeviceName()
        {
            var dev = GetDefaultDevice();

            if (dev != null)
            {
                return dev.FriendlyName;
            }

            return string.Empty;
        }

        /// <summary>
        /// 利用可能なすべてのデバイスの名前一覧を取得する。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllAvailableDeviceNames()
        {
            var devices = GetAllAvailableDevices();
            string[] result = new string[devices.Length];

            for(int i = 0; i < devices.Length; ++i)
            {
                result[i] = devices[i].FriendlyName;
            }

            return result;
        }

        /// <summary>
        /// 利用可能なデバイスをすべて取得する。
        /// </summary>
        /// <returns></returns>
        public static MMDevice[] GetAllAvailableDevices()
        {
            var result = new List<MMDevice>();
            var devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.All);

            foreach(var device in devices)
            {
                if (IsAvailableOutputDevice(device))
                {
                    result.Add(device);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 指定されたデバイスが利用可能であるか判定して返す。
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        private static bool IsAvailableOutputDevice(MMDevice device)
        {
            return device.State == DeviceState.Active;
        }
    }
}
