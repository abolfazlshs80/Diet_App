using Diet.Domain.common;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
using Diet.Domain.lifeCourse.Entities;
using ErrorOr;

namespace Diet.Domain.recommendationLifeCourse;
/// <summary>
///   برای نگهداری اطلاعات توصیه‌های خاص هر دوره زندگی است.
/// </summary>
public sealed class RecommendationLifeCourse : BaseEntity
{
    private RecommendationLifeCourse() { }

    public Guid RecommendationId { get; private set; }

    public recommendation. Recommendation Recommendation { get; private set; }

    public Guid LifeCourseId { get; private set; }

    public  LifeCourse LifeCourse { get; private set; }

    private RecommendationLifeCourse(Guid id, Guid recommendationId, Guid lifeCourseId)
    {
        Id = id;
        RecommendationId = recommendationId;
        LifeCourseId = lifeCourseId;
    }

    public static ErrorOr<Domain.recommendationLifeCourse.RecommendationLifeCourse> Create(CreateRecommendationLifeCourseCommand command)
    {
        return new RecommendationLifeCourse(
            Guid.NewGuid(),
            command.RecommendationId,
            command.LifeCourseId
        );
    }

    public static ErrorOr<RecommendationLifeCourse> Update(RecommendationLifeCourse existing, UpdateRecommendationLifeCourseCommand command)
    {
        return new RecommendationLifeCourse(
            existing.Id,
            command.RecommendationId,
            command.LifeCourseId
        );
    }
}