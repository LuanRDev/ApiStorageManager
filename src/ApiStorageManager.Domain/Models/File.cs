using ApiStorageManager.Domain.Interfaces;

namespace ApiStorageManager.Domain.Models
{
    public class File : BaseEntity, IAggregateRoot
    {
        public string? Name { get; private set; }
        public string? Url { get; private set; }
        public string? Empresa { get; private set; }
        public int CodigoEvento { get; private set; }
        public string? Metadata { get; private set; }
        public string? Type { get; private set; }
        public string? Extension { get; private set; }
        public byte[] Bytes { get; private set; }
        public File() { }
        public File(Guid id, string name, string empresa, int codigoEvento, string metadata, string type, string extension, byte[] bytes)
        {
            ValidateFile(id, name, empresa, codigoEvento, metadata, type, extension, bytes);
            Id = id;
            Empresa = empresa;
            CodigoEvento = codigoEvento;
            Url = $"eventos/empresas/{Empresa}/{CodigoEvento}/documentos/{Id}";
            Name = name;
            Metadata = metadata;
            Type = type;
            Extension = extension;
            Bytes = bytes;
        }

        private void ValidateFile(Guid id, string name, string empresa, int codigoEvento, string meta, string type, string extension, byte[] bytes)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("An Id for the file must be provided.");
            }
            if (codigoEvento <= 0)
            {
                throw new InvalidOperationException("A codigo evento for the file is needed.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("A name for the file is needed.");
            }
            if (string.IsNullOrEmpty(empresa))
            {
                throw new InvalidOperationException("A empresa for the file is needed.");
            }
            if (string.IsNullOrEmpty(meta))
            {
                throw new InvalidOperationException("The file Metadata is needed.");
            }
            if (string.IsNullOrEmpty(type))
            {
                throw new InvalidOperationException("The file Type is needed.");
            }
            if(bytes == null)
            {
                throw new InvalidOperationException("The file Bytes are needed.");
            }
        }
    }
}
