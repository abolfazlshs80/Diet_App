using Diet.Domain.common;
using Diet.Domain.Recommendation.Entities;
using Diet.Domain.supplement.Entities;

namespace Diet.Domain.lifeCourse;

/// <summary>
/// 
/// </summary>
public sealed class DurationAge:BaseEntity
{
    private DurationAge()
    {

    }
    public string Title { get; private set; }

    public ICollection<SupplementDurationAge> SupplementDurationAge { get; private set; }
    public ICollection<RecommendationDurationAge> RecommendationDurationAge { get; private set; }
}
