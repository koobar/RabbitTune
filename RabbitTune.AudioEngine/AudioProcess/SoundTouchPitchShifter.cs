using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using RabbitTune.AudioEngine.AudioProcess.SampleProviders;

namespace RabbitTune.AudioEngine.AudioProcess
{
    internal class SoundTouchPitchShifter : ISampleProvider
    {
        // 非公開変数
        private readonly ISampleProvider src;
        private readonly SoundTouchSampleProvider dest;
        private float pitch = 0;

        // コンストラクタ
        public SoundTouchPitchShifter(ISampleProvider source, bool fixClip)
        {
            this.src = source;
            this.dest = Create(source, fixClip);
        }

        /// <summary>
        /// SoundTouchによるピッチシフタを生成する。<br/>
        /// 第2引数はクリッピング（音割れ）を低減するかどうか。省略時はtrue。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fixClip"></param>
        /// <returns></returns>
        private SoundTouchSampleProvider Create(ISampleProvider source, bool fixClip = true)
        {
            var src = source;

            // 2チャンネル(ステレオ)を超えるチャンネル数か？
            if (src.WaveFormat.Channels > 2)
            {
                // SmbPitchShiftingSampleProviderが2チャンネルを超える
                // オーディオ入力をサポートしていない為、2チャンネルに変換する。
                src = src.ToStereo();
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
                if (this.dest != null)
                {
                    this.dest.SetPitchSemitones(value);
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

