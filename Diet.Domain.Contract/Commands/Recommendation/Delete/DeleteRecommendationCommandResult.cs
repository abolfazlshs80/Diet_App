using Diet.Domain.Contract.Commands.Recommendation.Delete;
using Order.Framework.Core.Bus;

public record DeleteRecommendationCommandResult(string state, string message) : ICommandResult;
