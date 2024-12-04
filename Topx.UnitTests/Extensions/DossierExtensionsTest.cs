using NUnit.Framework;
using Topx.Creator.Extensions;
using Topx.Data;
using System.Collections.Generic;

namespace Topx.UnitTests.Extensions
{
    [TestFixture]
    [TestOf(typeof(DossierExtensions))]
    public class DossierExtensionsTest
    {
        [Test]
        [TestCase("IdentificatieKenmerk", "", true)]
        [TestCase("IdentificatieKenmerk", "value", false)]
        [TestCase("Naam", "", true)]
        [TestCase("Naam", "value", false)]
        [TestCase("Omschrijving", "", true)]
        [TestCase("Omschrijving", "value", false)]
        [TestCase("Classificatie_", "", true)]
        [TestCase("Classificatie_", "value", false)]
        [TestCase("Dekking_", "", true)]
        [TestCase("Dekking_", "value", false)]
        [TestCase("Eventgeschiedenis_", "", true)]
        [TestCase("Eventgeschiedenis_", "value", false)]
        [TestCase("Eventplan_", "", true)]
        [TestCase("Eventplan_", "value", false)]
        [TestCase("Relatie_", "", true)]
        [TestCase("Relatie_", "value", false)]
        [TestCase("Context_", "", true)]
        [TestCase("Context_", "value", false)]
        [TestCase("Gebruiksrechten_", "", true)]
        [TestCase("Gebruiksrechten_", "value", false)]
        [TestCase("Vertrouwelijkheid_", "", true)]
        [TestCase("Vertrouwelijkheid_", "value", false)]
        [TestCase("Openbaarheid_", "", true)]
        [TestCase("Openbaarheid_", "value", false)]
        [TestCase("Integriteit", "", true)]
        [TestCase("Integriteit", "value", false)]
        public void IsElementEmpty_ShouldReturnExpectedResult(string fieldNameStart, string fieldValue, bool expectedResult)
        {
            var dossier = new Dossier
            {
                IdentificatieKenmerk = fieldNameStart == "IdentificatieKenmerk" ? fieldValue : null,
                Naam = fieldNameStart == "Naam" ? fieldValue : null,
                Omschrijving = fieldNameStart == "Omschrijving" ? fieldValue : null,
                Classificatie_Code = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_Omschrijving = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_Bron = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_DatumOfPeriode = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Dekking_InTijd_Begin = fieldNameStart == "Dekking_" ? fieldValue : null,
                Dekking_InTijd_Eind = fieldNameStart == "Dekking_" ? fieldValue : null,
                Dekking_GeografischGebied = fieldNameStart == "Dekking_" ? fieldValue : null,
                Taal = fieldNameStart == "Taal" ? fieldValue : null,
                Eventgeschiedenis_DatumOfPeriode = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventgeschiedenis_Type = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventgeschiedenis_VerantwoordelijkeFunctionaris = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventplan_DatumOfPeriode = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_DatumOfPeriode_Type = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_Aanleiding = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_Beschrijving = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Relatie_Id = fieldNameStart == "Relatie_" ? fieldValue : null,
                Relatie_Type = fieldNameStart == "Relatie_" ? fieldValue : null,
                Relatie_DatumOfPeriode = fieldNameStart == "Relatie_" ? fieldValue : null,
                Context_Actor_IdentificatieKenmerk = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Actor_AggregatieNiveau = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Actor_GeautoriseerdeNaam = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Activiteit_Naam = fieldNameStart == "Context_" ? fieldValue : null,
                Gebruiksrechten_OmschrijvingVoorwaarden = fieldNameStart == "Gebruiksrechten_" ? fieldValue : null,
                Gebruiksrechten_DatumOfPeriode = fieldNameStart == "Gebruiksrechten_" ? fieldValue : null,
                Vertrouwelijkheid_ClassificatieNiveau = fieldNameStart == "Vertrouwelijkheid_" ? fieldValue : null,
                Vertrouwelijkheid_DatumOfPeriode = fieldNameStart == "Vertrouwelijkheid_" ? fieldValue : null,
                Openbaarheid_OmschrijvingBeperkingen = fieldNameStart == "Openbaarheid_" ? fieldValue : null,
                Openbaarheid_DatumOfPeriode = fieldNameStart == "Openbaarheid_" ? fieldValue : null,
                Integriteit = fieldNameStart == "Integriteit" ? fieldValue : null
            };

            var result = dossier.IsElementEmpty(fieldNameStart);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        [TestCase("IdentificatieKenmerk", "", true)]
        [TestCase("IdentificatieKenmerk", "value", true)]
        [TestCase("IdentificatieKenmerk", null, true)]
        [TestCase("Naam", "", true)]
        [TestCase("Naam", "value", true)]
        [TestCase("Naam", null, true)]
        [TestCase("Omschrijving", "", true)]
        [TestCase("Omschrijving", "value", true)]
        [TestCase("Omschrijving", null, true)]
        [TestCase("Classificatie_", "", true)]
        [TestCase("Classificatie_", "value", true)]
        [TestCase("Classificatie_", null, true)]
        [TestCase("Dekking_", "", true)]
        [TestCase("Dekking_", "value", true)]
        [TestCase("Dekking_", null, true)]
        [TestCase("Eventgeschiedenis_", "", true)]
        [TestCase("Eventgeschiedenis_", "value", true)]
        [TestCase("Eventgeschiedenis_", null, true)]
        [TestCase("Eventplan_", "", true)]
        [TestCase("Eventplan_", "value", true)]
        [TestCase("Eventplan_", null, true)]
        [TestCase("Relatie_", "", true)]
        [TestCase("Relatie_", "value", true)]
        [TestCase("Relatie_", null, true)]
        [TestCase("Context_", "", true)]
        [TestCase("Context_", "value", true)]
        [TestCase("Context_", null, true)]
        [TestCase("Gebruiksrechten_", "", true)]
        [TestCase("Gebruiksrechten_", "value", true)]
        [TestCase("Gebruiksrechten_", null, true)]
        [TestCase("Vertrouwelijkheid_", "", true)]
        [TestCase("Vertrouwelijkheid_", "value", true)]
        [TestCase("Vertrouwelijkheid_", null, true)]
        [TestCase("Openbaarheid_", "", true)]
        [TestCase("Openbaarheid_", "value", true)]
        [TestCase("Openbaarheid_", null, true)]
        [TestCase("Integriteit", "", true)]
        [TestCase("Integriteit", "value", true)]
        [TestCase("Integriteit", null, true)]
        public void IsElementEmptyOrComplete_ShouldReturnExpectedResult(string fieldNameStart, string fieldValue, bool expectedResult)
        {
            var dossier = new Dossier
            {
                IdentificatieKenmerk = fieldNameStart == "IdentificatieKenmerk" ? fieldValue : null,
                Naam = fieldNameStart == "Naam" ? fieldValue : null,
                Omschrijving = fieldNameStart == "Omschrijving" ? fieldValue : null,
                Classificatie_Code = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_Omschrijving = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_Bron = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Classificatie_DatumOfPeriode = fieldNameStart == "Classificatie_" ? fieldValue : null,
                Dekking_InTijd_Begin = fieldNameStart == "Dekking_" ? fieldValue : null,
                Dekking_InTijd_Eind = fieldNameStart == "Dekking_" ? fieldValue : null,
                Dekking_GeografischGebied = fieldNameStart == "Dekking_" ? fieldValue : null,
                Taal = fieldNameStart == "Taal" ? fieldValue : null,
                Eventgeschiedenis_DatumOfPeriode = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventgeschiedenis_Type = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventgeschiedenis_VerantwoordelijkeFunctionaris = fieldNameStart == "Eventgeschiedenis_" ? fieldValue : null,
                Eventplan_DatumOfPeriode = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_DatumOfPeriode_Type = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_Aanleiding = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Eventplan_Beschrijving = fieldNameStart == "Eventplan_" ? fieldValue : null,
                Relatie_Id = fieldNameStart == "Relatie_" ? fieldValue : null,
                Relatie_Type = fieldNameStart == "Relatie_" ? fieldValue : null,
                Relatie_DatumOfPeriode = fieldNameStart == "Relatie_" ? fieldValue : null,
                Context_Actor_IdentificatieKenmerk = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Actor_AggregatieNiveau = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Actor_GeautoriseerdeNaam = fieldNameStart == "Context_" ? fieldValue : null,
                Context_Activiteit_Naam = fieldNameStart == "Context_" ? fieldValue : null,
                Gebruiksrechten_OmschrijvingVoorwaarden = fieldNameStart == "Gebruiksrechten_" ? fieldValue : null,
                Gebruiksrechten_DatumOfPeriode = fieldNameStart == "Gebruiksrechten_" ? fieldValue : null,
                Vertrouwelijkheid_ClassificatieNiveau = fieldNameStart == "Vertrouwelijkheid_" ? fieldValue : null,
                Vertrouwelijkheid_DatumOfPeriode = fieldNameStart == "Vertrouwelijkheid_" ? fieldValue : null,
                Openbaarheid_OmschrijvingBeperkingen = fieldNameStart == "Openbaarheid_" ? fieldValue : null,
                Openbaarheid_DatumOfPeriode = fieldNameStart == "Openbaarheid_" ? fieldValue : null,
                Integriteit = fieldNameStart == "Integriteit" ? fieldValue : null
            };

            var result = dossier.IsElementEmptyOrComplete(fieldNameStart);

            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}