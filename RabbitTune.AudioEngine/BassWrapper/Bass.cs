namespace RabbitTune.AudioEngine.BassWrapper
{
    internal class Bass
    {
        // 非公開定数
        public const int BASS_DEVICE_DECODE = 0;
        public const int BASS_POSITIONFLAG_BYTES = 0;
        public const int BASS_HANDLE_ERROR = 0;
        public const int BASS_CONFIG_OPTION_HANDLECOUNT = 41;
        public const int BASS_CONFIG_DSD_FREQUENCY = 67584;
        public const int BASS_CONFIG_DSD_GAIN = 67585;

        /// <summary>
        /// 最後に発生したエラーの種類
        /// </summary>
        public static BassErrors LastError
        {
            get
            {
                return BassNative.BASS_ErrorGetCode();
            }
        }

        /// <summary>
        /// ハンドルの総数
        /// </summary>
        public static int HandleCount
        {
            get
            {
                return BassNative.BASS_GetConfig(BASS_CONFIG_OPTION_HANDLECOUNT);
            }
        }

        /// <summary>
        /// DSDをPCMにデコードする際に使用するサンプルレート<br/>
        /// ※DSDのサンプルレートの1/8,1/16,1/32等で、44100Hz以上のサンプルレートを設定可能<br/>
        /// 指定されたサンプルレートが無効の場合、BASSライブラリ側で適切なサンプルレートが設定されるため、<br/>
        /// ここで指定した値が必ず使用されるとは限らない。
        /// 
        /// </summary>
        public static int DsdDecodingFrequency
        {
            set
            {
                BassNative.BASS_SetConfig(BASS_CONFIG_DSD_FREQUENCY, value);
            }
            get
            {
                return BassNative.BASS_GetConfig(BASS_CONFIG_DSD_FREQUENCY);
            }
        }

        /// <summary>
        /// DSDをPCMにデコードする際のゲイン値<br/>
        /// デシベル単位で指定する。
        /// </summary>
        public static int DsdDecodingGain
        {
            set
            {
                BassNative.BASS_SetConfig(BASS_CONFIG_DSD_GAIN, value);
            }
            get
            {
                return BassNative.BASS_GetConfig(BASS_CONFIG_DSD_GAIN);
            }
        }

        /// <summary>
        /// BASSライブラリを初期化する。初期化に成功した場合はtrueを、失敗した場合はfalseを返す。
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static bool Init(int device = -1)
        {
            return BassNative.BASS_Init(device);
        }

        /// <summary>
        /// BASSライブラリを解放する。
        /// </summary>
        /// <returns></returns>
        public static bool Free()
        {
            return BassNative.BASS_Free();
        }

        /// <summary>
        /// BASSライブラリのプラグインを読み込む。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int LoadPlugin(string fileName)
        {
            return BassNative.BASS_PluginLoad(fileName);
        }

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
            return BassNative.BASS_StreamCreateFile(false, path, offset, length, flags | BassFlags.Unicode);
        }

        /// <summary>
        /// 指定されたストリームを解放する。
        /// </summary>
        /// <param name="handle"></param>
        public static void StreamFree(int handle)
        {
            BassNative.BASS_StreamFree(handle);
        }

        /// <summary>
        /// 指定されたチャンネルのチャンネル情報を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static ChannelInfo GetChannelInfo(int handle)
        {
            BassNative.BASS_ChannelGetInfo(handle, out var info);

            return info;
        }

        /// <summary>
        /// 指定されたチャンネルのサンプルレートを取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static int ChannelGetSampleRate(int handle)
        {
            var info = GetChannelInfo(handle);

            return info.SampleRate;
        }

        /// <summary>
        /// 指定されたチャンネルのチャンネル数を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static int ChannelGetNumChannels(int handle)
        {
            var info = GetChannelInfo(handle);

            return info.Channels;
        }

        /// <summary>
        /// 指定されたチャンネルの量子化ビット数を取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static int ChannelGetBitsPerSample(int handle)
        {
            var info = GetChannelInfo(handle);

            return info.BitsPerSample;
        }

        /// <summary>
        /// 指定されたチャンネルの位置をバイト単位で取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static long GetChannelPosition(int handle)
        {
            return BassNative.BASS_ChannelGetPosition(handle, BASS_POSITIONFLAG_BYTES);
        }

        /// <summary>
        /// 指定されたチャンネルの再生位置をバイト単位で設定する。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="pos"></param>
        public static void SetChannelPosition(int handle, long pos)
        {
            BassNative.BASS_ChannelSetPosition(handle, pos, BASS_POSITIONFLAG_BYTES);
        }

        /// <summary>
        /// 指定されたチャンネルの長さをバイト単位で取得する。
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static long GetChannelLength(int handle)
        {
            return BassNative.BASS_ChannelGetLength(handle, BASS_POSITIONFLAG_BYTES);
        }

        /// <summary>
        /// チャンネルからデータを読み込む。
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int ReadChannel(int handle, byte[] buffer, int count)
        {
            return BassNative.BASS_ChannelGetData(handle, buffer, count);
        }

        public static long StreamGetFilePosition(int handle)
        {
            return BassNative.BASS_StreamGetFilePosition(handle);
        }
    }
}
