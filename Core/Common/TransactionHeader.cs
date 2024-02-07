using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required(ErrorMessage ="TIP version of the interface")]
        public string TipVersion { get; set; }
        /// <summary>
        /// Transaction identifier
        /// </summary>
        [Required(ErrorMessage ="Transaction identifier is required")]
        public TransactionIdentifier TransactionId { get; set; }
        /// <summary>
        /// Original Transaction identifier
        /// </summary>
        public TransactionIdentifier OriginalTransactionId { get; set; }
        /// <summary>
        /// Date and time the transaction was created - date-time represent UTC of the server. {"example": "2021-07-21T17:32:28Z"}
        /// </summary>
        [Required(ErrorMessage ="TimeStamp field is required")]
        public DateTime TimeStamp { get; set; }
    }
}
