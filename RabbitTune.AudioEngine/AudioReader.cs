using NAudio.Wave;
using RabbitTune.AudioEngine.Codecs;
using RabbitTune.AudioEngine.Codecs.BassCompat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RabbitTune.AudioEngine
{
    public class AudioReader
    {
        // 非公開変数
        private static readonly List<AudioFormatInfo> AudioFormatInfoCollection = new List<AudioFormatInfo>()
        {
            new AudioFormatInfo("WAV", typeof(WavDecoder), false, ".wav"),
            new AudioFormatInfo("AIFF", typeof(AiffFileReader), false, ".aif", ".aiff", ".aifc"),

            // media foundation
            new AudioFormatInfo("AMR", typeof(MediaFoundationReader), true, ".amr"),
            new AudioFormatInfo("3GPP", typeof(MediaFoundationReader),true, ".3gp"),
            new AudioFormatInfo("3GPP2", typeof(MediaFoundationReader),true, ".3g2"),
            new AudioFormatInfo("M2A", typeof(MediaFoundationReader), false, ".m2a"),
            new AudioFormatInfo("M4A", typeof(MediaFoundationReader), false, ".m4a"),
            new AudioFormatInfo("AAC", typeof(MediaFoundationReader), false, ".aac"),
            new AudioFormatInfo("FLAC", typeof(MediaFoundationReader), false, ".flac"),
            new AudioFormatInfo("MP1", typeof(MediaFoundationReader), false, ".mp1"),
            new AudioFormatInfo("MP2", typeof(MediaFoundationReader), false, ".mp2"),
            new AudioFormatInfo("MP3", typeof(MediaFoundationReader), false, ".mp3"),
            new AudioFormatInfo("WMA", typeof(MediaFoundationReader), false, ".wma"),
            new AudioFormatInfo("E-AC-3", typeof(MediaFoundationReader), false, ".eac3"),
        };
        private static readonly List<AudioFormatInfo> AdditionalAudioFormatInfoCollection = new List<AudioFormatInfo>()
        {
            new AudioFormatInfo("OGG", typeof(BassDecoder), true, ".ogg"),
            new AudioFormatInfo("OGA", typeof(BassDecoder), true, ".oga"),
            new AudioFormatInfo("Opus", typeof(BassDecoder), true, ".opus"),
            new AudioFormatInfo("WavPack", typeof(BassDecoder), true, ".wv"),
            new AudioFormatInfo("DSD", typeof(BassDecoder), true, ".dsf", ".dff", ".dsd"),
            new AudioFormatInfo("Audio CD Track", typeof(BassDecoder), true, ".cda"),
            new AudioFormatInfo("OptimFROG", typeof(BassDecoder), true, ".ofr"),
            new AudioFormatInfo("Musepack", typeof(BassDecoder), true, ".mpc"),
            new AudioFormatInfo("Speex", typeof(BassDecoder), true, ".spx"),
            new AudioFormatInfo("TTA", typeof(BassDecoder), true, ".tta"),
            new AudioFormatInfo("Monkey's Audio", typeof(BassDecoder), true, ".ape"),
            new AudioFormatInfo("MIDI", typeof(BassMidiDecoder), true, ".mid"),
        };
        private readonly WaveStream source;

        // コンストラクタ
        public AudioReader(string path)
        {
            this.source = CreateWaveSource(path);
        }

        #region フォーマット情報

        /// <summary>
        /// 指定されたファイルのフォーマット名を取得する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFormatName(string path)
        {
            var info = GetAudioFormatInfo(path);

            if(info != null)
            {
                return info.Description;
            }

            return "不明";
        }

        /// <summary>
        /// サポートされるフォーマット名の一覧を取得して返す。
        /// </summary>
        /// <returns></returns>
        public static string[] GetSupportedFormatNames()
        {
            var result = new List<string>();

            foreach(var info in AudioFormatInfoCollection)
            {
                result.Add(info.Description);
            }

            foreach (var info in AdditionalAudioFormatInfoCollection)
            {
                result.Add(info.Description);
            }

            return result.ToArray();
        }

        /// <summary>
        /// 指定された形式の拡張子の一覧を取得して返す。<br/>
        /// 不明ならnullを返す。
        /// </summary>
        /// <returns></returns>
        public static string[] GetFormatExtensions(string fmtName)
        {
            foreach(var info in AudioFormatInfoCollection)
            {
                if(info.Description == fmtName)
                {
                    return info.Extensions;
                }
            }

            foreach (var info in AdditionalAudioFormatInfoCollection)
            {
                if (info.Description == fmtName)
                {
                    return info.Extensions;
                }
            }

            return null;
        }

        /// <summary>
        /// サポートされるすべてのフォーマットの拡張子を取得する。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllSupportedFormatExtensions()
        {
            var result = new List<string>();

            foreach(var fmt in GetSupportedFormatNames())
            {
                foreach(var ext in GetFormatExtensions(fmt))
                {
                    result.Add(ext);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 指定されたファイルがサポートされている形式であるか判定して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsSupportedFormat(string path)
        {
            return GetAudioFormatInfo(path) != null;
        }

        /// <summary>
        /// 指定されたファイルのフォーマットを取得し、それに関する情報を格納したクラスのインスタンスを返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioFormatInfo GetAudioFormatInfo(string path)
        {
            foreach (var info in AudioFormatInfoCollection)
            {
                if (info.IsThisFormat(path))
                {
                    return info;
                }
            }

            foreach (var info in AdditionalAudioFormatInfoCollection)
            {
                if (info.IsThisFormat(path))
                {
                    return info;
                }
            }

            return null;
        }

        #endregion

        /// <summary>
        /// 指定されたファイルを読み込むためのWaveSourceのインスタンスを生成して返す。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private WaveStream CreateWaveSource(string path)
        {
            // ファイルが存在するか？
            if (File.Exists(path))
            {
                // ファイルのフォーマット情報を取得。
                var fmtInfo = GetAudioFormatInfo(path);

                // フォーマット情報の取得に成功した(=読み込みに対応している)か？
                if (fmtInfo != null)
                {
                    return CreateWaveSourceWithRegisteredDecoderTypes(fmtInfo, path);
                }
                else
                {
                    try
                    {
                        // フォーマット情報の取得に失敗した場合、とりあえずMediaFoundationDecoderで読み込んでみる。
                        return new MediaFoundationReader(path);
                    }
                    catch (Exception mfe)
                    {
                        throw mfe;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// AudioFormatInfoCollectionに登録されたデコーダの型で指定されたファイルのデコーダのインスタンスを作成する。
        /// </summary>
        /// <param name="fmtInfo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private WaveStream CreateWaveSourceWithRegisteredDecoderTypes(AudioFormatInfo fmtInfo, string path)
        {
            try
            {
                var decoder_instance = Activator.CreateInstance(fmtInfo.DecoderType, path);

                // デコーダのインスタンス生成に成功したか？
                if (decoder_instance != null && decoder_instance is WaveStream)
                {
                    return (WaveStream)decoder_instance;
                }
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }

            return null;
        }

        /// <summary>
        /// シークが可能であるかどうか
        /// </summary>
        public bool CanSeek => this.source.CanSeek;

        /// <summary>
        /// WaveFormat
        /// </summary>
        public WaveFormat WaveFormat => this.source.WaveFormat;

        /// <summary>
        /// オーディオソースの位置
        /// </summary>
        public long Position { get => this.source.Position; set => this.source.Position = value; }

        /// <summary>
        /// オーディオソースの長さ
        /// </summary>
        public long Length => this.source.Length;

        /// <summary>
        /// シークする
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        public void Seek(long offset, SeekOrigin origin)
        {
            this.source.Seek(offset, origin);
        }

        /// <summary>
        /// オーディオソースを破棄する。
        /// </summary>
        public void Dispose()
        {
            this.source?.Dispose();
        }

        /// <summary>
        /// オーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            return this.source.Read(buffer, offset, count);
        }
    }

    /// <summary>
    /// AudioReaderクラスをNAudioのWaveStreamを継承する形式に変換するためのクラス。<br/>
    /// IWaveProviderとも互換性があります。
    /// </summary>
    public class AudioReaderToWaveStream : WaveStream, IWaveProvider
    {
        // 非公開変数
        private AudioReader audioReader;

        // コンストラクタ
        public AudioReaderToWaveStream(AudioReader reader)
        {
            this.audioReader = reader;
        }

        /// <summary>
        /// WaveFormat
        /// </summary>
        public override WaveFormat WaveFormat => this.audioReader.WaveFormat;

        /// <summary>
        /// オーディオソースの長さ
        /// </summary>
        public override long Length => this.audioReader.Length;

        /// <summary>
        /// オーディオソースの位置
        /// </summary>
        public override long Position { get => this.audioReader.Position; set => this.audioReader.Position = value; }

        /// <summary>
        /// オーディオソースから読み込む。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.audioReader.Read(buffer, offset, count);
        }

        /// <summary>
        /// オーディオソースを破棄する。
        /// </summary>
        public new void Dispose()
        {
            this.audioReader.Dispose();
        }

        /// <summary>
        /// オーディオソースをシークする。
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        public new void Seek(long offset, SeekOrigin origin)
        {
            this.audioReader.Seek(offset, origin);
        }
    }
}
