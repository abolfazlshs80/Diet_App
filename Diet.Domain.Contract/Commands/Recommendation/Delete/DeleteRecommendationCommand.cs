using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Recommendation.Delete;

public record DeleteRecommendationCommand(Guid Id) : ICommand;
