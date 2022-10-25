using RabbitTune.AudioEngine.BassWrapper;

namespace RabbitTune.AudioEngine
{
    public static class Engine
    {
        /// <summary>
        /// ライブラリを初期化する。
        /// </summary>
        public static void Initialize()
        {
            // ネイティブライブラリのディレクトリを設定
            Win32Api.SetNativeDllDirectory();

            // BASS Audio Library の初期化
            InitBassLibrary();
        }

        /// <summary>
        /// ライブラリの使用終了処理を行う。
        /// </summary>
        public static void Free()
        {
            FreeBassLibrary();
        }

        /// <summary>
        /// BASSライブラリを初期化
        /// </summary>
        private static void InitBassLibrary()
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
        private static void FreeBassLibrary()
        {
            Bass.Free();
        }
    }
}
