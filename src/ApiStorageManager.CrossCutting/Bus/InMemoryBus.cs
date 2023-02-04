using ApiStorageManager.Domain.Interfaces;
using ApiStorageManager.Domain.Models.Messaging;
using ApiStorageManager.Infra.Mediator;
using FluentValidation.Results;
using MediatR;

namespace ApiStorageManager.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        } 
        
        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if(!@event.MessageType.Equals("DomainNotification"))
                _eventStore.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
