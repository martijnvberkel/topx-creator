﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Topx.Data;
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
            if (!ValidateHelper.TestForValidDate(_dossier.Dekking_InTijd_Begin))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Dekking_InTijd_Begin is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Dekking_InTijd_Eind))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Dekking_InTijd_Eind is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Classificatie_DatumOfPeriode))
                if (string.IsNullOrEmpty(_dossier.Classificatie_DatumOfPeriode) || !ValidateHelper.TestForValidYear(_dossier.Classificatie_DatumOfPeriode))
                    ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Classificatie_DatumOfPeriode is niet herkend als geldig jaar (verwacht format: yyyy) of als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Eventgeschiedenis_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Eventgeschiedenis_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Openbaarheid_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Openbaarheid_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Gebruiksrechten_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Gebruiksrechten_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (!ValidateHelper.TestForValidDate(_dossier.Vertrouwelijkheid_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Vertrouwelijkheid_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            // if (!TestForValidDate(_dossier.Relatie_DatumOfPeriode))
            //     ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.Relatie_DatumOfPeriode}: Relatie_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {DateParsing}");

           

            if (!string.IsNullOrEmpty(_dossier.Eventplan_DatumOfPeriode) && !ValidateHelper.TestForValidDate(_dossier.Eventplan_DatumOfPeriode))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: Eventplan_DatumOfPeriode is niet herkend als geldige datum (verwacht format: {ValidateHelper.DateParsing})");

            if (string.IsNullOrEmpty(_dossier.Eventgeschiedenis_Type))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Eventgeschiedenis_Type is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Vertrouwelijkheid_ClassificatieNiveau))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Vertrouwelijkheid_ClassificatieNiveau is leeg of afwezig");

            if (string.IsNullOrEmpty(_dossier.Openbaarheid_OmschrijvingBeperkingen))
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld Openbaarheid_OmschrijvingBeperkingen is leeg of afwezig");

            
            if (string.IsNullOrEmpty(_dossier.Taal) || !Enum.TryParse(_dossier.Taal.ToLower(), true, out taalType taaltype))
            {
                ValidationErrors.Add($"ERROR validatie: Dossier {_dossier.IdentificatieKenmerk}: verplicht veld TaalType is leeg of wordt niet herkend");
            }

            return !ValidationErrors.Any();
        }
    }
}
