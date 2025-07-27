using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Delete;
namespace Diet.Domain.UseCase.RecommendationDurationAge.Commands.Create
{
    public class DeleteRecommendationDurationAgeCommandValidator : AbstractValidator<DeleteRecommendationDurationAgeCommand>
    {
        public DeleteRecommendationDurationAgeCommandValidator()
        {
            // Add validation rules here
        }
    }
}
