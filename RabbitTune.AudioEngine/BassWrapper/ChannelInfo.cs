using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ChannelInfo
    {
        // 非公開変数
        private int sampleRate;
        private int channelCount;
        private BassFlags flags;
        private ChannelType channelType;
        private int origres;
        private int plugin;
        private int sample;
        private IntPtr fileName;

        /// <summary>
        /// サンプルレート
        /// </summary>
        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }
        }

        /// <summary>
        /// チャンネル数
        /// </summary>
        public int Channels
        {
            get
            {
                return this.channelCount;
            }
        }

        /// <summary>
        /// チャンネルの種類
        /// </summary>
        public ChannelType ChannelType
        {
            get
            {
                return this.channelType;
            }
        }

        /// <summary>
        /// 量子化ビット数
        /// </summary>
        public int BitsPerSample
        {
            get
            {
                if (this.flags.HasFlag(BassFlags.Byte))
                {
                    return 8;
                }
                else if (this.flags.HasFlag(BassFlags.Float))
                {
                    return 32;
                }
                else
                {
                    return 16;
                }
            }
        }
    }
}
