using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;

public record UpdateRecommendationDurationAgeCommand(Guid Id, Guid RecommendationId, Guid DurationAgeId) : ICommand;
