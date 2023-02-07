using File = ApiStorageManager.Domain.Models.File;

namespace ApiStorageManager.Domain.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        Task<File> GetById(Guid id, string empresa, int codigoEvento);

        void Add(File file);
        void Update(File file);
        void Delete(File file);
    }
}
