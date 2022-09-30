using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Dialogs
{
    public partial class FindDialog : Form
    {
        // コンストラクタ
        public FindDialog()
        {
            InitializeComponent();

            this.Font = SystemFonts.CaptionFont;
            this.SearchButton.Focus();
        }

        /// <summary>
        /// 検索語句
        /// </summary>
        public string SearchText
        {
            set
            {
                this.SearchTextBox.Text = value;
            }
            get
            {
                return this.SearchTextBox.Text;
            }
        }

        /// <summary>
        /// 大文字と小文字の判別オプション
        /// </summary>
        public bool JudgeBiggerOrLower
        {
            set
            {
                this.JudgeBittgerOrLowerCheckBox.Checked = value;
            }
            get
            {
                return this.JudgeBittgerOrLowerCheckBox.Checked;
            }
        }

        /// <summary>
        /// 完全一致のみ検索オプション
        /// </summary>
        public bool SearchAllMatchOnly
        {
            set
            {
                this.SearchAllMatchOnlyCheckBox.Checked = value;
            }
            get
            {
                return this.SearchAllMatchOnlyCheckBox.Checked;
            }
        }

        /// <summary>
        /// ダイアログの押されたボタン
        /// </summary>
        public new DialogResult DialogResult { private set; get; } = DialogResult.Cancel;

        /// <summary>
        /// フォームをモーダル ダイアログボックスとして表示する。
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            base.ShowDialog();

            return this.DialogResult;
        }

        /// <summary>
        /// 検索ボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンがクリックされた時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
