namespace RabbitTune.Controls.OptionPanels
{
    partial class AudioOptionPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.CurrentLatencyLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UseOutputFmtConvCheckBox = new System.Windows.Forms.CheckBox();
            this.WaveFormatDescriptionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AudioOutputAPIComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WASAPISyncModesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UseWASAPIExclusiveModeCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdateAudioOutputDevicesButton = new System.Windows.Forms.Button();
            this.AudioOutputDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShowAsioControlPanelButton = new System.Windows.Forms.Button();
            this.EnableMMCSSCheckBox = new System.Windows.Forms.CheckBox();
            this.AudioOutputLatencyScroll = new RabbitTune.Controls.Slider();
            this.WaveFormatConvertionBitsPerSampleComboBox = new RabbitTune.Controls.BitsPerSampleComboBox();
            this.WaveFormatConversionSampleRateComboBox = new RabbitTune.Controls.SampleRateComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputLatencyScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentLatencyLabel
            // 
            this.CurrentLatencyLabel.AutoSize = true;
            this.CurrentLatencyLabel.Location = new System.Drawing.Point(134, 151);
            this.CurrentLatencyLabel.Name = "CurrentLatencyLabel";
            this.CurrentLatencyLabel.Size = new System.Drawing.Size(74, 15);
            this.CurrentLatencyLabel.TabIndex = 11;
            this.CurrentLatencyLabel.Text = "レイテンシ:128";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "オーディオ出力のレイテンシ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.WaveFormatConvertionBitsPerSampleComboBox);
            this.groupBox2.Controls.Add(this.WaveFormatConversionSampleRateComboBox);
            this.groupBox2.Controls.Add(this.UseOutputFmtConvCheckBox);
            this.groupBox2.Controls.Add(this.WaveFormatDescriptionLinkLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(220, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 161);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出力フォーマット";
            // 
            // UseOutputFmtConvCheckBox
            // 
            this.UseOutputFmtConvCheckBox.AutoSize = true;
            this.UseOutputFmtConvCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseOutputFmtConvCheckBox.Location = new System.Drawing.Point(6, 22);
            this.UseOutputFmtConvCheckBox.Name = "UseOutputFmtConvCheckBox";
            this.UseOutputFmtConvCheckBox.Size = new System.Drawing.Size(134, 20);
            this.UseOutputFmtConvCheckBox.TabIndex = 10;
            this.UseOutputFmtConvCheckBox.Text = "フォーマット変換を行う";
            this.UseOutputFmtConvCheckBox.UseVisualStyleBackColor = true;
            this.UseOutputFmtConvCheckBox.CheckedChanged += new System.EventHandler(this.UseOutputFmtConvCheckBox_CheckedChanged);
            // 
            // WaveFormatDescriptionLinkLabel
            // 
            this.WaveFormatDescriptionLinkLabel.AutoSize = true;
            this.WaveFormatDescriptionLinkLabel.Location = new System.Drawing.Point(6, 132);
            this.WaveFormatDescriptionLinkLabel.Name = "WaveFormatDescriptionLinkLabel";
            this.WaveFormatDescriptionLinkLabel.Size = new System.Drawing.Size(117, 15);
            this.WaveFormatDescriptionLinkLabel.TabIndex = 9;
            this.WaveFormatDescriptionLinkLabel.TabStop = true;
            this.WaveFormatDescriptionLinkLabel.Text = "出力フォーマットについて";
            this.WaveFormatDescriptionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WaveFormatDescriptionLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "量子化ビット数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "サンプリング周波数";
            // 
            // AudioOutputAPIComboBox
            // 
            this.AudioOutputAPIComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioOutputAPIComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioOutputAPIComboBox.FormattingEnabled = true;
            this.AudioOutputAPIComboBox.Location = new System.Drawing.Point(6, 27);
            this.AudioOutputAPIComboBox.Name = "AudioOutputAPIComboBox";
            this.AudioOutputAPIComboBox.Size = new System.Drawing.Size(208, 23);
            this.AudioOutputAPIComboBox.TabIndex = 7;
            this.AudioOutputAPIComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioOutputAPIComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "オーディオ出力APIを選択してください。";
            // 
            // WASAPISyncModesComboBox
            // 
            this.WASAPISyncModesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WASAPISyncModesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WASAPISyncModesComboBox.FormattingEnabled = true;
            this.WASAPISyncModesComboBox.Location = new System.Drawing.Point(119, 16);
            this.WASAPISyncModesComboBox.Name = "WASAPISyncModesComboBox";
            this.WASAPISyncModesComboBox.Size = new System.Drawing.Size(83, 23);
            this.WASAPISyncModesComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "WASAPI駆動方式：";
            // 
            // UseWASAPIExclusiveModeCheckBox
            // 
            this.UseWASAPIExclusiveModeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseWASAPIExclusiveModeCheckBox.Location = new System.Drawing.Point(9, 45);
            this.UseWASAPIExclusiveModeCheckBox.Name = "UseWASAPIExclusiveModeCheckBox";
            this.UseWASAPIExclusiveModeCheckBox.Size = new System.Drawing.Size(171, 20);
            this.UseWASAPIExclusiveModeCheckBox.TabIndex = 3;
            this.UseWASAPIExclusiveModeCheckBox.Text = "WASAPIを排他モードで使用する";
            this.UseWASAPIExclusiveModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpdateAudioOutputDevicesButton
            // 
            this.UpdateAudioOutputDevicesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UpdateAudioOutputDevicesButton.Location = new System.Drawing.Point(174, 77);
            this.UpdateAudioOutputDevicesButton.Name = "UpdateAudioOutputDevicesButton";
            this.UpdateAudioOutputDevicesButton.Size = new System.Drawing.Size(40, 23);
            this.UpdateAudioOutputDevicesButton.TabIndex = 2;
            this.UpdateAudioOutputDevicesButton.Text = "更新";
            this.UpdateAudioOutputDevicesButton.UseVisualStyleBackColor = true;
            this.UpdateAudioOutputDevicesButton.Click += new System.EventHandler(this.UpdateAudioOutputDevicesButton_Click);
            // 
            // AudioOutputDevicesComboBox
            // 
            this.AudioOutputDevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioOutputDevicesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AudioOutputDevicesComboBox.FormattingEnabled = true;
            this.AudioOutputDevicesComboBox.Location = new System.Drawing.Point(6, 77);
            this.AudioOutputDevicesComboBox.Name = "AudioOutputDevicesComboBox";
            this.AudioOutputDevicesComboBox.Size = new System.Drawing.Size(162, 23);
            this.AudioOutputDevicesComboBox.TabIndex = 1;
            this.AudioOutputDevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.AudioOutputDevicesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "オーディオ出力デバイスを選択してください。";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WASAPISyncModesComboBox);
            this.groupBox1.Controls.Add(this.UseWASAPIExclusiveModeCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 73);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WASAPI固有設定";
            // 
            // ShowAsioControlPanelButton
            // 
            this.ShowAsioControlPanelButton.Enabled = false;
            this.ShowAsioControlPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShowAsioControlPanelButton.Location = new System.Drawing.Point(6, 107);
            this.ShowAsioControlPanelButton.Name = "ShowAsioControlPanelButton";
            this.ShowAsioControlPanelButton.Size = new System.Drawing.Size(208, 23);
            this.ShowAsioControlPanelButton.TabIndex = 16;
            this.ShowAsioControlPanelButton.Text = "ASIO出力設定";
            this.ShowAsioControlPanelButton.UseVisualStyleBackColor = true;
            this.ShowAsioControlPanelButton.Click += new System.EventHandler(this.ShowAsioControlPanelButton_Click);
            // 
            // EnableMMCSSCheckBox
            // 
            this.EnableMMCSSCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EnableMMCSSCheckBox.Location = new System.Drawing.Point(220, 173);
            this.EnableMMCSSCheckBox.Name = "EnableMMCSSCheckBox";
            this.EnableMMCSSCheckBox.Size = new System.Drawing.Size(103, 20);
            this.EnableMMCSSCheckBox.TabIndex = 17;
            this.EnableMMCSSCheckBox.Text = "MMCSSを有効化";
            this.EnableMMCSSCheckBox.UseVisualStyleBackColor = true;
            // 
            // AudioOutputLatencyScroll
            // 
            this.AudioOutputLatencyScroll.AutoSize = false;
            this.AudioOutputLatencyScroll.LargeChange = 1;
            this.AudioOutputLatencyScroll.Location = new System.Drawing.Point(6, 151);
            this.AudioOutputLatencyScroll.Maximum = 1000;
            this.AudioOutputLatencyScroll.MaximumSize = new System.Drawing.Size(32767, 22);
            this.AudioOutputLatencyScroll.Minimum = 10;
            this.AudioOutputLatencyScroll.Name = "AudioOutputLatencyScroll";
            this.AudioOutputLatencyScroll.ShowValueAsToolTip = true;
            this.AudioOutputLatencyScroll.Size = new System.Drawing.Size(129, 22);
            this.AudioOutputLatencyScroll.TabIndex = 15;
            this.AudioOutputLatencyScroll.TickFrequency = 0;
            this.AudioOutputLatencyScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AudioOutputLatencyScroll.Value = 128;
            this.AudioOutputLatencyScroll.ValueChanged += new System.EventHandler(this.AudioOutputLatencyTrackBar_ValueChanged);
            // 
            // WaveFormatConvertionBitsPerSampleComboBox
            // 
            this.WaveFormatConvertionBitsPerSampleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WaveFormatConvertionBitsPerSampleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveFormatConvertionBitsPerSampleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WaveFormatConvertionBitsPerSampleComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.WaveFormatConvertionBitsPerSampleComboBox.FormattingEnabled = true;
            this.WaveFormatConvertionBitsPerSampleComboBox.Location = new System.Drawing.Point(6, 106);
            this.WaveFormatConvertionBitsPerSampleComboBox.Name = "WaveFormatConvertionBitsPerSampleComboBox";
            this.WaveFormatConvertionBitsPerSampleComboBox.SelectedBitsPerSample = -1;
            this.WaveFormatConvertionBitsPerSampleComboBox.Size = new System.Drawing.Size(135, 23);
            this.WaveFormatConvertionBitsPerSampleComboBox.TabIndex = 12;
            // 
            // WaveFormatConversionSampleRateComboBox
            // 
            this.WaveFormatConversionSampleRateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WaveFormatConversionSampleRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaveFormatConversionSampleRateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WaveFormatConversionSampleRateComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.WaveFormatConversionSampleRateComboBox.FormattingEnabled = true;
            this.WaveFormatConversionSampleRateComboBox.Location = new System.Drawing.Point(6, 63);
            this.WaveFormatConversionSampleRateComboBox.Name = "WaveFormatConversionSampleRateComboBox";
            this.WaveFormatConversionSampleRateComboBox.SelectedSampleRate = -1;
            this.WaveFormatConversionSampleRateComboBox.Size = new System.Drawing.Size(135, 23);
            this.WaveFormatConversionSampleRateComboBox.TabIndex = 11;
            // 
            // AudioOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.EnableMMCSSCheckBox);
            this.Controls.Add(this.ShowAsioControlPanelButton);
            this.Controls.Add(this.AudioOutputLatencyScroll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurrentLatencyLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AudioOutputAPIComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AudioOutputDevicesComboBox);
            this.Controls.Add(this.UpdateAudioOutputDevicesButton);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Name = "AudioOptionPanel";
            this.Size = new System.Drawing.Size(370, 264);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioOutputLatencyScroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox UseWASAPIExclusiveModeCheckBox;
        private System.Windows.Forms.Button UpdateAudioOutputDevicesButton;
        private System.Windows.Forms.ComboBox AudioOutputDevicesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox WASAPISyncModesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AudioOutputAPIComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel WaveFormatDescriptionLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CurrentLatencyLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox UseOutputFmtConvCheckBox;
        private SampleRateComboBox WaveFormatConversionSampleRateComboBox;
        private BitsPerSampleComboBox WaveFormatConvertionBitsPerSampleComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private Slider AudioOutputLatencyScroll;
        private System.Windows.Forms.Button ShowAsioControlPanelButton;
        private System.Windows.Forms.CheckBox EnableMMCSSCheckBox;
    }
}
