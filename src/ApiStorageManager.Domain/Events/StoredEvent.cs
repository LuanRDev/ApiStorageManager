using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data) 
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
        }

        public Guid Id { get; private set; }
        public string Data { get; private set; }

    }
}
