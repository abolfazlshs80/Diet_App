using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDurationAge.Delete;

public record DeleteRecommendationDurationAgeCommand(Guid Id) : ICommand;
