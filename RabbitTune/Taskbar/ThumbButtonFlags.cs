using System;

namespace RabbitTune.Taskbar
{
    [Flags]
    public enum ThumbButtonFlags : uint
    {
        Enabled = 0x00,
        Disabled = 0x01,
        DisMissonClick = 0x02,
        NoBackground = 0x04,
        Hidden = 0x08,
        NonInterActive = 0x10
    }
}
