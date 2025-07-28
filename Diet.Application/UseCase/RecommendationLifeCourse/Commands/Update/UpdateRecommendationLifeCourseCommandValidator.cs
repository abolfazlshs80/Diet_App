using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
namespace Diet.Domain.UseCase.RecommendationLifeCourse.Commands.Create
{
    public class UpdateRecommendationLifeCourseCommandValidator : AbstractValidator<UpdateRecommendationLifeCourseCommand>
    {
        public UpdateRecommendationLifeCourseCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("شناسه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");

            RuleFor(x => x.LifeCourseId)
                .NotEmpty().WithMessage("شناسه دوره زندگی نمی‌تواند تهی یا مقدار پیش‌فرض باشد.");
        }
    }
}
