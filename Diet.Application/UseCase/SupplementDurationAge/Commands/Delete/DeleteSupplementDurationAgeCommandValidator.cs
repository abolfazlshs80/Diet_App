using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Delete;
namespace Diet.Domain.UseCase.SupplementDurationAge.Commands.Create
{
    public class DeleteSupplementDurationAgeCommandValidator : AbstractValidator<DeleteSupplementDurationAgeCommand>
    {
        public DeleteSupplementDurationAgeCommandValidator()
        {
            // Add validation rules here
        }
    }
}
