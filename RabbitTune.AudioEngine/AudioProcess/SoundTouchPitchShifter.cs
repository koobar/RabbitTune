using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using RabbitTune.AudioEngine.AudioProcess.SampleProviders;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class SoundTouchPitchShifter : ISampleProvider
    {
        // 非公開変数
        private readonly ISampleProvider src;
        private readonly SoundTouchSampleProvider soundTouch;
        private readonly ISampleProvider dest;
        private float pitch = 0;

        // コンストラクタ
        public SoundTouchPitchShifter(ISampleProvider source, bool fixClip)
        {
            this.src = source;
            this.soundTouch = Create(source, fixClip, out int dsr);

            if(dsr != source.WaveFormat.SampleRate)
            {
                this.dest = this.soundTouch;
            }
            else
            {
                this.dest = new WaveFormatConversion(this.soundTouch, true, 1, dsr, 32, this.soundTouch.WaveFormat.Channels);
            }
        }

        /// <summary>
        /// SoundTouchによるピッチシフタを生成する。<br/>
        /// 第2引数はクリッピング（音割れ）を低減するかどうか。省略時はtrue。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fixClip"></param>
        /// <returns></returns>
        private SoundTouchSampleProvider Create(ISampleProvider source, bool fixClip, out int defaultSampleRate)
        {
            var src = source;

            // 2チャンネル(ステレオ)を超えるチャンネル数か？
            if (src.WaveFormat.Channels > 2)
            {
                // SmbPitchShiftingSampleProviderが2チャンネルを超える
                // オーディオ入力をサポートしていない為、2チャンネルに変換する。
                src = src.ToStereo();
            }

            // サンプルレートが176400Hzを超える場合、環境によっては例外が発生する
            // 不具合を確認したので、一度176400Hzにダウンサンプルする。
            defaultSampleRate = src.WaveFormat.SampleRate;
            if(src.WaveFormat.SampleRate > 176400)
            {
                src = new WaveFormatConversion(src, true, 1, 176400, 32, src.WaveFormat.Channels);
            }

            if (fixClip)
            {
                src = new VolumeSampleProvider(src) { Volume = 0.925f };
            }

            return new SoundTouchSampleProvider(src, 1000);
        }

        /// <summary>
        /// ピッチ変化量
        /// </summary>
        public float Pitch
        {
            set
            {
                if (this.soundTouch != null)
                {
                    this.soundTouch.SetPitchSemitones(value);
                }

                this.pitch = value;
            }
            get
            {
                return this.pitch;
            }
        }

        /// <summary>
        /// このオーディオエフェクトプロセスを使用するかどうか
        /// </summary>
        public bool Enabled
        {
            get
            {
                if (this.pitch == 0)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// オーディオフォーマット
        /// </summary>
        public WaveFormat WaveFormat
        {
            get
            {
                if (this.Enabled)
                {
                    return this.dest.WaveFormat;
                }

                return this.src.WaveFormat;
            }
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
            if (this.Enabled)
            {
                return this.dest.Read(buffer, offset, count);
            }

            return this.src.Read(buffer, offset, count);
        }
    }
}

