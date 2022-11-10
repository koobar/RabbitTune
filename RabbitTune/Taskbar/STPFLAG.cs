using System;

namespace RabbitTune.Taskbar
{
    [Flags]
    public enum STPFLAG : uint
    {
        STPF_NONE = 0x00000000,
        STPF_USEAPPTHUMBNAILALWAYS = 0x00000001,
        STPF_USEAPPTHUMBNAILWHENACTIVE = 0x00000002,
        STPF_USEAPPPEEKALWAYS = 0x00000004,
        STPF_USEAPPPEEKWHENACTIVE = 0x00000008
    }
}
