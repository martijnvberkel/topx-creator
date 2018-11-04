using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using NUnit.Framework;
using Topx.Data;
using Topx.Interface;


namespace Topx.UnitTests
{
    [TestFixture]
    public class InterfaceTests
    {
        public InterfaceTests()
        {
            
        }

        [Test]
        public void TestDossierHeaders()
        {
            // given
            var moq = new Mock<ModelTopX>();

            // when
            var headers = new Headers(moq.Object);
            
            // assert
           // Assert.That(headers.GetHeaderMappingDossiers(), Is.EqualTo(Statics.MockHeaders));
           // Assert.That(headers.HeadersRecords, Is.EqualTo(Statics.MockHeadersRecords));
           // Assert.That(headers.HeadersBestanden, Is.EqualTo(Statics.MockHeadersBestanden));
           
         }

        private void Helper(List<string> headerList)
        {
            // x = new List<string>() {"a", "b"};
            var str = new StringBuilder();
            str.Append("x = new List<string>() {");
            foreach (var header in headerList)
            {
                str.Append($"\"{header}\",");
            }
            str.Append("}\"");
            Console.WriteLine(str);
        }
    }
}
