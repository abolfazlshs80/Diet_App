using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetById;
namespace Diet.Application.UseCase.RecommendationDurationAge.Queries.GetById;

public class GetByIdRecommendationDurationAgeQueryValidator : AbstractValidator<GetByIdRecommendationDurationAgeQuery>
{
    public GetByIdRecommendationDurationAgeQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
