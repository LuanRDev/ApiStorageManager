using ApiStorageManager.Domain.Commands.Validations;

namespace ApiStorageManager.Domain.Commands
{
    public class UploadNewFileCommand : FileCommand
    {
        public UploadNewFileCommand(Guid id, string name, string metadata, string type, string extension, byte[] bytes)
        {
            Id = id;
            Name = name;
            Metadata = metadata;
            Type = type;
            Extension = extension;
            Bytes = bytes;
        }

        public override bool IsValid()
        {
            ValidationResult = new UploadNewFileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
