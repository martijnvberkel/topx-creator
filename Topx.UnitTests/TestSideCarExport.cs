﻿using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using Moq;
using NLog;
using NUnit.Framework;
using Topx.Utility;

namespace Topx.UnitTests
{
    [TestFixture]
    public class TestSideCarExport
    {
        [Test]
        public void TestExport()
        {
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

            var count = 0;
            foreach (var action in ioUtilities.Actions)
            {
                Debug.WriteLine($"{count} {action.Type.ToString()} {action.PathSource} {action.PathTarget} {action.Content}");
                count += 1;
            }

            // Archief CreateDir
            Assert.AreEqual( Type.CreateDirectory, ioUtilities.Actions[0].Type);
            Assert.AreEqual(targetDir, ioUtilities.Actions[0].PathTarget);

            // Archief metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[1].Type);
            Assert.AreEqual(@"tartgetDir\1", ioUtilities.Actions[1].PathTarget);
            StringAssert.Contains("<identificatie>1</identificatie>", ioUtilities.Actions[1].Content);

           
            Assert.AreEqual(Type.Save, ioUtilities.Actions[2].Type );
            Assert.AreEqual(@"tartgetDir\test\1.metadata", ioUtilities.Actions[2].PathTarget);
            StringAssert.Contains("<aggregatieniveau>Archief</aggregatieniveau>", ioUtilities.Actions[2].Content);

            // Dossier CreateDir
            Assert.AreEqual(Type.CreateDirectory, ioUtilities.Actions[3].Type);
            Assert.AreEqual(@"tartgetDir\test\NL-0784-10009-BV000000023", ioUtilities.Actions[3].PathTarget);

            // Dossier metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[4].Type);
            Assert.AreEqual(@"tartgetDir\test\NL-0784-10009-BV000000023\NL-0784-10009-BV000000023.metadata", ioUtilities.Actions[4].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>NL-0784-10009-BV000000023</identificatiekenmerk>", ioUtilities.Actions[4].Content);
            StringAssert.Contains("Dossier", ioUtilities.Actions[4].Content);

            // Record CreateDir
            Assert.AreEqual(Type.CreateDirectory, ioUtilities.Actions[5].Type);
            Assert.AreEqual(@"tartgetDir\test\NL-0784-10009-BV000000023\B000004136", ioUtilities.Actions[5].PathTarget);

            // Record metadata
            Assert.AreEqual(Type.Save, ioUtilities.Actions[6].Type);
            Assert.AreEqual(@"tartgetDir\test\NL-0784-10009-BV000000023\B000004136\NL-0784-10009-BV000000023_B000004136.metadata", ioUtilities.Actions[6].PathTarget);
            StringAssert.Contains("<identificatiekenmerk>NL-0784-10009-BV000000023_B000004136</identificatiekenmerk>", ioUtilities.Actions[6].Content);
            StringAssert.Contains("Record", ioUtilities.Actions[6].Content);
        }
    }
}
