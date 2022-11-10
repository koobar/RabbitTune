using System;
using System.Runtime.InteropServices;

namespace RabbitTune.Taskbar
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ThumbButton
    {
        public ThumbButtonMask dwMask;
        public uint iID;
        public uint iBitmap;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szTip;
        public ThumbButtonFlags dwFlags;
    }
}
