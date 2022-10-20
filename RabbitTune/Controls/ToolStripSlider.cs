using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RabbitTune.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripSlider : ToolStripControlHost
    {
        public event EventHandler ValueChanged;

        // コンストラクタ
        public ToolStripSlider() : base(new Slider())
        {
            var slider = (Slider)base.Control;

            slider.ValueChanged += delegate
            {
                this.ValueChanged?.Invoke(null, null);
            };
        }

        /// <summary>
        /// 最小値
        /// </summary>
        public int Minimum
        {
            set
            {
                var slider = (Slider)base.Control;
                slider.Minimum = value;
            }
            get
            {
                return ((Slider)base.Control).Minimum;
            }
        }

        /// <summary>
        /// 値
        /// </summary>
        public int Value
        {
            set
            {
                var slider = (Slider)base.Control;
                slider.Value = value;
            }
            get
            {
                return ((Slider)base.Control).Value;
            }
        }

        /// <summary>
        /// 最大値
        /// </summary>
        public int Maximum
        {
            set
            {
                var slider = (Slider)base.Control;
                slider.Maximum = value;
            }
            get
            {
                return ((Slider)base.Control).Maximum;
            }
        }

        /// <summary>
        /// つまみが少し動いた際の変化量
        /// </summary>
        public int SmallChange
        {
            set
            {
                ((Slider)base.Control).SmallChange = value;
            }
            get
            {
                return ((Slider)base.Control).SmallChange;
            }
        }

        /// <summary>
        /// つまみが大きく動いた際の変化量
        /// </summary>
        public int LargeChange
        {
            set
            {
                ((Slider)base.Control).LargeChange = value;
            }
            get
            {
                return ((Slider)base.Control).LargeChange;
            }
        }
    }
}
