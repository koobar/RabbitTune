using NAudio.MediaFoundation;
using NAudio.Wave;
using RabbitTune.AudioEngine.AudioProcess.RabbitTune.AudioEngine.AudioProcess;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace RabbitTune.AudioEngine
{
    public class AudioWriter
    {
        // 非公開フィールド
        private readonly IWaveProvider source;

        // コンストラクタ
        public AudioWriter(AudioReader waveProvider)
        {
            this.source = new AudioReaderToWaveStream(waveProvider);
        }

        /// <summary>
        /// 指定されたパスのファイルにオーディオデータを書き込む。
        /// </summary>
        /// <param name="output"></param>
        public void WriteTo(string output)
        {
            string format = Path.GetExtension(output).ToLower();

            switch (format)
            {
                case ".wav":
                    WriteAsWav(output);
                    break;
                case ".mp3":
                    WriteAsMp3(output);
                    break;
                case ".aac":
                    WriteAsAac(output);
                    break;
                case ".wma":
                    WriteAsWma(output);
                    break;
            }
        }

        /// <summary>
        /// 指定されたパスにWAV形式で保存する。
        /// </summary>
        /// <param name="output"></param>
        private void WriteAsWav(string output)
        {
            WaveFileWriter.CreateWaveFile(output, this.source);
        }

        /// <summary>
        /// 指定されたパスにMP3形式で保存する。
        /// </summary>
        /// <param name="output"></param>
        /// <param name="bitRate"></param>
        private void WriteAsMp3(string output, int bitRate = 192000)
        {
            // Media Foundation API の使用準備
            MediaFoundationApi.Startup();

            // MP3形式に変換
            MediaFoundationEncoder.EncodeToMp3(this.source, output, bitRate);

            // Media Foundation API を終了
            MediaFoundationApi.Shutdown();
        }

        /// <summary>
        /// 指定されたパスにAAC形式で保存する。
        /// </summary>
        /// <param name="output"></param>
        /// <param name="bitRate"></param>
        private void WriteAsAac(string output, int bitRate = 192000)
        {
            // Media Foundation API の使用準備
            MediaFoundationApi.Startup();

            // AAC形式に変換
            MediaFoundationEncoder.EncodeToAac(this.source, output, bitRate);

            // Media Foundation API を終了
            MediaFoundationApi.Shutdown();
        }

        /// <summary>
        /// 指定されたパスにWMA形式で保存する。
        /// </summary>
        /// <param name="output"></param>
        /// <param name="bitRate"></param>
        private void WriteAsWma(string output, int bitRate = 192000)
        {
            // Media Foundation API の使用準備
            MediaFoundationApi.Startup();

            // WMA形式に変換
            MediaFoundationEncoder.EncodeToWma(this.source, output, bitRate);

            // Media Foundation API を終了
            MediaFoundationApi.Shutdown();
        }
    }
}
