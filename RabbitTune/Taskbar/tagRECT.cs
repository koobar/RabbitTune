using System.Runtime.InteropServices;

namespace RabbitTune.Taskbar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct tagRECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
