using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
namespace Diet.Domain.UseCase.SupplementDurationAge.Commands.Create
{
    public class CreateSupplementDurationAgeCommandValidator : AbstractValidator<CreateSupplementDurationAgeCommand>
    {
        public CreateSupplementDurationAgeCommandValidator()
        {
            // Add validation rules here
        }
    }
}
