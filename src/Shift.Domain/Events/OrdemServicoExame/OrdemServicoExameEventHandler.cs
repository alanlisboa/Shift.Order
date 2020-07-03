using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Events.OrdemServicoExame
{
    public class OrdemServicoExameEventHandler :
        INotificationHandler<OrdemServicoExameAddedEvent>,
        INotificationHandler<OrdemServicoExameUpdatedEvent>,
        INotificationHandler<OrdemServicoExameRemovedEvent>
    {
        public Task Handle(OrdemServicoExameAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrdemServicoExameUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrdemServicoExameRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
