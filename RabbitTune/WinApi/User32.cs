using System;
using System.Runtime.InteropServices;

namespace RabbitTune.WinApi
{
    internal static class User32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();
    }
}
