using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;

public record CreateRecommendationDisease_WhiteListCommand(Guid RecommendationId, Guid DiseaseId) : ICommand;
