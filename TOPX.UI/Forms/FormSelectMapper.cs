using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topx.Data;

namespace TOPX.UI.Forms
{
    public partial class FormSelectMapper : Form
    {
        private readonly List<FieldMapping> _fieldMappings;
        private readonly string _fieldnameToMap;
        

        private void FormSelectDossierMapper_Load(object sender, EventArgs e)
        {
            cmbFieldSelector.DataSource = _fieldMappings;
            cmbFieldSelector.ValueMember = "Id";
            cmbFieldSelector.DisplayMember = "DatabaseFieldName";
        }

        public FormSelectMapper(List<FieldMapping> fieldMappings, string fieldnameToMap)
        {
            _fieldMappings = fieldMappings;
            _fieldnameToMap = fieldnameToMap;
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbFieldSelector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var mapping = (from f in _fieldMappings where f.Id == Convert.ToInt32(cmbFieldSelector.SelectedValue) select f).FirstOrDefault();

            if (mapping != null)
            {
                var mappingCurrent = (from f in _fieldMappings where f.MappedFieldName == _fieldnameToMap select f).FirstOrDefault();

                if (mappingCurrent != null && _fieldnameToMap != mapping.MappedFieldName)
                {
                    if (!string.IsNullOrEmpty( mapping.MappedFieldName))
                        _fieldMappings.Add(new FieldMapping() {MappedFieldName = mapping.MappedFieldName});

                    if (!string.IsNullOrEmpty(mappingCurrent.DatabaseFieldName))
                        mappingCurrent.MappedFieldName = string.Empty;
                    else
                    {
                        _fieldMappings.Remove(mappingCurrent);
                    }
                }
                else if (string.IsNullOrEmpty(mappingCurrent?.DatabaseFieldName))
                {
                    _fieldMappings.Remove(mappingCurrent);
                }

                mapping.MappedFieldName = _fieldnameToMap;
                Close();
            }
        }
    }
}
