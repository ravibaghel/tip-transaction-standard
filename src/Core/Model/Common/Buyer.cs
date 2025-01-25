using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Buy-side organization information
    /// </summary>
    public class Buyer
    {
        private List<Identifier> _buyerIds;
        private string _buyerName;
        /// <summary>
        /// Array of identifier objects used to identify the buyer id and it source system
        /// </summary>
        public List<Identifier> BuyerIds
        {
            get { return _buyerIds; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("BuyerIds cannot be null or empty.");
                }
                _buyerIds = value;
            }
        }
        /// <summary>
        /// Buying organization name  
        /// </summary>
        public string BuyerName
        {
            get { return _buyerName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("BuyerName cannot be null or empty.");
                }
                _buyerName = value;
            }
        }
        /// <summary>
        /// External buyer reference Name
        /// </summary>
        public string BuyerReference { get; set; }
    }
}
