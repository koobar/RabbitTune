namespace RabbitTune.Dialogs
{
    partial class FindDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.DlgCancelButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.JudgeBittgerOrLowerCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchAllMatchOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "検索語句を入力してください。";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(12, 27);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(260, 23);
            this.SearchTextBox.TabIndex = 1;
            // 
            // DlgCancelButton
            // 
            this.DlgCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DlgCancelButton.Location = new System.Drawing.Point(197, 110);
            this.DlgCancelButton.Name = "DlgCancelButton";
            this.DlgCancelButton.Size = new System.Drawing.Size(75, 25);
            this.DlgCancelButton.TabIndex = 5;
            this.DlgCancelButton.Text = "キャンセル";
            this.DlgCancelButton.UseVisualStyleBackColor = true;
            this.DlgCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SearchButton.Location = new System.Drawing.Point(116, 110);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 25);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "検索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // JudgeBittgerOrLowerCheckBox
            // 
            this.JudgeBittgerOrLowerCheckBox.AutoSize = true;
            this.JudgeBittgerOrLowerCheckBox.Location = new System.Drawing.Point(12, 56);
            this.JudgeBittgerOrLowerCheckBox.Name = "JudgeBittgerOrLowerCheckBox";
            this.JudgeBittgerOrLowerCheckBox.Size = new System.Drawing.Size(159, 19);
            this.JudgeBittgerOrLowerCheckBox.TabIndex = 2;
            this.JudgeBittgerOrLowerCheckBox.Text = "大文字と小文字を区別する";
            this.JudgeBittgerOrLowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchAllMatchOnlyCheckBox
            // 
            this.SearchAllMatchOnlyCheckBox.AutoSize = true;
            this.SearchAllMatchOnlyCheckBox.Location = new System.Drawing.Point(12, 81);
            this.SearchAllMatchOnlyCheckBox.Name = "SearchAllMatchOnlyCheckBox";
            this.SearchAllMatchOnlyCheckBox.Size = new System.Drawing.Size(119, 19);
            this.SearchAllMatchOnlyCheckBox.TabIndex = 3;
            this.SearchAllMatchOnlyCheckBox.Text = "完全一致のみ検索";
            this.SearchAllMatchOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // FindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 147);
            this.Controls.Add(this.SearchAllMatchOnlyCheckBox);
            this.Controls.Add(this.JudgeBittgerOrLowerCheckBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DlgCancelButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "検索";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button DlgCancelButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.CheckBox JudgeBittgerOrLowerCheckBox;
        private System.Windows.Forms.CheckBox SearchAllMatchOnlyCheckBox;
    }
}