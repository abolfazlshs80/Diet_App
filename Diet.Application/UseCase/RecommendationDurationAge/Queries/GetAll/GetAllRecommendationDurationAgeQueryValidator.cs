using FluentValidation;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetAll;
namespace Diet.Application.UseCase.RecommendationDurationAge.Queries.GetAll;

public class GetAllRecommendationDurationAgeQueryValidator : AbstractValidator<GetAllRecommendationDurationAgeQuery>
{
    public GetAllRecommendationDurationAgeQueryValidator()
    {
        
    }
}
