using Baghel.TIP.Core.LogTimes;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    internal class WriteTest
    {
        [Test]
        public void CheckJSON()
        {
            var sellerLogTimes = new SellerLogTimes();
            //sellerLogTimes.TipVersion = "6.0.0";
            var transactionIdentifier = new Baghel.TIP.Core.Common.TransactionIdentifier();
            transactionIdentifier.TransactionId = "121212";
            transactionIdentifier.SourceId = "123456789";
            transactionIdentifier.TransactionType = Baghel.TIP.Core.Common.TransactionType.New;
            transactionIdentifier.SourceName = "Test";
            sellerLogTimes.TransactionId = transactionIdentifier;
            sellerLogTimes.TimeStamp = DateTime.Now;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());

            using StreamWriter sw = new StreamWriter(@"c:\temp\json.json");
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, sellerLogTimes);
            Assert.IsTrue(File.Exists(@"c:\temp\json.json"));

        }

    }
}
