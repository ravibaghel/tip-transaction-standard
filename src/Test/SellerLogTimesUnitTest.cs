using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
using NUnit.Framework.Internal;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Test
{
    [TestFixture]
    internal class SellerLogTimesUnitTest
    {
        private SellerLogTimes sellerLogTimes;
        [SetUp]
        public void Init() {
            //IValidate<Model> validate = (new ValidateSellerLogTimes(new CommonValidations()));
            sellerLogTimes = new SellerLogTimes();
            //sellerLogTimes.Error = new Baghel.TIP.Core.Model.Common.Error() { ErrorList = new Dictionary<string, string>() };
            //SellerLogTimesValidator sellerLogTimesValidator = new SellerLogTimesValidator();

        }
        [Test]
        public void IsValid() {
            var transactionIdentifier = new Baghel.TIP.Core.Model.Common.TransactionIdentifier
            {
                TransactionId = "121212",
                SourceId = "123456789",
                //TransactionType = TransactionType.New,
                SourceName = "Test"
            };
            sellerLogTimes.TransactionHeader = new TransactionHeader() { TransactionId = transactionIdentifier, TipVersion = "6.0" };
            //sellerLogTimes.TimeStamp = DateTime.Now;
            sellerLogTimes.ExternalComment = "Test Comment";
            sellerLogTimes.MediaOutlets = new List<MediaOutlet>
            {
                new MediaOutlet() { MediaOutletChannel = "RAVI", MediaOutletMarketName = "NYC", MediaOutletName = "RAVIC", MediaoutletReference = "RAVIR", MediaOutletType = "TV" }
            } ;
            //sellerLogTimes.Error = new Error() { ErrorList = new Dictionary<string, string>() };
            //sellerLogTimes.Validate();
            Assert.That(sellerLogTimes.TransactionHeader.TipVersion, Is.EqualTo("6.0"));
        }

        [Test]
        public void IsJSON()
        {
            var transactionIdentifier = new Baghel.TIP.Core.Model.Common.TransactionIdentifier
            {
                TransactionId = "121212",
                SourceId = "123456789",
                //TransactionType = TransactionType.New,
                SourceName = "Test"
            };
            sellerLogTimes.TransactionHeader = new TransactionHeader() { TransactionId = transactionIdentifier };
            //sellerLogTimes.TimeStamp = DateTime.Now;
            sellerLogTimes.ExternalComment = "Test Comment";
            sellerLogTimes.MediaOutlets = new List<MediaOutlet>
            {
                new MediaOutlet() {MediaOutletIds = new List<Identifier>{new Identifier { Id = "validId", SrcId = "src", SrcName = "Srcname", Version = "ver" }} ,MediaOutletChannel = "RAVI", MediaOutletMarketName = "NYC", MediaOutletName = "RAVIC", MediaoutletReference = "RAVIR", MediaOutletType = "TV" }
            };
            //sellerLogTimes.Error = new Error() { ErrorList = new Dictionary<string, string>() };
            //sellerLogTimes.Validate();
            Assert.IsNotEmpty(ToJson(sellerLogTimes));
        }

        [Test]
        public void LoadFromJSON()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var sellerLogTimes = JsonSerializer.Deserialize<SellerLogTimes>(File.ReadAllText(@"c:\temp\sample.json"), options);

            Assert.IsInstanceOf(typeof(SellerLogTimes),
                                sellerLogTimes);
        }

        private string ToJson(object obj)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
