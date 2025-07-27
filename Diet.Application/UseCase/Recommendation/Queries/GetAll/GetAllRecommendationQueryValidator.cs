using Diet.Domain.Contract.Queries.Recommendation.GetAll;
using FluentValidation;
namespace Diet.Application.UseCase.Recommendation.Queries.GetAll;

public class GetAllRecommendationQueryValidator : AbstractValidator<GetAllRecommendationQuery>
{
    public GetAllRecommendationQueryValidator()
    {
        
    }
}
