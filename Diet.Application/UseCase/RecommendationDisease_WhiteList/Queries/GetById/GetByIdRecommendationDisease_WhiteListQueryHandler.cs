using Diet.Domain.recommendationDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetById;

namespace Diet.Application.UseCase.RecommendationDisease_WhiteList.Queries.GetById;

public class GetByIdRecommendationDisease_WhiteListQueryHandler : IQueryHandler<GetByIdRecommendationDisease_WhiteListQuery, GetByIdRecommendationDisease_WhiteListQueryResult>
{
    private readonly IRecommendationDisease_WhiteListRepository _recommendationDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdRecommendationDisease_WhiteListQueryHandler(IRecommendationDisease_WhiteListRepository recommendationDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationDisease_WhiteListRepository = recommendationDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<GetByIdRecommendationDisease_WhiteListQueryResult>> Handle(GetByIdRecommendationDisease_WhiteListQuery query)
    {
        var result = await _recommendationDisease_WhiteListRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "RecommendationDisease_WhiteList not found");

        return new GetByIdRecommendationDisease_WhiteListQueryResult(result.Id,result.RecommendationId,result.DiseaseId);
    }
}
