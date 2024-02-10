using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Buy-side organization information
    /// </summary>
    public struct Buyer
    {
        /// <summary>
        /// Array of identifier objects used to identify the buyer id and it source system
        /// </summary>
        public List<Identifier> BuyerIds { get; set; }
        /// <summary>
        /// Buying organization name  
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// External buyer reference Name
        /// </summary>
        public string BuyerReference { get; set; }
    }
}
