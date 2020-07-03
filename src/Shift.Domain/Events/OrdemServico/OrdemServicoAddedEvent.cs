using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Events.OrdemServico
{
    public class OrdemServicoAddedEvent : Event
    {
        public OrdemServicoAddedEvent(Guid id, int numero, DateTime data, Guid pacienteId, Guid convenioId, Guid postoId, Guid medicoId)
        {
            Id = id;
            Numero = numero;
            DataOrdem = data;
            PacienteId = pacienteId;
            ConvenioId = convenioId;
            PostoColetaId = postoId;
            MedicoId = medicoId;
        }

        public Guid Id { get; protected set; }
        public int Numero { get; protected set; }
        public DateTime DataOrdem { get; protected set; }
        public Guid PacienteId { get; protected set; }
        public Guid ConvenioId { get; protected set; }
        public Guid PostoColetaId { get; protected set; }
        public Guid MedicoId { get; protected set; }
    }
}
