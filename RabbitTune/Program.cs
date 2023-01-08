using RabbitTune.AudioEngine;
using RabbitTune.WinApi;
using System;
using System.Diagnostics;
using System.IO;

namespace RabbitTune
{
    internal static class Program
    {
        // ���J�萔
        public const string APPLICATION_NAME = "RabbitTune";

        // ���J�ϐ�
        public static readonly Version ApplicationVersion = new Version(1, 0, 6, 0);
        public static bool ResetApplicationOptionRequested = false;

        // ����J�ϐ�
        private static AppConfigManager AppConfigManager;
        private static App AppInstance;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g �ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // �G���W��������������B
            Engine.Initialize();

            // �ݒ�Ǘ��p�N���X��������
            AppConfigManager = new AppConfigManager();

            // �ݒ��ǂݍ��ށB
            AppConfigManager.LoadAllOptions();

            // ���𑜓x�f�B�X�v���C���ł̕\�����[�h��ݒ�
            SetAppDPIMode();

            // �A�v���̃C���X�^���X�𐶐�
            AppInstance = new App();

            // ���C���t�H�[�����擾
            var mainWnd = AppInstance.GetMainForm();

            // �N������
            AppInstance.Run(args);

            // �ݒ��ۑ�
            AppConfigManager.SaveAllOptions(mainWnd);

            // ���C�u�����̎g�p�I������
            Engine.Free();
        }

        /// <summary>
        /// OS�̃X�P�[�����O�̎g�p�ݒ���s���B
        /// </summary>
        private static void SetAppDPIMode()
        {
            if (ApplicationOptions.CallSetProcessDPIAware)
            {
                User32.SetProcessDPIAware();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����̎��s�t�@�C���̃t���p�X���擾����B
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationFullPath()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }

        /// <summary>
        /// �A�v���P�[�V�����̎��s�t�@�C�����z�u���ꂽ�f�B���N�g�����擾����B
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationExecutingDirectory()
        {
            return Path.GetDirectoryName(GetApplicationFullPath());
        }
    }
}