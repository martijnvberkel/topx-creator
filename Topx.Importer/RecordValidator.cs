using System.Collections.Generic;
using System.Linq;
using Topx.Data;
using Topx.Utility;

namespace Topx.Importer
{
    public class RecordValidator
    {
        private readonly Record _record;
        public List<string> ValidationErrors = new List<string>();

        public RecordValidator(Record record)
        {
            _record = record;
        }

        public bool ValidateIgnoringOptionalFields()
        {
            var errorPrefix = $"ERROR Validatie: Record met DossierId {_record.DossierId}:";

            if (string.IsNullOrEmpty(_record.Bestand_Formaat_Bestandsnaam))
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam is leeg, dit veld is verplicht.");

            var illegalChars = Validations.GetIllegalCharsInFileName(_record.Bestand_Formaat_Bestandsnaam);
            if (illegalChars != string.Empty)
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam  {_record.Bestand_Formaat_Bestandsnaam} bevat ongeldige karakters: {illegalChars}");

            if (!Validations.TestForFileExtension(_record.Bestand_Formaat_Bestandsnaam))
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam bevat geen extensie (bijv .pdf of .docx): {_record.Bestand_Formaat_Bestandsnaam}");

            if (string.IsNullOrEmpty(_record.DossierId))
                ValidationErrors.Add($"{errorPrefix} DossierId is leeg, dit veld is verplicht.");

            if (string.IsNullOrEmpty(_record.Naam))
                ValidationErrors.Add($"{errorPrefix} Naam is leeg, dit veld is verplicht.");

            if (string.IsNullOrEmpty(_record.Bestand_Vorm_Redactiegenre))
                ValidationErrors.Add($"{errorPrefix} Bestand_Vorm_Redactiegenre is leeg, dit veld is verplicht.");
            return !ValidationErrors.Any();
        }
        
        public bool Validate()
        {
            var errorPrefix = $"ERROR Validatie: Record met DossierId {_record.DossierId}:";

            if (string.IsNullOrEmpty(_record.Bestand_Formaat_Bestandsnaam))
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam is leeg, dit veld is verplicht.");

            var illegalChars = Validations.GetIllegalCharsInFileName(_record.Bestand_Formaat_Bestandsnaam);
            if (illegalChars != string.Empty)
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam  {_record.Bestand_Formaat_Bestandsnaam} bevat ongeldige karakters: {illegalChars}");

            if (!Validations.TestForFileExtension(_record.Bestand_Formaat_Bestandsnaam))
                ValidationErrors.Add($"{errorPrefix} Bestand_Formaat_Bestandsnaam bevat geen extensie (bijv .pdf of .docx): {_record.Bestand_Formaat_Bestandsnaam}");

            if (string.IsNullOrEmpty(_record.DossierId))
                ValidationErrors.Add($"{errorPrefix} DossierId is leeg, dit veld is verplicht.");

            if (string.IsNullOrEmpty(_record.Naam))
                ValidationErrors.Add($"{errorPrefix} Naam is leeg, dit veld is verplicht.");

            if (string.IsNullOrEmpty(_record.Gebruiksrechten_OmschrijvingVoorwaarden))
                ValidationErrors.Add($"{errorPrefix} Gebruiksrechten_OmschrijvingVoorwaarden is leeg, dit veld is verplicht.");

            if (!Validations.TestForValidDate(_record.Gebruiksrechten_DatumOfPeriode))
                ValidationErrors.Add($"{errorPrefix} Gebruiksrechten_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (!Validations.TestForValidDate(_record.Vertrouwelijkheid_DatumOfPeriode))
                ValidationErrors.Add($"{errorPrefix} Vertrouwelijkheid_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (string.IsNullOrEmpty(_record.Vertrouwelijkheid_ClassificatieNiveau))
                ValidationErrors.Add($"{errorPrefix} Vertrouwelijkheid_ClassificatieNiveau is leeg, dit veld is verplicht.");

            if (string.IsNullOrEmpty(_record.Openbaarheid_OmschrijvingBeperkingen))
                ValidationErrors.Add($"{errorPrefix} Openbaarheid_OmschrijvingBeperkingen is leeg, dit veld is verplicht.");

            if (!Validations.TestForValidDate(_record.Openbaarheid_DatumOfPeriode))
                ValidationErrors.Add($"{errorPrefix} Openbaarheid_DatumOfPeriode waarde: {_record.Openbaarheid_DatumOfPeriode} is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (string.IsNullOrEmpty(_record.Bestand_Vorm_Redactiegenre))
                ValidationErrors.Add($"{errorPrefix} Bestand_Vorm_Redactiegenre is leeg, dit veld is verplicht.");
            return !ValidationErrors.Any();
        }
    }
}
