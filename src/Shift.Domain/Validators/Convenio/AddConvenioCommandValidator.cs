using Shift.Domain.Commands.Convenio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.Convenio
{
    public class AddNewConvenioCommandValidatior : ConvenioValidator<AddConvenioCommand>
    {
        public AddNewConvenioCommandValidatior()
        {
            ValidateNome();
        }
    }
}
