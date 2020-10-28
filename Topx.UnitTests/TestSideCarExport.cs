using System.IO;
using System.Xml.Linq;
using Moq;
using NLog;
using NUnit.Framework;
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
            Assert.AreEqual( Type.CreateDirectory, ioUtilities.Actions[0].Type);
            Assert.AreEqual(targetDir, ioUtilities.Actions[0].PathTarget);

            // Archief metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[1].Type);
            Assert.AreEqual(@"tartgetDir\1.metadata", ioUtilities.Actions[1].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>1</identificatiekenmerk>", ioUtilities.Actions[1].Content);

            // Dossier CreateDir
            Assert.AreEqual(Type.CreateDirectory, ioUtilities.Actions[2].Type);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023", ioUtilities.Actions[2].PathTarget);

            // Dossier metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[3].Type);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023.metadata", ioUtilities.Actions[3].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>NL-0784-10009-BV000000023</identificatiekenmerk>", ioUtilities.Actions[3].Content);
            StringAssert.Contains("Dossier", ioUtilities.Actions[3].Content);

            // Record CreateDir
            Assert.AreEqual(Type.CreateDirectory, ioUtilities.Actions[4].Type);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023\B000004136", ioUtilities.Actions[4].PathTarget);

            // Record metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[5].Type);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023\B000004136\NL-0784-10009-BV000000023_B000004136.metadata", ioUtilities.Actions[5].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>NL-0784-10009-BV000000023_B000004136</identificatiekenmerk>", ioUtilities.Actions[5].Content);
            StringAssert.Contains("Record", ioUtilities.Actions[5].Content);

            // Bestand metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[6].Type);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023\B000004136\B000004136.metadata", ioUtilities.Actions[6].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>B000004136</identificatiekenmerk>", ioUtilities.Actions[6].Content);
            StringAssert.Contains("Bestand", ioUtilities.Actions[6].Content);

            // Bestand copy
            Assert.AreEqual(Type.FileCopy, ioUtilities.Actions[7].Type);
            Assert.AreEqual(@"sourceDir\B000004136.pdf", ioUtilities.Actions[7].PathSource);
            Assert.AreEqual(@"tartgetDir\NL-0784-10009-BV000000023\B000004136\B000004136.pdf", ioUtilities.Actions[7].PathTarget);
        }
    }
}
