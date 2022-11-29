using RabbitTune.AudioEngine.BassWrapper.Cd;
using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper
{
    internal class BassNative
    {
        // 非公開定数
        private const string DLLNAME = @"bass.dll";

        /// <summary>
        /// BASSライブラリの初期化
        /// </summary>
        /// <param name="Device"></param>
        /// <param name="Frequency"></param>
        /// <param name="Flags"></param>
        /// <param name="Win"></param>
        /// <param name="ClsID"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_Init(int device = -1, int sampleRate = 44100, DeviceInitFlags flags = DeviceInitFlags.Default, IntPtr window = default(IntPtr), IntPtr clsID= default(IntPtr));

        /// <summary>
        /// BASSライブラリのプラグインを読み込む。
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, CharSet = CharSet.Unicode)]
        public static extern int BASS_PluginLoad(string path, BassFlags flags = BassFlags.Unicode);

        /// <summary>
        /// ファイルからストリームを生成する。
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="file"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, CharSet = CharSet.Unicode)]
        public static extern int BASS_StreamCreateFile(bool mem, string file, long offset, long length, BassFlags flags);

        /// <summary>
        /// 最後に発生したエラーを取得する。
        /// </summary>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern BassErrors BASS_ErrorGetCode();

        /// <summary>
        /// 指定されたチャンネルの情報を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_ChannelGetInfo(int handle, out ChannelInfo info);

        /// <summary>
        /// 指定されたチャンネルの位置を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern long BASS_ChannelGetPosition(int handle, int mode = 0);

        /// <summary>
        /// 指定されたチャンネルの位置を設定する。
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="Position"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_ChannelSetPosition(int handle, long position, int mode = 0);

        /// <summary>
        /// 指定されたチャンネルの長さをバイト単位で取得する。
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern long BASS_ChannelGetLength(int handle, int mode = 0);

        /// <summary>
        /// 指定されたチャンネルのデータを第3引数に指定した長さ分読み込んで第2引数の配列に格納する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern int BASS_ChannelGetData(int handle, /*[In, Out]*/byte[] buffer, int length);

        /// <summary>
        /// 指定されたストリームを解放する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_StreamFree(int handle);

        /// <summary>
        /// BASSライブラリを解放する。
        /// </summary>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern bool BASS_Free();

        /// <summary>
        /// コンフィグを取得する。
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern int BASS_GetConfig(int option);

        /// <summary>
        /// コンフィグを設定する。
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [DllImport(DLLNAME)]
        public static extern int BASS_SetConfig(int option, int mode);

        [DllImport(DLLNAME)]
        public static extern long BASS_StreamGetFilePosition(int Handle, int Mode = 0);
    }
}
