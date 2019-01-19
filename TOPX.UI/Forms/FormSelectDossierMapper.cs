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
    public partial class FormSelectDossierMapper : Form
    {
        private readonly List<FieldMapping> _fieldMappings;
        private readonly string _fieldnameToMap;

        private void FormSelectDossierMapper_Load(object sender, EventArgs e)
        {
            cmbFieldSelector.DataSource = _fieldMappings;
            cmbFieldSelector.ValueMember = "Id";
            cmbFieldSelector.DisplayMember = "DatabaseFieldName";
        }

        public FormSelectDossierMapper(List<FieldMapping> fieldMappings, string fieldnameToMap)
        {
            _fieldMappings = fieldMappings;
            _fieldnameToMap = fieldnameToMap;
            InitializeComponent();
        }

        private void btSubmitSelection_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbFieldSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFieldSelector.SelectedIndex > 0)
            {
                var mapping = (from f in _fieldMappings where f.Id == Convert.ToInt32(cmbFieldSelector.SelectedValue) select f).FirstOrDefault();
                if (mapping != null)
                {
                    if (!string.IsNullOrEmpty(mapping.MappedFieldName) && mapping.MappedFieldName != _fieldnameToMap)
                    {
                        _fieldMappings.Add(new FieldMapping() {MappedFieldName = _fieldnameToMap});
                    }
                    mapping.MappedFieldName = _fieldnameToMap;
                }
                Close();
            }
        }
    }
}
