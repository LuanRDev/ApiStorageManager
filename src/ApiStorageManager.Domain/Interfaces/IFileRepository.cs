using File = ApiStorageManager.Domain.Models.File;

namespace ApiStorageManager.Domain.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        Task<File> GetById(Guid id, string empresa, int codigoEvento);

        Task Add(File file);
        Task Update(File file);
        Task Delete(File file);
    }
}
