using Shift.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}