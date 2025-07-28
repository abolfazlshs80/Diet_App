using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Users.Delete;

public record DeleteUsersCommand(Guid Id) : ICommand;
