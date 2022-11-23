using NAudio.Wave;
using RabbitTune.AudioEngine.SoundTouchWrapper;
using System;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class SoundTouchSampleProvider : ISampleProvider
    {
        // 非公開変数
        private readonly ISampleProvider source;
        private readonly SoundTouch soundTouch;
        private readonly float[] sourceReadBuffer;
        private readonly float[] soundTouchReadBuffer;
        private bool FLAG_SEEK_REQUESTED;

        // コンストラクタ
        public SoundTouchSampleProvider(ISampleProvider src, int latency)
        {
            this.source = src;

            // SoundTouchを初期化
            this.soundTouch = new SoundTouch();
            this.soundTouch.SetSampleRate(src.WaveFormat.SampleRate);
            this.soundTouch.SetChannels(src.WaveFormat.Channels);

            // 各種バッファを作成
            this.sourceReadBuffer = new float[(src.WaveFormat.SampleRate * src.WaveFormat.Channels * (long)latency) / 1000];
            this.soundTouchReadBuffer = new float[this.sourceReadBuffer.Length * 10];
        }

        /// <summary>
        /// ピッチを設定する。
        /// </summary>
        /// <param name="semitones"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetPitchSemitones(float semitones)
        {
            if (semitones > 12.0f || semitones < -12.0f)
            {
                throw new ArgumentOutOfRangeException("semitones");
            }

            this.soundTouch.SetPitchSemitones(semitones);
        }

        /// <summary>
        /// テンポを設定する。
        /// </summary>
        /// <param name="tempo"></param>
        public void SetTempo(float tempo)
        {
            this.soundTouch.SetTempo(tempo);
        }

        /// <summary>
        /// オーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(float[] buffer, int offset, int count)
        {
            if (this.FLAG_SEEK_REQUESTED)
            {
                this.soundTouch.Clear();
                this.FLAG_SEEK_REQUESTED = false;
            }

            int samplesRead = 0;
            bool reachedEndOfSource = false;

            while (samplesRead < count)
            {
                if (this.soundTouch.NumberOfSamplesAvailable == 0)
                {
                    var readFromSource = this.source.Read(this.sourceReadBuffer, 0, this.sourceReadBuffer.Length);

                    if (readFromSource > 0)
                    {
                        this.soundTouch.PutSamples(this.sourceReadBuffer, (uint)(readFromSource / this.source.WaveFormat.Channels));
                    }
                    else
                    {
                        reachedEndOfSource = true;
                        this.soundTouch.Flush();
                    }
                }

                var desiredSampleFrames = (count - samplesRead) / this.source.WaveFormat.Channels;
                var received = this.soundTouch.ReceiveSamples(this.soundTouchReadBuffer, desiredSampleFrames) * this.source.WaveFormat.Channels;

                // 出力用バッファにSoundTouchから読み込んだサンプルをコピー
                for (int n = 0; n < received; n++)
                {
                    buffer[offset + samplesRead++] = this.soundTouchReadBuffer[n];
                }

                if (received == 0 && reachedEndOfSource)
                {
                    break;
                }
            }
            return samplesRead;
        }

        /// <summary>
        /// 波形フォーマット
        /// </summary>
        public WaveFormat WaveFormat => this.source.WaveFormat;

        public void Dispose()
        {
            this.soundTouch.Dispose();
        }

        public void Reposition()
        {
            FLAG_SEEK_REQUESTED = true;
        }
    }
}
