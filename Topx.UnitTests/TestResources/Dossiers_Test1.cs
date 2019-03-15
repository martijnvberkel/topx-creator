using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.UnitTests.TestResources
{
    public class Dossiers_Test1
    {
        private const long mb = 1024 * 1024; 
        public static List<Dossier> GetDossiers()
        {
            
            var record1 = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning Hoofdstraat 13 5121JA Rijen 17-05-1905",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "17-05-1905",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "17-05-1905",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B0.pdf",
                Bestand_Formaat_BestandsOmvang = 30 * mb,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "6024baa32d6a7f8ef10239d43c9dfd8b25a64b1fc8c9d34da7523ec5dbed9ac6",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("30-7-2015 12:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("20-8-2012"),
                Openbaarheid_DatumOfPeriode = "17-05-1905",
                DossierId = "NL-0000-10000-1"
            };

            var record2 = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning test_2",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "20-09-1905",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "16-05-1905",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B1.pdf",
                Bestand_Formaat_BestandsOmvang = 20 * mb,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "6024baa32d6a7f8ef10239d43c9dfd8bda7523ec5dbed9ac625a64b1fc8c9d34",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("31-8-2014 12:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("16-1-2010"),
                Openbaarheid_DatumOfPeriode = "01-07-1909",
                DossierId = "NL-0000-10000-1"
            };

            var record3 = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning test_3",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "20-09-1907",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "16-05-1908",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B2.pdf",
                Bestand_Formaat_BestandsOmvang = 90 * mb,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "523ec5dbed6a7f8ef10239dbda7523ec5dbed9ac625a64b1fc8c9d3443c9dfd8",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("21-8-2013 10:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("16-1-2011"),
                Openbaarheid_DatumOfPeriode = "01-07-1911",
                DossierId = "NL-0000-10000-2"
            };

            var record4 = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning test_3",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "20-09-1907",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "16-05-1908",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B3.pdf",
                Bestand_Formaat_BestandsOmvang = 300 * mb,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "bda7523ec5dbed9ac625aac625a64b1fc8c9d3443c9dfd8f10239dbda7523ec5d",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("21-8-2011 15:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("16-1-2013"),
                Openbaarheid_DatumOfPeriode = "01-07-1914",
                DossierId = "NL-0000-10000-3"
            };
            var record5 = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning test_3",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "20-09-1907",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "16-05-1908",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B3.pdf",
                Bestand_Formaat_BestandsOmvang = 300 * mb,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "bda7523ec5dbed9ac625aac625a64b1fc8c9d3443c9dfd8f10239dbda7523ec5d",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("21-8-2011 15:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("16-1-2013"),
                Openbaarheid_DatumOfPeriode = "01-07-1914",
                DossierId = "NL-0000-10000-3"
            };

            return new List<Dossier>()
            {
                new Dossier()
                {
                    Classificatie_Bron = "basisarchiefcode",
                    Classificatie_Code = "-1.733.21",
                    Classificatie_DatumOfPeriode = "02-03-2017",
                    Classificatie_Omschrijving = "Bouw van woningen en gebouwen",
                    Context_Activiteit_Naam = "CA",
                    Context_Actor_AggregatieNiveau = "Organisatie",
                    Context_Actor_GeautoriseerdeNaam = "Gemeente A",
                    Context_Actor_IdentificatieKenmerk = "K17272741",
                    Dekking_GeografischGebied = "D",
                    Dekking_InTijd_Begin = "20-02-2015",
                    Dekking_InTijd_Eind = "20-03-2016",
                    Eventgeschiedenis_DatumOfPeriode = "17-05-1905",
                    Eventgeschiedenis_Type = "Afsluiting",
                    Eventgeschiedenis_VerantwoordelijkeFunctionaris = "Gemeente A",
                    Gebruiksrechten_DatumOfPeriode = "17-05-1905",
                    Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                    IdentificatieKenmerk = "NL-0000-10000-1",
                    Integriteit = "Integer",
                    Naam = "bouwvergunning - bouwen landbouwerswoning Hoofdstraat 13 5121JA Rijen 17-05-1905",
                    Openbaarheid_DatumOfPeriode = "17-05-1910",
                    Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                    Relatie_Id = null,
                    Relatie_DatumOfPeriode = null,
                    Relatie_Type = null,
                    Taal = "dut",
                    Vertrouwelijkheid_DatumOfPeriode = "17-05-1905",
                    Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                    Records = new List<Record>() {record1, record2}
                },
                new Dossier()
                {
                    Classificatie_Bron = "basisarchiefcode",
                    Classificatie_Code = "-1.733.21",
                    Classificatie_DatumOfPeriode = "01-01-2017",
                    Classificatie_Omschrijving = "Bouw van woningen en gebouwen",
                    Context_Activiteit_Naam = "CA",
                    Context_Actor_AggregatieNiveau = "Organisatie",
                    Context_Actor_GeautoriseerdeNaam = "Gemeente A",
                    Context_Actor_IdentificatieKenmerk = "K17272741",
                    Dekking_GeografischGebied = "D",
                    Dekking_InTijd_Begin = "20-05-2015",
                    Dekking_InTijd_Eind = "20-05-2016",
                    Eventgeschiedenis_DatumOfPeriode = "17-05-1915",
                    Eventgeschiedenis_Type = "Afsluiting",
                    Eventgeschiedenis_VerantwoordelijkeFunctionaris = "Gemeente A",
                    Gebruiksrechten_DatumOfPeriode = "17-05-1915",
                    Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                    IdentificatieKenmerk = "NL-0000-10000-2",
                    Integriteit = "Integer",
                    Naam = "bouwvergunning - bouwen landbouwerswoning test2",
                    Openbaarheid_DatumOfPeriode = "17-05-1911",
                    Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                    Relatie_Id = null,
                    Relatie_DatumOfPeriode = null,
                    Relatie_Type = null,
                    Taal = "dut",
                    Vertrouwelijkheid_DatumOfPeriode = "20-09-1915",
                    Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                    Records = new List<Record>() {record3}
                },
                new Dossier()
                {
                    Classificatie_Bron = "basisarchiefcode",
                    Classificatie_Code = "-1.733.21",
                    Classificatie_DatumOfPeriode = "01-01-2017",
                    Classificatie_Omschrijving = "Bouw van woningen en gebouwen",
                    Context_Activiteit_Naam = "CA",
                    Context_Actor_AggregatieNiveau = "Organisatie",
                    Context_Actor_GeautoriseerdeNaam = "Gemeente A",
                    Context_Actor_IdentificatieKenmerk = "K17272741",
                    Dekking_GeografischGebied = "D",
                    Dekking_InTijd_Begin = "20-05-2015",
                    Dekking_InTijd_Eind = "20-05-2016",
                    Eventgeschiedenis_DatumOfPeriode = "17-05-1915",
                    Eventgeschiedenis_Type = "Afsluiting",
                    Eventgeschiedenis_VerantwoordelijkeFunctionaris = "Gemeente A",
                    Gebruiksrechten_DatumOfPeriode = "17-05-1915",
                    Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                    IdentificatieKenmerk = "NL-0000-10000-3",
                    Integriteit = "Integer",
                    Naam = "bouwvergunning - bouwen landbouwerswoning test2",
                    Openbaarheid_DatumOfPeriode = "17-05-1911",
                    Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                    Relatie_Id = null,
                    Relatie_DatumOfPeriode = null,
                    Relatie_Type = null,
                    Taal = "dut",
                    Vertrouwelijkheid_DatumOfPeriode = "20-09-1915",
                    Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                    Records = new List<Record>() {record4, record5}
                }
            };
        }
    }
}
