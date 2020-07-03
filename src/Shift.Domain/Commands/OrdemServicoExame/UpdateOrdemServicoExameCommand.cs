using Shift.Domain.Validators.OrdemServicoExame;
using System;

namespace Shift.Domain.Commands.OrdemServicoExame
{
    public class UpdateOrdemServicoExameCommand : OrdemServicoExameCommand
    {
        public UpdateOrdemServicoExameCommand(Guid id, Guid ordemId, Guid exameId, double valor)
        {
            Id = id;
            OrdemServicoId = ordemId;
            ExameId = exameId;
            Valor = valor;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrdemServicoExameCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
