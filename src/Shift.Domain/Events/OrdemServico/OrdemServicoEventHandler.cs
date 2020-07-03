using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shift.Domain.Events.OrdemServico
{
    public class OrdemServicoEventHandler :
        INotificationHandler<OrdemServicoAddedEvent>,
        INotificationHandler<OrdemServicoUpdatedEvent>,
        INotificationHandler<OrdemServicoRemovedEvent>
    {
        public Task Handle(OrdemServicoAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrdemServicoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrdemServicoRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
