using System.Collections.Generic;
using System.IO;

namespace RabbitTune.MediaLibrary
{
    public static class AudioTrackReader
    {
        /// <summary>
        /// フォルダ内のトラックをすべて読み込む。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<AudioTrack> ReadFolder(string path, IList<string> importFileExtensions = null)
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            var tracks = new List<AudioTrack>();

            foreach (var file in files)
            {
                var track = ReadTrack(file, importFileExtensions);

                if (track != null)
                {
                    tracks.Add(track);
                }
            }

            return tracks;
        }

        /// <summary>
        /// 指定されたトラックを読み込む。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioTrack ReadTrack(string path, IList<string> importFileExtensions = null)
        {
            if (importFileExtensions != null && importFileExtensions.Count > 0)
            {
                string extension = Path.GetExtension(path).ToLower();

                if (importFileExtensions.IndexOf(extension) == -1)
                {
                    return null;
                }
            }

            return new AudioTrack(path);
        }
    }
}
