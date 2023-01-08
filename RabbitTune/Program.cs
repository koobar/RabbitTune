using RabbitTune.AudioEngine;
using RabbitTune.WinApi;
using System;
using System.Diagnostics;
using System.IO;

namespace RabbitTune
{
    internal static class Program
    {
        // 公開定数
        public const string APPLICATION_NAME = "RabbitTune";

        // 公開変数
        public static readonly Version ApplicationVersion = new Version(1, 0, 6, 0);
        public static bool ResetApplicationOptionRequested = false;

        // 非公開変数
        private static AppConfigManager AppConfigManager;
        private static App AppInstance;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイント です。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化する。
            Engine.Initialize();

            // 設定管理用クラスを初期化
            AppConfigManager = new AppConfigManager();

            // 設定を読み込む。
            AppConfigManager.LoadAllOptions();

            // 高解像度ディスプレイ環境での表示モードを設定
            SetAppDPIMode();

            // アプリのインスタンスを生成
            AppInstance = new App();

            // メインフォームを取得
            var mainWnd = AppInstance.GetMainForm();

            // 起動処理
            AppInstance.Run(args);

            // 設定を保存
            AppConfigManager.SaveAllOptions(mainWnd);

            // ライブラリの使用終了処理
            Engine.Free();
        }

        /// <summary>
        /// OSのスケーリングの使用設定を行う。
        /// </summary>
        private static void SetAppDPIMode()
        {
            if (ApplicationOptions.CallSetProcessDPIAware)
            {
                User32.SetProcessDPIAware();
            }
        }

        /// <summary>
        /// アプリケーションの実行ファイルのフルパスを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationFullPath()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }

        /// <summary>
        /// アプリケーションの実行ファイルが配置されたディレクトリを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationExecutingDirectory()
        {
            return Path.GetDirectoryName(GetApplicationFullPath());
        }
    }
}