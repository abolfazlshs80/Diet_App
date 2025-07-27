using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;

public record UpdateRecommendationDisease_WhiteListCommand(Guid Id, Guid RecommendationId, Guid DiseaseId) : ICommand;
