using ATL;
using System;
using System.Drawing;
using System.IO;

namespace RabbitTune.MediaLibrary
{
    public class AudioTrack
    {
        // 非公開変数
        private string path;
        private Track tagReader;

        // 拡張子のリストは次のURLから引用
        // https://github.com/Zeugma440/atldotnet
        private static readonly string[] SupportedFileExtensions = new string[]
        {
            ".aac", ".mp4", ".m4a", ".m4b",
            ".caf", ".aax", ".aa", ".aif",
            ".aiff", ".aifc", ".dts", ".dsd",
            ".dsf", ".ac3", ".xm", ".flac",
            ".gym", ".it", ".mid", ".midi",
            ".ape", ".mp1", ".mp2", ".mp3",
            ".mpc", ".mp+", ".mod", ".ogg",
            ".oga", ".opus", ".ofr" , ".ofs",
            ".psf", ".psf1", ".psf2", ".minipsf",
            ".minipsf1", ".minipsf2", ".dsf",
            ".minidsf", ".gsf", ".minigsf",
            ".qfs", ".minisqf", ".s3m", ".spc",
            ".tak", ".tta", ".vqf", ".wav",
            ".bwav", ".bwf", ".vgm", ".wv", ".wma",
            ".afs"
        };

        // コンストラクタ
        public AudioTrack(string path)
        {
            if (CheckSupported(path))
            {
                try
                {
                    this.tagReader = new Track(path, true);
                }
                catch
                {
                    this.tagReader = null;
                }
            }

            this.path = path;
        }

        /// <summary>
        /// タグの読み込みに対応している形式であるかどうか判定する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool CheckSupported(string path)
        {
            string extension = Path.GetExtension(path).ToLower();

            if(Array.IndexOf(SupportedFileExtensions, extension) != -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// ファイルの場所
        /// </summary>
        public string Location
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get
            {
                string result = null;

                if(this.tagReader != null)
                {
                    result = this.tagReader.Title;
                }

                if(string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(this.Location))
                {
                    result = Path.GetFileNameWithoutExtension(this.Location);
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// アルバム
        /// </summary>
        public string Album
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.Album;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// アーティスト
        /// </summary>
        public string Artist
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.Artist;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// アルバムアーティスト
        /// </summary>
        public string AlbumArtist
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.AlbumArtist;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 年
        /// </summary>
        public int Year
        {
            get
            {
                if(this.tagReader != null)
                {
                    if(this.tagReader.Year != null)
                    {
                        return this.tagReader.Year.Value;
                    }
                }

                return -1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// ジャンル
        /// </summary>
        public string Genre
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.Genre;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 作曲者
        /// </summary>
        public string Composer
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.Composer;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// トラック番号
        /// </summary>
        public int TrackNumber
        {
            get
            {
                if (this.tagReader != null)
                {
                    if(this.tagReader.TrackNumber != null)
                    {
                        return this.tagReader.TrackNumber.Value;
                    }
                }

                return -1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 演奏時間
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                TimeSpan result = TimeSpan.FromMilliseconds(0);

                if (this.tagReader != null)
                {
                    result = TimeSpan.FromSeconds(this.tagReader.Duration);
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 歌詞
        /// </summary>
        public string Lyrics
        {
            get
            {
                string result = null;

                if (this.tagReader != null)
                {
                    result = this.tagReader.Lyrics.UnsynchronizedLyrics;
                }

                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// ビットレート(kbps)
        /// </summary>
        public int Bitrate
        {
            get
            {
                if (this.tagReader != null)
                {
                    int rate = this.tagReader.Bitrate;

                    if (rate != 0)
                    {
                        return rate;
                    }
                }

                return -1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// サンプルレート(hz)
        /// </summary>
        public int SampleRate
        {
            get
            {
                if (this.tagReader != null)
                {
                    int rate = (int)this.tagReader.SampleRate;

                    if (rate != 0)
                    {
                        return rate;
                    }
                }

                return -1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// トラックの画像を取得する。
        /// </summary>
        /// <returns></returns>
        public Image GetTrackPicture()
        {
            try
            {
                if (this.tagReader != null)
                {
                    var picts = this.tagReader.EmbeddedPictures;

                    if (picts.Count > 0)
                    {
                        var data = picts[0].PictureData;
                        var stream = new MemoryStream(data);
                        var img = Image.FromStream(stream);

                        return img;
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
    }
}
