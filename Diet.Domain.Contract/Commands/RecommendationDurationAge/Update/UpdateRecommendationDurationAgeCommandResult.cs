using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
using Order.Framework.Core.Bus;

public record UpdateRecommendationDurationAgeCommandResult(string state, string message) : ICommandResult;
