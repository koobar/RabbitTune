namespace RabbitTune.Dialogs
{
    partial class MidSideMixerDialog
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
            this.UsePreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.UseMidSideMixerCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SideSignalBoostLevelSlider = new RabbitTune.Controls.Slider();
            this.MidSignalBoostLevelSlider = new RabbitTune.Controls.Slider();
            this.MidSignalLevelLabel = new System.Windows.Forms.Label();
            this.SideSignalLevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SideSignalBoostLevelSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MidSignalBoostLevelSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "ミッドサイド ミキサーは、L/R方式のステレオ音声をMid信号と\r\nSide信号に分割し、それぞれの信号を増加、および減衰\r\nさせることで、音像の広がり方を調整す" +
    "るツールです。";
            // 
            // UsePreviewCheckBox
            // 
            this.UsePreviewCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.UsePreviewCheckBox.AutoSize = true;
            this.UsePreviewCheckBox.Location = new System.Drawing.Point(12, 159);
            this.UsePreviewCheckBox.Name = "UsePreviewCheckBox";
            this.UsePreviewCheckBox.Size = new System.Drawing.Size(59, 25);
            this.UsePreviewCheckBox.TabIndex = 6;
            this.UsePreviewCheckBox.Text = "プレビュー";
            this.UsePreviewCheckBox.UseVisualStyleBackColor = true;
            this.UsePreviewCheckBox.CheckedChanged += new System.EventHandler(this.UsePreviewCheckBox_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(224, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 25);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // UseMidSideMixerCheckBox
            // 
            this.UseMidSideMixerCheckBox.AutoSize = true;
            this.UseMidSideMixerCheckBox.Location = new System.Drawing.Point(12, 134);
            this.UseMidSideMixerCheckBox.Name = "UseMidSideMixerCheckBox";
            this.UseMidSideMixerCheckBox.Size = new System.Drawing.Size(165, 19);
            this.UseMidSideMixerCheckBox.TabIndex = 5;
            this.UseMidSideMixerCheckBox.Text = "ミッドサイド ミキサーを使用する";
            this.UseMidSideMixerCheckBox.UseVisualStyleBackColor = true;
            this.UseMidSideMixerCheckBox.CheckedChanged += new System.EventHandler(this.UseMidSideMixerCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Side";
            // 
            // SideSignalBoostLevelSlider
            // 
            this.SideSignalBoostLevelSlider.AutoSize = false;
            this.SideSignalBoostLevelSlider.LargeChange = 1;
            this.SideSignalBoostLevelSlider.Location = new System.Drawing.Point(47, 99);
            this.SideSignalBoostLevelSlider.Maximum = 32768;
            this.SideSignalBoostLevelSlider.MaximumSize = new System.Drawing.Size(32767, 22);
            this.SideSignalBoostLevelSlider.Name = "SideSignalBoostLevelSlider";
            this.SideSignalBoostLevelSlider.ShowValueAsToolTip = false;
            this.SideSignalBoostLevelSlider.Size = new System.Drawing.Size(200, 22);
            this.SideSignalBoostLevelSlider.TabIndex = 9;
            this.SideSignalBoostLevelSlider.TickFrequency = 0;
            this.SideSignalBoostLevelSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SideSignalBoostLevelSlider.ValueChanged += new System.EventHandler(this.SideSignalBoostLevelSlider_ValueChanged);
            // 
            // MidSignalBoostLevelSlider
            // 
            this.MidSignalBoostLevelSlider.AutoSize = false;
            this.MidSignalBoostLevelSlider.LargeChange = 1;
            this.MidSignalBoostLevelSlider.Location = new System.Drawing.Point(46, 69);
            this.MidSignalBoostLevelSlider.Maximum = 32768;
            this.MidSignalBoostLevelSlider.MaximumSize = new System.Drawing.Size(32767, 22);
            this.MidSignalBoostLevelSlider.Name = "MidSignalBoostLevelSlider";
            this.MidSignalBoostLevelSlider.ShowValueAsToolTip = true;
            this.MidSignalBoostLevelSlider.Size = new System.Drawing.Size(200, 22);
            this.MidSignalBoostLevelSlider.TabIndex = 8;
            this.MidSignalBoostLevelSlider.TickFrequency = 0;
            this.MidSignalBoostLevelSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MidSignalBoostLevelSlider.ValueChanged += new System.EventHandler(this.MidSignalBoostLevelSlider_ValueChanged);
            // 
            // MidSignalLevelLabel
            // 
            this.MidSignalLevelLabel.AutoSize = true;
            this.MidSignalLevelLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MidSignalLevelLabel.Location = new System.Drawing.Point(252, 71);
            this.MidSignalLevelLabel.Name = "MidSignalLevelLabel";
            this.MidSignalLevelLabel.Size = new System.Drawing.Size(30, 17);
            this.MidSignalLevelLabel.TabIndex = 10;
            this.MidSignalLevelLabel.Text = "x1.0";
            // 
            // SideSignalLevelLabel
            // 
            this.SideSignalLevelLabel.AutoSize = true;
            this.SideSignalLevelLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SideSignalLevelLabel.Location = new System.Drawing.Point(252, 101);
            this.SideSignalLevelLabel.Name = "SideSignalLevelLabel";
            this.SideSignalLevelLabel.Size = new System.Drawing.Size(30, 17);
            this.SideSignalLevelLabel.TabIndex = 11;
            this.SideSignalLevelLabel.Text = "x1.0";
            // 
            // MidSideMixerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 196);
            this.Controls.Add(this.SideSignalLevelLabel);
            this.Controls.Add(this.MidSignalLevelLabel);
            this.Controls.Add(this.SideSignalBoostLevelSlider);
            this.Controls.Add(this.MidSignalBoostLevelSlider);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UseMidSideMixerCheckBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.UsePreviewCheckBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MidSideMixerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ミッドサイド ミキサー";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MidSideMixerDialog_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.SideSignalBoostLevelSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MidSignalBoostLevelSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox UsePreviewCheckBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox UseMidSideMixerCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controls.Slider MidSignalBoostLevelSlider;
        private Controls.Slider SideSignalBoostLevelSlider;
        private System.Windows.Forms.Label MidSignalLevelLabel;
        private System.Windows.Forms.Label SideSignalLevelLabel;
    }
}