namespace RabbitTune.Controls.OptionPanels
{
    partial class MidiOptionPanel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SoundFontsListBox = new System.Windows.Forms.ListBox();
            this.soundFontBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddFontButton = new System.Windows.Forms.Button();
            this.RemoveFontButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UseXGCompatModeCheckBox = new System.Windows.Forms.CheckBox();
            this.VolumeSlider = new RabbitTune.Controls.Slider();
            this.UseHWMixingCheckBox = new System.Windows.Forms.CheckBox();
            this.UseSincInterpolationCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.soundFontBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIDIファイルの再生に使用するサウンドフォントを設定します。\r\n※MIDIファイルを再生するには、最低1つ以上のサウンドフォントが必要です。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "再生に使用するサウンドフォント一覧（上から順に使用されます）";
            // 
            // SoundFontsListBox
            // 
            this.SoundFontsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SoundFontsListBox.DataSource = this.soundFontBindingSource;
            this.SoundFontsListBox.DisplayMember = "Path";
            this.SoundFontsListBox.FormattingEnabled = true;
            this.SoundFontsListBox.Location = new System.Drawing.Point(7, 57);
            this.SoundFontsListBox.Name = "SoundFontsListBox";
            this.SoundFontsListBox.Size = new System.Drawing.Size(250, 184);
            this.SoundFontsListBox.TabIndex = 2;
            this.SoundFontsListBox.SelectedIndexChanged += new System.EventHandler(this.SoundFontsListBox_SelectedIndexChanged);
            // 
            // soundFontBindingSource
            // 
            this.soundFontBindingSource.DataSource = typeof(RabbitTune.AudioEngine.Codecs.SoundFont);
            // 
            // AddFontButton
            // 
            this.AddFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFontButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddFontButton.Location = new System.Drawing.Point(263, 57);
            this.AddFontButton.Name = "AddFontButton";
            this.AddFontButton.Size = new System.Drawing.Size(104, 23);
            this.AddFontButton.TabIndex = 3;
            this.AddFontButton.Text = "フォントを追加";
            this.AddFontButton.UseVisualStyleBackColor = true;
            this.AddFontButton.Click += new System.EventHandler(this.AddFontButton_Click);
            // 
            // RemoveFontButton
            // 
            this.RemoveFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveFontButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RemoveFontButton.Location = new System.Drawing.Point(263, 86);
            this.RemoveFontButton.Name = "RemoveFontButton";
            this.RemoveFontButton.Size = new System.Drawing.Size(104, 23);
            this.RemoveFontButton.TabIndex = 4;
            this.RemoveFontButton.Text = "フォントを削除";
            this.RemoveFontButton.UseVisualStyleBackColor = true;
            this.RemoveFontButton.Click += new System.EventHandler(this.RemoveFontButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(263, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 2);
            this.label3.TabIndex = 5;
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MoveUpButton.Location = new System.Drawing.Point(263, 117);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(104, 23);
            this.MoveUpButton.TabIndex = 6;
            this.MoveUpButton.Text = "上に移動";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MoveDownButton.Location = new System.Drawing.Point(263, 146);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(104, 23);
            this.MoveDownButton.TabIndex = 7;
            this.MoveDownButton.Text = "下に移動";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(263, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 2);
            this.label4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "音量：";
            // 
            // UseXGCompatModeCheckBox
            // 
            this.UseXGCompatModeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseXGCompatModeCheckBox.AutoSize = true;
            this.UseXGCompatModeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseXGCompatModeCheckBox.Location = new System.Drawing.Point(266, 221);
            this.UseXGCompatModeCheckBox.Name = "UseXGCompatModeCheckBox";
            this.UseXGCompatModeCheckBox.Size = new System.Drawing.Size(95, 20);
            this.UseXGCompatModeCheckBox.TabIndex = 11;
            this.UseXGCompatModeCheckBox.Text = "XG音源互換";
            this.UseXGCompatModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // VolumeSlider
            // 
            this.VolumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeSlider.AutoSize = false;
            this.VolumeSlider.LargeChange = 1;
            this.VolumeSlider.Location = new System.Drawing.Point(263, 195);
            this.VolumeSlider.Maximum = 100;
            this.VolumeSlider.MaximumSize = new System.Drawing.Size(32767, 22);
            this.VolumeSlider.Name = "VolumeSlider";
            this.VolumeSlider.ShowValueAsToolTip = true;
            this.VolumeSlider.Size = new System.Drawing.Size(104, 20);
            this.VolumeSlider.TabIndex = 10;
            this.VolumeSlider.TickFrequency = 0;
            this.VolumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeSlider.ValueChanged += new System.EventHandler(this.VolumeSlider_ValueChanged);
            // 
            // UseHWMixingCheckBox
            // 
            this.UseHWMixingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseHWMixingCheckBox.AutoSize = true;
            this.UseHWMixingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseHWMixingCheckBox.Location = new System.Drawing.Point(7, 247);
            this.UseHWMixingCheckBox.Name = "UseHWMixingCheckBox";
            this.UseHWMixingCheckBox.Size = new System.Drawing.Size(323, 20);
            this.UseHWMixingCheckBox.TabIndex = 12;
            this.UseHWMixingCheckBox.Text = "ハードウェアミキシングを有効化（CPUの一部が開放されます）";
            this.UseHWMixingCheckBox.UseVisualStyleBackColor = true;
            // 
            // UseSincInterpolationCheckBox
            // 
            this.UseSincInterpolationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseSincInterpolationCheckBox.AutoSize = true;
            this.UseSincInterpolationCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseSincInterpolationCheckBox.Location = new System.Drawing.Point(7, 273);
            this.UseSincInterpolationCheckBox.Name = "UseSincInterpolationCheckBox";
            this.UseSincInterpolationCheckBox.Size = new System.Drawing.Size(338, 20);
            this.UseSincInterpolationCheckBox.TabIndex = 13;
            this.UseSincInterpolationCheckBox.Text = "Sinc補完を使用してサンプルをミックスする。（高音質、高負荷）";
            this.UseSincInterpolationCheckBox.UseVisualStyleBackColor = true;
            // 
            // MidiOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.UseSincInterpolationCheckBox);
            this.Controls.Add(this.UseHWMixingCheckBox);
            this.Controls.Add(this.UseXGCompatModeCheckBox);
            this.Controls.Add(this.VolumeSlider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RemoveFontButton);
            this.Controls.Add(this.AddFontButton);
            this.Controls.Add(this.SoundFontsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MidiOptionPanel";
            this.Size = new System.Drawing.Size(370, 303);
            ((System.ComponentModel.ISupportInitialize)(this.soundFontBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox SoundFontsListBox;
        private System.Windows.Forms.Button AddFontButton;
        private System.Windows.Forms.Button RemoveFontButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Slider VolumeSlider;
        private System.Windows.Forms.CheckBox UseXGCompatModeCheckBox;
        private System.Windows.Forms.BindingSource soundFontBindingSource;
        private System.Windows.Forms.CheckBox UseHWMixingCheckBox;
        private System.Windows.Forms.CheckBox UseSincInterpolationCheckBox;
    }
}
