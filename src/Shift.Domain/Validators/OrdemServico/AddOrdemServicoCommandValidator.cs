using Shift.Domain.Commands.OrdemServico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServico
{
    public class AddNewOrdemServicoCommandValidatior : OrdemServicoValidator<AddOrdemServicoCommand>
    {
        public AddNewOrdemServicoCommandValidatior()
        {
            ValidateMedico();
            ValidateConvenio();
            ValidateDataOrdem();
            ValidatePostoColeta();
        }
    }
}
