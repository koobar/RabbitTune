using System;

namespace RabbitTune.Taskbar
{
    [Flags]
    public enum TbpFlag : uint
    {
        NoProgress = 0x00,
        Indeterminate = 0x01,
        Normal = 0x02,
        Error = 0x04,
        Paused = 0x08
    }
}
