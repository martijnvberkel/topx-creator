using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture()]
    public class TestXmlValidation
    {
        public void Test_Validate_Success()
        {
            // Given
            var xmlToValidate = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\ExpectedOutput1.xml"));
            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlToValidate);

            // Then
            Assert.That(xmlhelper.ValidationErrors.Length, Is.EqualTo(0));
        }

        public void Test_Validate_Fails()
        {
            // Given
            var xmlToValidate = File.ReadAllText(Path.Combine(Statics.AppPath(), @"TestResources\TopXOutput_NotValid.xml"));
            var xmlhelper = new XmlHelper();

            // When
            xmlhelper.ValidateXmlString(xmlToValidate);

            // Then
            Assert.That(xmlhelper.ValidationErrors.Length, Is.GreaterThan(0));
        }
    }
}
