using ApiStorageManager.Domain.Interfaces;

namespace ApiStorageManager.Domain.Models
{
    public class File : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string UrlAddress { get; private set; }
        public string Empresa { get; private set; }
        public string CodigoEvento { get; private set; }
        public string Meta { get; private set; }
        public string Type { get; private set; }
        public string Extension { get; private set; }
        public byte[] Bytes { get; private set; }

        public File(Guid id, string name, string empresa, string codigoEvento, string urlAddress, string meta, string type, string extension, byte[] bytes)
        {
            ValidateFile(id, name, empresa, codigoEvento, urlAddress, meta, type, extension, bytes);
            Id = id;
            Empresa = empresa;
            CodigoEvento = codigoEvento;
            UrlAddress = urlAddress;
            Name = name;
            Meta = meta;
            Type = type;
            Extension = extension;
            Bytes = bytes;
        }

        private void ValidateFile(Guid id, string name, string empresa, string codigoEvento, string urlAddress, string meta, string type, string extension, byte[] bytes)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("An Id for the file must be provided.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("A name for the file is needed.");
            }
            if (string.IsNullOrEmpty(empresa))
            {
                throw new InvalidOperationException("A empresa for the file is needed.");
            }
            if (string.IsNullOrEmpty(codigoEvento))
            {
                throw new InvalidOperationException("A codigo evento for the file is needed.");
            }
            if (string.IsNullOrEmpty(urlAddress))
            {
                throw new InvalidOperationException("A urlAddress for the file is needed.");
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
