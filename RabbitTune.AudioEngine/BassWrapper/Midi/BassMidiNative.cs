using System;
using System.Runtime.InteropServices;

namespace RabbitTune.AudioEngine.BassWrapper.Midi
{
    internal class BassMidiNative
    {
        // 非公開定数
        private const string DLLNAME = @"bassmidi.dll";

        /// <summary>
        /// サウンドフォントを圧縮してメモリ使用量を削減する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontCompact")]
        public static extern bool BASS_MIDI_FontCompact(int handle);

        /// <summary>
        /// サウンドフォントを解放する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontFree")]
        public static extern bool BASS_MIDI_FontFree(int handle);

        /// <summary>
        /// 指定されたサウンドフォントの情報を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="Info"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontGetInfo")]
        public static extern bool BASS_MIDI_FontGetInfo(int handle, out SoundFontInfo Info);

        /// <summary>
        /// 指定されたサウンドフォントの指定されたプリセットの名前を取得し、その文字列のポインタを返す。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="preset"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontGetPreset")]
        private static extern IntPtr BASS_MIDI_FontGetPreset_Native(int handle, int preset, int bank);

        /// <summary>
        /// 指定されたサウンドフォントの指定されたプリセットの名前を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="preset"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static string BASS_MIDI_FontGetPreset(int handle, int preset, int bank)
        {
            return Marshal.PtrToStringAnsi(BASS_MIDI_FontGetPreset_Native(handle, preset, bank));
        }

        /// <summary>
        /// 指定されたサウンドフォントのプリセットをすべて取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="presets"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontGetPresets")]
        public static extern bool BASS_MIDI_FontGetPresets(int handle, [In, Out] int[] presets);

        /// <summary>
        /// 指定されたサウンドフォントの音量を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontGetVolume")]
        public static extern float BASS_MIDI_FontGetVolume(int handle);

        /// <summary>
        /// 指定されたサウンドフォントの音量を設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontSetVolume")]
        public static extern bool BASS_MIDI_FontSetVolume(int handle, float volume);

        /// <summary>
        /// 指定されたファイル等の情報からMIDIストリームを生成してそのハンドルを返す。
        /// </summary>
        /// <param name="mem"></param>
        /// <param name="file"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="flags"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, CharSet = CharSet.Unicode)]
        public static extern int BASS_MIDI_StreamCreateFile(bool mem, string file, long offset, long length, BassFlags flags, int freq = 0);

        /// <summary>
        /// 指定されたMIDIストリームのサウンドフォントを設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="fonts"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_StreamSetFonts")]
        public static extern int BASS_MIDI_StreamSetFonts(int handle, SoundFont[] fonts, int count);

        /// <summary>
        /// サウンドフォントを読み込む。
        /// </summary>
        /// <param name="File"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, CharSet = CharSet.Unicode, EntryPoint = "BASS_MIDI_FontInit")]
        private static extern int BASS_MIDI_FontInit_Native(string path, SoundFontInitFlags flags);

        /// <summary>
        /// サウンドフォントを読み込んでそのハンドルを返す。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static int BASS_MIDI_FontInit(string path)
        {
            return BASS_MIDI_FontInit_Native(path, SoundFontInitFlags.Unicode);
        }

        /// <summary>
        /// サウンドフォントを読み込んでそのハンドルを返す。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static int BASS_MIDI_FontInit(string path, SoundFontInitFlags flags)
        {
            return BASS_MIDI_FontInit_Native(path, flags | SoundFontInitFlags.Unicode);
        }

        /// <summary>
        /// サウンドフォントを読み込む。
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="Preset"></param>
        /// <param name="Bank"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontLoad")]
        public static extern bool BASS_MIDI_FontLoad(int Handle, int Preset, int Bank);

        /// <summary>
        /// 指定されたハンドルのMIDIファイルに必要なサンプルを予め読み込む。
        /// </summary>
        /// <param name="Handle"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_StreamLoadSamples")]
        public static extern bool BASS_MIDI_StreamLoadSamples(int handle);

        /// <summary>
        /// 指定されたハンドルのサウンドフォントの、指定されたプリセット、バンクをアンロードする。
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="Preset"></param>
        /// <param name="Bank"></param>
        /// <returns></returns>
        [DllImport(DLLNAME, EntryPoint = "BASS_MIDI_FontUnload")]
        public static extern bool BASS_MIDI_FontUnload(int Handle, int Preset, int Bank);
    }
}
