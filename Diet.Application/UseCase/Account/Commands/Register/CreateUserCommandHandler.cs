

using Diet.Application.Interface;
using Diet.Domain.Contract.Commands.Account.Register;
using Diet.Framework.Core.Bus;
using ErrorOr;


namespace Identity.Application.UseCase.User.Commands.Rgister;

public class RgisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    public RgisterUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<ErrorOr<RegisterUserCommandResult>> Handle(RegisterUserCommand command)
    {
        var userResult = await _authenticationService.Register(command);
        if (userResult.IsError)
            return userResult.FirstError;
         
        return new RegisterUserCommandResult("success", "User saved.");
    }
}
