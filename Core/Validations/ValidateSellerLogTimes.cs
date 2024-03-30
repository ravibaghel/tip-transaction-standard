using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
namespace Baghel.TIP.Core.Validations
{
    internal class ValidateSellerLogTimes : ValidationLinker<SellerLogTimes>
    {
        public ValidateSellerLogTimes(IValidate<SellerLogTimes> validate) : base(validate)
        {
        }
        public override void Validate(SellerLogTimes model)
        {
            base.Validate(model);
            var sellerLogTimes = model;
            if (sellerLogTimes.MediaOutlets == null) model.Error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
            else if (sellerLogTimes.MediaOutlets.Count == 0) model.Error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
            else {
                CommonValidations.ValidateMediaOutlets(sellerLogTimes.MediaOutlets, model.Error);
            }
            if (sellerLogTimes.Units == null) model.Error.ErrorList.Add("units", "units cannot be empty");
            else if(sellerLogTimes.Units.Count==0) model.Error.ErrorList.Add("units", "units cannot be empty");
        }

    }
}
