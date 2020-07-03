using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Events.OrdemServicoExame
{
    public class OrdemServicoExameRemovedEvent : Event
    {
        public OrdemServicoExameRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
