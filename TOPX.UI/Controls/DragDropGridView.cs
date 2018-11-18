using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOPX.UI.Controls
{
    public class DragDropGridView : DataGridView
    {
        public DragDropGridView()
        {
            DragDrop += DragDropEvent;
            CellMouseMove += CellMouseMoveEvent;
            DragOver += DragOverEvent;
        }

        private void DragOverEvent(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void CellMouseMoveEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.CurrentCell.ColumnIndex == 0)
            {
                this.DoDragDrop(this[e.ColumnIndex, e.RowIndex].FormattedValue, DragDropEffects.Copy);
            }
        }

        private void DragDropEvent(object sender, DragEventArgs e)
        {
            var cellvalue = e.Data.GetData(typeof(string)) as string;
            var cursorLocation = this.PointToClient(new Point(e.X, e.Y));

            var hittest = this.HitTest(cursorLocation.X, cursorLocation.Y);
            var currentRowIdex = this.CurrentCell.RowIndex;

            if (hittest.ColumnIndex == 0 && hittest.RowIndex != -1 && hittest.RowIndex != currentRowIdex)
            {
                this[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;
                this.CurrentCell.Value = string.Empty;
                this.CurrentCell.Selected = false;
            }
        }
    }
}
