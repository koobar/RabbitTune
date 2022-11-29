using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper.Cd
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CDInfo
    {
        // 非公開フィールド
        IntPtr vendor;
        IntPtr product;
        IntPtr rev;
        int letter;
        int rwflags;
        bool canopen;
        bool canlock;
        int maxspeed;
        int cache;
        bool cdtext;

        public string Name => this.product == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(this.product);
        public string Manufacturer => this.vendor == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(this.vendor);
        public string Revision => this.rev == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(this.rev);
        public int SpeedMultiplier => (int)(this.maxspeed / 176.4);
        public char DriveLetter => this.letter != -1 ? char.ToUpper((char)(this.letter + 65)) : '_';
        public bool CanOpen => this.canopen;
        public bool CanLock => this.canlock;
        public int MaxSpeed => this.maxspeed;
        public int Cache => this.cache;
        public bool CDText => this.cdtext;
        public int ReadWriteFlags => this.rwflags;
    }
}
