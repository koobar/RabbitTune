using RabbitTune.AudioEngine.Codecs.BassCompat;

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
            BassLib.Init();
        }

        /// <summary>
        /// ライブラリの使用終了処理を行う。
        /// </summary>
        public static void Free()
        {
            BassLib.Free();
        }
    }
}
