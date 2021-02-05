using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestValidations
    {
        [Test]
        public void TestFileNameValidation_Success()
        {
            var filename = "test.pdf";
            var result = Validations.TestForIllegalCharsInFileName(filename);
            Assert.That(result, Is.True);
        }
        [Test]
        public void TestFileNameValidation_Fail()
        {
            var filename = "test*.pdf";
            var result = Validations.TestForIllegalCharsInFileName(filename);
            Assert.That(result, Is.False);
        }
        [Test]
        public void TestFileNameValidation_Fail2()
        {
            var filename = "test test.pdf";
            var result = Validations.TestForIllegalCharsInFileName(filename);
            Assert.That(result, Is.False);
        }
        public void TestFileNameValidation_Fail3()
        {
            var filename = @"test\test.pdf";
            var result = Validations.TestForIllegalCharsInFileName(filename);
            Assert.That(result, Is.False);
        }
    }
}
