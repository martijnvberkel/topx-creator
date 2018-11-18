using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public Importer()
        {
            //_entities = entities;
        }
       

        public void ImportDossiers(List<FieldMapping> mappings, StreamReader dossierStream, Headers.MappingType mappingType)
        {
            var result = GetDataTable_old(mappings, dossierStream, mappingType);
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

        private DataTable GetDataTable_old(List<FieldMapping> mappingsDossiers, StreamReader dossierStream, Headers.MappingType mappingType)
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

        public List<Dossier> GetDossiers(List<FieldMapping> mappingsDossiers, StreamReader dossierStream, Headers.MappingType mappingType)
        {
            var readLineAsHeader = dossierStream.ReadLine();
            if (readLineAsHeader == null) return null;
            var headersSource = readLineAsHeader.Split(';');

            var dossiers = new List<Dossier>();
            while (dossierStream.Peek() > 0)
            {
                var dossier = new Dossier();
                var fieldsSource = dossierStream.ReadLine()?.Split(';');
                if (fieldsSource == null)
                {
                    Error = true;
                    ErrorMessage = "Unexpected end of stream";
                }
                for (var index = 0; index <= headersSource.Length - 1; index++)
                {
                    var mappedfield = (from f in mappingsDossiers where f.MappedFieldName == headersSource[index] select f.DatabaseFieldName).FirstOrDefault();
                    if (mappedfield == null)
                        continue;
                    var propertyInfo = dossier.GetType().GetProperty(mappedfield);
                    
                    if (propertyInfo != null)
                        propertyInfo.SetValue(dossier, fieldsSource[index], null);
                }
                dossiers.Add(dossier);
            }
            return dossiers;
        }
    }
}
