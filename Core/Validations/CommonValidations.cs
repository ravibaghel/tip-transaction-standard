using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Validations
{
    internal class CommonValidations: IValidate<SellerLogTimes>
    {
        public void Validate(SellerLogTimes model)
        {
            if (string.IsNullOrEmpty(model.TransactionHeader.TipVersion)) model.Error.ErrorList.Add("TransactionHeader.TipVersion", "tipVersion cannot be empty");
            if (string.IsNullOrEmpty(model.TransactionHeader.TransactionId.SourceId)) model.Error.ErrorList.Add("TransactionHeader.TransactionId.SourceId", "SourceId cannot be empty");
            if (string.IsNullOrEmpty(model.TransactionHeader.TransactionId.SourceName)) model.Error.ErrorList.Add("TransactionHeader.TransactionId.SourceName", "SourceName cannot be empty");
            if (model.TransactionHeader.TimeStamp.Equals(default(System.DateTime))) model.Error.ErrorList.Add("TransactionHeader.TimeStamp", "Timestamp cannot be empty");
        }

        
    }
}
