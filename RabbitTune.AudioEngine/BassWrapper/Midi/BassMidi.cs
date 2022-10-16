using System.Collections.Generic;
using System.Linq;

namespace RabbitTune.AudioEngine.BassWrapper.Midi
{
    internal static class BassMidi
    {
        // 公開定数
        public const int BASS_CONFIGURE_AUTOFONT = 66562;

        #region ストリーム関連

        /// <summary>
        /// ストリームを生成する。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static int CreateStreamFromFile(string path, long offset = 0, long length = 0, BassFlags flags = BassFlags.Default)
        {
            int handle = BassMidiNative.BASS_MIDI_StreamCreateFile(false, path, offset, length, flags | BassFlags.Unicode);

            return handle;
        }

        /// <summary>
        /// 指定されたストリームのサウンドフォントを設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="fonts"></param>
        /// <returns></returns>
        public static int SetStreamSoundFont(int streamHandle, IList<SoundFont> fonts)
        {
            return BassMidiNative.BASS_MIDI_StreamSetFonts(streamHandle, fonts.ToArray(), fonts.Count);
        }

        #endregion

        #region サウンドフォントの読み込みと解放、圧縮など

        /// <summary>
        /// オートフォントの設定
        /// </summary>
        /// <param name="mode"></param>
        public static void SetAutoFont(int mode)
        {
            BassNative.BASS_SetConfig(BASS_CONFIGURE_AUTOFONT, mode);
        }

        /// <summary>
        /// 指定されたパスのサウンドフォントのハンドルを生成して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="useXGDrumMode"></param>
        /// <returns></returns>
        private static int CreateSoundFontHandle(string path, bool useXGDrumMode)
        {
            int handle;

            if (useXGDrumMode)
            {
                handle = BassMidiNative.BASS_MIDI_FontInit(path, SoundFontInitFlags.XGDrums);
            }
            else
            {
                handle = BassMidiNative.BASS_MIDI_FontInit(path);
            }

            return handle;
        }

        /// <summary>
        /// サウンドフォントを読み込む。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="preset"></param>
        /// <param name="bank"></param>
        /// <param name="useXGDrumMode"></param>
        /// <returns></returns>
        public static SoundFont Load(string path, int preset = -1, int bank = 0, bool useXGDrumMode = false)
        {
            int fontHandle = CreateSoundFontHandle(path, useXGDrumMode);

            if (fontHandle != Bass.BASS_HANDLE_ERROR)
            {
                return new SoundFont()
                {
                    Handle = fontHandle,
                    Preset = preset,
                    Bank = bank
                };
            }
            else
            {
                return new SoundFont();
            }
        }

        /// <summary>
        /// 指定されたサウンドフォントを解放する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <returns></returns>
        public static bool Free(int fontHandle)
        {
            return BassMidiNative.BASS_MIDI_FontFree(fontHandle);
        }

        /// <summary>
        /// 指定されたサウンドフォントを解放する。
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static bool Free(SoundFont font)
        {
            return Free(font.Handle);
        }

        /// <summary>
        /// 指定されたサウンドフォントを圧縮してメモリ使用量を削減する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <returns></returns>
        public static bool Compact(int fontHandle)
        {
            return BassMidiNative.BASS_MIDI_FontCompact(fontHandle);
        }

        /// <summary>
        /// 指定されたサウンドフォントを圧縮してメモリ使用量を削減する。
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static bool Compact(SoundFont font)
        {
            return Compact(font.Handle);
        }

        #endregion

        #region サウンドフォント情報

        /// <summary>
        /// 指定されたサウンドフォントの情報を取得する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <returns></returns>
        public static SoundFontInfo GetInfo(int fontHandle)
        {
            BassMidiNative.BASS_MIDI_FontGetInfo(fontHandle, out var info);

            return info;
        }

        /// <summary>
        /// 指定されたサウンドフォントの情報を取得する。
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public static SoundFontInfo GetInfo(SoundFont font)
        {
            return GetInfo(font.Handle);
        }

        /// <summary>
        /// 指定されたサウンドフォントの情報を取得する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SoundFontInfo GetInfo(string path)
        {
            int fontHandle = CreateSoundFontHandle(path, false);
            var info = GetInfo(fontHandle);

            // 読み込みに使用しただけのフォントを解放する。
            Free(fontHandle);

            return info;
        }

        /// <summary>
        /// 指定されたサウンドフォントの指定されたバンドにおける、指定されたプリセットの名前を取得して返す。
        /// </summary>
        /// <param name="soundFont"></param>
        /// <param name="preset"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static string GetPresetName(int fontHandle, int preset, int bank)
        {
            return BassMidiNative.BASS_MIDI_FontGetPreset(fontHandle, preset, bank);
        }

        /// <summary>
        /// 指定されたサウンドフォントの指定されたバンドにおける、指定されたプリセットの名前を取得して返す。
        /// </summary>
        /// <param name="soundFont"></param>
        /// <param name="preset"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static string GetPresetName(SoundFont soundFont, int preset, int bank)
        {
            return BassMidiNative.BASS_MIDI_FontGetPreset(soundFont.Handle, preset, bank);
        }

        /// <summary>
        /// 指定されたサウンドフォントのプリセットをすべて取得して返す。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <returns></returns>
        public static int[] GetPresets(int fontHandle)
        {
            if (!BassMidiNative.BASS_MIDI_FontGetInfo(fontHandle, out var info))
            {
                return null;
            }

            var ret = new int[info.Presets];

            return BassMidiNative.BASS_MIDI_FontGetPresets(fontHandle, ret) ? ret : null;
        }

        /// <summary>
        /// 指定されたサウンドフォントのプリセットをすべて取得して返す。
        /// </summary>
        /// <param name="soundFont"></param>
        /// <returns></returns>
        public static int[] GetPresets(SoundFont soundFont)
        {
            return GetPresets(soundFont.Handle);
        }

        #endregion

        #region 音量

        /// <summary>
        /// 指定されたサウンドフォントの音量を取得する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <returns></returns>
        public static float GetFontVolume(int fontHandle)
        {
            return BassMidiNative.BASS_MIDI_FontGetVolume(fontHandle);
        }

        /// <summary>
        /// 指定されたサウンドフォントの音量を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static float GetFontVolume(SoundFont font)
        {
            return BassMidiNative.BASS_MIDI_FontGetVolume(font.Handle);
        }

        /// <summary>
        /// 指定されたサウンドフォントの音量を設定する。<br/>
        /// 音量は、0から1の浮動小数点数で指定する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <param name="volume"></param>
        public static void SetFontVolume(int fontHandle, float volume)
        {
            BassMidiNative.BASS_MIDI_FontSetVolume(fontHandle, volume);
        }

        /// <summary>
        /// 指定されたサウンドフォントの音量を設定する。<br/>
        /// 音量は、0から1の浮動小数点数で指定する。
        /// </summary>
        /// <param name="fontHandle"></param>
        /// <param name="volume"></param>
        public static void SetFontVolume(SoundFont font, float volume)
        {
            BassMidiNative.BASS_MIDI_FontSetVolume(font.Handle, volume);
        }

        #endregion
    }
}
