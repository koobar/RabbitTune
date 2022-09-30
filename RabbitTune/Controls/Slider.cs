using System.Drawing;
using System.Windows.Forms;

namespace RabbitTune.Controls
{
    public class Slider : TrackBar
    {
        // 非公開変数
        private readonly ToolTip ValueToolTip;

        // コンストラクタ
        public Slider()
        {
            this.ValueToolTip = new ToolTip();

            this.AutoSize = false;
            this.TickStyle = TickStyle.None;
            this.TickFrequency = 0;
            this.MaximumSize = new Size(short.MaxValue, 22);
            this.Height = 22;
            this.SmallChange = 1;
            this.LargeChange = 1;
            this.ValueChanged += delegate
            {
                OnValueChanged();
            };
        }

        /// <summary>
        /// 値が変更された際にToolTipに値を表示するかどうか
        /// </summary>
        public bool ShowValueAsToolTip { set; get; } = true;

        /// <summary>
        /// 値が変更された際の処理
        /// </summary>
        private void OnValueChanged()
        {
            if (this.ShowValueAsToolTip)
            {
                this.ValueToolTip.SetToolTip(this, this.Value.ToString());
            }
        }
    }
}