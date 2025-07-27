using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
namespace Diet.Domain.UseCase.RecommendationDisease_WhiteList.Commands.Create
{
    public class UpdateRecommendationDisease_WhiteListCommandValidator : AbstractValidator<UpdateRecommendationDisease_WhiteListCommand>
    {
        public UpdateRecommendationDisease_WhiteListCommandValidator()
        {
            // Add validation rules here
        }
    }
}
