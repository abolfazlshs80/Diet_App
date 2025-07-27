using Diet.Domain.Contract.Commands.Recommendation.Create;
using Order.Framework.Core.Bus;

public record CreateRecommendationCommandResult(string state, string message) : ICommandResult;
