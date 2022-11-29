using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper.Cd
{
    internal class BassCdNative
    {
        // 非公開フィールド
        private const string DLLNAME = @"basscd.dll";

        /// <summary>
        /// CDドライブの速度を設定する。
        /// </summary>
        /// <param name="Drive"></param>
        /// <param name="Speed"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_CD_SetSpeed(int drive, int speed);

        /// <summary>
        /// CDドライブの速度を取得する。
        /// </summary>
        /// <param name="Drive"></param>
        /// <param name="Speed"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern int BASS_CD_GetSpeed(int drive);

        /// <summary>
        /// CDドライブの情報を取得する。
        /// </summary>
        /// <param name="drive"></param>
        /// <param name="Info"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_CD_GetInfo(int drive, out CDInfo Info);
    }
}
