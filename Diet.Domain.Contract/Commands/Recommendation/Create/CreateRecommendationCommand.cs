using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Recommendation.Create;

public record CreateRecommendationCommand(string Title, string EnglishTitle, string Description, string HowToUse) : ICommand;
