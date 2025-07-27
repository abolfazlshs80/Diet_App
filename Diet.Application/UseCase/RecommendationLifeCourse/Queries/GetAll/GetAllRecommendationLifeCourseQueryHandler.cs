using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Queries.GetAll;

public class GetAllRecommendationLifeCourseQueryHandler : IQueryHandler<GetAllRecommendationLifeCourseQuery, GetAllRecommendationLifeCourseQueryResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRecommendationLifeCourseQueryHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
    }

    public async Task<ErrorOr<GetAllRecommendationLifeCourseQueryResult>> Handle(GetAllRecommendationLifeCourseQuery query)
    {
        var result = await _recommendationLifeCourseRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllRecommendationLifeCourseQueryResult(
            result.Count,
            result.Select(_ => new GetRecommendationLifeCourseItem(_.Id, _.RecommendationId, _.LifeCourseId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
