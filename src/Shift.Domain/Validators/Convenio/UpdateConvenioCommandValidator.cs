using Shift.Domain.Commands.Convenio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.Convenio
{
    public class UpdateConvenioCommandValidator : ConvenioValidator<UpdateConvenioCommand>
    {
        public UpdateConvenioCommandValidator()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
