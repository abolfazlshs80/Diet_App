using Diet;
using Diet.Domain.Contract.Commands.Recommendation.Create;
using FluentValidation;
namespace Diet.Domain.UseCase.Recommendation.Commands.Create
{
    public class CreateRecommendationCommandValidator : AbstractValidator<CreateRecommendationCommand>
    {
        public CreateRecommendationCommandValidator()
        {
            // Add validation rules here
        }
    }
}
