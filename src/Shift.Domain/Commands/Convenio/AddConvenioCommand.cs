using Shift.Domain.Validators.Convenio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.Convenio
{
    public class AddConvenioCommand : ConvenioCommand
    {
        public AddConvenioCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewConvenioCommandValidatior().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
