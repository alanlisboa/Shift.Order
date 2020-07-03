using Shift.Domain.Validators.OrdemServico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServico
{
    public class RemoveOrdemServicoCommand : OrdemServicoCommand
    {
        public RemoveOrdemServicoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrdemServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
