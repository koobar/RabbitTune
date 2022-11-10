using System;
using System.Windows.Forms;

namespace RabbitTune
{
    internal class MediaButtonDriver : IDisposable
    {
        // イベント
        public event EventHandler PlayPauseButtonPush;
        public event EventHandler PreviousButtonPush;
        public event EventHandler NextButtonPush;

        // グローバルホットキー
        private readonly HotKey MediaPlayPauseButtonHotKey;
        private readonly HotKey MediaPreviousButtonHotKey;
        private readonly HotKey MediaNextButtonHotKey;

        // コンストラクタ
        public MediaButtonDriver()
        {
            this.MediaPlayPauseButtonHotKey = new HotKey(Keys.None, Keys.MediaPlayPause);
            this.MediaPlayPauseButtonHotKey.HotKeyPush += delegate
            {
                OnMediaPlayPauseButtonPush();
            };
            this.MediaPreviousButtonHotKey = new HotKey(Keys.None, Keys.MediaPreviousTrack);
            this.MediaPreviousButtonHotKey.HotKeyPush += delegate
            {
                OnMediaPreviousButtonPush();
            };
            this.MediaNextButtonHotKey = new HotKey(Keys.None, Keys.MediaNextTrack);
            this.MediaNextButtonHotKey.HotKeyPush += delegate
            {
                OnMediaNextButtonPush();
            };
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            this.MediaPlayPauseButtonHotKey.Dispose();
            this.MediaPreviousButtonHotKey.Dispose();
            this.MediaNextButtonHotKey.Dispose();
        }

        private void OnMediaPlayPauseButtonPush()
        {
            this.PlayPauseButtonPush?.Invoke(null, null);
        }

        private void OnMediaPreviousButtonPush()
        {
            this.PreviousButtonPush?.Invoke(null, null);
        }

        private void OnMediaNextButtonPush()
        {
            this.NextButtonPush?.Invoke(null, null);
        }
    }
}
