using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Events.Convenio
{
    public class ConvenioEventHandler :
        INotificationHandler<ConvenioAddedEvent>,
        INotificationHandler<ConvenioUpdatedEvent>,
        INotificationHandler<ConvenioRemovedEvent>
    {
        public Task Handle(ConvenioAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ConvenioUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ConvenioRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
