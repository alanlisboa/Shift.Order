using Shift.Domain.Validators.OrdemServico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Commands.OrdemServico
{
    public class AddOrdemServicoCommand : OrdemServicoCommand
    {
        public AddOrdemServicoCommand(DateTime data, int numero, Guid pacienteId, Guid convenioId, Guid postoId, Guid medicoId)
        {
            DataOrdem = data;
            Numero = numero;
            PacienteId = pacienteId;
            ConvenioId = convenioId;
            PostoColetaId = postoId;
            MedicoId = medicoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewOrdemServicoCommandValidatior().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
