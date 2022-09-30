/* Timer class
 * copyright (c) 2022 koobar.
 * ================================================================================
 * System.Windows.Forms.TimerのTickイベントの発生間隔を2パターン設定できるように
 * 拡張したラッパークラスです。短い間隔で発生させたいイベントと、長い間隔で発生させたい
 * イベントを1つのタイマーで記述できます。*/
using System;
using WTimer = System.Windows.Forms.Timer;

namespace RabbitTune.AudioEngine
{
    internal class Timer : IDisposable
    {
        // イベント
        public event EventHandler ShortTick;
        public event EventHandler LongTick;

        // 非公開定数
        private const uint TIMER_TICK_MINIMUM = 10;     // 1を設定すると速すぎて精度が落ちる。

        // 非公開変数
        private readonly WTimer timer;
        private ulong shortTickCounter = 0;
        private ulong longTickCounter = 0;
        private uint shortInterval = 64;
        private uint longInterval = 1000;

        // コンストラクタ
        public Timer()
        {
            this.timer = new WTimer();
            this.timer.Interval = (int)TIMER_TICK_MINIMUM;           
            this.timer.Tick += UpdateTimer;
        }

        /// <summary>
        /// タイマーを更新する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer(object sender, EventArgs e)
        {
            // ShortTick, LongTick用のカウンタをそれぞれ加算
            this.shortTickCounter += (uint)this.timer.Interval;
            this.longTickCounter += (uint)this.timer.Interval;
            
            // ShortTickを発生させるべきタイミングか？
            if (this.shortTickCounter >= this.ShortInterval)
            {
                // カウンタを処理
                this.shortTickCounter = 0;
                this.ShortTickCount += 1;

                // イベントを発生させる。
                this.ShortTick?.Invoke(null, null);
            }

            // LongTickを発生させるべきタイミングか？
            if(this.longTickCounter >= this.LongInterval)
            {
                // カウンタを処理
                this.longTickCounter = 0;
                this.LongTickCount += 1;

                // イベントを発生させる。
                this.LongTick?.Invoke(null, null);
            }
        }

        /// <summary>
        /// ShortTickイベントが発生した回数
        /// </summary>
        public long ShortTickCount { set; get; } = 0;

        /// <summary>
        /// LongTickイベントが発生した回数
        /// </summary>
        public long LongTickCount { set; get; } = 0;

        /// <summary>
        /// ShortTickイベントを発生させる間隔（ミリ秒単位）
        /// </summary>
        public uint ShortInterval
        {
            set
            {
                if (value < TIMER_TICK_MINIMUM)
                {
                    throw new ArgumentOutOfRangeException("ShortInterval", $"ShortIntervalに指定されたShortTickの実行間隔が小さすぎます。実行間隔は、{TIMER_TICK_MINIMUM}以上の整数を指定してください。");
                }
                else
                {
                    this.shortInterval = value;
                }
            }
            get
            {
                return this.shortInterval;
            }
        }

        /// <summary>
        /// LongTickイベントを発生させる間隔（ミリ秒単位）
        /// </summary>
        public uint LongInterval
        {
            set
            {
                if(value < TIMER_TICK_MINIMUM)
                {
                    throw new ArgumentOutOfRangeException("LongInterval", $"LongIntervalに指定されたLongTickの実行間隔が小さすぎます。実行間隔は、{TIMER_TICK_MINIMUM}以上の整数を指定してください。");
                }
                else
                {
                    this.longInterval = value;
                }
            }
            get
            {
                return this.longInterval;
            }
        }

        /// <summary>
        /// タイマーを起動する。
        /// </summary>
        public void Start()
        {
            this.timer.Start();
        }

        /// <summary>
        /// タイマーを停止する。
        /// </summary>
        public void Stop()
        {
            // タイマーを停止する。
            this.timer.Stop();

            // ティックカウンタを初期化する。
            this.ShortTickCount = 0;
            this.LongTickCount = 0;
            this.shortTickCounter = 0;
            this.longTickCounter = 0;
        }

        /// <summary>
        /// タイマーを破棄する。
        /// </summary>
        public void Dispose()
        {
            if (this.timer.Enabled)
            {
                Stop();
            }

            this.timer.Dispose();
        }
    }
}
