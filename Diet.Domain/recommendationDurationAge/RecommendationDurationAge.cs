using Diet.Domain.common;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
using Diet.Domain.durationAge.Entities;
using ErrorOr;

namespace Diet.Domain.recommendationDurationAge;

/// <summary>
///   نگهدارنده توصیه‌های خاص  برای ‌ دوره سنی است.
/// </summary>
public sealed class RecommendationDurationAge: BaseEntity
{
    private RecommendationDurationAge() { }

    public Guid RecommendationId { get; private set; }

    public recommendation. Recommendation Recommendation { get; private set; }

    public Guid DurationAgeId { get; private set; }

    public DurationAge DurationAge { get; private set; }

    private RecommendationDurationAge(Guid id, Guid recommendationId, Guid durationAgeId)
    {
        Id = id;
        RecommendationId = recommendationId;
        DurationAgeId = durationAgeId;
    }

    public static ErrorOr<RecommendationDurationAge> Create(CreateRecommendationDurationAgeCommand command)
    {
        return new RecommendationDurationAge(
            Guid.NewGuid(),
            command.RecommendationId,
            command.DurationAgeId
        );
    }

    public static ErrorOr<RecommendationDurationAge> Update(RecommendationDurationAge existing, UpdateRecommendationDurationAgeCommand command)
    {
        return new RecommendationDurationAge(
            existing.Id,
            command.RecommendationId,
            command.DurationAgeId
        );
    }
}