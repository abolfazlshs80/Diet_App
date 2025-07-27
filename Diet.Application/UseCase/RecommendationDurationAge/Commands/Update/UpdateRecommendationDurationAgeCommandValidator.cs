using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
namespace Diet.Domain.UseCase.RecommendationDurationAge.Commands.Create
{
    public class UpdateRecommendationDurationAgeCommandValidator : AbstractValidator<UpdateRecommendationDurationAgeCommand>
    {
        public UpdateRecommendationDurationAgeCommandValidator()
        {
            // Add validation rules here
        }
    }
}
