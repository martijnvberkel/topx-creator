using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Topx.FileAnalysis;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestOfficeAnalysis
    {
        [Test]
        public void TestPasswordProtection()
        {
            // Given
            var file  = Path.Combine(Statics.AppPath(), @"TestResources\Passwordprotected.docx");

            // When
            var test = MsOffice.IsPasswordProtected(file);

            // Then
            Assert.That(test, Is.True);
        }

        [Test]
        public void TestPasswordProtection2()
        {
            // Given
            var file = Path.Combine(Statics.AppPath(), @"TestResources\Passwordprotected.doc");

            // When
            var test = MsOffice.IsPasswordProtected(file);

            // Then
            Assert.That(test, Is.True);
        }

        [Test]
        public void TestNoPasswordProtection()
        {
            // Given
            var file = Path.Combine(Statics.AppPath(), @"TestResources\NoPassword.docx");

            // When
            var test = MsOffice.IsPasswordProtected(file);

            // Then
            Assert.That(test, Is.False);
        }
        [Test]
        public void TestExcelPasswordProtection()
        {
            // Given
            var file = Path.Combine(Statics.AppPath(), @"TestResources\Passwordprotected.xlsx");

            // When
            var test = MsOffice.IsPasswordProtected(file);

            // Then
            Assert.That(test, Is.True);
        }
    }
}
