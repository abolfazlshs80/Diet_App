using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
using Order.Framework.Core.Bus;

public record CreateRecommendationDurationAgeCommandResult(string state, string message) : ICommandResult;
