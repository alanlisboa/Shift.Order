using Shift.Domain.Validators.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServicoExame
{
    public class RemoveOrdemServicoExameCommand : OrdemServicoExameCommand
    {
        public RemoveOrdemServicoExameCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrdemServicoExameCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
