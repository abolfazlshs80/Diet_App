using Diet.Domain.recommendationLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetById;

namespace Diet.Application.UseCase.RecommendationLifeCourse.Queries.GetById;

public class GetByIdRecommendationLifeCourseQueryHandler : IQueryHandler<GetByIdRecommendationLifeCourseQuery, GetByIdRecommendationLifeCourseQueryResult>
{
    private readonly IRecommendationLifeCourseRepository _recommendationLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdRecommendationLifeCourseQueryHandler(IRecommendationLifeCourseRepository recommendationLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _recommendationLifeCourseRepository = recommendationLifeCourseRepository;
    }

    public async Task<ErrorOr<GetByIdRecommendationLifeCourseQueryResult>> Handle(GetByIdRecommendationLifeCourseQuery query)
    {
        var result = await _recommendationLifeCourseRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "RecommendationLifeCourse not found");

        return new GetByIdRecommendationLifeCourseQueryResult(result.Id,result.RecommendationId,result.LifeCourseId);
    }
}
