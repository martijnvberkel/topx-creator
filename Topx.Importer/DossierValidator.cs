using System;
using System.Collections.Generic;
using System.Linq;
using Topx.Data;
using Topx.Utility;
using static Topx.Data.DTO.TopX;

namespace Topx.Importer
{
    public class DossierValidator
    {
        private readonly Dossier _dossier;


        public List<string> ValidationErrors = new List<string>();

        public DossierValidator(Dossier dossier)
        {
            _dossier = dossier;
        }

        public bool Validate()
        {
            ValidationErrors.Clear();
            if (!Validations.TestForValidDate(_dossier.Dekking_InTijd_Begin))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Dekking_InTijd_Begin is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (!Validations.TestForValidDate(_dossier.Dekking_InTijd_Eind))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Dekking_InTijd_Eind is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (!Validations.TestForValidDate(_dossier.Classificatie_DatumOfPeriode))
                if (string.IsNullOrEmpty(_dossier.Classificatie_DatumOfPeriode) || !Validations.TestForValidYear(_dossier.Classificatie_DatumOfPeriode))
                    ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Classificatie_DatumOfPeriode is niet herkend als geldig jaar (verwacht format: yyyy) of als geldige datum (verwacht format: {Validations.DateParsing})");

            if (!_dossier.Eventgeschiedenis_DatumOfPeriode.Contains("|"))
                if (!Validations.TestForValidDate(_dossier.Eventgeschiedenis_DatumOfPeriode))
                    ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Eventgeschiedenis_DatumOfPeriode {_dossier.Eventgeschiedenis_DatumOfPeriode} is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (_dossier.Openbaarheid_OmschrijvingBeperkingen.Contains(","))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Veld Openbaarheid_OmschrijvingBeperkingen bevat een komma, dit is niet toegestaan. Voor het opsplitsen van meerdere velden kan alleen een pipe-karakter | worden gebruikt.");

            if (_dossier.Openbaarheid_DatumOfPeriode.Contains(","))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Veld Openbaarheid_DatumOfPeriode bevat een komma, dit is niet toegestaan. Voor het opsplitsen van meerdere velden kan alleen een pipe-karakter | worden gebruikt.");

            if (!TestMultipleDates(_dossier.Openbaarheid_OmschrijvingBeperkingen, _dossier.Openbaarheid_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: De combinatie van Openbaarheid_OmschrijvingBeperkingen en Openbaarheid_DatumOfPeriode is niet valide. (verwacht format: {Validations.DateParsing}) De waardes zijn: {_dossier.Openbaarheid_OmschrijvingBeperkingen}, {_dossier.Openbaarheid_DatumOfPeriode}");

            if (!Validations.TestForValidDate(_dossier.Gebruiksrechten_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Gebruiksrechten_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (!TestMultipleDates(_dossier.Vertrouwelijkheid_ClassificatieNiveau, _dossier.Vertrouwelijkheid_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: De combinatie van Vertrouwelijkheid_ClassificatieNiveau en Vertrouwelijkheid_DatumOfPeriode is niet valide. (verwacht format: {Validations.DateParsing}) De waardes zijn: {_dossier.Vertrouwelijkheid_ClassificatieNiveau}, {_dossier.Vertrouwelijkheid_DatumOfPeriode}");

            if (!string.IsNullOrEmpty(_dossier.Eventplan_DatumOfPeriode) && !Validations.TestForValidDate(_dossier.Eventplan_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Eventplan_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {Validations.DateParsing})");

            if (string.IsNullOrEmpty(_dossier.Eventgeschiedenis_Type))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Eventgeschiedenis_Type is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Vertrouwelijkheid_ClassificatieNiveau))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Vertrouwelijkheid_ClassificatieNiveau is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Openbaarheid_OmschrijvingBeperkingen))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Openbaarheid_OmschrijvingBeperkingen is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Eventgeschiedenis_VerantwoordelijkeFunctionaris))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Eventgeschiedenis_VerantwoordelijkeFunctionaris is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Context_Actor_IdentificatieKenmerk))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Context_Actor_IdentificatieKenmerk is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Context_Activiteit_Naam))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Context_Activiteit_Naam is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Context_Actor_AggregatieNiveau))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Context_Actor_AggregatieNiveau is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Context_Actor_GeautoriseerdeNaam))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Context_Actor_GeautoriseerdeNaam is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Taal) || !Enum.TryParse(_dossier.Taal.ToLower(), true, out taalType taaltype))
            {
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld TaalType is leeg of wordt niet herkend");
            }

            if (string.IsNullOrEmpty(_dossier.Classificatie_Code))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Classificatie_Code is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Classificatie_Omschrijving))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Classificatie_Omschrijving is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Classificatie_Bron))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Classificatie_Bron is leeg of afwezig");

            return !ValidationErrors.Any();
        }

        private bool TestMultipleDates(string comments, string dates)
        {
            // valid is bijvoorbeeld
            // comments = 'Geheim, Openbaar'
            // dates = '1-1-2010, 20-12-2015'
            if (string.IsNullOrEmpty(comments) || string.IsNullOrEmpty(dates))
                return false;
            var arrComments = comments.Split('|');
            var arrDates = dates.RemoveSpaces().Split('|');

            // Check of de arrays gelijk zijn
            if (arrComments.Length != arrDates.Length)
                return false;

            // check alle data of ze valide zijn
            if (arrDates.Any(date => !Validations.TestForValidDate(date)))
                return false;

            return true;

        }
    }
}
