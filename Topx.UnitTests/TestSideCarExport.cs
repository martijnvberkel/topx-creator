using System.IO;
using System.Xml.Linq;
using Moq;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Topx.Sidecar;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestSideCarExport
    {
       [Test]
        public void TestExport()
        {
            // Real export without mocks

            var logger = new Mock<ILogger>();
            var xDoc = XDocument.Load(@"D:\TopX Testfiles\SideCarExport\TopxValidatedOutput.xml");
            var export = new Export(  @"D:\TopX Testfiles\TestFiles", @"D:\TopX Testfiles\SideCarExport\Target", new IOUtilities(),  logger.Object);
            
            export.Create(xDoc);
        }

        [Test]
        public void TestMockExport()
        {
            var logger = new Mock<ILogger>();
            var xDoc = XDocument.Load(Path.Combine(Statics.AppPath(), @"TestResources\TopxOutputForSidecarTest.xml"));
            var targetDir = "tartgetDir";
            var ioUtilities = new MockIOUtilities();
            var export = new Export("sourceDir", targetDir, ioUtilities, logger.Object);

            export.Create(xDoc);

            // DEBUG: To view the action-sequence of a validated output to use in the unittests

            // var count = 0;
            // foreach (var action in ioUtilities.Actions)
            // {
            //     Debug.WriteLine($"{count} {action.Type.ToString()} {action.PathSource} {action.PathTarget} {action.Content}");
            //     count += 1;
            // }

            // Archief CreateDir
            Assert.That(ioUtilities.Actions[0].Type, Is.EqualTo(Type.CreateDirectory));
            Assert.That(ioUtilities.Actions[0].PathTarget, Is.EqualTo(targetDir));

            // Archief metadata
            Assert.That(ioUtilities.Actions[1].Type, Is.EqualTo(Type.Save));
            Assert.That(ioUtilities.Actions[1].PathTarget, Is.EqualTo(@"tartgetDir\1\1.metadata"));
            StringAssert.Contains("<identificatiekenmerk>1</identificatiekenmerk>", ioUtilities.Actions[1].Content);

            // Dossier CreateDir
            Assert.That(ioUtilities.Actions[2].Type, Is.EqualTo(Type.CreateDirectory));
            Assert.That(ioUtilities.Actions[2].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023"));

            // Dossier metadata
            Assert.That(ioUtilities.Actions[3].Type, Is.EqualTo(Type.Save));
            Assert.That(ioUtilities.Actions[3].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023.metadata"));
            StringAssert.Contains("<identificatiekenmerk>NL-0784-10009-BV000000023</identificatiekenmerk>", ioUtilities.Actions[3].Content);
            StringAssert.Contains("Dossier", ioUtilities.Actions[3].Content);

            // Record CreateDir
            Assert.That(ioUtilities.Actions[4].Type, Is.EqualTo(Type.CreateDirectory));
            Assert.That(ioUtilities.Actions[4].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023_B000004136"));

            // Record metadata
            Assert.That(ioUtilities.Actions[5].Type, Is.EqualTo(Type.Save));
            Assert.That(ioUtilities.Actions[5].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023_B000004136\NL-0784-10009-BV000000023_B000004136.metadata"));
           // StringAssert.Contains(ioUtilities.Actions[5].Content, "<identificatiekenmerk>NL-0784-10009-BV000000023_B000004136</identificatiekenmerk>");
            StringAssert.Contains("Record", ioUtilities.Actions[5].Content);

            // Bestand metadata
            Assert.That(ioUtilities.Actions[6].Type, Is.EqualTo(Type.Save));
            Assert.That(ioUtilities.Actions[6].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023_B000004136\B000004136.metadata"));
            StringAssert.Contains("<identificatiekenmerk>B000004136</identificatiekenmerk>", ioUtilities.Actions[6].Content);
            StringAssert.Contains("Bestand", ioUtilities.Actions[6].Content);

            // Bestand copy
            Assert.That(ioUtilities.Actions[7].Type, Is.EqualTo(Type.FileCopy));
            Assert.That(ioUtilities.Actions[7].PathSource, Is.EqualTo(@"sourceDir\B000004136.pdf"));
            Assert.That(ioUtilities.Actions[7].PathTarget, Is.EqualTo(@"tartgetDir\1\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023_B000004136\B000004136.pdf"));
        }
    }
}
