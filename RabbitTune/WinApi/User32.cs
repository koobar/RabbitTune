using System;
using System.Runtime.InteropServices;

namespace RabbitTune.WinApi
{
    internal static class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);
    }
}
