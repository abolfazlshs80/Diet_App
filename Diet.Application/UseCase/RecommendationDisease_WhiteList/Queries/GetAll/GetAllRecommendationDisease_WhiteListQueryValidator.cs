using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetAll;
namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Queries.GetAll;

public class GetAllRecommendationDisease_WhiteListQueryValidator : AbstractValidator<GetAllRecommendationDisease_WhiteListQuery>
{
    public GetAllRecommendationDisease_WhiteListQueryValidator()
    {
        
    }
}
