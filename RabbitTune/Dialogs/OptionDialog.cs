using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class OptionDialog : Form
    {
        // コンストラクタ
        public OptionDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.AudioOptionPanel.SaveOptions();
            this.MIDIOptionPanel.SaveOptions();
            this.DSDPlaybackOptionPanel.SaveOptions();
            this.OtherOptionsPanel.SaveOptions();

            Close();
        }
    }
}
