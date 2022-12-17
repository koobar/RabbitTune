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
        public const string KEY_SHOW_AS_MINIPLAYER_MODE = @"ShowAsMiniplayerMode";
        public const string KEY_DONOT_ADD_ASSOCIATED_FILE_TO_DEFAULT_PLAYLIST = @"DoNotAddAssociatedFileToDefaultPlaylist";
        public const string KEY_AUTOPLAY_WHEN_GIVEN_FILE_PATH_AS_COMMAND_LINE_ARGS = @"AutoPlayWhenGivenFilePathAsCommandLineArguments";
        public const string KEY_ALLOW_MULTI_INSTANCE = @"AllowMultiInstance";
        public const string KEY_CALL_SET_PROCESS_DPI_AWARE_FUNC = @"CallSetProcessDPIAware";
        public const string KEY_CREATE_NEW_PLAYLIST_WHEN_OPEN_FROM_COMMANDLINE_ARGS = @"CreateNewPlaylistWhenOpenFromCommandlineArgs";

        // 設定値
        public static string DefaultPlaylistPath;
        public static bool AlwaysOnTop;
        public static RepeatMode RepeatMode;
        public static FormWindowState MainFormWindowState;
        public static Size MainFormSize;
        public static bool ShowMainFormLeftSideToolPanel;
        public static bool ShowMainFormAsMiniplayerMode;
        public static bool DoNotAddAssociatedFileToDefaultPlaylist;
        public static bool AutoPlayWhenGivenFilePathAsCommandLineArguments;
        public static bool AllowMultiInstance;
        public static bool CallSetProcessDPIAware;
        public static bool CreateNewPlaylistWhenOpenFromCommandlineArgs;
    }
}
