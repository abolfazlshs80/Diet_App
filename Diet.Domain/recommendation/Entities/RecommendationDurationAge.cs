using Diet.Domain.common;
using Diet.Domain.lifeCourse;

namespace Diet.Domain.Recommendation.Entities;

/// <summary>
///   نگهدارنده توصیه‌های خاص  برای ‌ دوره سنی است.
/// </summary>
public sealed class RecommendationDurationAge: BaseEntity
{
    private RecommendationDurationAge() { }

    public Guid RecommendationId { get; private set; }

    public Recommendation Recommendation { get; private set; }

    public Guid DurationAgeId { get; private set; }

    public DurationAge DurationAge { get; private set; }
}