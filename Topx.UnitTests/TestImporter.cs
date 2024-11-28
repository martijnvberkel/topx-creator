using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gu.SerializationAsserts;
using Moq;
using NUnit.Framework;
using Topx.Data;
using Topx.DataServices;
using Topx.Importer;
using Topx.UnitTests.TestResources;
using Topx.Utility;


namespace Topx.UnitTests
{
    [TestFixture]
    public class TestImporter
    {

        private List<Dossier> GetDossier()
        {
            var record = new Record()
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
            return new List<Dossier>() { new Dossier()
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
        }

        [Test]
        public void IgnoreExtraField_In_FileStream()
        {
            //Arrange
            var mockDataservice = new Mock<IDataService>(MockBehavior.Strict);

            var importer = new Importer.Importer(mockDataservice.Object, enableValidation: false);
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
                new FieldMapping(){DatabaseFieldName = "Relatie_Id", MappedFieldName = "B"}
            };
            var streamreader = CreateReader($"A;B;C{Environment.NewLine}TestA;TestB;TestC");

            mockDataservice.Setup(t => t.SaveDossier(It.Is<Dossier>(y => y.Naam == "TestA" && y.Relatie_Id == "TestB" && y.IdentificatieKenmerk == null)))
                .Returns(true);

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
            
            var importer = new Importer.Importer(mockDataservice.Object, enableValidation: false);
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
            };
            var streamreader = CreateReader($"A;B{Environment.NewLine}TestA;TestB{Environment.NewLine}this_is_not_a_good_csv");

           // mockDataservice.Setup(t => t.SaveDossier(It.Is<Dossier>(y => y.Naam == "TestA" && y.Relatie_Id == null && y.IdentificatieKenmerk == null)));
            mockDataservice.Setup(x => x.SaveDossier(It.IsAny<Dossier>())).Returns(true);
            // Act
            importer.SaveDossiers(mappings, streamreader);

            // Assert
            Assert.That(importer.Error, Is.EqualTo(true));
            Assert.That(importer.ErrorsImportDossiers.ToString(), Contains.Substring("ERROR: Dossier this_is_not_a_good_csv kon niet worden ingelezen, aantal kolommen is onjuist"));
        }

        [Test]
        public void TopxConversion()
        {

            // Arrange
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
            var recordinformationPackage = converter.ParseDataToTopx(GetDossier())[0];
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput2.xml"));

            // Assert
            XmlAssert.Equal(xmlCompare, xmlstreamActual);

        }

        [Test]
        public void TopxConversion_TestOpenbaarheid()
        {

            // Arrange
            var dossiers = GetDossier();

            // muteer de openbaarheid
            dossiers[0].Openbaarheid_DatumOfPeriode = "1-1-2010| 1-1-2015";
            dossiers[0].Openbaarheid_OmschrijvingBeperkingen = "Geheim| Openbaar";


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
            var recordinformationPackage = converter.ParseDataToTopx(dossiers)[0];
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput_Openbaarheid.xml"));

            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlstreamActual);

