namespace RabbitTune.AudioEngine.BassWrapper.Dsd
{
    internal static class BassDsd
    {
        // 非公開定数
        public const int DSD_FREQUENCY = 67584;
        public const int DSD_GAIN = 67585;

        /// <summary>
        /// DSDからPCMに変換する際のサンプルレートを設定する。
        /// </summary>
        /// <param name="frequency"></param>
        public static void SetDSDToPCMFrequency(int frequency)
        {
            BassNative.BASS_SetConfig(DSD_FREQUENCY, frequency);
        }

        /// <summary>
        /// DSDからPCMに変換する際のサンプルレートを取得する。
        /// </summary>
        /// <returns></returns>
        public static int GetDSDToPCMFrequency()
        {
            return BassNative.BASS_GetConfig(DSD_FREQUENCY);
        }

        /// <summary>
        /// DSDからPCMに変換する際のゲイン値を設定する。
        /// </summary>
        /// <param name="gain"></param>
        /// <returns></returns>
        public static void SetDSDToPCMGain(int gain)
        {
            BassNative.BASS_SetConfig(DSD_GAIN, gain);
        }

        /// <summary>
        /// DSDからPCMに変換する際のゲイン値を取得する。
        /// </summary>
        public static int GetDSDToPCMGain()
        {
            return BassNative.BASS_GetConfig(DSD_GAIN);
        }
    }
}
