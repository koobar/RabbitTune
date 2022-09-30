using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class SampleToPcm : IWaveProvider
    {
        // 非公開変数
        private IWaveProvider dst;

        // コンストラクタ
        public SampleToPcm(ISampleProvider src, int bitsPerSample)
        {
            // 指定された量子化ビット数のPCMに変換する。
            switch (bitsPerSample)
            {
                case 16:
                    this.dst = new SampleToWaveProvider16(src);
                    break;
                case 24:
                    this.dst = new SampleToWaveProvider24(src);
                    break;
                case 32:
                    this.dst = new SampleToWaveProvider(src);
                    break;
            }
        }

        /// <summary>
        /// このオーディオソースのフォーマット
        /// </summary>
        public WaveFormat WaveFormat => this.dst.WaveFormat;

        /// <summary>
        /// オーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            return this.dst.Read(buffer, offset, count);
        }
    }
}
