using Shift.Domain.Commands.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Validators.OrdemServicoExame
{
    public class AddNewOrdemServicoExameCommandValidatior : OrdemServicoExameValidator<AddOrdemServicoExameCommand>
    {
        public AddNewOrdemServicoExameCommandValidatior()
        {
            ValidateExame();
            ValidateOrdem();
            ValidateValor();
        }
    }
}
