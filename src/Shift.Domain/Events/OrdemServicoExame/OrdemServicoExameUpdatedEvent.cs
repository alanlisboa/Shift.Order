using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Events.OrdemServicoExame
{
    public class OrdemServicoExameUpdatedEvent : Event
    {
        public OrdemServicoExameUpdatedEvent(Guid id, Guid ordemId, Guid exameId, double valor)
        {
            Id = id;
            OrdemServicoId = ordemId;
            ExameId = exameId;
            Valor = valor;
        }

        public Guid Id { get; protected set; }
        public Guid OrdemServicoId { get; protected set; }
        public Guid ExameId { get; protected set; }
        public double Valor { get; protected set; }
    }
}
