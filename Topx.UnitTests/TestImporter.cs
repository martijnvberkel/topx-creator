using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Topx.Data;
using Topx.Interface;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestImporter
    {
        [Test]
        public void IgnoreExtraField_In_FileStream()
        {
            //Arrange
            var importer = new Importer.Importer();
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
                new FieldMapping(){DatabaseFieldName = "Relatie_Id", MappedFieldName = "B"}
            };
            var streamreader = CreateReader($"A;B;C{Environment.NewLine}TestA;TestB;TestC");
            // Act
            var dossiers = importer.GetDossiers(mappings,streamreader, Headers.FieldMappingType.DOSSIER);

            // Assert
            Assert.That(dossiers.Count, Is.EqualTo(1));
            Assert.That(importer.Error, Is.EqualTo(false));
            Assert.That(dossiers[0].Naam, Is.EqualTo("A"));
            Assert.That(dossiers[0].Relatie_Id, Is.EqualTo("B"));
        }

        [Test]
        public void Ignore_unexpected_EOF()
        {
            //Arrange
            var importer = new Importer.Importer();
            var mappings = new List<FieldMapping>()
            {
                new FieldMapping(){DatabaseFieldName = "Naam", MappedFieldName = "A"},
            };
            var streamreader = CreateReader($"A;B{Environment.NewLine}TestA;TestB{Environment.NewLine} this_is_not_a_good_csv");
            // Act
            var dossiers = importer.GetDossiers(mappings, streamreader, Headers.FieldMappingType.DOSSIER);

            // Assert
            Assert.That(dossiers.Count, Is.EqualTo(2));
            Assert.That(importer.Error, Is.EqualTo(false));
        }

        public StreamReader CreateReader(string testString)
        {
            var encoding = new UTF8Encoding();
            var testArray = encoding.GetBytes(testString);
            var ms = new MemoryStream(testArray);
            return  new StreamReader(ms);
        }
    }
}
