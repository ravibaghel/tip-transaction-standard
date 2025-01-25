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
    public class AcceptedResponse : Response
    {
        private string _transactionId;
        private DateTime _timeStamp;
        /// <summary>
        /// Gets or Sets TransactionId
        /// </summary>
        public string TransactionId
        {
            get { return _transactionId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("TransactionId cannot be null or empty.");
                }
                _transactionId = value;
            }
        }
        /// <summary>
        /// Gets or Sets TimeStamp
        /// </summary>
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("TimeStamp cannot be null.");
                }
                _timeStamp = value;
            }
        }
    }
}
