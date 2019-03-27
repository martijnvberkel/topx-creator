using System;
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
            var dossiersWithNoRecords = (from a in dossiers where a.Records == null || a.Records.Count == 0 select a).ToList();
            var complexLinks_records = new Dictionary<string, List<Record>>();
            foreach (var dossier in dossiersWithNoRecords)
            {
                // Clean check

                if (dossier.ComplexLinks == null || !dossier.ComplexLinks.Any())
                {
                    HandleErrorNoRecordNoComplexLink(dossier);
                    continue;
                }

                if (dossier.ComplexLinks.Count > 1)
                {
                    HandleMoreThanOneComplexlinkToOneDossier(dossier);
                    continue;
                }

                var complexLink = dossier.ComplexLinks.FirstOrDefault().ComplexLinkNummer;
                var dossiersWithComplexLinks = _dataservice.GetDossiersByComplexLink(complexLink);

                // Uitval wanneer meerdere dossiers met hetzelfde complexlinknummer records hebben (er mag maar 1 dossier records bevatten)
                var dossiersWithComplexLinksWithRecords = dossiersWithComplexLinks.Where(t => t.Records.Any()) .ToList();
                if (dossiersWithComplexLinksWithRecords.Count(t => t.Records != null) > 1)
                {
                    HandleErrorMultipleDossiersWithRecordsWithSameComplexLink(dossiersWithComplexLinksWithRecords);
                    continue;
                }
                if (!complexLinks_records.ContainsKey(complexLink))
                    complexLinks_records.Add(complexLink, dossiersWithComplexLinksWithRecords.FirstOrDefault()?.Records.ToList());

            }
            // complexLinks_records collectie bevat nu alle complexlinknummers en bijhorende list<records>

            foreach (var complexLinksRecord in complexLinks_records)
            {
                var dossiersbyComplexlink = _dataservice.GetDossiersByComplexLink(complexLinksRecord.Key);
                foreach (var dossier in dossiersbyComplexlink)
                {
                    if (dossier.Records.Any())
                        continue;  // Skip het ene dossier wat al is voorzien van de recordset

                    _dataservice.AttachRecordsToDossier(dossier, complexLinksRecord.Value);
                }
            }
            
            if (ErrorMessages.Length > 0)
                Error = true;
        }

        private void HandleErrorMultipleDossiersWithRecordsWithSameComplexLink(List<Dossier> dossiers)
        {
            ErrorMessages.AppendLine($"Er zijn meerdere dossiers gevonden bij een complexLinkNummer met records. Er mag maar één dossier records bevatten. Het betreft dossiers {DossiersAsString(dossiers)}");
        }

        private void HandleMoreThanOneComplexlinkToOneDossier(Dossier dossier)
        {
            ErrorMessages.AppendLine($"Dossier {dossier.IdentificatieKenmerk} heeft meer dan één complexlinknummer gekoppeld: {ComplexlinkNummersAsString(dossier.ComplexLinks)}");
        }

        private void HandleErrorNoRecordNoComplexLink(Dossier dossier)
        {
            ErrorMessages.AppendLine($"Dossier {dossier.IdentificatieKenmerk} heeft geen records en geen complexlinknummer. Deze kan niet worden verwerkt.");
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

        private string ComplexlinkNummersAsString(IEnumerable<ComplexLink> complexLinks)
        {
            var text = string.Empty;
            foreach (var complexlink in complexLinks)
            {
                text += complexlink.ComplexLinkNummer + ", ";
            }
            if (text.EndsWith(", "))
                text = text.Substring(0, text.Length - 2);
            return text;
        }
    }
}
