namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Transaction identifier details
    /// </summary>
    public struct TransactionIdentifier
    {
        /// <summary>
        /// Global unique identifier (GUID). {"format":"uuid", "example":"1C237FDD-940D-499E-AA20-DF3B9CE0908E"}
        /// </summary>

        public string TransactionId { get; set; }
        /// <summary>
        /// Indicates the transaction type. New, Change, Cancel, Reject, Recall, Confirm 
        /// </summary>

        public TransactionType TransactionType { get; set; }
        /// <summary>
        /// Indicates the unique identifier of the source of information from an external system 
        /// </summary>

        public string SourceId { get; set; }
        /// <summary>
        /// Indicates the name of the source of information from an external system 
        /// </summary>

        public string SourceName { get; set; }

        
    }
}
