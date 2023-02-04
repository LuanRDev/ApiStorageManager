using ApiStorageManager.Domain.Models.Messaging;
using FluentValidation.Results;

namespace ApiStorageManager.Infra.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
