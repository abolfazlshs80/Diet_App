using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Delete;

public record DeleteRecommendationDisease_WhiteListCommand(Guid Id) : ICommand;