            // Assert
            Assert.That(xmlhelper.ValidationErrors.Length, Is.EqualTo(0));
            XmlAssert.Equal(xmlCompare, xmlstreamActual);

        }

        [Test]
        public void TopXConversion_TestGeolocationMultipleRecords()
        {
            // Arrange
            var dossiers = GetDossier();

            // muteer de geolocation
            dossiers[0].Dekking_GeografischGebied = "Test1| Test2 | Test3";
          


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
            var recordinformationPackage = converter.ParseDataToTopx(dossiers)[0];
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput_Geolocatie_array.xml"));

            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlstreamActual);

            // Assert
            Assert.That(xmlhelper.ValidationErrors.Length, Is.EqualTo(0));
            XmlAssert.Equal(xmlCompare, xmlstreamActual);
        }

        [Test]
        public void TopXConversion_TestEventsMultipleRecords()
        {
            // Arrange
            var dossiers = GetDossier();

            // muteer de geolocation
            dossiers[0].Eventgeschiedenis_DatumOfPeriode = "1-1-2017| 01-01-2018  |01-01-2019";
            dossiers[0].Eventgeschiedenis_Type = "Afsluiting|Wijziging|Whatever";
            dossiers[0].Eventgeschiedenis_VerantwoordelijkeFunctionaris = "A|B|C";



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
            var recordinformationPackage = converter.ParseDataToTopx(dossiers)[0];
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput_Eventgeschiedenis_array.xml"));

            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlstreamActual);

            // Assert
            Assert.That(xmlhelper.ValidationErrors.Length, Is.EqualTo(0));
            XmlAssert.Equal(xmlCompare, xmlstreamActual);
        }

        [Test]
        public void TopXConversion_TestEventsMultipleRecords_Err_UnequalCollection()
        {
            // Arrange
            var dossiers = GetDossier();

            // muteer de geolocation
            dossiers[0].Eventgeschiedenis_DatumOfPeriode = "01-01-2017| 01-01-2018  |01-01-2019";
            dossiers[0].Eventgeschiedenis_Type = "Afsluiting|Wijziging|Whatever";
            dossiers[0].Eventgeschiedenis_VerantwoordelijkeFunctionaris = "A|B";  // dus series hebben een ongelijk aantel elementen



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
            var recordinformationPackage = converter.ParseDataToTopx(dossiers)[0];
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput_Eventgeschiedenis_array.xml"));

            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlstreamActual);

            // Assert
            var expectedError = "De velden Eventgeschiedenis_DatumOfPeriode, Eventgeschiedenis_Type en Eventgeschiedenis_VerantwoordelijkeFunctionaris moeten evenveel records bevatten, gescheiden met een pipe karakter.";

            Assert.That(converter.ErrorMessage.ToString(), Is.SupersetOf(expectedError));
        }



        [Test]
        public void Test_DossierValidator_Dates_Fail()
        {
            var dossier = new Dossier()
            {
                Dekking_InTijd_Begin = "this_is_not_a_date",
                Dekking_InTijd_Eind = "this_is_not_a_date",
                Classificatie_DatumOfPeriode = "this_is_not_a_date",
                Gebruiksrechten_DatumOfPeriode = "this_is_not_a_date",
                Vertrouwelijkheid_DatumOfPeriode = "this_is_not_a_date",
                Openbaarheid_DatumOfPeriode = "this_is_not_a_date",
                Eventgeschiedenis_DatumOfPeriode = "this_is_not_a_date",
                Relatie_DatumOfPeriode = "this_is_not_a_date",
                Openbaarheid_OmschrijvingBeperkingen = string.Empty
            };
            var dossierValidator = new DossierValidator(dossier);

            var result = dossierValidator.Validate();
            Assert.That(result, Is.EqualTo(false));
            Assert.That(dossierValidator.ValidationErrors.Count, Is.EqualTo(16));
        }

        [Test]
        public void Test_DossierValidator_Dates_Success()
        {
            var date = "22-1-2000";
            var dossier = new Dossier()
            {
                Dekking_InTijd_Begin = date,
                Dekking_InTijd_Eind = date,
                Classificatie_DatumOfPeriode = date,
                Gebruiksrechten_DatumOfPeriode = date,
                Vertrouwelijkheid_DatumOfPeriode = date,
                Openbaarheid_DatumOfPeriode = date,
                Eventgeschiedenis_DatumOfPeriode = date,
                Relatie_DatumOfPeriode = date,
                Eventgeschiedenis_Type = "x",
                Taal = "dut",
                Vertrouwelijkheid_ClassificatieNiveau = "x",
                Openbaarheid_OmschrijvingBeperkingen = "x",
                Naam = "x",
                Eventgeschiedenis_VerantwoordelijkeFunctionaris = "x",
                IdentificatieKenmerk = "x",
                Context_Activiteit_Naam = "x",
                Context_Actor_AggregatieNiveau = "x",
                Context_Actor_GeautoriseerdeNaam = "x",
                Context_Actor_IdentificatieKenmerk = "x",
                Classificatie_Bron = "x",
                Classificatie_Omschrijving = "x",
                Classificatie_Code = "x"
            };
            var dossierValidator = new DossierValidator(dossier);

            var result = dossierValidator.Validate();
            Assert.That(result, Is.True);
            Assert.That(dossierValidator.ValidationErrors.Count, Is.EqualTo(0));
        }

        [Test]

        public void TestBatch()
        {
            var dossiers = Dossiers_Test1.GetDossiers();
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
            var recordinformationPackage = converter.ParseDataToTopx(dossiers, 50);
            var xmlHelper = new Utility.XmlHelper();
            var xmlstreamActual = xmlHelper.GetXmlStringFromObject(recordinformationPackage[0]);

            // Act
            var xmlCompare = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput1.xml"));

            // Assert
            XmlAssert.Equal(xmlCompare, xmlstreamActual);

        }


        private StreamReader CreateReader(string testString)
        {
            var encoding = new UTF8Encoding();
            var testArray = encoding.GetBytes(testString);
            var ms = new MemoryStream(testArray);
            return new StreamReader(ms);
        }


    }
}
