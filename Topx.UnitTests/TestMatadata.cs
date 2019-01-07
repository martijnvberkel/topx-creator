using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Topx.Data;
using Topx.FileAnalysis;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestMatadata
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

            var metadata = new Metadata(true, true, true, false, path, records);

            // When
            metadata.Collect();

            // Then
            Assert.NotNull(records[0].Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd);
            Assert.NotNull(records[0].Bestand_Formaat_FysiekeIntegriteit_Waarde);
            Assert.That(records[0].Bestand_Formaat_FysiekeIntegriteit_Algoritme, Is.EqualTo("sha256"));
            Assert.That(records[0].Bestand_Formaat_BestandsOmvang, Is.EqualTo(13264));
        }
        [Test]
        public void Test_Files_NotFound()
        {
            // Given
            var path = Path.Combine(Statics.AppPath(), @"TestResources\MetadataFiles");
            var records = new List<Record>()
            {
                new Record()
                {
                    Bestand_Formaat_Bestandsnaam = "dummy.pdf"
                },
                new Record()
                {
                    Bestand_Formaat_Bestandsnaam = "dummy_does_not_exists.pdf"
                }
            };

            var metadata = new Metadata(true, true, true, false, path, records);

            // When
            var result = metadata.TestIfAllFilesArePresent();

            // Then
            Assert.That(result, Is.EqualTo(false));
            StringAssert.Contains("File dummy_does_not_exists.pdf niet gevonden", metadata.ErrorMessages.ToString());
        }
    }
}

