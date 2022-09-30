using NAudio.Wave;
using System;
using System.Linq;

namespace RabbitTune.AudioEngine.AudioOutputApi
{
    public class DirectSound
    {
        /// <summary>
        /// 指定された名前のデバイスを取得する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static Guid GetDevice(string deviceName)
        {
            var devices = DirectSoundOut.Devices;

            foreach (var device in devices)
            {
                if (device.Description == deviceName)
                {
                    return device.Guid;
                }
            }

            return DirectSoundOut.DSDEVID_DefaultPlayback;
        }

        /// <summary>
        /// 指定された名前のデバイスのデバイス情報を取得する。
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public static DirectSoundDeviceInfo GetDeviceInfo(string deviceName)
        {
            var devices = DirectSoundOut.Devices;

            foreach (var device in devices)
            {
                if (device.Description == deviceName)
                {
                    return device;
                }
            }

            return null;
        }

        /// <summary>
        /// デフォルトデバイスの名前を取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultDeviceName()
        {
            return GetAllAvailableDeviceNames()[0];
        }

        /// <summary>
        /// 利用可能なすべてのデバイスの名前一覧を取得する。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllAvailableDeviceNames()
        {
            var devices = GetAllAvailableDevices();
            string[] result = new string[devices.Length];

            for (int i = 0; i < devices.Length; ++i)
            {
                result[i] = devices[i].Description;
            }

            return result;
        }

        /// <summary>
        /// 利用可能なすべてのデバイスを取得する。
        /// </summary>
        /// <returns></returns>
        public static DirectSoundDeviceInfo[] GetAllAvailableDevices()
        {
            return DirectSoundOut.Devices.ToArray();
        }
    }
}
