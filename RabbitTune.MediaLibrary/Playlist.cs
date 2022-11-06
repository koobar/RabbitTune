using System.Collections.Generic;
using System.IO;

namespace RabbitTune.MediaLibrary
{
    public class Playlist
    {
        // 非公開フィールド
        private string location;
        private bool isNew;
        private bool isFile;
        private bool isDirectory;
        private bool isDiscDrive;
        private DriveInfo driveInfo;

        // コンストラクタ
        public Playlist()
        {
            this.Tracks = new List<AudioTrack>();
            this.NotFoundFiles = new List<string>();

            // 後始末
            UpdatePlaylistTypeProperties();
        }

        /// <summary>
        /// トラック一覧
        /// </summary>
        public List<AudioTrack> Tracks { set; get; }

        /// <summary>
        /// 見つからなかったファイルの一覧
        /// </summary>
        public List<string> NotFoundFiles { set; get; }

        /// <summary>
        /// トラック数
        /// </summary>
        public int TrackCount
        {
            get
            {
                return this.Tracks.Count;
            }
        }

        /// <summary>
        /// ファイルの場所
        /// </summary>
        public string Location
        {
            set
            {
                this.location = value;
                UpdatePlaylistTypeProperties();
            }
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// 新規作成されたプレイリストかどうか
        /// </summary>
        public bool IsNew
        {
            get
            {
                return this.isNew;
            }
        }

        /// <summary>
        /// ファイルから読み込まれたプレイリストかどうか
        /// </summary>
        public bool IsFile
        {
            get
            {
                return this.isFile;
            }
        }

        /// <summary>
        /// ディレクトリ（フォルダ）から読み込まれたプレイリストかどうか
        /// </summary>
        public bool IsDirectory
        {
            get
            {
                return this.isDirectory;
            }
        }

        /// <summary>
        /// ディスクドライブから読み込まれたプレイリストかどうか
        /// </summary>
        public bool IsDiscDrive
        {
            get
            {
                return this.isDiscDrive;
            }
        }

        /// <summary>
        /// ドライブの情報<br/>
        /// ディスクドライブから読み込まれたプレイリストでない場合、nullが格納される。
        /// </summary>
        public DriveInfo DriveInfo
        {
            get
            {
                return this.driveInfo;
            }
        }

        /// <summary>
        /// 与えられたパスのドライブがディスクドライブであるか判定する。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        private static bool IsDisc(string path, out DriveInfo info)
        {
            if (string.IsNullOrEmpty(path))
            {
                info = null;
                return false;
            }

            info = new DriveInfo(path[0].ToString());
            return info.DriveType == DriveType.CDRom;
        }

        /// <summary>
        /// 与えられたパスが、ファイル、ディレクトリ、またはディスクドライブであるのかを判定する。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isFile"></param>
        /// <param name="isDirectory"></param>
        /// <param name="isDiscDrive"></param>
        /// <param name="driveInfo"></param>
        public static void GetPlaylistType(string path, out bool isNew, out bool isFile, out bool isDirectory, out bool isDiscDrive, out DriveInfo driveInfo)
        {
            isNew = string.IsNullOrEmpty(path);
            isFile = File.Exists(path);
            isDirectory = Directory.Exists(path);
            isDiscDrive = IsDisc(path, out driveInfo);

            // ディスクドライブであったか？
            if (isDiscDrive)
            {
                isDirectory = false;
            }
        }

        /// <summary>
        /// プレイリストの種類に関連するプロパティを更新する。
        /// </summary>
        private void UpdatePlaylistTypeProperties()
        {
            GetPlaylistType(this.Location, out this.isNew, out this.isFile, out this.isDirectory, out this.isDiscDrive, out this.driveInfo);
        }
    }
}
