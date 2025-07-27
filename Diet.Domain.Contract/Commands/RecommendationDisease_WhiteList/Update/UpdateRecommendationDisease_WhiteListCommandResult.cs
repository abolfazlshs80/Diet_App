using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
using Order.Framework.Core.Bus;

public record UpdateRecommendationDisease_WhiteListCommandResult(string state, string message) : ICommandResult;
