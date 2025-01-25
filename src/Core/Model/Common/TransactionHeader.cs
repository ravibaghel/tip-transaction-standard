using System;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// General transaction header information
    /// </summary>

    public class TransactionHeader
    {
        private string _tipVersion;
        private TransactionIdentifier _transactionId;
        private System.DateTime _timeStamp;

        /// <summary>
        /// TIP version of the interface
        /// </summary>
        public string TipVersion
        {
            get { return _tipVersion; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    
                    throw new ArgumentException("TipVersion cannot be null or empty.");
                }
                _tipVersion = value;
            }
        }
        /// <summary>
        /// Transaction identifier
        /// </summary>

        public TransactionIdentifier TransactionId
        {
            get { return _transactionId; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(TransactionId), "TransactionId cannot be null.");
                }
                _transactionId = value;
            }
        }
        /// <summary>
        /// Original Transaction identifier
        /// </summary>
        public TransactionIdentifier OriginalTransactionId { get; set; }
        /// <summary>
        /// Date and time the transaction was created - date-time represent UTC of the server. {"example": "2021-07-21T17:32:28Z"}
        /// </summary>

        public System.DateTime TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(TimeStamp), "TimeStamp cannot be null.");
                }
                _timeStamp = value;
            }
        }

    }
}
