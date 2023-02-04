using ApiStorageManager.Application.Interfaces;
using ApiStorageManager.Application.ViewModels;
using ApiStorageManager.Domain.Commands;
using ApiStorageManager.Domain.Interfaces;
using ApiStorageManager.Infra.Mediator;
using AutoMapper;
using FluentValidation.Results;

namespace ApiStorageManager.Application.Services
{
    public class FileAppService : IFileAppService
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _fileRepository;
        private readonly IMediatorHandler _mediator;

        public FileAppService(IMapper mapper, IFileRepository fileRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _fileRepository = fileRepository;
            _mediator = mediator;
        }

        public async Task<FileViewModel> GetById(Guid id, string empresa, string codigoEvento)
        {
            return _mapper.Map<FileViewModel>(await _fileRepository.GetById(id, empresa, codigoEvento));
        }

        public async Task<ValidationResult> Upload(FileViewModel fileViewModel)
        {
            var uploadCommand = _mapper.Map<UploadNewFileCommand>(fileViewModel);
            return await _mediator.SendCommand(uploadCommand);
        }

        public async Task<ValidationResult> Update(FileViewModel fileViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFileCommand>(fileViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var deleteCommand = _mapper.Map<DeleteFileCommand>(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
