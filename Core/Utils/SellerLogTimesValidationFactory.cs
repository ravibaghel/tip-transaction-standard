using Baghel.TIP.Core.Model.LogTimes;
using Baghel.TIP.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Utils
{
    internal class SellerLogTimesValidationFactory : IFactoryValidation<SellerLogTimes>
    {
        public IValidate<SellerLogTimes> Create()
        {
            
            return new ValidateSellerLogTimes(new SellerLogTimesCommonValidations());
        }

    }
}
