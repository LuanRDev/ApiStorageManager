using ApiStorageManager.Domain.Models.Messaging;

namespace ApiStorageManager.Domain.Events
{
    public class FileUploadedEvent : Event
    {
        public FileUploadedEvent(Guid id, string name, string meta, string type, string extension, byte[] bytes) 
        {
            Id = id;
            Name = name;
            Meta = meta;
            Type = type;
            Extension = extension;
            Bytes = bytes;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Meta { get; private set; }
        public string Type { get; private set; }
        public string Extension { get; private set; }
        public byte[] Bytes { get; private set; }
    }
}
