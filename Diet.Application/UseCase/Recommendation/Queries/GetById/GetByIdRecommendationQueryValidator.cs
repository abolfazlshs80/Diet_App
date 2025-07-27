using Diet.Domain.Contract.Queries.Recommendation.GetById;
using FluentValidation;
namespace Diet.Application.UseCase.Recommendation.Queries.GetById;

public class GetByIdRecommendationQueryValidator : AbstractValidator<GetByIdRecommendationQuery>
{
    public GetByIdRecommendationQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
