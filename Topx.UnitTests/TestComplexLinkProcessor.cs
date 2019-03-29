using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Topx.ComplexLinks;
using Topx.Data;
using Topx.DataServices;
using Topx.UnitTests.TestResources;

namespace Topx.UnitTests
{
    [TestFixture()]
    public class TestComplexLinkProcessor
    {
        public void Test_HappyFlow()
        {
            // given
            var dossiers = Dossiers_TestComplexLink1 .GetDossiers();
          
            var allComplexLinks = new List<string>() {"2"};

            var mockDataservice = new Mock<IDataService>();
            mockDataservice.Setup(t => t.GetAllDossiers()).Returns(dossiers);
            mockDataservice.Setup(t => t.GetComplexLinksWithMoreThanOneOccurence()).Returns(allComplexLinks);

            // when
            var complexlinkProcessor = new ComplexLinkProcessor(mockDataservice.Object);
            complexlinkProcessor.Process();

            // then
            Assert.That(complexlinkProcessor.Error, Is.EqualTo(false));
        }

        public void Test_MultipleDossiersWithRecords()
        {
            // given
            var dossiers = Dossiers_TestComplexLink1.GetDossiers();
            dossiers[2].Records.Add(new Record());

            var allComplexLinks = new List<string>() { "2" };

            var mockDataservice = new Mock<IDataService>();
            mockDataservice.Setup(t => t.GetAllDossiers()).Returns(dossiers);
            mockDataservice.Setup(t => t.GetComplexLinksWithMoreThanOneOccurence()).Returns(allComplexLinks);

            // when
            var complexlinkProcessor = new ComplexLinkProcessor(mockDataservice.Object);
            complexlinkProcessor.Process();

            // then
            Assert.That(complexlinkProcessor.Error, Is.EqualTo(true));

            var expectedError = "Complexlinknummer 2 is gekoppeld aan meerdere dossiers die ook records bevatten: NL-0000-10000-2, NL-0000-10000-3. Er mag maar één dossier zijn met records.\r\n";
            Assert.That(complexlinkProcessor.ErrorMessages.ToString(), Is.EqualTo(expectedError));
        }

        public void Test_MultipleDossierNoRecords()
        {
            // given
            var dossiers = Dossiers_TestComplexLink1.GetDossiers();
            dossiers[1].Records = null;

            var allComplexLinks = new List<string>() { "2" };

            var mockDataservice = new Mock<IDataService>();
            mockDataservice.Setup(t => t.GetAllDossiers()).Returns(dossiers);
            mockDataservice.Setup(t => t.GetComplexLinksWithMoreThanOneOccurence()).Returns(allComplexLinks);

            // when
            var complexlinkProcessor = new ComplexLinkProcessor(mockDataservice.Object);
            complexlinkProcessor.Process();

            // then
            Assert.That(complexlinkProcessor.Error, Is.EqualTo(true));

            var expectedError = "Complexlinknummer 2 is gekoppeld aan meerdere dossiers die geen van allen records bevatten: NL-0000-10000-2, NL-0000-10000-3. Er moet één dossier zijn met records.\r\n";
            Assert.That(complexlinkProcessor.ErrorMessages.ToString(), Is.EqualTo(expectedError));
        }
        [Test]
        public void TestCloneDossiers()
        {
            // given
            var records = new List<Record>() {new Record() {Naam = "a"}};
            var dossier = new Dossier() {IdentificatieKenmerk = "1", Records = records};

            var recordsClone = records.Select(record => record.Clone()).ToList();

            // when
            var newDossier = new Dossier() { IdentificatieKenmerk = "3", Records = recordsClone};
             
            // then
            Assert.That(newDossier.Records.FirstOrDefault().Naam, Is.EqualTo(dossier.Records.FirstOrDefault().Naam));

        }
    }
}
