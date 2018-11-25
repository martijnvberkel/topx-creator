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
using Topx.DataServices;
using Topx.Interface;

namespace Topx.Importer
{
    public class Importer
    {
        private readonly IDataService _dataservice;
        public string ErrorMessage;
        public StringBuilder ErrorsImportDossiers = new StringBuilder();
        public StringBuilder ErrorsImportRecords = new StringBuilder();
        public bool Error;

        public Importer(IDataService globalsService)
        {
            _dataservice = globalsService;

        }

        public void SaveDossiers(List<FieldMapping> mappingsDossiers, StreamReader dossierStream)
        {
            var readLineAsHeader = dossierStream.ReadLine();
            if (readLineAsHeader == null)
            {
                Error = true;
                ErrorMessage = "File is leeg";
                return;
            };
            var headersSource = readLineAsHeader.Split(';');

            while (dossierStream.Peek() > 0)
            {
                var dossier = new Dossier();
                var fieldsSource = dossierStream.ReadLine()?.Split(';');

                try
                {

                    if (fieldsSource == null)
                    {
                        Error = true;
                        ErrorMessage = "Unexpected end of stream";
                        return;
                    }
                    if (string.IsNullOrEmpty(fieldsSource[0])) continue;  // skip rows without id

                    for (var index = 0; index <= headersSource.Length - 1; index++)
                    {
                        var mappedfield = (from f in mappingsDossiers where f.MappedFieldName == headersSource[index] select f.DatabaseFieldName).FirstOrDefault();
                        if (mappedfield == null)
                            continue;
                        var propertyInfo = dossier.GetType().GetProperty(mappedfield);

                        if (propertyInfo != null)
                            propertyInfo.SetValue(dossier, fieldsSource[index], null);
                    }
                    _dataservice.SaveDossier(dossier);
                }
                catch (Exception e)
                {
                    ErrorsImportDossiers.AppendLine($"Dossier {fieldsSource?[0]} kon niet worden geïmporteerd: {e.Message}");
                    Error = true;
                }
            }
        }
        public void SaveRecords(List<FieldMapping> mappingsRecords, StreamReader recordsStream)
        {
            var readLineAsHeader = recordsStream.ReadLine();
            if (readLineAsHeader == null)
            {
                Error = true;
                ErrorMessage = "File is leeg";
                return;
            };
            var headersSource = readLineAsHeader.Split(';');

            while (recordsStream.Peek() > 0)
            {
                var record = new Record();
                var fieldsSource = recordsStream.ReadLine()?.Split(';');
                try
                {

                    if (fieldsSource == null)
                    {
                        Error = true;
                        ErrorMessage = "Unexpected end of stream";
                        return;
                    }
                    if (string.IsNullOrEmpty(fieldsSource[0])) continue;  // skip rows without id

                    for (var index = 0; index <= headersSource.Length - 1; index++)
                    {
                        var mappedfield = (from f in mappingsRecords where f.MappedFieldName == headersSource[index] select f.DatabaseFieldName).FirstOrDefault();
                        if (mappedfield == null)
                            continue;
                        var propertyInfo = record.GetType().GetProperty(mappedfield);

                        if (propertyInfo != null)
                        {
                            if (propertyInfo.PropertyType == typeof(string))
                                propertyInfo.SetValue(record, fieldsSource[index], null);
                            if (propertyInfo.PropertyType == typeof(Int64))
                                propertyInfo.SetValue(record, Convert.ToInt64(fieldsSource[index]), null);

                        }
                    }
                    _dataservice.SaveRecord(record);
                }
                catch (Exception e)
                {
                    ErrorsImportRecords.AppendLine($"Record {fieldsSource?[0]} kon niet worden geïmporteerd: {e.Message}");
                    Error = true;
                }
            }
        }
    }
}
