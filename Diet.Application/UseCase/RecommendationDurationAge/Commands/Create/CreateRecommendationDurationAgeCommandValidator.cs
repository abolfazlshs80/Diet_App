using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
namespace Diet.Domain.UseCase.RecommendationDurationAge.Commands.Create
{
    public class CreateRecommendationDurationAgeCommandValidator : AbstractValidator<CreateRecommendationDurationAgeCommand>
    {
        public CreateRecommendationDurationAgeCommandValidator()
        {


            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.DurationAgeId)
                .NotEmpty().WithMessage("شناسه مدت زمان سنی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
