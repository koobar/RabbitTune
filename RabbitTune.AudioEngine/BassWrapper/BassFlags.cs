namespace RabbitTune.AudioEngine.BassWrapper
{
    internal enum BassFlags : uint
    {
        Default,
        Byte = 0x1,
        Mono = 0x2,
        Loop = 0x4,
        Bass3D = 0x8,
        SoftwareMixing = 0x10,
        FX = 0x80,
        Float = 0x100,
        Prescan = 0x20000,
        AutoFree = 0x40000,
        RestrictDownloadRate = 0x80000,
        StreamDownloadBlocks = 0x100000,
        Decode = 0x200000,
        StreamStatus = 0x800000,
        AsyncFile = 0x40000000,
        Unicode = 0x80000000,

        // Sample
        MuteMax = 0x20,
        VAM = 0x40,
        SampleOverrideLowestVolume = 0x10000,
        SampleOverrideLongestPlaying = 0x20000,
        SampleOverrideDistance = 0x30000,
        SampleChannelNew = 0x1,
        SampleChannelStream = 0x2,

        // BASSMIDI
        MidiNoHeader = 0x1,
        Midi16Bit = 0x2,
        MidiNoSystemReset = 0x800,
        MidiDecayEnd = 0x1000,
        MidiNoFx = 0x2000,
        MidiDecaySeek = 0x4000,
        MidiNoCrop = 0x8000,
        MidiNoteOff1 = 0x10000,
        MidiFontMemoryMap = 0x20000,
        MidiFontXGDRUMS = 0x40000,
        MidiSincInterpolation = 0x800000,

        // BASSCD
        CDSubChannel = 0x200,
        CDSubchannelNoHW = 0x400,
        CdC2Errors = 0x800,
    }
}
