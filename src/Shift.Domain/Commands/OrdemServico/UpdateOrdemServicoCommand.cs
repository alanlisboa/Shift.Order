using Shift.Domain.Validators.OrdemServico;
using System;

namespace Shift.Domain.Commands.OrdemServico
{
    public class UpdateOrdemServicoCommand : OrdemServicoCommand
    {
        public UpdateOrdemServicoCommand(Guid id, DateTime data, int numero, Guid pacienteId, Guid convenioId, Guid postoId, Guid medicoId)
        {
            Id = id;
            DataOrdem = data;
            Numero = numero;
            PacienteId = pacienteId;
            ConvenioId = convenioId;
            PostoColetaId = postoId;
            MedicoId = medicoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrdemServicoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
