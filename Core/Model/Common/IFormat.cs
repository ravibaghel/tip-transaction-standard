using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    internal interface IFormat<T>
    {
        string ToJSON();
        T FromJSON(string json);
    }
}
