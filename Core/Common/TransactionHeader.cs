namespace Baghel.TIP.Core.Common
{
    /// <summary>
    /// General transaction header information
    /// </summary>
    public abstract class TransactionHeader
    {
        /// <summary>
        /// TIP version of the interface
        /// </summary>
        
        public string TipVersion { get; set; }
        /// <summary>
        /// Transaction identifier
        /// </summary>
        
        public TransactionIdentifier TransactionId { get; set; }
        /// <summary>
        /// Original Transaction identifier
        /// </summary>
        public TransactionIdentifier OriginalTransactionId { get; set; }
        /// <summary>
        /// Date and time the transaction was created - date-time represent UTC of the server. {"example": "2021-07-21T17:32:28Z"}
        /// </summary>
        
        public DateTime TimeStamp { get; set; }
    }
}
