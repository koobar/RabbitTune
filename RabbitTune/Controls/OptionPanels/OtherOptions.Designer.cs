namespace RabbitTune.Controls.OptionPanels
{
    partial class OtherOptions
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
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DoNotAddAssociatedFileToDefaultPlaylistCheckBox
            // 
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.AutoSize = true;
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Location = new System.Drawing.Point(4, 4);
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Name = "DoNotAddAssociatedFileToDefaultPlaylistCheckBox";
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Size = new System.Drawing.Size(306, 20);
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.TabIndex = 0;
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.Text = "関連付けで開かれた際にデフォルトプレイリストに追加しない";
            this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox
            // 
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.AutoSize = true;
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Location = new System.Drawing.Point(4, 32);
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Name = "AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox";
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Size = new System.Drawing.Size(282, 20);
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.TabIndex = 1;
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.Text = "起動時にファイルを指定された場合に自動再生を行う";
            this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // OtherOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox);
            this.Controls.Add(this.DoNotAddAssociatedFileToDefaultPlaylistCheckBox);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OtherOptions";
            this.Size = new System.Drawing.Size(370, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DoNotAddAssociatedFileToDefaultPlaylistCheckBox;
        private System.Windows.Forms.CheckBox AutoPlayWhenGivenFilePathAsCommandLineArgumentsCheckBox;
    }
}
