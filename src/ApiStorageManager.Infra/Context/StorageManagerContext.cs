using ApiStorageManager.Domain.Interfaces;
using ApiStorageManager.Infra.Mediator;

namespace ApiStorageManager.Infra.Context
{
    /*public class StorageManagerContext : IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public StorageManagerContext(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Commit()
        {
            await _mediatorHandler.PublishDomainEvents().ConfigureAwait(false);

            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents(this IMediatorHandler mediator)
        {
            var domainEntities = ctx.ChangeTracker
                 .Entries<Entity>()
                 .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }*/
}
