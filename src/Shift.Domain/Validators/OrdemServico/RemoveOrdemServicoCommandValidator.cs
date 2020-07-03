using Shift.Domain.Commands.OrdemServico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServico
{
    public class RemoveOrdemServicoCommandValidator : OrdemServicoValidator<RemoveOrdemServicoCommand>
    {
        public RemoveOrdemServicoCommandValidator()
        {
            ValidateId();
        }
    }
}
