using Diet;
using FluentValidation;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Delete;
namespace Diet.Domain.UseCase.RecommendationLifeCourse.Commands.Create
{
    public class DeleteRecommendationLifeCourseCommandValidator : AbstractValidator<DeleteRecommendationLifeCourseCommand>
    {
        public DeleteRecommendationLifeCourseCommandValidator()
        {
            // Add validation rules here
        }
    }
}
