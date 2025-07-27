using Diet.Domain.Contract.Commands.RecommendationDurationAge.Delete;
using Order.Framework.Core.Bus;

public record DeleteRecommendationDurationAgeCommandResult(string state, string message) : ICommandResult;
