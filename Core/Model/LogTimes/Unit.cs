using Baghel.TIP.Core.Model.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public Advertiser Advertiser { get; set; }
        public Brand Brand { get; set; }
        public Product Product { get; set; }
        public SalesElementHeader SalesElementHeader { get; set; }
        /// <summary>
        /// This indicates the program the spot aired in -  'as-aired' information 
        /// </summary>
        public string Program { get; set; }
        /// <summary>
        /// This indicates the daypart the spot aired in -  'as-aired' information 
        /// </summary>
        public string Daypart { get; set; }
        /// <summary>
        /// Type of advertising such as a commercial, billboard or other types of advertisement
        /// </summary>
        public string InventoryType { get; set; }
        /// <summary>
        /// $0 (i.e., free) ad impressions/pricing that a publisher includes with paid media to maximize the overall proposal/order
        /// </summary>
        public bool IsBonus { get; set; }
        /// <summary>
        /// Length of commercial unit
        /// </summary>
        public int AiredLength { get; set; }
        /// <summary>
        /// Actual length of commerical unit 
        /// </summary>
        public int BooedLength { get; set; }
        /// <summary>
        /// Gross unit rate 
        /// </summary>
        public float Rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Creative Creative { get; set; }
        /// <summary>
        /// Indicated the airing status for the spot 
        ///Aired  = 'as-aired' reconciliation for the spot is complete
        ///No Run = spot either did not run or didn't run as contracted when the broadcast log was played out 
        ///Scheduled  = spot is placed on a pre log that has not yet been played out
        ///Finalized = spot is placed on a log that is in a 'final status' and ready to be played out and the spot is locked from edits
        ///Not Scheduled = spot has not yet been placed on a future broadcast log
        ///Preempted = spot has been removed from a future broadcast log; the buyer will be offered a makegood or issued a credit
        /// </summary>
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Indicate if the spot was issued a credit due to a discrepancy
        /// </summary>
        public bool IsCredit { get; set; }
        /// <summary>
        /// Array of TimePeriod objects indicating SalesElement ordered day and time period constraints 
        /// </summary>
        public List<TimePeriod> TimePeriods { get; set; }
        /// <summary>
        /// Not required when unit's status is "No Run"
        /// </summary>
        public Common.DateTime DateTime { get; set; }

        public List<ChildUnit> ChildUnits { get; set; }
    }
}
