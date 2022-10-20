using ATL;
using ATL.Playlist;
using System.Collections.Generic;
using System.IO;

namespace RabbitTune.MediaLibrary.PlaylistFormats
{
    public class ATLPlaylistProvider : IPlaylistFormatProvider
    {
        // 非公開変数
        private readonly IList<string> ImportFileExtensions;

        // コンストラクタ
        public ATLPlaylistProvider() { }
        public ATLPlaylistProvider(IList<string> importFileExtensions)
        {
            this.ImportFileExtensions = importFileExtensions;
        }

        /// <summary>
        /// トラック一覧
        /// </summary>
        public List<AudioTrack> Tracks { set; get; }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Dispose()
        {
            this.Tracks.Clear();
        }

        /// <summary>
        /// プレイリストを読み込む。
        /// </summary>
        /// <param name="path"></param>
        public void ReadPlaylist(string path, out List<string> notFoundFiles)
        {
            var io = PlaylistIOFactory.GetInstance().GetPlaylistIO(path);
            notFoundFiles = new List<string>();
            this.Tracks = new List<AudioTrack>();

            foreach(var trackLocation in io.FilePaths)
            {
                // ファイルが存在するか？
                if (File.Exists(trackLocation))
                {
                    string ext = Path.GetExtension(trackLocation).ToLower();

                    if (this.ImportFileExtensions != null)
                    {
                        if (this.ImportFileExtensions.IndexOf(ext) != -1)
                        {
                            var track = new AudioTrack(trackLocation);
                            this.Tracks.Add(track);
                        }
                    }
                    else
                    {
                        var track = new AudioTrack(trackLocation);
                        this.Tracks.Add(track);
                    }
                }
                else
                {
                    notFoundFiles.Add(trackLocation);
                }
            }
        }

        /// <summary>
        /// プレイリストを保存する。
        /// </summary>
        /// <param name="path"></param>
        public void SavePlaylist(string path)
        {
            var io = PlaylistIOFactory.GetInstance().GetPlaylistIO(path);

            if (this.Tracks != null)
            {
                var atlTracks = new Track[this.Tracks.Count];

                for (int i = 0; i < atlTracks.Length; ++i)
                {
                    atlTracks[i] = new Track(this.Tracks[i].Location, false);
                }

                io.Tracks = atlTracks;
            }
            else
            {
                File.Create(path);
            }
        }
    }
}
