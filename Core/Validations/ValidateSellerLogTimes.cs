using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
namespace Baghel.TIP.Core.Validations
{
    internal class ValidateSellerLogTimes : IValidate<SellerLogTimes>
    {
        public void Validate(SellerLogTimes model)
        {
            var error = new Error();
            error.ErrorList = new Dictionary<string, string>();
            if(string.IsNullOrEmpty(model.TipVersion))error.ErrorList.Add("tipVersion", "tipVersion cannot be empty");
            model.Response = error;
            
        }
    }
}
