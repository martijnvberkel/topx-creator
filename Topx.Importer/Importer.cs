using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Topx.Data;
using Topx.Interface;

namespace Topx.Importer
{
    public class Importer
    {
        private readonly ModelTopX _entities;
        public string ErrorMessage;
        public bool Error;

        public Importer(ModelTopX entities)
        {
            _entities = entities;
        }

        public void ImportDossiers(List<FieldMapping> mappings, List<string> headersDossiers, StreamReader dossierStream, Headers.MappingType mappingType)
        {
            var result = GetDataTable(mappings, dossierStream, mappingType);
        }

        //public void ImportDossiers(List<FieldMapping> mappings, List<string> headersDossiers, StreamReader dossierStream)
        //{
        //    var mappingsDossiers = mappings.Where(t => t.Type == Headers.MappingType.DOSSIER.ToString()) .ToList();
        //    var result = GetDataTable(mappingsDossiers, dossierStream, Headers.MappingType.DOSSIER);

        //}

        //public void ImportRecords(List<FieldMapping> mappings, List<string> headersRecords, StreamReader dossierStream)
        //{
        //    var mappingsDossiers = mappings.Where(t => t.Type == Headers.MappingType.RECORD.ToString()).ToList();
        //    var result = GetDataTable(mappingsDossiers, dossierStream, Headers.MappingType.RECORD);

        //}

        private DataTable GetDataTable(List<FieldMapping> mappingsDossiers, StreamReader dossierStream, Headers.MappingType mappingType)
        {
            var topxDataTable = new TopXDataTable(';');
            using (var dataConnection = new SqlConnection(_entities.Database.Connection.ConnectionString))
            {
                dataConnection.Open();
                var sqldataadapter = new SqlDataAdapter();

                var query = mappingType == Headers.MappingType.DOSSIER ? "select * from Dossiers" : "select * from Records";

                var sqlCommand = new SqlCommand(query, dataConnection);

                var objCommandBuilder = new SqlCommandBuilder(sqldataadapter);
                var table = new DataTable();
                sqldataadapter.SelectCommand = sqlCommand;
                sqldataadapter.FillSchema(table, SchemaType.Source);
                sqldataadapter.Fill(table);
               
                topxDataTable.LoadFromStream(mappingsDossiers, dossierStream, table);
                if (topxDataTable.ErrorList.Length > 0)
                {
                    ErrorMessage = topxDataTable.ErrorList.ToString();
                    Error = true;
                }

                sqldataadapter.Update(table);
                return table;
            }
        }
    }
}
