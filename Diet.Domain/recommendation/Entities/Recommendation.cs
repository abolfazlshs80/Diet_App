using Diet.Domain.common;

namespace Diet.Domain.Recommendation.Entities;
/// <summary>
///    نمایانگر یک مکمل غذایی است.
/// </summary>
public sealed class Recommendation:BaseEntity
{
    private Recommendation() { }
    public string? Title { get;private set; }
    public string? EnglishTitle { get; private set; }
    public string? Description { get; private set; }
    public string? HowToUse { get; private set; }

    public ICollection< RecommendationDisease_WhiteList> RecommendationDisease_WhiteList  { get; private set; }
    public ICollection<RecommendationDurationAge> RecommendationDurationAge { get; private set; }
    public ICollection<RecommendationLifeCourse> RecommendationLifeCourse { get; private set; }
}
