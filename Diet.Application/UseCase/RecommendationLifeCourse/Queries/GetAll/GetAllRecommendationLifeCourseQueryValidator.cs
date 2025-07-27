using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetAll;
namespace Diet.Application.UseCase.RecommendationLifeCourse.Queries.GetAll;

public class GetAllRecommendationLifeCourseQueryValidator : AbstractValidator<GetAllRecommendationLifeCourseQuery>
{
    public GetAllRecommendationLifeCourseQueryValidator()
    {
        
    }
}
