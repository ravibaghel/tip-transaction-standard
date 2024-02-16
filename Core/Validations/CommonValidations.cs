using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Validations
{
    internal abstract class CommonValidations
    {
        public void Validate(Model.Common.Model model, Error error)
        {
            if (string.IsNullOrEmpty(model.TransactionHeader.TipVersion)) error.ErrorList.Add("TransactionHeader.TipVersion", "tipVersion cannot be empty");
            if (string.IsNullOrEmpty(model.TransactionHeader.TransactionId.SourceId)) error.ErrorList.Add("TransactionHeader.TransactionId.SourceId", "SourceId cannot be empty");
            if (string.IsNullOrEmpty(model.TransactionHeader.TransactionId.SourceName)) error.ErrorList.Add("TransactionHeader.TransactionId.SourceName", "SourceName cannot be empty");
            if (model.TransactionHeader.TimeStamp.Equals(default(System.DateTime))) error.ErrorList.Add("TransactionHeader.TimeStamp", "Timestamp cannot be empty");

        }
    }
}
