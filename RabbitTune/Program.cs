using RabbitTune.AudioEngine;
using RabbitTune.AudioEngine.AudioOutputApi;
using RabbitTune.AudioEngine.Codecs;
using RabbitTune.ConfigFile;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RabbitTune
{
    internal static class Program
    {
        // 公開変数
        public static readonly string ApplicationDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\RabbitTune";
        public static readonly string ApplicationConfigFilePath = $"{ApplicationDataPath}\\config.dat";
        public static readonly string DefaultDefaultPlaylistPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)}\\RabbitTune\\default.m3u8";
        public static readonly string ApplicationName = "RabbitTune";
        public static readonly Version ApplicationVersion = new Version(1, 0, 5, 0);
        public static bool ResetApplicationOptionRequested = false;

        // 非公開変数
        private static MainForm MainForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // エンジンを初期化する。
            Engine.Initialize();

            // 設定を読み込む。
            LoadAllOptions();

            // ビジュアルスタイルなどの描画設定
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // メインフォーム作成
            MainForm = new MainForm(args);

            // 起動処理
            Application.Run(MainForm);

            // 設定を保存
            SaveAllOptions();

            // ライブラリの使用終了処理
            Engine.Free();
        }

        /// <summary>
        /// アプリケーションの実行ファイルのフルパスを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationFullPath()
        {
            return Process.GetCurrentProcess().MainModule.FileName;
        }

        /// <summary>
        /// アプリケーションの実行ファイルが配置されたディレクトリを取得する。
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationExecutingDirectory()
        {
            return Path.GetDirectoryName(GetApplicationFullPath());
        }

        /// <summary>
        /// アプリケーション設定を保存する。
        /// </summary>
        public static void SaveAllOptions()
        {
            if (ResetApplicationOptionRequested)
            {
                File.Delete(ApplicationConfigFilePath);
                File.Delete(DefaultDefaultPlaylistPath);
                Application.Restart();
            }
            else
            {
                var writer = new PropertyFileWriter(ApplicationConfigFilePath);

                // メインフォームの表示設定
                var wndSize = MainForm.GetRestoreFormSize();
                writer.WriteEmptyLine();
                writer.WriteComment("MainForm Layouts");
                writer.WriteProperty(ApplicationOptions.KEY_ALWAYS_ON_TOP, ApplicationOptions.AlwaysOnTop);
                writer.WriteProperty(ApplicationOptions.KEY_MAINWND_STATE, MainForm.WindowState);
                writer.WriteProperty(ApplicationOptions.KEY_MAINWND_WIDTH, wndSize.Width);
                writer.WriteProperty(ApplicationOptions.KEY_MAINWND_HEIGHT, wndSize.Height);
                writer.WriteProperty(ApplicationOptions.KEY_SHOW_LEFTTOOLPANEL, MainForm.ShowLeftSideToolPanel);
                writer.WriteProperty(ApplicationOptions.KEY_SHOW_AS_MINIPLAYER_MODE, MainForm.ShowAsMiniplayerMode);

                // アプリ設定
                writer.WriteEmptyLine();
                writer.WriteComment("Application Options");
                writer.WriteProperty(ApplicationOptions.KEY_REPEAT_MODE, ApplicationOptions.RepeatMode);
                writer.WriteProperty(ApplicationOptions.KEY_DONOT_ADD_ASSOCIATED_FILE_TO_DEFAULT_PLAYLIST, ApplicationOptions.DoNotAddAssociatedFileToDefaultPlaylist);
                writer.WriteProperty(ApplicationOptions.KEY_AUTOPLAY_WHEN_GIVEN_FILE_PATH_AS_COMMAND_LINE_ARGS, ApplicationOptions.AutoPlayWhenGivenFilePathAsCommandLineArguments);

                // プレイリスト
                writer.WriteEmptyLine();
                writer.WriteComment("Playlists");
                writer.WriteProperty(ApplicationOptions.KEY_DEFAULT_PLAYLIST_PATH, ApplicationOptions.DefaultPlaylistPath);
                writer.WriteStringArrayProperty(PlaylistsDataBase.KEY_FAVORITE_PLAYLISTS, PlaylistsDataBase.FavoritePlaylists);
                writer.WriteStringArrayProperty(PlaylistsDataBase.KEY_RECENT_PLAYLISTS, PlaylistsDataBase.RecentPlaylists);

                // オーディオ出力設定
                writer.WriteEmptyLine();
                writer.WriteComment("Audio Output Options");
                writer.WriteProperty(AudioPlayerManager.KEY_AUDIO_OUTPUT_DEVICE_API, AudioPlayerManager.OutputDeviceApiType);
                writer.WriteProperty(AudioPlayerManager.KEY_AUDIO_OUTPUT_DEVICE_NAME, AudioPlayerManager.AudioOutputDevice);
                writer.WriteProperty(AudioPlayerManager.KEY_USE_WASAPI_EVENTSYNC, AudioPlayerManager.UseWasapiEventSync);
                writer.WriteProperty(AudioPlayerManager.KEY_USE_WASAPI_EXCLUSIVE_MODE, AudioPlayerManager.UseWasapiExclusiveMode);
                writer.WriteProperty(AudioPlayerManager.KEY_PLAYBACK_LATENCY, AudioPlayerManager.PlaybackLatency);
                writer.WriteProperty(AudioPlayerManager.KEY_ENABLE_MMCSS, AudioPlayerManager.EnableMMCSS);

                // 音響処理設定
                writer.WriteProperty(AudioPlayerManager.KEY_USE_OUTFMTCONV, AudioPlayerManager.UseDeviceOutputWaveFormatConversion);
                writer.WriteProperty(AudioPlayerManager.KEY_OUTFMTCONV_SAMPLERATE, AudioPlayerManager.DeviceOutputWaveFormatSampleRate);
                writer.WriteProperty(AudioPlayerManager.KEY_OUTFMT_BITSPERSAMPLE, AudioPlayerManager.DeviceOutputWaveFormatBitsPerSample);
                writer.WriteProperty(AudioPlayerManager.KEY_USE_RESAMPLER, AudioPlayerManager.UseReSampler);
                writer.WriteProperty(AudioPlayerManager.KEY_RESAMPLER_SAMPLERATE, AudioPlayerManager.ReSamplerSampleRate);
                writer.WriteProperty(AudioPlayerManager.KEY_RESAMPLER_BITSPERSAMPLE, AudioPlayerManager.ReSamplerBitsPerSample);
                writer.WriteProperty(AudioPlayerManager.KEY_RESAMPLER_CHANNELS, AudioPlayerManager.ReSamplerChannels);
                writer.WriteProperty(AudioPlayerManager.KEY_AUDIO_OUTPUT_VOLUME, AudioPlayerManager.Volume);
                writer.WriteProperty(AudioPlayerManager.KEY_AUDIO_OUTPUT_PANNING, AudioPlayerManager.Balance);
                writer.WriteProperty(AudioPlayerManager.KEY_USE_EQUALIZER, AudioPlayerManager.UseEqualizer);
                writer.WriteProperty(AudioPlayerManager.KEY_EQUALIZER_DOWNSAMPLE_TO_32K, AudioPlayerManager.DownSampleTo32KBeforeEqualizerProcess);
                writer.WriteDoubleArrayProperty(AudioPlayerManager.KEY_EQUALIZER_GAINDECIBELS, AudioPlayerManager.EqualizerAverageGainDecibels);
                writer.WriteProperty(AudioPlayerManager.KEY_PLAYBACK_SPEED, AudioPlayerManager.PlaybackSpeed);
                writer.WriteProperty(AudioPlayerManager.KEY_PITCHSHIFTER_FIX_CLIP, AudioPlayerManager.PitchShifterFixClip);
                writer.WriteProperty(AudioPlayerManager.KEY_PLAYBACK_PITCH, AudioPlayerManager.Pitch);
                writer.WriteProperty(AudioPlayerManager.KEY_SOUNDTOUCH_PITCHSHIFTER_PITCHSEMITONES, AudioPlayerManager.SoundTouchPitchSemitones);
                writer.WriteProperty(AudioPlayerManager.KEY_SOUNDTOUCH_PITCHSHIFTER_FIX_CLIP, AudioPlayerManager.SoundTouchPitchShifterFixClip);

                // MIDI・サウンドフォントの設定
                writer.WriteEmptyLine();
                writer.WriteComment("MIDI Options");
                writer.WriteProperty(AudioPlayerManager.KEY_MIDI_USE_HWMIXING, AudioPlayerManager.MidiUseHardwareMixing);
                writer.WriteProperty(AudioPlayerManager.KEY_MIDI_USE_SINC_INTERPOLATION, AudioPlayerManager.MidiUseSincInterpolation);
                string[] fonts = new string[AudioPlayerManager.SoundFonts.Length];
                for(int i = 0; i < AudioPlayerManager.SoundFonts.Length; ++i)
                {
                    fonts[i] = AudioPlayerManager.SoundFonts[i].ToString();
                }
                writer.WriteStringArrayProperty(AudioPlayerManager.KEY_SOUNDFONTS, fonts);

                // DSDの設定
                writer.WriteEmptyLine();
                writer.WriteComment("DSD Options");
                writer.WriteProperty(AudioPlayerManager.KEY_DSDTOPCM_SAMPLERATE, AudioPlayerManager.DsdToPcmSampleRate);
                writer.WriteProperty(AudioPlayerManager.KEY_DSDTOPCM_GAIN, AudioPlayerManager.DsdToPcmGain);

                // 後始末
                writer.Dispose();
            }
        }
       
        /// <summary>
        /// アプリケーション設定を読み込む。
        /// </summary>
        public static void LoadAllOptions()
        {
            var reader = new PropertyFileReader(ApplicationConfigFilePath);

            // アプリ設定
            ApplicationOptions.RepeatMode = (RepeatMode)reader.GetValueAsEnum(
                ApplicationOptions.KEY_REPEAT_MODE,
                RepeatMode.NoRepeat,
                typeof(RepeatMode));
            ApplicationOptions.AlwaysOnTop = reader.GetValueAsBoolean(ApplicationOptions.KEY_ALWAYS_ON_TOP, false);
            ApplicationOptions.MainFormWindowState = (FormWindowState)reader.GetValueAsEnum(ApplicationOptions.KEY_MAINWND_STATE, FormWindowState.Normal, typeof(FormWindowState));
            ApplicationOptions.MainFormSize = new Size(
                reader.GetValueAsInt(ApplicationOptions.KEY_MAINWND_WIDTH, MainForm.DEFAULT_WINDOW_WIDTH),
                reader.GetValueAsInt(ApplicationOptions.KEY_MAINWND_HEIGHT, MainForm.DEFAULT_WINDOW_HEIGHT));
            ApplicationOptions.ShowMainFormLeftSideToolPanel = reader.GetValueAsBoolean(ApplicationOptions.KEY_SHOW_LEFTTOOLPANEL, true);
            ApplicationOptions.ShowMainFormAsMiniplayerMode = reader.GetValueAsBoolean(ApplicationOptions.KEY_SHOW_AS_MINIPLAYER_MODE, false);
            ApplicationOptions.DoNotAddAssociatedFileToDefaultPlaylist = reader.GetValueAsBoolean(ApplicationOptions.KEY_DONOT_ADD_ASSOCIATED_FILE_TO_DEFAULT_PLAYLIST, false);
            ApplicationOptions.AutoPlayWhenGivenFilePathAsCommandLineArguments = reader.GetValueAsBoolean(ApplicationOptions.KEY_AUTOPLAY_WHEN_GIVEN_FILE_PATH_AS_COMMAND_LINE_ARGS, true);

            // プレイリストなど
            PlaylistsDataBase.AutoInvokeAnyEvents = false;
            ApplicationOptions.DefaultPlaylistPath = reader.GetValue(ApplicationOptions.KEY_DEFAULT_PLAYLIST_PATH, DefaultDefaultPlaylistPath);
            PlaylistsDataBase.SetFavoritePlaylists(reader.GetStringArrayValue(PlaylistsDataBase.KEY_FAVORITE_PLAYLISTS));
            PlaylistsDataBase.SetRecentPlaylists(reader.GetStringArrayValue(PlaylistsDataBase.KEY_RECENT_PLAYLISTS));
            PlaylistsDataBase.AutoInvokeAnyEvents = true;

            // オーディオ出力設定
            AudioPlayerManager.OutputDeviceApiType = (AudioOutputDeviceApiType)reader.GetValueAsEnum(
                AudioPlayerManager.KEY_AUDIO_OUTPUT_DEVICE_API,
                AudioOutputDeviceApiType.Wasapi,
                typeof(AudioOutputDeviceApiType));
            AudioPlayerManager.AudioOutputDevice = reader.GetValue(AudioPlayerManager.KEY_AUDIO_OUTPUT_DEVICE_NAME, null);
            AudioPlayerManager.PlaybackLatency = reader.GetValueAsInt(AudioPlayerManager.KEY_PLAYBACK_LATENCY, 128);
            AudioPlayerManager.UseWasapiEventSync = reader.GetValueAsBoolean(AudioPlayerManager.KEY_USE_WASAPI_EVENTSYNC, false);
            AudioPlayerManager.UseWasapiExclusiveMode = reader.GetValueAsBoolean(AudioPlayerManager.KEY_USE_WASAPI_EXCLUSIVE_MODE, false);
            AudioPlayerManager.EnableMMCSS = reader.GetValueAsBoolean(AudioPlayerManager.KEY_ENABLE_MMCSS, false);

            // 音響処理設定
            AudioPlayerManager.UseDeviceOutputWaveFormatConversion = reader.GetValueAsBoolean(AudioPlayerManager.KEY_USE_OUTFMTCONV, false);
            AudioPlayerManager.DeviceOutputWaveFormatSampleRate = reader.GetValueAsInt(AudioPlayerManager.KEY_OUTFMTCONV_SAMPLERATE, AudioPlayer.WAVEFORMAT_NOCONV);
            AudioPlayerManager.DeviceOutputWaveFormatBitsPerSample = reader.GetValueAsInt(AudioPlayerManager.KEY_OUTFMT_BITSPERSAMPLE, AudioPlayer.WAVEFORMAT_NOCONV);
            AudioPlayerManager.Volume = reader.GetValueAsInt(AudioPlayerManager.KEY_AUDIO_OUTPUT_VOLUME, 80);
            AudioPlayerManager.Balance = reader.GetValueAsInt(AudioPlayerManager.KEY_AUDIO_OUTPUT_PANNING, 0);
            AudioPlayerManager.SetReSamplerOptions(
                 reader.GetValueAsBoolean(AudioPlayerManager.KEY_USE_RESAMPLER, false),
                 reader.GetValueAsInt(AudioPlayerManager.KEY_RESAMPLER_SAMPLERATE, 44100),
                 reader.GetValueAsInt(AudioPlayerManager.KEY_RESAMPLER_BITSPERSAMPLE, 16),
                 reader.GetValueAsInt(AudioPlayerManager.KEY_RESAMPLER_CHANNELS, 2));
            AudioPlayerManager.UseEqualizer = reader.GetValueAsBoolean(AudioPlayerManager.KEY_USE_EQUALIZER);
            AudioPlayerManager.DownSampleTo32KBeforeEqualizerProcess = reader.GetValueAsBoolean(AudioPlayerManager.KEY_EQUALIZER_DOWNSAMPLE_TO_32K);
            AudioPlayerManager.EqualizerAverageGainDecibels = reader.GetDoubleArrayValue(AudioPlayerManager.KEY_EQUALIZER_GAINDECIBELS, 0, 10).ToArray();
            AudioPlayerManager.PlaybackSpeed = reader.GetValueAsFloat(AudioPlayerManager.KEY_PLAYBACK_SPEED, 1.0f);
            AudioPlayerManager.PitchShifterFixClip = reader.GetValueAsBoolean(AudioPlayerManager.KEY_PITCHSHIFTER_FIX_CLIP);
            AudioPlayerManager.Pitch = reader.GetValueAsInt(AudioPlayerManager.KEY_PLAYBACK_PITCH, 0);
            AudioPlayerManager.SoundTouchPitchSemitones = reader.GetValueAsInt(AudioPlayerManager.KEY_SOUNDTOUCH_PITCHSHIFTER_PITCHSEMITONES, 0);
            AudioPlayerManager.SoundTouchPitchShifterFixClip = reader.GetValueAsBoolean(AudioPlayerManager.KEY_SOUNDTOUCH_PITCHSHIFTER_FIX_CLIP);

            // MIDI・サウンドフォントの設定
            var soundFontOptions = reader.GetStringArrayValue(AudioPlayerManager.KEY_SOUNDFONTS);
            var soundFonts = new SoundFont[soundFontOptions.Length];
            for(int i = 0; i < soundFonts.Length; ++i)
            {
                soundFonts[i] = SoundFont.FromString(soundFontOptions[i]);
            }
            AudioPlayerManager.SoundFonts = soundFonts;
            AudioPlayerManager.MidiUseHardwareMixing = reader.GetValueAsBoolean(AudioPlayerManager.KEY_MIDI_USE_HWMIXING);
            AudioPlayerManager.MidiUseSincInterpolation = reader.GetValueAsBoolean(AudioPlayerManager.KEY_MIDI_USE_SINC_INTERPOLATION);

            // DSDの設定
            AudioPlayerManager.DsdToPcmSampleRate = reader.GetValueAsInt(AudioPlayerManager.KEY_DSDTOPCM_SAMPLERATE, 88200);
            AudioPlayerManager.DsdToPcmGain = reader.GetValueAsInt(AudioPlayerManager.KEY_DSDTOPCM_GAIN, 6);
        }
    }
}