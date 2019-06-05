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
    public class TestPdfAnalysis
    {
        [Test]
        public void TestPasswordPretection()
        {
            // Given
            var file  = Path.Combine(Statics.AppPath(), @"TestResources\ProtectDocument_output.pdf");

            // When
            var test = Pdf.IsPasswordProtected(file);

            // Then
            Assert.That(test, Is.True);
        }
    }
}
