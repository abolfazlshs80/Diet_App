using Diet.Domain.recommendationDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.RecommendationDurationAge.Queries.GetAll;

public class GetAllRecommendationDurationAgeQueryHandler : IQueryHandler<GetAllRecommendationDurationAgeQuery, GetAllRecommendationDurationAgeQueryResult>
{
    private readonly IRecommendationDurationAgeRepository _recommendationDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRecommendationDurationAgeQueryHandler(IRecommendationDurationAgeRepository recommendationDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDurationAgeRepository = recommendationDurationAgeRepository;
    }

    public async Task<ErrorOr<GetAllRecommendationDurationAgeQueryResult>> Handle(GetAllRecommendationDurationAgeQuery query)
    {
        var result = await _recommendationDurationAgeRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllRecommendationDurationAgeQueryResult(
            result.Count,
            result.Select(_ => new GetRecommendationDurationAgeItem(_.Id, _.RecommendationId, _.DurationAgeId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
