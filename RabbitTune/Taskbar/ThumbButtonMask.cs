using System;

namespace RabbitTune.Taskbar
{
    [Flags]
    public enum ThumbButtonMask : uint
    {
        Bitmap = 0x01,
        Icon = 0x02,
        ToolTip = 0x04,
        Flags = 0x08
    }
}
