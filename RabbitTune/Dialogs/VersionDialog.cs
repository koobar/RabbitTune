using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class VersionDialog : Form
    {
        // コンストラクタ
        public VersionDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
        }

        private void VersionDialog_Load(object sender, EventArgs e)
        {
            this.ApplicationNameWithVersionLabel.Text = $"RabbitTune version.{Program.ApplicationVersion}";
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/koobar/RabbitTune.Windows");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\License.txt");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"{Program.GetApplicationExecutingDirectory()}\\doc\\thirdpartylicenses");
        }
    }
}
