using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
namespace Diet.Domain.UseCase.SupplementDurationAge.Commands.Create
{
    public class UpdateSupplementDurationAgeCommandValidator : AbstractValidator<UpdateSupplementDurationAgeCommand>
    {
        public UpdateSupplementDurationAgeCommandValidator()
        {
            RuleFor(x => x.Id)
         .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.SupplementId)
                .NotEmpty().WithMessage("شناسه مکمل نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DurationAgeId)
                .NotEmpty().WithMessage("شناسه مدت زمان سنی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
