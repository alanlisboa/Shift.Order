using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Events.OrdemServicoExame
{
    public class OrdemServicoExameAddedEvent : Event
    {
        public OrdemServicoExameAddedEvent(Guid id, Guid ordemId, Guid exameId, double valor)
        {
            Id = id;
            OrdemServicoId = ordemId;
            ExameId = exameId;
            Valor = valor;
        }

        public Guid Id { get; protected set; }
        public Guid OrdemServicoId { get; protected set; }
        public Guid ExameId { get; set; }
        public double Valor { get; set; }
    }
}
