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
    public struct Advertiser
    {
        /// <summary>
        /// Array of identifier objects used to identify the advertiser id and its source system 
        /// </summary>
        public List<Identifier> AdvertiserIds { get; set; }
        /// <summary>
        /// Advertiser name
        /// </summary>
        public string AdvertiserName { get; set; }
        /// <summary>
        /// External advertiser reference to support data mapping differences between systems 
        /// </summary>
        public string AdvertiserReference { get; set; }

        
    }
}
