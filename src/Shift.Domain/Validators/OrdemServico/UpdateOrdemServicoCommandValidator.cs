using Shift.Domain.Commands.OrdemServico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServico
{
    public class UpdateOrdemServicoCommandValidator : OrdemServicoValidator<UpdateOrdemServicoCommand>
    {
        public UpdateOrdemServicoCommandValidator()
        {
            ValidateId();
            ValidateMedico();
            ValidateConvenio();
            ValidateDataOrdem();
            ValidatePostoColeta();
        }
    }
}
