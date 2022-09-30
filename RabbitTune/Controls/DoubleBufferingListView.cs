using System.Windows.Forms;

namespace RabbitTune.Controls
{
    internal class DoubleBufferingListView : ListView
    {
        public DoubleBufferingListView()
        {
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint,
                true);
        }
    }
}
