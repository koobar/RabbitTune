namespace RabbitTune.Controls
{
    partial class EqualizerOptionControl
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
            this.LevelTrackBar = new System.Windows.Forms.TrackBar();
            this.AverageFreqLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LevelTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LevelTrackBar
            // 
            this.LevelTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LevelTrackBar.AutoSize = false;
            this.LevelTrackBar.LargeChange = 1;
            this.LevelTrackBar.Location = new System.Drawing.Point(8, 4);
            this.LevelTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.LevelTrackBar.Maximum = 100;
            this.LevelTrackBar.Minimum = -100;
            this.LevelTrackBar.Name = "LevelTrackBar";
            this.LevelTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LevelTrackBar.Size = new System.Drawing.Size(41, 272);
            this.LevelTrackBar.TabIndex = 0;
            this.LevelTrackBar.TickFrequency = 10;
            this.LevelTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.LevelTrackBar.ValueChanged += new System.EventHandler(this.LevelTrackBar_ValueChanged);
            // 
            // AverageFreqLabel
            // 
            this.AverageFreqLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AverageFreqLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AverageFreqLabel.Location = new System.Drawing.Point(0, 295);
            this.AverageFreqLabel.Name = "AverageFreqLabel";
            this.AverageFreqLabel.Size = new System.Drawing.Size(53, 15);
            this.AverageFreqLabel.TabIndex = 1;
            this.AverageFreqLabel.Text = "Freq";
            this.AverageFreqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LevelLabel
            // 
            this.LevelLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LevelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LevelLabel.Location = new System.Drawing.Point(0, 310);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(53, 15);
            this.LevelLabel.TabIndex = 2;
            this.LevelLabel.Text = "Level";
            this.LevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EqualizerOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.LevelTrackBar);
            this.Controls.Add(this.AverageFreqLabel);
            this.Controls.Add(this.LevelLabel);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(432, 325);
            this.Name = "EqualizerOptionControl";
            this.Size = new System.Drawing.Size(53, 325);
            ((System.ComponentModel.ISupportInitialize)(this.LevelTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar LevelTrackBar;
        private System.Windows.Forms.Label AverageFreqLabel;
        private System.Windows.Forms.Label LevelLabel;
    }
}
