using Diet.Domain.Contract.Commands.Users.Create;
using Diet.Domain.Contract.Commands.Users.Delete;
using Diet.Domain.Contract.Commands.Users.Update;
using Diet.Domain.Contract.DTOs.Users;
using Diet.Domain.Contract.Queries.Users.GetAll;
using Diet.Domain.Contract.Queries.Users.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Users")]
public class UsersController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;

    public UsersController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateUsers))]
    public async Task<IActionResult> CreateUsers(CreateUsersDto request)
    {
        var command = _mapper.Map<CreateUsersCommand>(request);
        var result = await _commandBus.Send<CreateUsersCommand, CreateUsersCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpPut(nameof(UpdateUsers))]
    public async Task<IActionResult> UpdateUsers(UpdateUsersDto request)
    {
        var command = _mapper.Map<UpdateUsersCommand>(request);
        var result = await _commandBus.Send<UpdateUsersCommand, UpdateUsersCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpDelete(nameof(DeleteUsers))]
    public async Task<IActionResult> DeleteUsers(DeleteUsersDto request)
    {
        var command = _mapper.Map<DeleteUsersCommand>(request);
        var result = await _commandBus.Send<DeleteUsersCommand, DeleteUsersCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetUsers))]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersDto request)
    {
        var query = _mapper.Map<GetByIdUsersQuery>(request);
        var result = await _queryBus.Send<GetByIdUsersQuery, GetByIdUsersQueryResult>(query);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersDto request)
    {
        var query = _mapper.Map<GetAllUsersQuery>(request);
        var result = await _queryBus.Send<GetAllUsersQuery, GetAllUsersQueryResult>(query);
        return result.Match(Ok, Problem);
    }
}
