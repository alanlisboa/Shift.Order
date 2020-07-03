using Shift.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift.Domain.Events.Convenio
{
    public class ConvenioRemovedEvent : Event
    {
        public ConvenioRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
