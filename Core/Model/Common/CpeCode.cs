using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Packages the buyer's client code, product code and estimate codes
    /// </summary>
    public struct CpeCode
    {
        /// <summary>
        /// Client code provided from the buyer
        /// </summary>
        public string ClientCode { get; set; }
        /// <summary>
        /// Product code provided from the buyer
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// Estimate code provided from the buyer
        /// </summary>
        public string EstimateCode { get; set; }

    }
}
