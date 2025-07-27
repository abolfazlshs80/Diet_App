using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Role.Delete;

public record DeleteRoleCommand(Guid Id) : ICommand;
