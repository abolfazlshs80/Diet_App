using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementGroup.Create;

public record CreateSupplementGroupCommand(string Title) : ICommand;
