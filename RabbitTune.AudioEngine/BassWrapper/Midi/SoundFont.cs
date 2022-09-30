using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper.Midi
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SoundFont
    {
        /// <summary>
        /// サウンドフォントのハンドル
        /// </summary>
        public int Handle;

        /// <summary>
        /// プリセット番号（0~65535, -1を指定した場合、サウンドフォントに含まれるすべてのプリセットを使用する。）
        /// </summary>
        public int Preset;

        /// <summary>
        /// ベースバンク番号、または各プリセットのバンク番号
        /// </summary>
        public int Bank;
    }
}
