using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
namespace Diet.Domain.UseCase.RecommendationDisease_WhiteList.Commands.Create
{
    public class CreateRecommendationDisease_WhiteListCommandValidator : AbstractValidator<CreateRecommendationDisease_WhiteListCommand>
    {
        public CreateRecommendationDisease_WhiteListCommandValidator()
        {
            // Add validation rules here
        }
    }
}
