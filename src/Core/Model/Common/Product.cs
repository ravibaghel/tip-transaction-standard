using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Product category information
    /// </summary>
    public class Product
    {
        private List<Identifier> _productIds;
        private string _productName;
        /// <summary>
        /// Array of identifier objects used to identify the product id and its source system
        /// </summary>
        public List<Identifier> ProductIds
        {
            get { return _productIds; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("ProductIds cannot be null or empty.");
                }
                _productIds = value;
            }
        }
        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ProductName cannot be null or empty.");
                }
                _productName = value;
            }
        }
        /// <summary>
        /// External product reference name
        /// </summary>
        public string ProductReference { get; set; }
    }
}
