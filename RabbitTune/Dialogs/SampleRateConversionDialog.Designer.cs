namespace RabbitTune.Dialogs
{
    partial class SampleRateConversionDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UseSampleRateConversionCheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.BitsPerSampleComboBox = new RabbitTune.Controls.BitsPerSampleComboBox();
            this.SampleRateComboBox = new RabbitTune.Controls.SampleRateComboBox();
            this.ChannelsComboBox = new RabbitTune.Controls.ChannelsComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "サンプリング周波数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "量子化ビット数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "チャンネル数";
            // 
            // UseSampleRateConversionCheckBox
            // 
            this.UseSampleRateConversionCheckBox.AutoSize = true;
            this.UseSampleRateConversionCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseSampleRateConversionCheckBox.Location = new System.Drawing.Point(15, 56);
            this.UseSampleRateConversionCheckBox.Name = "UseSampleRateConversionCheckBox";
            this.UseSampleRateConversionCheckBox.Size = new System.Drawing.Size(198, 20);
            this.UseSampleRateConversionCheckBox.TabIndex = 7;
            this.UseSampleRateConversionCheckBox.Text = "サンプリング周波数変換を使用する";
            this.UseSampleRateConversionCheckBox.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKButton.Location = new System.Drawing.Point(257, 56);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // BitsPerSampleComboBox
            // 
            this.BitsPerSampleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BitsPerSampleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BitsPerSampleComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.BitsPerSampleComboBox.FormattingEnabled = true;
            this.BitsPerSampleComboBox.Location = new System.Drawing.Point(151, 27);
            this.BitsPerSampleComboBox.Name = "BitsPerSampleComboBox";
            this.BitsPerSampleComboBox.SelectedBitsPerSample = -1;
            this.BitsPerSampleComboBox.Size = new System.Drawing.Size(100, 23);
            this.BitsPerSampleComboBox.TabIndex = 11;
            // 
            // SampleRateComboBox
            // 
            this.SampleRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SampleRateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SampleRateComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.SampleRateComboBox.FormattingEnabled = true;
            this.SampleRateComboBox.Location = new System.Drawing.Point(15, 27);
            this.SampleRateComboBox.Name = "SampleRateComboBox";
            this.SampleRateComboBox.SelectedSampleRate = -1;
            this.SampleRateComboBox.Size = new System.Drawing.Size(130, 23);
            this.SampleRateComboBox.TabIndex = 10;
            // 
            // ChannelsComboBox
            // 
            this.ChannelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChannelsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChannelsComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.ChannelsComboBox.FormattingEnabled = true;
            this.ChannelsComboBox.Location = new System.Drawing.Point(257, 27);
            this.ChannelsComboBox.Name = "ChannelsComboBox";
            this.ChannelsComboBox.SelectedChannels = -1;
            this.ChannelsComboBox.Size = new System.Drawing.Size(75, 23);
            this.ChannelsComboBox.TabIndex = 12;
            // 
            // SampleRateConversionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(344, 91);
            this.Controls.Add(this.ChannelsComboBox);
            this.Controls.Add(this.BitsPerSampleComboBox);
            this.Controls.Add(this.SampleRateComboBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.UseSampleRateConversionCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SampleRateConversionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "サンプリング周波数変換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox UseSampleRateConversionCheckBox;
        private System.Windows.Forms.Button OKButton;
        private Controls.SampleRateComboBox SampleRateComboBox;
        private Controls.BitsPerSampleComboBox BitsPerSampleComboBox;
        private Controls.ChannelsComboBox ChannelsComboBox;
    }
}