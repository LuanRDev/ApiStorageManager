using ApiStorageManager.Application.Interfaces;
using ApiStorageManager.Application.Services;
using ApiStorageManager.Domain.Commands;
using ApiStorageManager.Domain.Events;
using ApiStorageManager.Domain.Interfaces;
using ApiStorageManager.CrossCutting.Bus;
using ApiStorageManager.Infra.Mediator;
using ApiStorageManager.Infra.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ApiStorageManager.Infra.Repositories.EventSourcing;
using ApiStorageManager.Infra.Data;
using ApiStorageManager.Infra.Context;

namespace ApiStorageManager.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IFileAppService, FileAppService>();

            services.AddScoped<INotificationHandler<FileUploadedEvent>, FileEventHandler>();
            services.AddScoped<INotificationHandler<FileUpdatedEvent>, FileEventHandler>();
            services.AddScoped<INotificationHandler<FileDeletedEvent>, FileEventHandler>();

            services.AddScoped<IRequestHandler<UploadNewFileCommand, ValidationResult>, FileCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateFileCommand, ValidationResult>, FileCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteFileCommand, ValidationResult>, FileCommandHandler>();

            services.AddScoped<IFileRepository, FileRepository>();

            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}
