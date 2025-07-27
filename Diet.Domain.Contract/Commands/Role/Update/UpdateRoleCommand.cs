using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Role.Update;

public record UpdateRoleCommand(Guid Id, string Name) : ICommand;
