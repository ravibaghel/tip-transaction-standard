using Baghel.TIP.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Utils
{
    public interface IFactoryValidation<T>
    {
        IValidate<T> Create();
    }
}
