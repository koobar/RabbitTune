using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper.Midi
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SoundFontInfo
    {
        IntPtr name;
        IntPtr copyright;
        IntPtr comment;

        /// <summary>
        /// サウンドフォントに含まれるプリセットの数
        /// </summary>
        public int Presets;

        /// <summary>
        /// サウンドフォントに含まれるサンプルデータのサイズ
        /// </summary>
        public int SampleDataSize;

        /// <summary>
        /// メモリ上に読み込まれたサウンドフォントのサンプルデータのサイズ
        /// </summary>
        public int SampleDataLoaded;

        /// <summary>
        /// サンプルデータの種類
        /// </summary>
        public int SampleDataType;

        /// <summary>
        /// サウンドフォントの名前
        /// </summary>
        public string Name => name == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(name);

        /// <summary>
        /// 著作権表示
        /// </summary>
        public string Copyright => copyright == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(copyright);

        /// <summary>
        /// サウンドフォントに含まれるコメント
        /// </summary>
        public string Comment => comment == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(comment);
    }
}
