using System;
using System.Collections.Generic;
using System.Linq;

namespace RabbitTune
{
    public static class PlaylistsDataBase
    {
        // イベント
        public static event EventHandler FavoritePlaylistChanged;
        public static event EventHandler RecentPlaylistsChanged;

        // 公開定数
        public const string KEY_FAVORITE_PLAYLISTS = @"FavoritePlaylists";
        public const string KEY_RECENT_PLAYLISTS = @"RecentPlaylists";

        // 公開変数
        public static List<string> FavoritePlaylists;
        public static List<string> RecentPlaylists;

        /// <summary>
        /// データベース変更時等に発生するイベントを自動的に実行するかどうか
        /// </summary>
        public static bool AutoInvokeAnyEvents { set; get; } = true;

        /// <summary>
        /// イベントを実行する。
        /// </summary>
        /// <param name="eventHandler"></param>
        private static void InvokeEvent(EventHandler eventHandler)
        {
            if (AutoInvokeAnyEvents)
            {
                eventHandler?.Invoke(null, null);
            }
        }

        /// <summary>
        /// お気に入りプレイリストの一覧を設定する。
        /// </summary>
        /// <param name="items"></param>
        public static void SetFavoritePlaylists(IList<string> items)
        {
            FavoritePlaylists = items.ToList();

            // イベントを実行
            InvokeEvent(FavoritePlaylistChanged);
        }

        /// <summary>
        /// 最近開いたプレイリストの一覧を設定する。
        /// </summary>
        /// <param name="items"></param>
        public static void SetRecentPlaylists(IList<string> items)
        {
            RecentPlaylists = items.ToList();

            // イベントを実行
            InvokeEvent(RecentPlaylistsChanged);
        }

        /// <summary>
        /// お気に入りプレイリストのデータに登録する。
        /// </summary>
        /// <param name="path"></param>
        public static void AddFavoritePlaylist(string path)
        {
            if (path == ApplicationOptions.DefaultPlaylistPath)
            {
                return;
            }

            if (FavoritePlaylists.Contains(path) == false)
            {
                FavoritePlaylists.Add(path);
            }

            // イベントを実行
            InvokeEvent(FavoritePlaylistChanged);
        }

        /// <summary>
        /// 最近開いたプレイリストのデータに登録する。
        /// </summary>
        /// <param name="path"></param>
        public static void AddRecentPlaylist(string path)
        {
            if (path == ApplicationOptions.DefaultPlaylistPath)
            {
                return;
            }

            if (RecentPlaylists.Contains(path) == false)
            {
                RecentPlaylists.Add(path);
            }

            // イベントを実行
            InvokeEvent(RecentPlaylistsChanged);
        }

        /// <summary>
        /// お気に入りプレイリストから削除
        /// </summary>
        /// <param name="path"></param>
        public static void RemoveFromFavoritePlaylist(string path)
        {
            FavoritePlaylists.Remove(path);

            // イベントを実行
            InvokeEvent(FavoritePlaylistChanged);
        }

        /// <summary>
        /// 最近開いたプレイリストから削除
        /// </summary>
        /// <param name="path"></param>
        public static void RemoveFromRecentPlaylist(string path)
        {
            RecentPlaylists.Remove(path);

            // イベントを実行
            InvokeEvent(RecentPlaylistsChanged);
        }
    }
}
