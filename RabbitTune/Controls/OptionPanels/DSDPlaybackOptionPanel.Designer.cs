namespace RabbitTune.Controls.OptionPanels
{
    partial class DSDPlaybackOptionPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSDPlaybackOptionPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DSDToPCMConvertSampleRateComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DSDToPCMConvertGainValueComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.borderLine2 = new RabbitTune.Controls.BorderLine();
            this.borderLine1 = new RabbitTune.Controls.BorderLine();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSD->PCM変換設定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "PCM変換時のサンプルレート：";
            // 
            // DSDToPCMConvertSampleRateComboBox
            // 
            this.DSDToPCMConvertSampleRateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DSDToPCMConvertSampleRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DSDToPCMConvertSampleRateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DSDToPCMConvertSampleRateComboBox.FormattingEnabled = true;
            this.DSDToPCMConvertSampleRateComboBox.Location = new System.Drawing.Point(163, 57);
            this.DSDToPCMConvertSampleRateComboBox.Name = "DSDToPCMConvertSampleRateComboBox";
            this.DSDToPCMConvertSampleRateComboBox.Size = new System.Drawing.Size(202, 23);
            this.DSDToPCMConvertSampleRateComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "PCM変換時のゲイン値：";
            // 
            // DSDToPCMConvertGainValueComboBox
            // 
            this.DSDToPCMConvertGainValueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DSDToPCMConvertGainValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DSDToPCMConvertGainValueComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DSDToPCMConvertGainValueComboBox.FormattingEnabled = true;
            this.DSDToPCMConvertGainValueComboBox.Location = new System.Drawing.Point(163, 86);
            this.DSDToPCMConvertGainValueComboBox.Name = "DSDToPCMConvertGainValueComboBox";
            this.DSDToPCMConvertGainValueComboBox.Size = new System.Drawing.Size(203, 23);
            this.DSDToPCMConvertGainValueComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(5, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 107);
            this.label4.TabIndex = 7;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // borderLine2
            // 
            this.borderLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderLine2.Location = new System.Drawing.Point(4, 117);
            this.borderLine2.Margin = new System.Windows.Forms.Padding(5);
            this.borderLine2.Name = "borderLine2";
            this.borderLine2.Size = new System.Drawing.Size(362, 14);
            this.borderLine2.TabIndex = 6;
            // 
            // borderLine1
            // 
            this.borderLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderLine1.Location = new System.Drawing.Point(4, 39);
            this.borderLine1.Margin = new System.Windows.Forms.Padding(4);
            this.borderLine1.Name = "borderLine1";
            this.borderLine1.Size = new System.Drawing.Size(362, 11);
            this.borderLine1.TabIndex = 1;
            // 
            // DSDPlaybackOptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.borderLine2);
            this.Controls.Add(this.DSDToPCMConvertGainValueComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DSDToPCMConvertSampleRateComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.borderLine1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Name = "DSDPlaybackOptionPanel";
            this.Size = new System.Drawing.Size(370, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BorderLine borderLine1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DSDToPCMConvertSampleRateComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DSDToPCMConvertGainValueComboBox;
        private BorderLine borderLine2;
        private System.Windows.Forms.Label label4;
    }
}
