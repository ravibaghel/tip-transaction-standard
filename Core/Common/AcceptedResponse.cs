using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Common
{
    /// <summary>
    /// Defines successful return from all APIs
    /// </summary>
    public class AcceptedResponse
    {
        public string TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
