using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
using Baghel.TIP.Core.Validations;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    internal class SellerLogTimesUnitTest
    {
        private SellerLogTimes sellerLogTimes;
        [SetUp]
        public void Init() {
            IValidate<Model> validate = (new ValidateSellerLogTimes(new CommonValidations()));
            sellerLogTimes = new SellerLogTimes(validate);
            sellerLogTimes.Error = new Baghel.TIP.Core.Model.Common.Error() { ErrorList = new Dictionary<string, string>() };

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
            sellerLogTimes.TransactionHeader = new TransactionHeader() { TransactionId = transactionIdentifier };
            //sellerLogTimes.TimeStamp = DateTime.Now;
            sellerLogTimes.ExternalComment = "Test Comment";
            sellerLogTimes.MediaOutlets = new List<MediaOutlet>
            {
                new MediaOutlet() { MediaOutletChannel = "RAVI", MediaOutletMarketName = "NYC", MediaOutletName = "RAVIC", MediaoutletReference = "RAVIR", MediaoutletType = "TV", MediaOutletIds = new List<Identifier>{new Identifier { Id = "", SrcId = "src", SrcName = "Srcname", Version = "ver" } }
            } };
            sellerLogTimes.Error = new Error() { ErrorList = new Dictionary<string, string>() };
            sellerLogTimes.Validate();
            Assert.That(sellerLogTimes.Error.ErrorList["TransactionHeader.TipVersion"], Is.EqualTo("tipVersion cannot be empty"));
        }
    }
}
