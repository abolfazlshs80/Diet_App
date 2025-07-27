using Diet;
using Diet.Domain.Contract.Commands.Recommendation.Update;
using FluentValidation;
namespace Diet.Domain.UseCase.Recommendation.Commands.Create
{
    public class UpdateRecommendationCommandValidator : AbstractValidator<UpdateRecommendationCommand>
    {
        public UpdateRecommendationCommandValidator()
        {
            // Add validation rules here
        }
    }
}
