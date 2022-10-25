namespace RabbitTune.Dialogs
{
    partial class OptionDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.DlgCancelButton = new System.Windows.Forms.Button();
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.AudioPlaybackOption = new System.Windows.Forms.TabPage();
            this.AudioOptionPanel = new RabbitTune.Controls.OptionPanels.AudioOptionPanel();
            this.MIDIPlaybackOption = new System.Windows.Forms.TabPage();
            this.MIDIOptionPanel = new RabbitTune.Controls.OptionPanels.MidiOptionPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DSDPlaybackOptionPanel = new RabbitTune.Controls.OptionPanels.DSDPlaybackOptionPanel();
            this.panel1.SuspendLayout();
            this.OptionsTabControl.SuspendLayout();
            this.AudioPlaybackOption.SuspendLayout();
            this.MIDIPlaybackOption.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.DlgCancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 30);
            this.panel1.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKButton.Location = new System.Drawing.Point(235, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DlgCancelButton
            // 
            this.DlgCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DlgCancelButton.Location = new System.Drawing.Point(316, 2);
            this.DlgCancelButton.Name = "DlgCancelButton";
            this.DlgCancelButton.Size = new System.Drawing.Size(75, 23);
            this.DlgCancelButton.TabIndex = 0;
            this.DlgCancelButton.Text = "キャンセル";
            this.DlgCancelButton.UseVisualStyleBackColor = true;
            this.DlgCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.AudioPlaybackOption);
            this.OptionsTabControl.Controls.Add(this.MIDIPlaybackOption);
            this.OptionsTabControl.Controls.Add(this.tabPage1);
            this.OptionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(394, 295);
            this.OptionsTabControl.TabIndex = 1;
            // 
            // AudioPlaybackOption
            // 
            this.AudioPlaybackOption.Controls.Add(this.AudioOptionPanel);
            this.AudioPlaybackOption.Location = new System.Drawing.Point(4, 24);
            this.AudioPlaybackOption.Name = "AudioPlaybackOption";
            this.AudioPlaybackOption.Padding = new System.Windows.Forms.Padding(3);
            this.AudioPlaybackOption.Size = new System.Drawing.Size(386, 267);
            this.AudioPlaybackOption.TabIndex = 0;
            this.AudioPlaybackOption.Text = "オーディオ設定";
            this.AudioPlaybackOption.UseVisualStyleBackColor = true;
            // 
            // AudioOptionPanel
            // 
            this.AudioOptionPanel.AutoScroll = true;
            this.AudioOptionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.AudioOptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioOptionPanel.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.AudioOptionPanel.Location = new System.Drawing.Point(3, 3);
            this.AudioOptionPanel.Name = "AudioOptionPanel";
            this.AudioOptionPanel.Size = new System.Drawing.Size(380, 261);
            this.AudioOptionPanel.TabIndex = 0;
            // 
            // MIDIPlaybackOption
            // 
            this.MIDIPlaybackOption.Controls.Add(this.MIDIOptionPanel);
            this.MIDIPlaybackOption.Location = new System.Drawing.Point(4, 24);
            this.MIDIPlaybackOption.Name = "MIDIPlaybackOption";
            this.MIDIPlaybackOption.Size = new System.Drawing.Size(386, 267);
            this.MIDIPlaybackOption.TabIndex = 2;
            this.MIDIPlaybackOption.Text = "MIDI再生設定";
            this.MIDIPlaybackOption.UseVisualStyleBackColor = true;
            // 
            // MIDIOptionPanel
            // 
            this.MIDIOptionPanel.AutoScroll = true;
            this.MIDIOptionPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MIDIOptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MIDIOptionPanel.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.MIDIOptionPanel.Location = new System.Drawing.Point(0, 0);
            this.MIDIOptionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MIDIOptionPanel.Name = "MIDIOptionPanel";
            this.MIDIOptionPanel.Size = new System.Drawing.Size(386, 267);
            this.MIDIOptionPanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.DSDPlaybackOptionPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(386, 267);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "DSD再生設定";
            // 
            // DSDPlaybackOptionPanel
            // 
            this.DSDPlaybackOptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DSDPlaybackOptionPanel.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.DSDPlaybackOptionPanel.Location = new System.Drawing.Point(0, 0);
            this.DSDPlaybackOptionPanel.Name = "DSDPlaybackOptionPanel";
            this.DSDPlaybackOptionPanel.Size = new System.Drawing.Size(386, 267);
            this.DSDPlaybackOptionPanel.TabIndex = 0;
            // 
            // OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(394, 325);
            this.Controls.Add(this.OptionsTabControl);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "詳細設定";
            this.panel1.ResumeLayout(false);
            this.OptionsTabControl.ResumeLayout(false);
            this.AudioPlaybackOption.ResumeLayout(false);
            this.MIDIPlaybackOption.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button DlgCancelButton;
        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.TabPage AudioPlaybackOption;
        private Controls.OptionPanels.AudioOptionPanel AudioOptionPanel;
        private System.Windows.Forms.TabPage MIDIPlaybackOption;
        private Controls.OptionPanels.MidiOptionPanel MIDIOptionPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.OptionPanels.DSDPlaybackOptionPanel DSDPlaybackOptionPanel;
    }
}