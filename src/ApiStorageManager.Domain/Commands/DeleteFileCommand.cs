using ApiStorageManager.Domain.Commands.Validations;

namespace ApiStorageManager.Domain.Commands
{
    public class DeleteFileCommand : FileCommand
    {
        public DeleteFileCommand(Guid id) 
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteFileCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
