﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;
using Topx.DataServices;

namespace Topx.ComplexLinks
{
    public class ComplexLinkProcessor
    {
        private readonly IDataService _dataservice;
        public bool Error;
        public StringBuilder ErrorMessages = new StringBuilder();

        public ComplexLinkProcessor(IDataService dataservice)
        {
            _dataservice = dataservice;
        }

        public void Process()
        {
            var dossiers = _dataservice.GetAllDossiers();
            
            foreach (var complexLink in _dataservice.GetComplexLinksWithMoreThanOneOccurence())
            {
                var dossiersWithSameComplexLinknr = (from a in dossiers where a.ComplexLinks.Any(t => t.ComplexLinkNummer == complexLink) select a) .ToList();

                // Er mag maar maximaal 1 dossier records bevatten
                var dossierWithRecords = (from a in dossiersWithSameComplexLinknr where a.Records != null && a.Records.Any() select a) .ToList();
                if (dossierWithRecords.Count() > 1)
                    HandleErrorMultipleRecords(dossierWithRecords, complexLink);

                // Er moet 1 dossier zijn met records
                if (!dossierWithRecords.Any())
                    HandleErrorNoRecords(dossiersWithSameComplexLinknr, complexLink);

                else  // Clean: 1 dossier met records
                {
                    var recordsToCopy = dossierWithRecords.FirstOrDefault()?.Records;
                    var dossiersWithoutRecords = (from a in dossiersWithSameComplexLinknr where a.Records != null select a).ToList();
                    foreach (var dossierWithoutRecords in dossiersWithoutRecords)
                    {
                        _dataservice.AttachRecordsToDossier(dossierWithoutRecords, recordsToCopy);
                    }
                }

            }
            if (ErrorMessages.Length > 0)
                Error = true;
        }

        private void HandleErrorNoRecords(List<Dossier> dossiersWithSameComplexLinknr, string complexLink)
        {
            ErrorMessages.AppendLine(
                $"Complexlinknummer {complexLink} is gekoppeld aan meerdere dossiers die geen van allen records bevatten: { DossiersAsString(dossiersWithSameComplexLinknr) }. Er moet één dossier zijn met records.");
        }

        private void HandleErrorMultipleRecords(IEnumerable<Dossier> dossierWithRecords, string complexLink)
        {
            ErrorMessages.AppendLine(
                $"Complexlinknummer {complexLink} is gekoppeld aan meerdere dossiers die ook records bevatten: { DossiersAsString(dossierWithRecords) }. Er mag maar één dossier zijn met records.");
        }

        private string DossiersAsString(IEnumerable<Dossier> dossierWithRecords)
        {
            var dossiersText = string.Empty;
            foreach (var dossierWithRecord in dossierWithRecords)
            {
                dossiersText += dossierWithRecord.IdentificatieKenmerk + ", ";
            }
            if (dossiersText.EndsWith(", "))
                dossiersText = dossiersText.Substring(0, dossiersText.Length - 2);
            return dossiersText;
        }
    }
}
