using NUnit.Framework;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestValidations
    {
        public string[] Fail = { "test test.pdf", "test*.pdf", "a@.b", "a<.b", "<a.b", "a:a.b", "a”.b", "a|b", "a\".b", "a .b", "CON", "COM1" };
        public string[] Valid = { "test.pdf", "con.pdf", "a.b", "com1.pdf" };

        [Test]
        public void TestFileNameValidation_Success()
        {
            foreach (var filename in Valid)
            {
                var result = Validations.GetIllegalCharsInFileName(filename);
                Assert.AreEqual(result, string.Empty);
            }
        }
        [Test]
        public void TestFileNameValidation_Fail()
        {
            foreach (var filename in Fail)
            {
                var result = Validations.GetIllegalCharsInFileName(filename);
                Assert.AreNotEqual(result, string.Empty);
            }
        }
        [Test]
        public void TestFileNameValidationAndCheckReturnedChar1_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("test test");
            Assert.AreEqual(result, " ");
        }

        [Test]
        public void TestFileNameValidationAndCheckReturnedChar2_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("a:a.b");
            Assert.AreEqual(result, ":");
        }

        [Test]
        public void TestFileNameValidationAndCheckReturnedChar3_Fail()
        {
            var result = Validations.GetIllegalCharsInFileName("COM1");
            Assert.AreEqual(result, "COM1");
        }
    }
}