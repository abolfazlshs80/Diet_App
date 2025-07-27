using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
namespace Diet.Domain.UseCase.RecommendationLifeCourse.Commands.Create
{
    public class CreateRecommendationLifeCourseCommandValidator : AbstractValidator<CreateRecommendationLifeCourseCommand>
    {
        public CreateRecommendationLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
