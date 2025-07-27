using Diet.Domain.recommendation.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using System.Linq;
using Diet.Domain.Contract.Queries.Recommendation.GetAll;

namespace Diet.Application.UseCase.Recommendation.Queries.GetAll;

public class GetAllRecommendationQueryHandler : IQueryHandler<GetAllRecommendationQuery, GetAllRecommendationQueryResult>
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRecommendationQueryHandler(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<ErrorOr<GetAllRecommendationQueryResult>> Handle(GetAllRecommendationQuery query)
    {
        var result = await _recommendationRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllRecommendationQueryResult(
            result.Count,
            result.Select(_ => new GetRecommendationItem(_.Id, _.Title,_.EnglishTitle,_.Description,_.HowToUse)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
