using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.Importer
{
    public class TopXDataTable
    {
        private readonly char _delimiter;
        public StringBuilder ErrorList = new StringBuilder();

        public TopXDataTable(char delimiter)
        {
            _delimiter = delimiter;

        }
      
        public DataTable LoadFromStream(List<FieldMapping> fieldmapping, StreamReader stream, DataTable table)
        {
            var headersSource = stream.ReadLine().Split(_delimiter);


            while (stream.Peek() > 0)
            {
                var fieldsSource = stream.ReadLine().Split(_delimiter);
                var row = table.NewRow();
                for (var index = 0; index <= fieldsSource.Length - 1; index++)
                {
                    var headerTarget = fieldmapping.FirstOrDefault(t => t.MappedFieldName == headersSource[index])?.DatabaseFieldName;
                    if (headerTarget != null)
                    {
                        if (ValidateField(table, headerTarget,  fieldsSource[0], fieldsSource[index]))
                        row[headerTarget] = fieldsSource[index];
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private bool ValidateField(DataTable table, string headerTarget, string identifier, object value)
        {
            // check length
            var col = table.Columns[headerTarget];
            if (col.DataType == typeof(string))
            {
                if (value.ToString().Length > col.MaxLength)
                {
                    ErrorList.AppendLine($"String in record {identifier} in kolom {col.ColumnName} is te groot");
                    return false;
                }
            }
            return true;
        }
    }
}
