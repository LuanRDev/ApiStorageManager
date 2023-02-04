namespace ApiStorageManager.Domain.Commands.Validations
{
    public class UploadNewFileCommandValidation : FileValidation<UploadNewFileCommand>
    {
        public UploadNewFileCommandValidation() 
        {
            ValidateBase64File();
        }
    }
}
