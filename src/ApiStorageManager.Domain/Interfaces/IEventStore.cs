using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Interfaces
{
    public interface IEventStore
    {
        Task Save<T>(T theEvent) where T : Event;
    }
}
