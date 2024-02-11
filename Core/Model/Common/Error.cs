using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Defines errors returned from all APIs
    /// </summary>
    public class Error : Response
    {
        /// <summary>
        /// Gets or Sets ErrorCode
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Gets or Sets ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or Sets ErrorList
        /// </summary>
        public Dictionary<string, string> ErrorList { get; set; }
    }
}
