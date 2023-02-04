using FluentValidation;

namespace ApiStorageManager.Domain.Commands.Validations
{
    public abstract class FileValidation<T> : AbstractValidator<T> where T : FileCommand
    {
        protected void ValidateBase64File()
        {
            RuleFor(f => f.Name).NotEmpty();
        }

        protected void ValidateId()
        {
            RuleFor(f => f.Id).NotEmpty();
        }
    }
}
