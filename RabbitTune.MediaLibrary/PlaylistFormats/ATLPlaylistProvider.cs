using ATL;
using ATL.Playlist;
using System.Collections.Generic;
using System.IO;

namespace RabbitTune.MediaLibrary.PlaylistFormats
{
    public class ATLPlaylistProvider : IPlaylistFormatProvider
    {
        // 非公開フィールド
        private readonly IList<string> ImportFileExtensions;

        // コンストラクタ
        public ATLPlaylistProvider() { }
        public ATLPlaylistProvider(IList<string> importFileExtensions)
        {
            this.ImportFileExtensions = importFileExtensions;
        }

        /// <summary>
        /// 読み込み可能かどうか
        /// </summary>
        public bool CanRead { set; get; } = true;

        /// <summary>
        /// 書き込み可能かどうか
        /// </summary>
        public bool CanWrite { set; get; } = true;

        /// <summary>
        /// プレイリストを書き込む。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="playlist"></param>
        public void SavePlaylist(string path, Playlist playlist)
        {
            if(playlist == null)
            {
                playlist = new Playlist();
            }

            if (playlist.Tracks != null)
            {
                var io = PlaylistIOFactory.GetInstance().GetPlaylistIO(path);
                var atlTracks = new Track[playlist.TrackCount];

                for (int i = 0; i < atlTracks.Length; ++i)
                {
                    atlTracks[i] = new Track(playlist.Tracks[i].Location, false);
                }

                io.Tracks = atlTracks;
            }
            else
            {
                File.Create(path);
            }

            // プレイリストデータの場所を更新しておく。
            playlist.Location = path;
        }

        /// <summary>
        /// プレイリストを読み込む。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Playlist ReadPlaylist(string path)
        {
            var result = new Playlist();
            var io = PlaylistIOFactory.GetInstance().GetPlaylistIO(path);
            result.Location = path;

            foreach (var trackLocation in io.FilePaths)
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
                            result.Tracks.Add(track);
                        }
                    }
                    else
                    {
                        var track = new AudioTrack(trackLocation);
                        result.Tracks.Add(track);
                    }
                }
                else
                {
                    result.NotFoundFiles.Add(trackLocation);
                }
            }

            return result;
        }
    }
}
