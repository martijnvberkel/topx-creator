using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.NUnit4;
using Moq;
using NUnit.Framework;
using Topx.Creator;
using Topx.Data;
using Topx.DataServices;
using Topx.Importer;
using Topx.UnitTests.TestResources;
using Topx.Utility;

namespace Topx.UnitTests
{
    internal class TestOptionalFieldValidations
    {
        [Theory, AutoData]
        public void Dossiers_Test1(Globals mockGlobals)
        {
            var record = new Record
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning Hoofdstraat 13 5121JA Rijen 17-05-1905",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "17-05-1905",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "17-05-1905",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B000000058.pdf",
                Bestand_Formaat_BestandsOmvang = 1200000,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "6024baa32d6a7f8ef10239d43c9dfd8b25a64b1fc8c9d34da7523ec5dbed9ac6",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("30-7-2015 12:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("20-8-2012"),
                Openbaarheid_DatumOfPeriode = "17-05-1905",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                DossierId = "NL-0000-10000-1"
            };
            var dossiers = new List<Dossier>() { new Dossier()
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
                Records = new List<Record>() { record }
            }};

            var validator = new DossierValidator(dossiers[0]);
            var result = validator.Validate();
            Assert.That(result, Is.True);

           // var mockGlobals = new Mock<Globals>();
            var mockDataService = new Mock<IDataService>();

            var parser = new Parser(mockGlobals, mockDataService.Object);
            parser.ParseDataToTopx(dossiers);
            var resultParser = parser.ErrorMessage.ToString();
            Assert.That(parser.ErrorMessage.Length, Is.EqualTo(0));

            var xmlhelper = new XmlHelper();
            var success = xmlhelper.ValidateXmlString(resultParser);

            Assert.That(success, Is.True);
        }

        
    }
}
