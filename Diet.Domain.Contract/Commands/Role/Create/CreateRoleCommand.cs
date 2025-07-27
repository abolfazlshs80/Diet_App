using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Role.Create;

public record CreateRoleCommand(string Name) : ICommand;
