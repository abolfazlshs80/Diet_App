using Diet.Domain.Contract.Commands.Recommendation.Update;
using Order.Framework.Core.Bus;

public record UpdateRecommendationCommandResult(string state, string message) : ICommandResult;
