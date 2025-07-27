using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetById;

namespace Diet.Application.UseCase.RecommendationDurationAge.Queries.GetById;

public class GetByIdRecommendationDurationAgeQueryHandler : IQueryHandler<GetByIdRecommendationDurationAgeQuery, GetByIdRecommendationDurationAgeQueryResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdRecommendationDurationAgeQueryHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;
    }

    public async Task<ErrorOr<GetByIdRecommendationDurationAgeQueryResult>> Handle(GetByIdRecommendationDurationAgeQuery query)
    {
        var result = await _recommendationDurationAgeRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "RecommendationDurationAge not found");

        return new GetByIdRecommendationDurationAgeQueryResult(result.Id,result.RecommendationId,result.DurationAgeId);
    }
}
