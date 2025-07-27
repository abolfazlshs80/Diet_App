using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Delete;
namespace Diet.Domain.UseCase.RecommendationDisease_WhiteList.Commands.Create
{
    public class DeleteRecommendationDisease_WhiteListCommandValidator : AbstractValidator<DeleteRecommendationDisease_WhiteListCommand>
    {
        public DeleteRecommendationDisease_WhiteListCommandValidator()
        {
            // Add validation rules here
        }
    }
}
