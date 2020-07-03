using Shift.Domain.Validators.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServicoExame
{
    public class AddOrdemServicoExameCommand : OrdemServicoExameCommand
    {
        public AddOrdemServicoExameCommand(Guid ordemId, Guid exameId, double valor)
        {
            OrdemServicoId = ordemId;
            ExameId = exameId;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewOrdemServicoExameCommandValidatior().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
