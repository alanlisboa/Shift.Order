using Shift.Core.Domain;
using System;
using System.Collections.Generic;

namespace Shift.Domain.Models
{
    public class OrdemServico : Entity, IAggregateRoot
    {
        public OrdemServico(Guid id, int numero, DateTime data, Guid pacienteId, Guid convenioId, Guid postoId, Guid medicoId)
        {
            Id = id;
            Numero = numero;
            DataOrdem = data;
            PacienteId = pacienteId;
            ConvenioId = convenioId;
            PostoColetaId = postoId;
            MedicoId = medicoId;
        }

        public OrdemServico()
        {
        }

        public int Numero { get; private set; }
        public DateTime DataOrdem { get; private set; }
        public Guid PacienteId { get; private set; }
        public Paciente Paciente { get; private set; }
        public Guid ConvenioId { get; private set; }
        public virtual Convenio Convenio { get; private set; }
        public Guid PostoColetaId { get; set; }
        public virtual PostoColeta PostoColeta { get; private set; }
        public Guid MedicoId { get; private set; }
        public virtual Medico Medico { get; private set; }
        public virtual ICollection<OrdemServicoExame> Exames { get; private set; }
    }
}
