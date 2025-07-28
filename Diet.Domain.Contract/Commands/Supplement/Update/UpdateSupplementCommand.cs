using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Supplement.Update;

public record UpdateSupplementCommand(Guid Id, string Title, string EnglishTitle, string Description, string HowToUse, Guid SupplementGroupId) : ICommand;
