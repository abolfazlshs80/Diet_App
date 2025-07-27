using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;

public record CreateRecommendationDurationAgeCommand(Guid RecommendationId, Guid DurationAgeId) : ICommand;
