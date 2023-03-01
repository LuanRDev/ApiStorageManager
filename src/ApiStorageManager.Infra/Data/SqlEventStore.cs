using ApiStorageManager.Domain.Events;
using ApiStorageManager.Domain.Interfaces;
using ApiStorageManager.Domain.Models.Messaging;
using ApiStorageManager.Infra.Repositories.EventSourcing;
using Newtonsoft.Json;

namespace ApiStorageManager.Infra.Data
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task Save<T>(T theEvent) where T : Event 
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData
                );
            _eventStoreRepository.Store(storedEvent);
        }
    }
}
