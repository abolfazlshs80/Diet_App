
using Diet.Api.Controllers;
using Diet.Domain.Contract.Commands.Account.Register;
using Diet.Domain.Contract.DTOs.Authentication;
using Diet.Framework.Core.Bus;
using Identity.Domain.Contract.Commands.User.Login;

using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("Account")]
public class AccountController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IMapper _mapper;

    public AccountController(ICommandBus commandBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        var createUserCommand = _mapper.Map<RegisterUserCommand>(request);
        var createUserResult =
            await _commandBus.Send<RegisterUserCommand, RegisterUserCommandResult>(createUserCommand);

        return createUserResult.Match(
             createUser => Ok(createUser),
             errors => Problem(errors));
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginDto request)
    {
        var loginUserCommand = _mapper.Map<LoginUserCommand>(request);
        var loginUserResult =
            await _commandBus.Send<LoginUserCommand, LoginUserCommandResult>(loginUserCommand);

        return loginUserResult.Match(
             loginUser => Ok(loginUser),
             errors => Problem(errors));
    }

}

