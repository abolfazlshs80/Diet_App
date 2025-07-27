using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
namespace Diet.Domain.UseCase.RecommendationLifeCourse.Commands.Create
{
    public class UpdateRecommendationLifeCourseCommandValidator : AbstractValidator<UpdateRecommendationLifeCourseCommand>
    {
        public UpdateRecommendationLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
