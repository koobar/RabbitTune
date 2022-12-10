namespace RabbitTune.Dialogs
{
    partial class VersionDialog
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
            this.ApplicationNameWithVersionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AppIconViewer = new System.Windows.Forms.PictureBox();
            this.GitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.borderLine1 = new RabbitTune.Controls.BorderLine();
            ((System.ComponentModel.ISupportInitialize)(this.AppIconViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationNameWithVersionLabel
            // 
            this.ApplicationNameWithVersionLabel.AutoSize = true;
            this.ApplicationNameWithVersionLabel.Location = new System.Drawing.Point(66, 12);
            this.ApplicationNameWithVersionLabel.Name = "ApplicationNameWithVersionLabel";
            this.ApplicationNameWithVersionLabel.Size = new System.Drawing.Size(125, 15);
            this.ApplicationNameWithVersionLabel.TabIndex = 1;
            this.ApplicationNameWithVersionLabel.Text = "RabbitTune version.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copyright (c) 2022 koobar.";
            // 
            // AppIconViewer
            // 
            this.AppIconViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AppIconViewer.Image = global::RabbitTune.Properties.Resources.appicon;
            this.AppIconViewer.Location = new System.Drawing.Point(12, 12);
            this.AppIconViewer.Name = "AppIconViewer";
            this.AppIconViewer.Size = new System.Drawing.Size(48, 48);
            this.AppIconViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AppIconViewer.TabIndex = 0;
            this.AppIconViewer.TabStop = false;
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.Location = new System.Drawing.Point(164, 45);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(45, 15);
            this.GitHubLinkLabel.TabIndex = 4;
            this.GitHubLinkLabel.TabStop = true;
            this.GitHubLinkLabel.Text = "GitHub";
            this.GitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabel_LinkClicked);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(197, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 188);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "本ソフトウェアのライセンス";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(12, 208);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(118, 15);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "オープンソースソフトウェア";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(66, 45);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(92, 15);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "RabbitTuneのHP";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(259, 107);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "このソフトウェアは、数多くのオープンソース\r\nソフトウェアやアイコン素材などを使用して\r\n作成されました。これらのライセンスについて、\r\n詳しくは、doc\\thi" +
    "rdpartylicenseフォルダ内の\r\nテキストファイルをご参照ください。なお、上記の\r\nフォルダは下記の「オープンソースソフトウェア」から\r\n直接開くこと" +
    "ができます。";
            this.textBox1.WordWrap = false;
            // 
            // borderLine1
            // 
            this.borderLine1.Location = new System.Drawing.Point(12, 60);
            this.borderLine1.Margin = new System.Windows.Forms.Padding(4);
            this.borderLine1.Name = "borderLine1";
            this.borderLine1.Size = new System.Drawing.Size(259, 11);
            this.borderLine1.TabIndex = 10;
            // 
            // VersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.borderLine1);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GitHubLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ApplicationNameWithVersionLabel);
            this.Controls.Add(this.AppIconViewer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "バージョン情報";
            this.Load += new System.EventHandler(this.VersionDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppIconViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AppIconViewer;
        private System.Windows.Forms.Label ApplicationNameWithVersionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel GitHubLinkLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private Controls.BorderLine borderLine1;
        private System.Windows.Forms.TextBox textBox1;
    }
}