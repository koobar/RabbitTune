using System;
using System.Runtime.InteropServices;

namespace RabbitTune.WinApi
{
    internal static class User32
    {
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr handle, int command);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
    }
}
