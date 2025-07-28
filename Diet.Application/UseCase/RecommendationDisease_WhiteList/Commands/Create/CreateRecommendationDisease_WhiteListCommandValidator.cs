using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
namespace Diet.Domain.UseCase.RecommendationDisease_WhiteList.Commands.Create
{
    public class CreateRecommendationDisease_WhiteListCommandValidator : AbstractValidator<CreateRecommendationDisease_WhiteListCommand>
    {
        public CreateRecommendationDisease_WhiteListCommandValidator()
        {
    

            RuleFor(x => x.RecommendationId)
                .NotEmpty().WithMessage("شناسه توصیه نمی‌تواند مقدار پیش‌فرض یا تهی باشد.");

            RuleFor(x => x.DiseaseId)
                .NotEmpty().WithMessage("شناسه بیماری نمی‌تواند مقدار پیش‌فرض یا تهی باشد.");
        }
    }
}
