

using Diet.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.User.Login;

public record LoginUserCommand( string Mobile, string Password) : ICommand;

