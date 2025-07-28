using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
namespace Diet.Domain.UseCase.RecommendationDurationAge.Commands.Create
{
    public class UpdateRecommendationDurationAgeCommandValidator : AbstractValidator<UpdateRecommendationDurationAgeCommand>
    {
        public UpdateRecommendationDurationAgeCommandValidator()
        {
            RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DurationAgeId)
                .NotEmpty().WithMessage("شناسه مدت زمان سنی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
