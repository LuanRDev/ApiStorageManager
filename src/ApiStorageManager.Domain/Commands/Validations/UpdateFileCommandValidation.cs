namespace ApiStorageManager.Domain.Commands.Validations
{
    public class UpdateFileCommandValidation : FileValidation<UpdateFileCommand>
    {
        public UpdateFileCommandValidation() 
        {
            ValidateId();
            ValidateBase64File();
        }
    }
}
