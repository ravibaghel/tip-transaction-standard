using Baghel.TIP.Core.Model.Common;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Allows the seller to send to the buyer the log times information. No Request from buyer is required.
    /// </summary>
    public class SellerLogTimes : Response
    {
        private TransactionHeader _transactionHeader;
        private List<MediaOutlet> _mediaOutlets;
        private List<Unit> _units;
       
        public TransactionHeader TransactionHeader
        {
            get { return _transactionHeader; }
            set
            {
                if (value == null)
                {
                    Errors.Add("TransactionHeader cannot be null.");
                    throw new ArgumentNullException(nameof(TransactionHeader), "TransactionHeader cannot be null.");
                }
                _transactionHeader = value;
            }
        }
        /// <summary>
        /// String that indicates additional information the seller can send to the buyer
        /// </summary>
        public string ExternalComment { get; set; }
        /// <summary>
        /// Array of MediaOutlet objects  
        /// </summary>
        public List<MediaOutlet> MediaOutlets
        {
            get { return _mediaOutlets; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("MediaOutlets cannot be null or empty.", nameof(MediaOutlets));
                }
                _mediaOutlets = value;
            }
        }
        /// <summary>
        /// Units listed in the API units can be defined by the system that is creating the API. 
        /// </summary>
        public List<Unit> Units
        {
            get { return _units; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("Units cannot be null or empty.", nameof(Units));
                }
                _units = value;
            }
        }

    }
}
