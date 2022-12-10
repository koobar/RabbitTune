using System.Windows.Forms;

namespace RabbitTune.Controls.OptionPanels
{
    public partial class OtherOptions : UserControl
    {
        // コンストラクタ
        public OtherOptions()
        {
            InitializeComponent();
            LoadOptions();
        }

        /// <summary>
        /// 設定を読み込んで表示に反映する。
        /// </summary>
        private void LoadOptions()
        {
            if (!ControlUtils.IsDesignMode())
            {
                this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Checked = ApplicationOptions.DoNotAddAssociatedFileToDefaultPlaylist;
                this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Checked = ApplicationOptions.AutoPlayWhenGivenFilePathAsCommandLineArguments;
                this.AllowMultiInstanceCheckBox.Checked = ApplicationOptions.AllowMultiInstance;
            }
        }

        /// <summary>
        /// 設定を保存する。
        /// </summary>
        public void SaveOptions()
        {
            ApplicationOptions.DoNotAddAssociatedFileToDefaultPlaylist = this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Checked;
            ApplicationOptions.AutoPlayWhenGivenFilePathAsCommandLineArguments = this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Checked;
            ApplicationOptions.AllowMultiInstance = this.AllowMultiInstanceCheckBox.Checked;
        }
    }
}
