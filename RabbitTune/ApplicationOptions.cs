using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune
{
    public static class ApplicationOptions
    {
        // 設定キー
        public const string KEY_DEFAULT_PLAYLIST_PATH = @"DefaultPlaylistPath";
        public const string KEY_REPEAT_MODE = @"RepeatMode";
        public const string KEY_MAINWND_STATE = @"WindowState";
        public const string KEY_MAINWND_WIDTH = @"MainFormWidth";
        public const string KEY_MAINWND_HEIGHT = @"MainFormHeight";
        public const string KEY_SHOW_LEFTTOOLPANEL = @"ShowLeftSideToolPanel";
        public const string KEY_ALWAYS_ON_TOP = @"AlwaysOnTop";

        // 設定値
        public static string DefaultPlaylistPath;
        public static bool AlwaysOnTop = false;
        public static RepeatMode RepeatMode;
        public static FormWindowState MainFormWindowState;
        public static Size MainFormSize;
        public static bool ShowMainFormLeftSideToolPanel;
    }
}
