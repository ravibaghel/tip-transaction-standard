using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Validations
{
    public interface IValidate<T>
    {
        public void Validate(T model);


    }
}
