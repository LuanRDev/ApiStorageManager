using MediatR;

namespace ApiStorageManager.Domain.Events
{
    public class FileEventHandler :
        INotificationHandler<FileUploadedEvent>,
        INotificationHandler<FileUpdatedEvent>,
        INotificationHandler<FileDeletedEvent>
    {
        public Task Handle(FileUploadedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FileUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FileDeletedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
