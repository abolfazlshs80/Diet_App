using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.SupplementGroup.Delete;

public record DeleteSupplementGroupCommand(Guid Id) : ICommand;
