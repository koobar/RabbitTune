using System;

namespace RabbitTune.AudioEngine.SoundTouchWrapper
{
    internal class SoundTouch : IDisposable
    {
        // 非公開変数
        private readonly IntPtr soundTouchHandle;

        // コンストラクタ
        public SoundTouch()
        {
            // ネイティブライブラリの読み込みディレクトリを設定
            Win32Api.SetNativeDllDirectory();

            // SoundTouchのインスタンスのハンドルを取得。
            this.soundTouchHandle = SoundTouchInterop.soundtouch_createInstance();
        }

        // デストラクタ
        ~SoundTouch()
        {
            DestroySoundTouchInstance();
        }
        
        /// <summary>
        /// テンポを設定する。
        /// </summary>
        /// <param name="tempo"></param>
        public void SetTempo(float tempo)
        {
            SoundTouchInterop.soundtouch_setTempoChange(this.soundTouchHandle, tempo);
        }

        /// <summary>
        /// ピッチ変化量を設定する。
        /// </summary>
        /// <param name="pitch"></param>
        public void SetPitch(float pitch)
        {
            SoundTouchInterop.soundtouch_setPitch(this.soundTouchHandle, pitch);
        }

        /// <summary>
        /// ピッチ変化量を半音単位で設定する。
        /// </summary>
        /// <param name="semitones"></param>
        public void SetPitchSemitones(float semitones)
        {
            SoundTouchInterop.soundtouch_setPitchSemiTones(this.soundTouchHandle, semitones);
        }

        /// <summary>
        /// サンプルレートを設定する。
        /// </summary>
        /// <param name="sampleRate"></param>
        public void SetSampleRate(int sampleRate)
        {
            uint srate = (uint)sampleRate;
            SoundTouchInterop.soundtouch_setSampleRate(this.soundTouchHandle, srate);
        }

        /// <summary>
        /// チャンネル数
        /// </summary>
        /// <param name="channels"></param>
        public void SetChannels(int channels)
        {
            uint numChannels = (uint)channels;
            SoundTouchInterop.soundtouch_setChannels(this.soundTouchHandle, numChannels);
        }

        /// <summary>
        /// SoundTouch のインスタンスを破棄する。
        /// </summary>
        private void DestroySoundTouchInstance()
        {
            if (this.soundTouchHandle != IntPtr.Zero)
            {
                SoundTouchInterop.soundtouch_destroyInstance(this.soundTouchHandle);
            }
        }

        /// <summary>
        /// このインスタンスを破棄する。
        /// </summary>
        public void Dispose()
        {
            DestroySoundTouchInstance();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// SoundTouch のインスタンスをクリアする。
        /// </summary>
        public void Clear()
        {
            SoundTouchInterop.soundtouch_clear(this.soundTouchHandle);
        }

        public void Flush()
        {
            SoundTouchInterop.soundtouch_flush(this.soundTouchHandle);
        }

        /// <summary>
        /// SoundTouch のインスタンスにサンプルを書き込む。
        /// </summary>
        /// <param name="samples"></param>
        public void PutSamples(float[] samples)
        {
            uint num = (uint)samples.LongLength;

            PutSamples(samples, num);
        }

        /// <summary>
        /// SoundTouch のインスタンスに、指定された個数のサンプルを書き込む。
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="numSamples"></param>
        public void PutSamples(float[] samples, uint numSamples)
        {
            SoundTouchInterop.soundtouch_putSamples(this.soundTouchHandle, samples, numSamples);
        }

        /// <summary>
        /// SoundTouch のインスタンスから、指定された最大個数のサンプルを読み込む。<br/>
        /// 戻り値は、読み込んだサンプル数を返す。
        /// </summary>
        /// <param name="outBuffer"></param>
        /// <param name="maxSamples"></param>
        /// <returns></returns>
        public int ReceiveSamples(float[] outBuffer, int maxSamples)
        {
            return (int)SoundTouchInterop.soundtouch_receiveSamples(this.soundTouchHandle, outBuffer, (uint)maxSamples);
        }

        /// <summary>
        /// 利用可能なサンプル数
        /// </summary>
        public int NumberOfSamplesAvailable
        {
            get
            {
                return (int)SoundTouchInterop.soundtouch_numSamples(this.soundTouchHandle);
            }
        }
    }
}
