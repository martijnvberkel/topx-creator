using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Topx.Importer
{
    public class GenericImport
    {
        public List<string> Errror = new List<string>();

        public void ImportFile(string csvFilePath, string tableName)
        {
            using (var streamreader = new StreamReader(csvFilePath, Encoding.Default))
            {
                streamreader.ReadLine(); // 
                using (SqlConnection c = new SqlConnection("data source=.;initial catalog=TOPX;integrated security=True;multipleactiveresultsets=True"))
                {
                    c.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + tableName, c))
                    {
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        var datatable = new DataTable();
                        adapter.Fill(datatable);

                        InsertIntoTable(datatable, streamreader, adapter);
                        
                    }
                }
            }
        }

        private void InsertIntoTable(DataTable datatable, StreamReader streamreader, SqlDataAdapter adapter)
        {
            while (!streamreader.EndOfStream)
            {

                var line = streamreader.ReadLine();
                var record = line.Split(";"[0]);

                var row = datatable.NewRow();
                for (var column = 0; column <= record.Length - 1; column++)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(record[column]))
                            continue;
                        row[column] = record[column];
                    }
                    catch (Exception e)
                    {
                        Errror.Add($"ERROR ID {row[0]}: {e.Message}");
                    }
                    }
                datatable.Rows.Add(row);
                adapter.Update(datatable);
            }

        }
    }
}

