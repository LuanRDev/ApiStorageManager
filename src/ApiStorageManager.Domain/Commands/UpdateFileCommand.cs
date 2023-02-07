using ApiStorageManager.Domain.Commands.Validations;

namespace ApiStorageManager.Domain.Commands
{
    public class UpdateFileCommand : FileCommand
    {   
        public UpdateFileCommand(Guid id, string name, string empresa, int codigoEvento, string metadata, string type, string extension, byte[] bytes) 
        {
            Id = id;
            Name = name;
            Empresa = empresa;
            CodigoEvento = codigoEvento;
            Metadata = metadata;
            Type = type;
            Extension = extension;
            Bytes = bytes;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
