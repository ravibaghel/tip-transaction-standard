using Baghel.TIP.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Unit detail information 
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Seller generated unique number for unit (ID will likely change if unit is moved to another week during recon process).
        /// </summary>
        public string UnitId { get; set; }
        /// <summary>
        /// Array of ReferenceId objects containing the order id references; may also contain originating RFP and Proposal id and source references 
        /// </summary>
        public List<ReferenceIdentifier> ReferenceIds { get; set; }
        /// <summary>
        /// Array of identifier objects to identify a line id and system source; note- once the identifier object has been adopted the goal is to remove existing lineNum and lineReference
        /// </summary>
        public List<Identifier> LineReferences { get; set; }
        public CpeCode CpeCode { get; set; }
        public Buyer Buyer { get; set; }
    }
}
