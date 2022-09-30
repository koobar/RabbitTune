using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Collections.Generic;

namespace RabbitTune.AudioEngine.AudioProcess
{
    public class PitchShifter : ISampleProvider
    {
        // 非公開変数
        private readonly Dictionary<int, float> pitchFactors = new Dictionary<int, float>()     // ピッチ変化量とAの周波数の対応表
        {
            { -12, 220.0f },
            { -11, 233.082f },
            { -10, 246.942f },
            { -9, 261.626f },
            { -8, 277.183f },
            { -7, 293.665f },
            { -6, 311.127f },
            { -5, 329.628f },
            { -4, 349.228f },
            { -3, 369.994f },
            { -2, 391.995f },
            { -1, 415.305f },
            { 0, 440.0f },
            { 1, 466.164f },
            { 2, 493.883f },
            { 3, 523.251f },
            { 4, 554.365f },
            { 5, 587.330f },
            { 6, 622.254f },
            { 7, 659.255f },
            { 8, 698.456f },
            { 9, 739.989f },
            { 10, 783.991f },
            { 11, 830.609f },
            { 12, 880.0f },
        };
        private ISampleProvider src;
        private SmbPitchShiftingSampleProvider dest;
        private int pitch = 0;
        
        // コンストラクタ
        public PitchShifter(ISampleProvider source, bool fixClip)
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
        private SmbPitchShiftingSampleProvider Create(ISampleProvider source, bool fixClip = true, int fftSize = 4096, long osamp = 4L)
        {
            var src = source;

            // 2チャンネル(ステレオ)を超えるチャンネル数か？
            if(src.WaveFormat.Channels > 2)
            {
                // SmbPitchShiftingSampleProviderが2チャンネルを超える
                // オーディオ入力をサポートしていない為、2チャンネルに変換する。
                src = src.ToStereo();
            }

            if (fixClip)
            {
                src = new VolumeSampleProvider(src) { Volume = 0.925f };
            }

            return new SmbPitchShiftingSampleProvider(src, fftSize, osamp, 1f);
        }
        
        /// <summary>
        /// ピッチ変化量
        /// </summary>
        public int Pitch
        {
            set
            {
                if (this.dest != null)
                {
                    this.dest.PitchFactor = this.pitchFactors[value] / 440.0f;
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
                if(this.pitch == 0)
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
