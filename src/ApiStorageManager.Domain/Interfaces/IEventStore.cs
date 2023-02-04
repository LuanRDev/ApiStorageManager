using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
