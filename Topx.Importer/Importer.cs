﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Topx.Data;
using Topx.DataServices;

namespace Topx.Importer
{
    public class Importer
    {
        private readonly IDataService _dataservice;
        private readonly bool _enableValidation;
        public string ErrorMessage;
        public StringBuilder ErrorsImportDossiers = new StringBuilder();
        public StringBuilder ErrorsImportRecords = new StringBuilder();
        public bool ComplexLinksFound;

        public int NrOfDossiers = 0;
        public int NrOfRecords = 0;
        private readonly string[] _fieldsThatMaybeEmpty =
        {
            "Bestand_Formaat_BestandsOmvang",
            "Bestand_Formaat_BestandsFormaat",
            "Bestand_Formaat_FysiekeIntegriteit_Algoritme",
            "Bestand_Formaat_FysiekeIntegriteit_Waarde",
            "Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd",
            "Bestand_Formaat_IdentificatieKenmerk",
            "ComplexlinkNummer (optioneel)"
        };

        public bool Error => ErrorsImportDossiers.Length > 0 || ErrorsImportRecords.Length > 0 || !string.IsNullOrEmpty(ErrorMessage);

        public Importer(IDataService globalsService, bool enableValidation = true)
        {
            _dataservice = globalsService;
            _enableValidation = enableValidation;
        }

        public void SaveDossiers(List<FieldMapping> mappingsDossiers, StreamReader dossierStream)
        {
            var readLineAsHeader = dossierStream.ReadLine();
            if (readLineAsHeader == null)
            {
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
                        ErrorMessage = "Unexpected end of stream";
                        return;
                    }
                    if (string.IsNullOrEmpty(fieldsSource[0]))
                        continue;  // skip rows without id

                    if (headersSource.Length != fieldsSource.Length)
                    {
                        ErrorsImportDossiers.AppendLine($"ERROR: Dossier {fieldsSource?[0]} kon niet worden ingelezen, aantal kolommen is onjuist. Dit kan ontstaan door gebruik van puntkomma's of 'new lines' in tekstvelden. Controleer de file in bijv Notepad++ voor diagnose");
                        continue;
                    }

                    ComplexLink complexLink = null;
                    for (var index = 0; index <= headersSource.Length - 1; index++)
                    {
                        var mappedfield = (from f in mappingsDossiers where f.MappedFieldName == headersSource[index] select f.DatabaseFieldName).FirstOrDefault();
                        if (mappedfield == null)
                            continue;

                        if (mappedfield.StartsWith("ComplexlinkNummer"))
                            complexLink = new ComplexLink() { ComplexLinkNummer = fieldsSource[index] };

                        var propertyInfo = dossier.GetType().GetProperty(mappedfield);

                        if (propertyInfo != null)
                            propertyInfo.SetValue(dossier, fieldsSource[index], null);
                    }

                    var dossierValidator = new DossierValidator(dossier);
                    var isValidated = _enableValidation ? dossierValidator.Validate() : dossierValidator.ValidateIgnoringOptionalFields();
                    if (isValidated)
                    {
                        if (complexLink != null)
                        {
                            ComplexLinksFound = true;
                            dossier.ComplexLinks.Add(complexLink);
                        }

                        if (!_dataservice.SaveDossier(dossier))
                        {
                            ErrorsImportDossiers.AppendLine(_dataservice.ErrorMessage);
                        }
                        NrOfDossiers++;
                    }
                    else
                    {
                        foreach (var validatorValidationError in dossierValidator.ValidationErrors)
                        {
                            ErrorsImportDossiers.AppendLine(validatorValidationError);
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorsImportDossiers.AppendLine($"Dossier {fieldsSource?[0]} kon niet worden geïmporteerd: Message: {e.Message} InnerException: {e.InnerException}");
                }
            }
        }
        public void SaveRecords(List<FieldMapping> mappingsRecords, StreamReader recordsStream)
        {
            var readLineAsHeader = recordsStream.ReadLine();
            if (readLineAsHeader == null)
            {
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
                    if (headersSource.Length != fieldsSource.Length)
                    {
                        ErrorsImportRecords.AppendLine($"ERROR: Records {fieldsSource?[0]} kon niet worden ingelezen, aantal kolommen is onjuist. Dit kan ontstaan door gebruik van puntkomma's in tekstvelden.");
                        continue;
                    }

                    if (fieldsSource == null)
                    {
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

                        if (propertyInfo != null && !string.IsNullOrEmpty(fieldsSource[index]))
                        {
                            if (propertyInfo.PropertyType == typeof(string))
                                propertyInfo.SetValue(record, fieldsSource[index], null);
                            if (propertyInfo.PropertyType == typeof(Int64?))
                                propertyInfo.SetValue(record, Convert.ToInt64(fieldsSource[index].Replace(".", string.Empty)), null);

                            if (propertyInfo.PropertyType == typeof(DateTime?))
                                propertyInfo.SetValue(record, Convert.ToDateTime(fieldsSource[index]), null);

                        }
                    }
                    var recordvalidator = new RecordValidator(record);

                    var isValidated = _enableValidation ? recordvalidator.Validate() : recordvalidator.ValidateIgnoringOptionalFields();
                    if (isValidated)
                    {
                        if (!_dataservice.SaveAddedRecord(record))
                            ErrorsImportRecords.AppendLine(_dataservice.ErrorMessage);
                        else
                            NrOfRecords++;
                    }
                    else
                    {
                        foreach (var validatorValidationError in recordvalidator.ValidationErrors)
                        {
                            ErrorsImportRecords.AppendLine(validatorValidationError);
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorsImportRecords.AppendLine($"Record {fieldsSource?[0]} kon niet worden geïmporteerd: {e.Message}");
                }
            }
        }

        public bool CheckHealthyFieldmappings(List<FieldMapping> fieldmappings)
        {
            foreach (var fieldmapping in fieldmappings.Where(t => t.DatabaseFieldName != null && !t.DatabaseFieldName.StartsWith("ComplexLink", true, CultureInfo.InvariantCulture) && t.DatabaseFieldName != "Omschrijving"))
            {
                if (!string.IsNullOrEmpty(fieldmapping.DatabaseFieldName) && string.IsNullOrEmpty(fieldmapping.MappedFieldName) && !_fieldsThatMaybeEmpty.Contains(fieldmapping.DatabaseFieldName) && !fieldmapping.Optional)
                    return false;
            }
            return true;
        }
    }
}
