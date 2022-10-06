/* NAudioで再生速度変更を実現したクラス
 * Copyright (c) 2022 koobar. licensed under the WTFPL.
 * ================================================================================
 * NAudioには、WaveFormatプロパティで誤ったサンプルレートを設定したインスタンスを
 * 返すと、再生速度が変化するといった挙動が存在する。これを逆手にとり、再生速度を
 * 遅くしたい場合には、元々のサンプルレートより大きいサンプルレートで、また、
 * 再生速度を速くしたい場合には、元々のサンプルレートより小さいサンプルレートで
 * サンプルレート変換を行い、Readメソッドでは変換後のIWaveProviderから読み込む。
 * 一方で、WaveFormatプロパティでは、変換前のWaveFormatをそのまま返す。一見誤った実装に
 * 見える（実際に誤っている）が、これにより再生速度を意図的に変化させることが可能となる。*/
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RabbitTune.AudioEngine.AudioProcess
{
    public class PlaybackSpeedSetter : ISampleProvider
    {
        // 非公開変数
        private ISampleProvider src;
        private ISampleProvider dest;
        private float speedRate;

        // コンストラクタ
        public PlaybackSpeedSetter(ISampleProvider src)
        {
            this.src = src;
            this.dest = src;
            this.speedRate = 1.0f;
        }

        /// <summary>
        /// 0.25fから2.0fの間で速度を変更できます。
        /// （0.5f=1/2倍速、1.0f=1倍、2.0f=2倍速です。）
        /// </summary>
        public float Speed
        {
            set
            {
                // 値が0.1fから2.0fの間か？
                if (value <= 2.0f && value >= 0.1f)
                {
                    // 速度変更後のサンプルレートを求める。
                    int rate = (int)(this.src.WaveFormat.SampleRate / value);

                    // 音声をサンプルレート変換する。
                    // ここでは、MediaFoundationResamplerよりも高速に動作する、WdlResamplingSampleProviderを使用する。
                    this.dest = new WdlResamplingSampleProvider(this.src, rate);

                    // 後始末
                    this.speedRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(value.ToString());
                }
            }
            get => this.speedRate;
        }

        /// <summary>
        /// このオーディオプロセスを使用するかどうか
        /// </summary>
        public bool Enabled
        {
            get
            {
                if(this.Speed == 1.0f)
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
            if (!this.Enabled)
            {
                return this.src.Read(buffer, offset, count);
            }
            else
            {
                return this.dest.Read(buffer, offset, count);
            }
        }
    }
}
