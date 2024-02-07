using Baghel.TIP.Core.LogTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            sellerLogTimes.TipVersion = "6.0.0";
            var transactionIdentifier = new Baghel.TIP.Core.Common.TransactionIdentifier();
            transactionIdentifier.TransactionId = "121212";
            transactionIdentifier.SourceId = "123456789";
            transactionIdentifier.TransactionType = Baghel.TIP.Core.Common.TransactionType.New;
            transactionIdentifier.SourceName = "Test";
            sellerLogTimes.TransactionId = transactionIdentifier;
            sellerLogTimes.TimeStamp = DateTime.Now;
            string fileName = @"c:\temp\tip.json";
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(sellerLogTimes,serializeOptions);
            File.WriteAllText(fileName, jsonString);
            Assert.IsTrue(File.Exists(@"c:\temp\tip.json"));

        }

    }
}
