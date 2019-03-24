using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;
using Topx.Data;
using Topx.DataServices;
using Topx.FileAnalysis;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestMetadata
    {
        [Test]
        public void Test_Hash_FileSize()
        {
            // Given
            var path = Path.Combine(Statics.AppPath(), @"TestResources\MetadataFiles");
            var records = new List<Record>() {new Record()
            {
                Bestand_Formaat_Bestandsnaam = "dummy.pdf"
            }};

            var dossiers = new List<Dossier>()
            {
                new Dossier()
                {
                    Records = records
                }
            };

            var mockDataservice = new Mock<IDataService>();

            var metadata = new Metadata(true, true, true, false, path, dossiers, mockDataservice.Object);

            // When
            metadata.Collect();

            // Then
            Assert.NotNull(records[0].Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd);
            Assert.NotNull(records[0].Bestand_Formaat_FysiekeIntegriteit_Waarde);
            Assert.That(records[0].Bestand_Formaat_FysiekeIntegriteit_Algoritme, Is.EqualTo("sha256"));
            Assert.That(records[0].Bestand_Formaat_BestandsOmvang, Is.EqualTo(13264));
        }

       
    }
}

