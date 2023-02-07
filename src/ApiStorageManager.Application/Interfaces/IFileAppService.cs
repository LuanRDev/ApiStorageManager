using ApiStorageManager.Application.ViewModels;
using FluentValidation.Results;

namespace ApiStorageManager.Application.Interfaces
{
    public interface IFileAppService : IDisposable
    {
        Task<FileViewModel> GetById(Guid id, string empresa, int codigoEvento);
        Task<ValidationResult> Upload(FileViewModel file);
        Task<ValidationResult> Update(FileViewModel file);
        Task<ValidationResult> Delete(Guid id);

    }
}
