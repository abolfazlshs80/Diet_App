using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
namespace Diet.Domain.UseCase.RecommendationLifeCourse.Commands.Create
{
    public class CreateRecommendationLifeCourseCommandValidator : AbstractValidator<CreateRecommendationLifeCourseCommand>
    {
        public CreateRecommendationLifeCourseCommandValidator()
        {

            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.LifeCourseId)
                .NotEmpty().WithMessage("شناسه دوره زندگی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
