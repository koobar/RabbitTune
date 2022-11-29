using System;

namespace RabbitTune.AudioEngine.BassWrapper.Cd
{
    public class BassCd
    {
        /// <summary>
        /// 指定されたドライブの最大動作速度を取得する。
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <returns></returns>
        public static int GetMaximumSpeed(char driveLetter)
        {
            int drive = GetDriveNumber(driveLetter);

            if(drive == -1)
            {
                return -1;
            }

            BassCdNative.BASS_CD_GetInfo(drive, out var info);

            return info.MaxSpeed;
        }

        /// <summary>
        /// 指定されたドライブの動作速度を倍率で設定する。
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <param name="speed"></param>
        public static void SetDriveMultiplier(char driveLetter, int multiplier)
        {
            // 倍率で指定された速度から1秒当たりのキロバイト数を求めて速度とする。
            int speed = (int)Math.Round(multiplier * 176.4);

            // ドライブの速度を設定する。
            SetDriveSpeed(driveLetter, speed);
        }

        /// <summary>
        /// 指定されたドライブの速度を設定する。
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <param name="speed"></param>
        public static void SetDriveSpeed(char driveLetter, int speed)
        {
            int drive = GetDriveNumber(driveLetter);

            if(drive == -1)
            {
                return;
            }

            BassCdNative.BASS_CD_SetSpeed(drive, speed);
        }

        /// <summary>
        /// 指定されたドライブの動作速度を取得する。
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <returns></returns>
        public static int GetDriveSpeed(char driveLetter)
        {
            int drive = GetDriveNumber(driveLetter);

            if(drive == -1)
            {
                return -1;
            }

            return BassCdNative.BASS_CD_GetSpeed(drive);
        }

        /// <summary>
        /// 利用可能なドライブ数を取得する。
        /// </summary>
        /// <returns></returns>
        private static int GetNumberOfDrives()
        {
            int i;

            // CDドライブ情報の取得に失敗するまで情報を取得し、その回数をiをインクリメントすることでカウントする。
            for (i = 0; BassCdNative.BASS_CD_GetInfo(i, out var info); ++i) { }

            return i;
        }

        /// <summary>
        /// ドライブレターで指定されたドライブのドライブ番号を取得する。<br/>
        /// ドライブ番号の取得に失敗した場合、-1を返す。
        /// </summary>
        /// <param name="driveLetter"></param>
        /// <returns></returns>
        private static int GetDriveNumber(char driveLetter)
        {
            var max = GetNumberOfDrives();

            for(int i = 0; i < max; ++i)
            {
                BassCdNative.BASS_CD_GetInfo(i, out var info);

                if(info.DriveLetter == driveLetter)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
