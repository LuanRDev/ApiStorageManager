using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Commands
{
    public abstract class FileCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Empresa { get; protected set; }
        public string CodigoEvento { get; protected set; }
        public string UrlAddress { get; protected set; }
        public string Meta { get; protected set; }
        public string Type { get; protected set; }
        public string Extension { get; protected set; }
        public byte[] Bytes { get; protected set; }
    }
}
