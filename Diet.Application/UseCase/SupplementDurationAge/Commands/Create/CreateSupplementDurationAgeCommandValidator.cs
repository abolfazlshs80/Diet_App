using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
namespace Diet.Domain.UseCase.SupplementDurationAge.Commands.Create
{
    public class CreateSupplementDurationAgeCommandValidator : AbstractValidator<CreateSupplementDurationAgeCommand>
    {
        public CreateSupplementDurationAgeCommandValidator()
        {

            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DurationAgeId)
                .NotEmpty().WithMessage("شناسه مدت زمان سنی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
