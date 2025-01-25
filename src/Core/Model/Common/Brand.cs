using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Advertising brand information
    /// </summary>
    public class Brand
    {
        private List<Identifier> _brandIds;
        private string _brandName;
        /// <summary>
        /// Array of identifier objects used to identify the brand id and its source system 
        /// </summary>
        public List<Identifier> BrandIds
        {
            get { return _brandIds; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("BrandIds cannot be null or empty.");
                }
                _brandIds = value;
            }
        }
        /// <summary>
        /// Brand Name
        /// </summary>
        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("BrandName cannot be null or empty.");
                }
                _brandName = value;
            }
        }
        /// <summary>
        /// External brand reference name
        /// </summary>
        public string BrandReference { get; set; }
    }
}
