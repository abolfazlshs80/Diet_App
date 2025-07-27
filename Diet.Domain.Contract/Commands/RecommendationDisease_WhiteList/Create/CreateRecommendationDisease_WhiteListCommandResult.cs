using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
using Order.Framework.Core.Bus;

public record CreateRecommendationDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
