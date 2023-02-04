using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Events
{
    public class FileDeletedEvent : Event
    {
        public FileDeletedEvent(Guid id) 
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
