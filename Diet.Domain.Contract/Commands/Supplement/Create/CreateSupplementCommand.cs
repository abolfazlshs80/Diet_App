using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Supplement.Create;

public record CreateSupplementCommand(string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId) : ICommand;
