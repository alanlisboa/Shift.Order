using Shift.Domain.Commands.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServicoExame
{
    public class UpdateOrdemServicoExameCommandValidator : OrdemServicoExameValidator<UpdateOrdemServicoExameCommand>
    {
        public UpdateOrdemServicoExameCommandValidator()
        {
            ValidateId();
            ValidateExame();
            ValidateOrdem();
            ValidateValor();
        }
    }
}
