using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topx.Data;

namespace TOPX.UI.Controls
{
    /// <summary>
    /// This extension takes care of drag & drop behaviour, and keeping the datasource in sync
    /// The first column can be dragged / dropped, the second is static. When a drop takes place
    /// in a non-empty row, a new element is added with only the value of the targetted row 
    /// </summary>
    public class DragDropGridView : DataGridView
    {
        public DragDropGridView()
        {
            DragDrop += DragDropEvent;
            CellMouseMove += CellMouseMoveEvent;
            DragOver += DragOverEvent;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
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
            var cursorLocation = PointToClient(new Point(e.X, e.Y));
            var hittest = HitTest(cursorLocation.X, cursorLocation.Y);

            // Test for valid drop position
            if (hittest.ColumnIndex == 0 && hittest.RowIndex != -1 && hittest.RowIndex != CurrentCell.RowIndex)
            {
                var targetMappedFieldname = Convert.ToString(this[0, hittest.RowIndex].Value);
                var targetDatabaseFieldname = Convert.ToString(this[1, hittest.RowIndex].Value);

                var listFieldMappings = (List<FieldMapping>)DataSource;
                Enum.TryParse(listFieldMappings.FirstOrDefault()?.Type, out MappingType fieldmappingType);
                var sourceValue = CurrentCell.Value.ToString();

                var targetfieldmapping = listFieldMappings.FirstOrDefault(t => t.DatabaseFieldName == targetDatabaseFieldname);
                var sourcefieldmapping = listFieldMappings.FirstOrDefault(t => t.MappedFieldName == CurrentRow.Cells[0].Value.ToString());
                if (targetfieldmapping != null && sourcefieldmapping != null)
                {
                    targetfieldmapping.MappedFieldName = sourceValue;
                    sourcefieldmapping.MappedFieldName = string.Empty;
                    if (!string.IsNullOrEmpty(targetfieldmapping.MappedFieldName))
                    {
                        if (!listFieldMappings.Exists(t => t.MappedFieldName == targetMappedFieldname))
                            listFieldMappings.Add(new FieldMapping() { MappedFieldName = targetMappedFieldname, Type = fieldmappingType.ToString() });
                    }

                    // cleanup empty rows
                    listFieldMappings.RemoveAll(t => string.IsNullOrEmpty(t.MappedFieldName) && string.IsNullOrEmpty(t.DatabaseFieldName));
                    DataSource = listFieldMappings.ToList();
                }
            }
        }
    }
}
