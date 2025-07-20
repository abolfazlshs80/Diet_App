using Diet.Domain.common;
using Diet.Domain.disease;

namespace Diet.Domain.Recommendation.Entities;
/// <summary>
///   نگهدارنده توصیه های خاص برای بیماری‌ها  است.
/// </summary>
public sealed class RecommendationDisease_WhiteList:BaseEntity
{
    private RecommendationDisease_WhiteList() { }

    public Guid RecommendationId { get; private set; }

    public  Recommendation Recommendation { get; private set; }

    public Guid DiseaseId { get; private set; }
    
    public  Disease Disease { get; private set; }
}
