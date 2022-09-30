using RabbitTune.AudioEngine.BassWrapper.Midi;
using System;
using BassSoundFont = RabbitTune.AudioEngine.BassWrapper.Midi.SoundFont;

namespace RabbitTune.AudioEngine.Codecs.BassCompat
{
    public class SoundFont
    {
        // コンストラクタ
        public SoundFont(string path, bool useXGDrumMode)
        {
            this.Path = path;
            this.UseXGDrumMode = useXGDrumMode;
        }

        /// <summary>
        /// サウンドフォントの場所
        /// </summary>
        public string Path { private set; get; }

        /// <summary>
        /// XGドラムモードを使用するかどうか
        /// </summary>
        public bool UseXGDrumMode { private set; get; }

        /// <summary>
        /// サウンドフォントの音量
        /// </summary>
        public int Volume { set; get; } = 80;

        /// <summary>
        /// 使用するプリセット
        /// </summary>
        public int Preset { set; get; } = -1;

        /// <summary>
        /// 使用するバンク
        /// </summary>
        public int Bank { set; get; } = 0;

        /// <summary>
        /// このサウンドフォントが実際に使用されるかどうか
        /// </summary>
        public bool Enabled { set; get; } = true;

        /// <summary>
        /// 文字列からSoundFontクラスのインスタンスを生成する。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static SoundFont FromString(string str)
        {
            var tokens = str.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string path = null;
            bool useXGDrumMode = false;
            int volume = 80;
            int preset = -1;
            int bank = 0;
            bool enabled = true;
            int tok_cnt = tokens.Length - 1;

            if (tok_cnt >= 0)
            {
                path = tokens[0];
            }

            if (tok_cnt >= 1)
            {
                useXGDrumMode = toBoolean(tokens[1]);
            }

            if (tok_cnt >= 2)
            {
                volume = int.Parse(tokens[2]);
            }

            if (tok_cnt >= 3)
            {
                preset = int.Parse(tokens[3]);
            }

            if (tok_cnt >= 4)
            {
                bank = int.Parse(tokens[4]);
            }

            if (tok_cnt >= 5)
            {
                enabled = toBoolean(tokens[5]);
            }

            return new SoundFont(path, useXGDrumMode)
            {
                Volume = volume,
                Preset = preset,
                Bank = bank,
                Enabled = enabled
            };

            bool toBoolean(string s)
            {
                if(s.ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 文字列に変換する。
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return $"{this.Path}|{this.UseXGDrumMode}|{this.Volume}|{this.Preset}|{this.Bank}|{this.Enabled}";
        }

        /// <summary>
        /// BASSラッパーで使用するSoundFont型に変換する。
        /// </summary>
        /// <returns></returns>
        public BassSoundFont ToBassSoundFont()
        {
            var font = BassMidi.Load(this.Path, this.Preset, this.Bank, this.UseXGDrumMode);

            BassMidi.SetFontVolume(font, this.Volume / 100.0f);
            return font;
        }
    }
}
