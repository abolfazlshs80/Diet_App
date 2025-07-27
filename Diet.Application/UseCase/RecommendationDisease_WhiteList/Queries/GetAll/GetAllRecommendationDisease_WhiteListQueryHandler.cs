using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Queries.GetAll;

public class GetAllRecommendationDisease_WhiteListQueryHandler : IQueryHandler<GetAllRecommendationDisease_WhiteListQuery, GetAllRecommendationDisease_WhiteListQueryResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _recommendationDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRecommendationDisease_WhiteListQueryHandler(IRecommendationDisease_WhiteListRepository recommendationDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDisease_WhiteListRepository = recommendationDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<GetAllRecommendationDisease_WhiteListQueryResult>> Handle(GetAllRecommendationDisease_WhiteListQuery query)
    {
        var result = await _recommendationDisease_WhiteListRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllRecommendationDisease_WhiteListQueryResult(
            result.Count,
            result.Select(_ => new GetRecommendationDisease_WhiteListItem(_.Id, _.RecommendationId, _.DiseaseId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
