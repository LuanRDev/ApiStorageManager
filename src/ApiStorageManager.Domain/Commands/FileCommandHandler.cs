﻿using ApiStorageManager.Domain.Models.Messaging;
using FluentValidation.Results;
using MediatR;
using File = ApiStorageManager.Domain.Models.File;
using ApiStorageManager.Domain.Events;
using ApiStorageManager.Domain.Interfaces;

namespace ApiStorageManager.Domain.Commands
{
    public class FileCommandHandler : CommandHandler,
        IRequestHandler<UploadNewFileCommand, ValidationResult>,
        IRequestHandler<DeleteFileCommand, ValidationResult>,
        IRequestHandler<UpdateFileCommand, ValidationResult>
    {
        private readonly IFileRepository _fileRepository;

        public FileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<ValidationResult> Handle(UploadNewFileCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var file = new File(Guid.NewGuid(), message.Name, message.Empresa, message.CodigoEvento, message.UrlAddress, message.Meta, message.Type, message.Extension, message.Bytes);

            if(await _fileRepository.GetById(file.Id, file.Empresa, file.CodigoEvento) != null) 
            {
                AddError("The file has already been sent, please use the Update method.");
                return ValidationResult;
            }

            file.AddDomainEvent(new FileUploadedEvent(file.Id, file.Name, file.Meta, file.Type, file.Extension, file.Bytes));

            _fileRepository.Add(file);

            return await Commit(_fileRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateFileCommand message, CancellationToken cancellationToken)
        {
            if(!message.IsValid()) return message.ValidationResult;

            var file = new File(Guid.NewGuid(), message.Name, message.Empresa, message.CodigoEvento, message.UrlAddress, message.Meta, message.Type, message.Extension, message.Bytes);
            var existingFile = await _fileRepository.GetById(file.Id, file.Empresa, file.CodigoEvento);

            if(existingFile != null & existingFile.Id != file.Id)
            {
                if (!existingFile.Equals(file))
                {
                    AddError("The file has already been sent.");
                    return ValidationResult;
                }
            }

            file.AddDomainEvent(new FileUpdatedEvent(file.Id, file.Name, file.Meta, file.Type, file.Extension, file.Bytes));

            _fileRepository.Update(file);

            return await Commit(_fileRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteFileCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var file = await _fileRepository.GetById(message.Id, message.Empresa, message.CodigoEvento);

            if(file is null) 
            {
                AddError("The file doesn´t exists.");
            }

            file.AddDomainEvent(new FileDeletedEvent(message.Id));

            _fileRepository.Delete(file);

            return await Commit(_fileRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _fileRepository.Dispose();
        }
    }
}
