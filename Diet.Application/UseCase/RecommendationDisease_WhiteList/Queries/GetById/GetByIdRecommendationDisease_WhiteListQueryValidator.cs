using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetById;
namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Queries.GetById;

public class GetByIdRecommendationDisease_WhiteListQueryValidator : AbstractValidator<GetByIdRecommendationDisease_WhiteListQuery>
{
    public GetByIdRecommendationDisease_WhiteListQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
