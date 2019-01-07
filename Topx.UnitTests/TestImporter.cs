using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gu.SerializationAsserts;
using Moq;
using NUnit.Framework;
using Topx.Data;
using Topx.DataServices;


namespace Topx.UnitTests
{
    [TestFixture]
    public class TestImporter
    {

        
        [Test]
        public void IgnoreExtraField_In_FileStream()
        {
            //Arrange
            var mockDataservice = new Mock<IDataService>(MockBehavior.Strict);
           
            var importer = new Importer.Importer(mockDataservice.Object);
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
                new FieldMapping(){DatabaseFieldName = "Relatie_Id", MappedFieldName = "B"}
            };
            var streamreader = CreateReader($"A;B;C{Environment.NewLine}TestA;TestB;TestC");

            mockDataservice.Setup(t => t.SaveDossier(It.Is<Dossier>(y => y.Naam == "TestA" && y.Relatie_Id == "TestB" && y.IdentificatieKenmerk == null)));

            // Act
            importer.SaveDossiers(mappings, streamreader);

            // Assert
            Assert.That(importer.Error, Is.EqualTo(false));
        }

        [Test]
        public void Notice_unexpected_EOF_Dossier()
        {
            //Arrange
            var mockDataservice = new Mock<IDataService>(MockBehavior.Strict);
            var importer = new Importer.Importer(mockDataservice.Object);
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
            };
            var streamreader = CreateReader($"A;B{Environment.NewLine}TestA;TestB{Environment.NewLine}this_is_not_a_good_csv");
            // Act
            mockDataservice.Setup(t => t.SaveDossier(It.Is<Dossier>(y => y.Naam == "TestA" && y.Relatie_Id ==null && y.IdentificatieKenmerk == null)));

            // Act
            importer.SaveDossiers(mappings, streamreader);

            // Assert
            Assert.That(importer.Error, Is.EqualTo(true));
            Assert.That(importer.ErrorsImportDossiers.ToString(), Contains.Substring("ERROR: Dossier this_is_not_a_good_csv kon niet worden ingelezen, aantal kolommen is onjuist"));
        }

        [Test]
        public void TopxConversion()
        {
           
            var record = new Record()
            {
                Naam = "tekening (technisch) - bouwen landbouwerswoning Hoofdstraat 13 5121JA Rijen 17-05-1905",
                Gebruiksrechten_OmschrijvingVoorwaarden = "Vrij te gebruiken",
                Gebruiksrechten_DatumOfPeriode = "17-05-1905",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Vertrouwelijkheid_DatumOfPeriode = "17-05-1905",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Bestand_Vorm_Redactiegenre = "Tekening (technisch)",
                Bestand_Formaat_Bestandsnaam = "B000000058.pdf",
                Bestand_Formaat_BestandsOmvang = 1200000,
                Bestand_Formaat_BestandsFormaat = "fmt/354",
                Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256",
                Bestand_Formaat_FysiekeIntegriteit_Waarde = "6024baa32d6a7f8ef10239d43c9dfd8b25a64b1fc8c9d34da7523ec5dbed9ac6",
                Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = Convert.ToDateTime("30-7-2015 12:50"),
                Bestand_Formaat_DatumAanmaak = Convert.ToDateTime("20-8-2012"),
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
                Openbaarheid_DatumOfPeriode = "17-05-1905",
                Openbaarheid_OmschrijvingBeperkingen = "Openbaar",
                Relatie_Id = null,
                Relatie_DatumOfPeriode = null,
                Relatie_Type = null,
                Taal = "dut",
                Vertrouwelijkheid_DatumOfPeriode = "17-05-1905",
                Vertrouwelijkheid_ClassificatieNiveau = "Niet vertrouwelijk",
                Records = new List<Record>() { record }
            }};
            var globals = new Globals()
            {
                BronArchief = "a",
                DatumArchief = Convert.ToDateTime("2018-12-13"),
                DoelArchief = "b",
                IdentificatieArchief = "c",
                NaamArchief = "d",
                OmschrijvingArchief = "e"
            };

            var mockDataservice = new Mock<IDataService>();

            var converter = new Creator.Parser(globals, mockDataservice.Object);
            var recordinformationPackage = converter.ParseDataToTopx(dossiers);
          
            var xmlstreamActual = Utility.XmlHelper. GetXmlStringFromObject(recordinformationPackage);

            var xmlCompare = File.ReadAllText(Path.Combine(Statics. AppPath(), @"TestResources\ExpectedOutput1.xml"));

            XmlAssert.Equal(xmlCompare, xmlstreamActual);

        }

       


        private StreamReader CreateReader(string testString)
        {
            var encoding = new UTF8Encoding();
            var testArray = encoding.GetBytes(testString);
            var ms = new MemoryStream(testArray);
            return  new StreamReader(ms);
        }


    }
}
