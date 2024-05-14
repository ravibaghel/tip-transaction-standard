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
        private int _errorCode;
        private string _errorMessage;
        /// <summary>
        /// Gets or Sets ErrorCode
        /// </summary>
        public int ErrorCode
        {
            get { return _errorCode; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ErrorCode must be a positive integer.");
                }
                _errorCode = value;
            }
        }
        /// <summary>
        /// Gets or Sets ErrorMessage
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ErrorMessage cannot be null or empty.");
                }
                _errorMessage = value;
            }
        }
        /// <summary>
        /// Gets or Sets ErrorList
        /// </summary>
        public Dictionary<string, string> ErrorList { get; set; }
    }
}
