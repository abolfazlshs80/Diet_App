using Diet;
using Diet.Domain.Contract.Commands.Recommendation.Delete;
using FluentValidation;
namespace Diet.Domain.UseCase.Recommendation.Commands.Create
{
    public class DeleteRecommendationCommandValidator : AbstractValidator<DeleteRecommendationCommand>
    {
        public DeleteRecommendationCommandValidator()
        {
            // Add validation rules here
        }
    }
}
