using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RabbitTune
{
    internal class HotKey : IDisposable
    {
        // 非公開フィールド
        private HotKeyForm form;

        // イベント
        public event EventHandler HotKeyPush;

        // コンストラクタ
        public HotKey(Keys modKey, Keys key)
        {
            this.form = new HotKeyForm(modKey, key, RaiseHotKeyPush);
        }

        private void RaiseHotKeyPush()
        {
            if (this.HotKeyPush != null)
            {
                this.HotKeyPush(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 破棄する。
        /// </summary>
        public void Dispose()
        {
            this.form.Dispose();
        }

        class HotKeyForm : Form
        {
            [DllImport("user32.dll")]
            extern static int RegisterHotKey(IntPtr HWnd, int ID, Keys MOD_KEY, Keys KEY);

            [DllImport("user32.dll")]
            extern static int UnregisterHotKey(IntPtr HWnd, int ID);

            const int WM_HOTKEY = 0x0312;
            int id;
            ThreadStart proc;

            public HotKeyForm(Keys modKey, Keys key, ThreadStart proc)
            {
                this.proc = proc;

                for (int i = 0x0000; i <= 0xbfff; i++)
                {
                    if (RegisterHotKey(this.Handle, i, modKey, key) != 0)
                    {
                        id = i;
                        break;
                    }
                }
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == WM_HOTKEY)
                {
                    if ((int)m.WParam == id)
                    {
                        proc();
                    }
                }
            }

            protected override void Dispose(bool disposing)
            {
                UnregisterHotKey(this.Handle, id);
                base.Dispose(disposing);
            }
        }
    }
}
