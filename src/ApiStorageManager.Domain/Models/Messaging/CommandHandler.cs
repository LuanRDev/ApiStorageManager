using ApiStorageManager.Domain.Interfaces;
using FluentValidation.Results;

namespace ApiStorageManager.Domain.Models.Messaging
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult= new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (uow.Commit().IsFaulted) AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "There was an error saving data").ConfigureAwait(false);
        }
            
    }
}
