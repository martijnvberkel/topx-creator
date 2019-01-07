using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topx.UnitTests
{
    public class Statics
    {
        public static string AppPath()
        {
            var appPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (appPath != null && (appPath.FullName.Contains(@"\bin\")
                                       || appPath.FullName.EndsWith(@"\bin", StringComparison.CurrentCultureIgnoreCase)))
            {
                appPath = appPath.Parent;
            }
            return appPath.FullName;
        }

        public static List<string> MockHeaders = new List<string>()
        {
            "IdentificatieKenmerk",
            "Naam",
            "Classificatie_Code",
            "Classificatie_Omschrijving",
            "Classificatie_Bron",
            "Classificatie_DatumOfPeriode",
            "Dekking_InTijd_Begin",
            "Dekking_InTijd_Eind",
            "Dekking_GeografischGebied",
            "Taal",
            "Eventgeschiedenis_DatumOfPeriode",
            "Eventgeschiedenis_Type",
            "Eventgeschiedenis_VerantwoordelijkeFunctionaris",
            "Eventplan_DatumOfPeriode",
            "Eventplan_DatumOfPeriode_Type",
            "Eventplan_Aanleiding",
            "Eventplan_Beschrijving",
            "Relatie_Id",
            "Relatie_Type",
            "Relatie_DatumOfPeriode",
            "Context_Actor_IdentificatieKenmerk",
            "Context_Actor_AggregatieNiveau",
            "Context_Actor_GeautoriseerdeNaam",
            "Context_Activiteit_Naam",
            "Gebruiksrechten_OmschrijvingVoorwaarden",
            "Gebruiksrechten_DatumOfPeriode",
            "Vertrouwelijkheid_ClassificatieNiveau",
            "Vertrouwelijkheid_DatumOfPeriode",
            "Openbaarheid_OmschrijvingBeperkingen",
            "Openbaarheid_DatumOfPeriode",
            "Integriteit"
        };

        public static List<string> MockHeadersRecords = new List<string>()
        {
            "Naam",
            "Taal",
            "Gebruiksrechten_OmschrijvingVoorwaarden",
            "Gebruiksrechten_DatumOfPeriode",
            "Vertrouwelijkheid_ClassificatieNiveau",
            "Vertrouwelijkheid_DatumOfPeriode",
            "Openbaarheid_OmschrijvingBeperkingen",
            "Bestand_Vorm_Redactiegenre",
            "Bestand_Formaat_Bestandsnaam",
            "Bestand_Formaat_BestandsOmvang",
            "Bestand_Formaat_BestandsFormaat",
            "Bestand_Formaat_FysiekeIntegriteit_Algoritme",
            "Bestand_Formaat_FysiekeIntegriteit_Waarde"
        };

        public static List<string> MockHeadersBestanden = new List<string>()
        {
            "Dossier_IdentificatieKenmerk",
            "Naam",
            "Relatie_RelatieId",
            "Relatie_TypeRelatie",
            "Relatie_DatumOfPperiode",
            "Vorm_RedactieGenre",
            "Formaat_IdentificatieKenmerk",
            "Formaat_Bestandsnaam_Naam",
            "Formaat_Bestandsnaam_Extentie",
            "Formaat_Omvang",
            "Formaat_Bestandsformaat",
            "Formaat_FysiekeIntegriteit_Algoritme",
            "Formaat_FysiekeIntegriteit_Waarde",
            "Formaat_FysiekeIntegriteit_DatumEnTijd",
            "Formaat_DatumAanmaak",
        };
    }
}
