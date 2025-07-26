using Diet.Domain.common;
using Diet.Domain.lifeCourse.Entities;

namespace Diet.Domain.Recommendation.Entities;
/// <summary>
///   برای نگهداری اطلاعات توصیه‌های خاص هر دوره زندگی است.
/// </summary>
public sealed class RecommendationLifeCourse : BaseEntity
{
    private RecommendationLifeCourse() { }

    public Guid RecommendationId { get; private set; }

    public  Recommendation Recommendation { get; private set; }

    public Guid LifeCourseId { get; private set; }

    public  LifeCourse LifeCourse { get; private set; }
}