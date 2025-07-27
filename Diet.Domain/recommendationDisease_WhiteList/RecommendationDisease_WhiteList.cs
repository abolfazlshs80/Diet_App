using Diet.Domain.common;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
using Diet.Domain.disease;
using ErrorOr;

namespace Diet.Domain.recommendationDisease_WhiteList;
/// <summary>
///   نگهدارنده توصیه های خاص برای بیماری‌ها  است.
/// </summary>
public sealed class RecommendationDisease_WhiteList:BaseEntity
{
    private RecommendationDisease_WhiteList() { }

    public Guid RecommendationId { get; private set; }

    public recommendation. Recommendation Recommendation { get; private set; }

    public Guid DiseaseId { get; private set; }
    
    public disease.Disease Disease { get; private set; }

    private RecommendationDisease_WhiteList(Guid id, Guid recommendationId, Guid diseaseId)
    {
        Id = id;
        RecommendationId = recommendationId;
        DiseaseId = diseaseId;
    }

    public static ErrorOr<RecommendationDisease_WhiteList> Create(CreateRecommendationDisease_WhiteListCommand command)
    {
        return new RecommendationDisease_WhiteList(
            Guid.NewGuid(),
            command.RecommendationId,
            command.DiseaseId
        );
    }

    public static ErrorOr<RecommendationDisease_WhiteList> Update(RecommendationDisease_WhiteList existing, UpdateRecommendationDisease_WhiteListCommand command)
    {
        return new RecommendationDisease_WhiteList(
            existing.Id,
            command.RecommendationId,
            command.DiseaseId
        );
    }
}
