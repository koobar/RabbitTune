/* SoundTouch C# Interop class. */
using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.SoundTouchWrapper
{
    internal static class SoundTouchInterop
    {
        // 非公開定数
        private const string SOUNDTOUCH_DLL = @"SoundTouch.dll";

        /// <summary>
        /// SoundTouch のインスタンスを生成し、そのハンドルを返す。
        /// </summary>
        /// <returns></returns>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr soundtouch_createInstance();

        /// <summary>
        /// 指定されたハンドルのインスタンスを破棄する。
        /// </summary>
        /// <param name="handle"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_destroyInstance(IntPtr handle);

        /// <summary>
        /// 指定されたハンドルのインスタンスのテンポを設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="newTempo"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_setTempoChange(IntPtr handle, float newTempo);

        /// <summary>
        /// 指定されたハンドルのインスタンスのピッチを設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="newPitch"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_setPitch(IntPtr handle, float newPitch);

        /// <summary>
        /// 指定されたハンドルのインスタンスのピッチを半音単位で設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="newPitch"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_setPitchSemiTones(IntPtr handle, float newPitch);

        /// <summary>
        /// 指定されたハンドルのインスタンスのチャンネル数を設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="numChannels"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_setChannels(IntPtr handle, uint numChannels);

        /// <summary>
        /// 指定されたハンドルのインスタンスのサンプルレートを設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="srate"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_setSampleRate(IntPtr handle, uint srate);

        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_flush(IntPtr handle);

        /// <summary>
        /// 指定されたハンドルのインスタンスにサンプルを送信する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="samples"></param>
        /// <param name="numSamples"></param>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void soundtouch_putSamples(IntPtr handle, float[] samples, uint numSamples);

        /// <summary>
        /// 指定されたハンドルのインスタンスから、指定された個数のサンプルを取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="outBuffer"></param>
        /// <param name="maxSamples"></param>
        /// <returns></returns>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint soundtouch_receiveSamples(IntPtr handle, float[] outBuffer, uint maxSamples);

        /// <summary>
        /// 指定されたハンドルのインスタンスで利用可能なサンプルの総数を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint soundtouch_numSamples(IntPtr handle);

        /// <summary>
        /// 指定されたハンドルのインスタンスを初期化する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(SOUNDTOUCH_DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint soundtouch_clear(IntPtr handle);
    }
}
