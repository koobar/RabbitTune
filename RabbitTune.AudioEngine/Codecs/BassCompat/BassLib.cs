using RabbitTune.AudioEngine.BassWrapper;

namespace RabbitTune.AudioEngine.Codecs.BassCompat
{
    internal class BassLib
    {
        /// <summary>
        /// BASSライブラリを初期化
        /// </summary>
        public static void Init()
        {
            Bass.Init(Bass.BASS_DEVICE_DECODE);
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bassopus.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bassdsd.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\basswv.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\basscd.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bassape.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bass_tta.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bass_spx.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bass_ofr.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bass_mpc.dll");
            Bass.LoadPlugin($"{Win32Api.GetNativeDllDirectory()}\\bassmidi.dll");
        }

        /// <summary>
        /// BASSライブラリを解放する。
        /// </summary>
        public static void Free()
        {
            Bass.Free();
        }
    }
}
