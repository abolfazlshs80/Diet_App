using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetById;
namespace Diet.Application.UseCase.RecommendationLifeCourse.Queries.GetById;

public class GetByIdRecommendationLifeCourseQueryValidator : AbstractValidator<GetByIdRecommendationLifeCourseQuery>
{
    public GetByIdRecommendationLifeCourseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
