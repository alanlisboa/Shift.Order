using Shift.Domain.Commands.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServicoExame
{
    public class RemoveOrdemServicoExameCommandValidator : OrdemServicoExameValidator<RemoveOrdemServicoExameCommand>
    {
        public RemoveOrdemServicoExameCommandValidator()
        {
            ValidateId();
        }
    }
}
