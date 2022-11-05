using System.Windows.Forms;

namespace RabbitTune.Controls
{
    partial class PlaylistViewer
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
            this.AudioTracksViewer = new RabbitTune.Controls.DoubleBufferingListView();
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // AudioTracksViewer
            // 
            this.AudioTracksViewer.AllowColumnReorder = true;
            this.AudioTracksViewer.AllowDrop = true;
            this.AudioTracksViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleColumn});
            this.AudioTracksViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioTracksViewer.FullRowSelect = true;
            this.AudioTracksViewer.HideSelection = false;
            this.AudioTracksViewer.Location = new System.Drawing.Point(0, 0);
            this.AudioTracksViewer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AudioTracksViewer.MultiSelect = false;
            this.AudioTracksViewer.Name = "AudioTracksViewer";
            this.AudioTracksViewer.Size = new System.Drawing.Size(257, 240);
            this.AudioTracksViewer.TabIndex = 0;
            this.AudioTracksViewer.UseCompatibleStateImageBehavior = false;
            this.AudioTracksViewer.View = System.Windows.Forms.View.Details;
            this.AudioTracksViewer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AudioTracksViewer_ColumnClick);
            this.AudioTracksViewer.SelectedIndexChanged += new System.EventHandler(this.AudioTracksViewer_SelectedIndexChanged);
            this.AudioTracksViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioTracksViewer_DragDrop);
            this.AudioTracksViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.AudioTracksViewer_DragEnter);
            this.AudioTracksViewer.DoubleClick += new System.EventHandler(this.AudioTracksViewer_DoubleClick);
            // 
            // PlaylistViewer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.AudioTracksViewer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlaylistName = "PlaylistViewer";
            this.Size = new System.Drawing.Size(257, 240);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioTracksViewer_DragDrop);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferingListView AudioTracksViewer;
        private ColumnHeader TitleColumn;
    }
}
