using NUnit.Framework;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestValidations
    {
        public string[] Fail = { "test,test.pdf", "test.test.pdf", "test test.pdf", "test*.pdf", "a@.b", "a<.b", "<a.b", "a:a.b", "a”.b", "a|b", "a\".b", "a .b", "CON", "COM1" };
        public string[] Valid = { "test.pdf", "con.pdf", "a.b", "com1.pdf" };

        [Test]
        public void TestFileNameValidation_Success()
        {
            foreach (var filename in Valid)
            {
                var result = Validations.GetIllegalCharsInFileName(filename);
                Assert.That(string.Empty, Is.EqualTo(result));
            }
        }
        [Test]
        public void TestFileNameValidation_Fail()
        {
            foreach (var filename in Fail)
            {
                var result = Validations.GetIllegalCharsInFileName(filename);
                Assert.That(string.Empty, Is.EqualTo(result));
            }
        }
        [Test]
        public void TestFileNameValidationAndCheckReturnedChar1_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("test test");
            Assert.That(" ", Is.EqualTo(result));
        }
      
        [Test]
        public void TestFileNameValidationAndCheckReturnedChar2_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("a:a.b");
            Assert.That(":", Is.EqualTo(result));
        }

        [Test]
        public void TestFileNameValidationAndCheckReturnedChar3_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("COM1");
            Assert.That("COM1", Is.EqualTo(result));
        }
        [Test]
        public void TestFileNameValidationAndCheckReturnedChar4_Ok()
        {
            var result = Validations.GetIllegalCharsInFileName("AC-00004431_V000109427.pdf");
            Assert.That(string.Empty, Is.EqualTo(result));
        }
    }
}