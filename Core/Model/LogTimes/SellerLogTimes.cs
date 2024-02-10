using Baghel.TIP.Core.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Allows the seller to send to the buyer the log times information. No Request from buyer is required.
    /// </summary>
    public class SellerLogTimes : TransactionHeader
    {
        /// <summary>
        /// String that indicates additional information the seller can send to the buyer
        /// </summary>
        public string ExternalComment { get; set; }
        /// <summary>
        /// Array of MediaOutlet objects  
        /// </summary>
        public List<MediaOutlet> MediaOutlets { get; set; }

       
    }
}
