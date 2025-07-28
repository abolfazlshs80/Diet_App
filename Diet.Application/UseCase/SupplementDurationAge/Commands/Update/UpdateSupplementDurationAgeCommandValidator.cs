using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
namespace Diet.Domain.UseCase.SupplementDurationAge.Commands.Create
{
    public class UpdateSupplementDurationAgeCommandValidator : AbstractValidator<UpdateSupplementDurationAgeCommand>
    {
        public UpdateSupplementDurationAgeCommandValidator()
        {
            // Add validation rules here
        }
    }
}
