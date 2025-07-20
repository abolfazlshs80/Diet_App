using Diet.Domain.common;
using Diet.Domain.lifeCourse;

namespace Diet.Domain.Recommendation.Entities;
/// <summary>
///   برای نگهداری اطلاعات توصیه‌های خاص هر دوره زندگی است.
/// </summary>
public class RecommendationLifeCourse : BaseEntity
{
    private RecommendationLifeCourse() { }

    public Guid RecommendationId { get; private set; }

    public virtual Recommendation Recommendation { get; private set; }

    public Guid LifeCourseId { get; private set; }

    public virtual LifeCourse LifeCourse { get; private set; }
}