using Baghel.TIP.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Validations
{
    internal class ValidationLinker<T> : IValidate<T>
    {
        private readonly IValidate<T> _validator;

        public ValidationLinker(IValidate<T> validate)
        {
            _validator = validate;
        }

        public virtual void Validate(T model)
        {

            _validator.Validate(model);
        }
    }
}
