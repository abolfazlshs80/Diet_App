using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Delete;
using Order.Framework.Core.Bus;

public record DeleteRecommendationDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
