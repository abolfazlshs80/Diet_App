using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
namespace Diet.Domain.UseCase.RecommendationDisease_WhiteList.Commands.Create
{
    public class UpdateRecommendationDisease_WhiteListCommandValidator : AbstractValidator<UpdateRecommendationDisease_WhiteListCommand>
    {
        public UpdateRecommendationDisease_WhiteListCommandValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty().WithMessage("شناسه نمی‌تواند مقدار پیش‌فرض یا تهی باشد.");

            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند مقدار پیش‌فرض یا تهی باشد.");

            RuleFor(x => x.DiseaseId)
                .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند مقدار پیش‌فرض یا تهی باشد.");
        }
    }
}
