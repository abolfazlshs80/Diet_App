using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementGroup.Update;

public record UpdateSupplementGroupCommand(Guid Id, string Title) : ICommand;
