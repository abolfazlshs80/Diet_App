using Diet.Domain.Contract.Commands.UserRole.Create;
using Diet.Domain.Contract.Commands.UserRole.Delete;
using Diet.Domain.Contract.Commands.UserRole.Update;
using Diet.Domain.Contract.DTOs.UserRole;
using Diet.Domain.Contract.Queries.UserRole.GetAll;
using Diet.Domain.Contract.Queries.UserRole.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("UserRole")]
public class UserRoleController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;

    public UserRoleController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateUserRole))]
    public async Task<IActionResult> CreateUserRole(CreateUserRoleDto request)
    {
        var command = _mapper.Map<CreateUserRoleCommand>(request);
        var result = await _commandBus.Send<CreateUserRoleCommand, CreateUserRoleCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpPut(nameof(UpdateUserRole))]
    public async Task<IActionResult> UpdateUserRole(UpdateUserRoleDto request)
    {
        var command = _mapper.Map<UpdateUserRoleCommand>(request);
        var result = await _commandBus.Send<UpdateUserRoleCommand, UpdateUserRoleCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpDelete(nameof(DeleteUserRole))]
    public async Task<IActionResult> DeleteUserRole(DeleteUserRoleDto request)
    {
        var command = _mapper.Map<DeleteUserRoleCommand>(request);
        var result = await _commandBus.Send<DeleteUserRoleCommand, DeleteUserRoleCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetUserRole))]
    public async Task<IActionResult> GetUserRole([FromQuery] GetUserRoleDto request)
    {
        var query = _mapper.Map<GetByIdUserRoleQuery>(request);
        var result = await _queryBus.Send<GetByIdUserRoleQuery, GetByIdUserRoleQueryResult>(query);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetAllUserRole))]
    public async Task<IActionResult> GetAllUserRole([FromQuery] GetAllUserRoleDto request)
    {
        var query = _mapper.Map<GetAllUserRoleQuery>(request);
        var result = await _queryBus.Send<GetAllUserRoleQuery, GetAllUserRoleQueryResult>(query);
        return result.Match(Ok, Problem);
    }
}
