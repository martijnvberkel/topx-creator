using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Topx.FileAnalysis;

namespace Topx.UnitTests
{
    public class TestPronomIdentification
    {
        public TestPronomIdentification()
        {
            
        }
        public void TestPdf()
        {
           //var pdfFile = File.ReadAllBytes(Path.Combine(Statics.AppPath(), @"TestResources\MetadataFiles\dummy.pdf"));

            var identificator = new Identificator(@"D:\Tools\droid-binary-6.4-binx\droid.bat", @"D:\TopX_Data\TestFiles", new Mock<NLog.Logger>().Object);
            identificator.IdentifyFiles(null);
        }
    }
}
