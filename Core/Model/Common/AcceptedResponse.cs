using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Defines successful return from all APIs
    /// </summary>
    public class AcceptedResponse
    {
        /// <summary>
        /// Gets or Sets TransactionId
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// Gets or Sets TimeStamp
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
