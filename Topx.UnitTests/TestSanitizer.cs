using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Topx.Data;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture()]
    public class TestSanitizer
    {
        [Test]
        public void TestSanitize()
        {
            var fieldmappings = new List<FieldMapping>()
            {
                new FieldMapping() {DatabaseFieldName = "db1", MappedFieldName = "mp1"},
                new FieldMapping() {DatabaseFieldName = "db1", MappedFieldName = "mp2"},
                new FieldMapping() {DatabaseFieldName = "db2", MappedFieldName = "mp3"},
                new FieldMapping() {DatabaseFieldName = "db3", MappedFieldName = "mp3"},
            };
            

            Sanitizer.CheckAndFixSanityOfFieldMappings(fieldmappings);

            var expectedFieldmappings = new List<FieldMapping>()
            {
                new FieldMapping() {DatabaseFieldName = "db1", MappedFieldName = "mp2"},
                new FieldMapping() {DatabaseFieldName = "db3", MappedFieldName = "mp3"},
            };

            Assert.That(fieldmappings[0].MappedFieldName, Is.EqualTo(expectedFieldmappings[0].MappedFieldName));
            Assert.That(fieldmappings[0].DatabaseFieldName, Is.EqualTo(expectedFieldmappings[0].DatabaseFieldName));
            Assert.That(fieldmappings[1].MappedFieldName, Is.EqualTo(expectedFieldmappings[1].MappedFieldName));
            Assert.That(fieldmappings[1].DatabaseFieldName, Is.EqualTo(expectedFieldmappings[1].DatabaseFieldName));
            Assert.That(fieldmappings.Count, Is.EqualTo(2));
        }
        [Test]
        public void TestDoNotSanitize()
        {
            var fieldmappings = new List<FieldMapping>()
            {
                new FieldMapping() {DatabaseFieldName = "db1", MappedFieldName = "mp1"},
                new FieldMapping() {DatabaseFieldName = "db2", MappedFieldName = "mp2"},
                new FieldMapping() {DatabaseFieldName = "db3", MappedFieldName = "mp3"},
                new FieldMapping() {DatabaseFieldName = "db4", MappedFieldName = "mp4"},
            };

            Sanitizer.CheckAndFixSanityOfFieldMappings(fieldmappings);
           
            Assert.That(fieldmappings.Count, Is.EqualTo(4));
        }
    }
}
