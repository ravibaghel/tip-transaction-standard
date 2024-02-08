using Baghel.TIP.Core.Common;

namespace Baghel.TIP.Core.LogTimes
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
        public IList<MediaOutlet> MediaOutlets { get; set; }
    }
}
