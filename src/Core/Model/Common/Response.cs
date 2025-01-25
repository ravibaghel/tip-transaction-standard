using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    public abstract class Response
    {
        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
