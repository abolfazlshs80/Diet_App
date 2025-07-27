using Diet.Domain.recommendation.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Recommendation.GetById;

namespace Diet.Application.UseCase.Recommendation.Queries.GetById;

public class GetByIdRecommendationQueryHandler : IQueryHandler<GetByIdRecommendationQuery, GetByIdRecommendationQueryResult>
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdRecommendationQueryHandler(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<ErrorOr<GetByIdRecommendationQueryResult>> Handle(GetByIdRecommendationQuery query)
    {
        var result = await _recommendationRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Recommendation not found");

        return new GetByIdRecommendationQueryResult(result.Id, result.Title,result.EnglishTitle, result.Description,result.HowToUse);
    }
}
