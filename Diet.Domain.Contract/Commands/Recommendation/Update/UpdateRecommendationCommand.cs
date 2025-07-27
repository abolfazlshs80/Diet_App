using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Recommendation.Update;

public record UpdateRecommendationCommand(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse) : ICommand;
