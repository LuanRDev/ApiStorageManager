namespace ApiStorageManager.Domain.Commands.Validations
{
    public class DeleteFileCommandValidation : FileValidation<DeleteFileCommand>
    {
        public DeleteFileCommandValidation() 
        {
            ValidateId();
        }
    }
}
