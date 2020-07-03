using Newtonsoft.Json;
using Shift.Core.Messaging;
using Shift.Data.Repositories.EventSourcing;
using Shift.Domain.Core.Events;

namespace Shift.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        
        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Application");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}