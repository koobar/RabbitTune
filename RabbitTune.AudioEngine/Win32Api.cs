using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine
{
    internal static class Win32Api
    {
        // 非公開変数
        private static string currentNativeDllDirectory;

        /// <summary>
        /// アプリケーションを実行しているプラットフォームに応じた<br/>
        /// ネイティブライブラリのディレクトリを自動判別して設定する。
        /// </summary>
        public static void SetNativeDllDirectory()
        {
            string process_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            // プロセスのビット数に応じたDLLの配置先を設定
            if (Environment.Is64BitProcess)
            {
                SetNativeDllDirectory($"{process_dir}\\lib\\x64");
            }
            else
            {
                SetNativeDllDirectory($"{process_dir}\\lib\\x86");
            }
        }

        /// <summary>
        /// ネイティブライブラリのディレクトリを指定された場所に設定する。
        /// </summary>
        /// <param name="lpPathName"></param>
        public static void SetNativeDllDirectory(string lpPathName)
        {
            SetDllDirectory(lpPathName);

            currentNativeDllDirectory = lpPathName;
        }

        /// <summary>
        /// 現在のネイティブライブラリのディレクトリを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetNativeDllDirectory()
        {
            return currentNativeDllDirectory;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableMMCSS(bool fEnable);
    }
}
