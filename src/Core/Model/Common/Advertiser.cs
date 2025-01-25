using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Advertiser information
    /// </summary>
    public class Advertiser
    {
        private List<Identifier> _advertiserIds;
        private string _advertiserName;
        /// <summary>
        /// Array of identifier objects used to identify the advertiser id and its source system 
        /// </summary>
        public List<Identifier> AdvertiserIds
        {
            get { return _advertiserIds; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("AdvertiserIds cannot be null or empty.");
                }
                _advertiserIds = value;
            }
        }
        /// <summary>
        /// Advertiser name
        /// </summary>
        public string AdvertiserName
        {
            get { return _advertiserName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("AdvertiserName cannot be null or empty.");
                }
                _advertiserName = value;
            }
        }
        /// <summary>
        /// External advertiser reference to support data mapping differences between systems 
        /// </summary>
        public string AdvertiserReference { get; set; }

        
    }
}
