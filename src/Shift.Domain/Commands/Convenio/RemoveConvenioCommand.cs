using Shift.Domain.Validators.Convenio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.Convenio
{
    public class RemoveConvenioCommand : ConvenioCommand
    {
        public RemoveConvenioCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveConvenioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
