using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

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
            var transactionIdentifier = new Baghel.TIP.Core.Model.Common.TransactionIdentifier
            {
                TransactionId = "121212",
                SourceId = "123456789",
                TransactionType = TransactionType.New,
                SourceName = "Test"
            };
            sellerLogTimes.TransactionId = transactionIdentifier;
            sellerLogTimes.TimeStamp = DateTime.Now;
            sellerLogTimes.ExternalComment = "Test Comment";
            sellerLogTimes.MediaOutlets = new List<MediaOutlet>
            {
                new MediaOutlet() { MediaOutletChannel = "RAVI", MediaOutletMarketName = "NYC", MediaOutletName = "RAVIC", MediaoutletReference = "RAVIR", MediaoutletType = "TV", MediaOutletIds = new List<Identifier>{new Identifier { Id = "ID", SrcId = "src", SrcName = "Srcname", Version = "ver" } }
            } };
            string fileName = @"c:\temp\tip.json";
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            serializeOptions.Converters.Add(new JsonStringEnumConverter());
            string jsonString = JsonSerializer.Serialize(sellerLogTimes, serializeOptions);
            //string jsonString = JsonConvert.SerializeObject(sellerLogTimes, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
            
            Assert.IsTrue(File.Exists(@"c:\temp\tip.json"));

        }

        [Test]
        public void CheckXML()
        {
            var sellerLogTimes = new SellerLogTimes();
            sellerLogTimes.TipVersion = "6.0.0";
            var transactionIdentifier = new Baghel.TIP.Core.Model.Common.TransactionIdentifier
            {
                TransactionId = "121212",
                SourceId = "123456789",
                TransactionType = TransactionType.New,
                SourceName = "Test"
            };
            sellerLogTimes.TransactionId = transactionIdentifier;
            sellerLogTimes.TimeStamp = DateTime.Now;
            sellerLogTimes.ExternalComment = "Test Comment";
            sellerLogTimes.MediaOutlets = new List<MediaOutlet>
            {
                new MediaOutlet() { MediaOutletChannel = "RAVI", MediaOutletMarketName = "NYC", MediaOutletName = "RAVIC", MediaoutletReference = "RAVIR", MediaoutletType = "TV", MediaOutletIds = new List<Identifier>{new Identifier { Id = "ID", SrcId = "src", SrcName = "Srcname", Version = "ver" } }
            } };
            string fileName = @"c:\temp\tip.xml";
            
            
            var serializer = new XmlSerializer(typeof(SellerLogTimes));
            using var memoryStream = new MemoryStream();
            XmlTextWriter streamWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            streamWriter.Formatting = Formatting.Indented;
            
            serializer.Serialize(streamWriter, sellerLogTimes);

            var result = Encoding.UTF8.GetString(memoryStream.ToArray());
            File.WriteAllText(fileName, result);
            Assert.IsTrue(File.Exists(@"c:\temp\tip.xml"));

        }

    }
}
