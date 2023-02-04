using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Models
{
    public abstract class BaseEntity
    {
        protected BaseEntity() 
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        private List<Event> _domainEvents;
        public IReadOnlyCollection<Event> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent) 
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents() 
        {
            _domainEvents?.Clear();
        }
    }
}
