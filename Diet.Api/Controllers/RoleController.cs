using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.Role.Create;
using Diet.Domain.Contract.Commands.Role.Delete;
using Diet.Domain.Contract.Commands.Role.Update;
using Diet.Domain.Contract.DTOs.Role;
using Diet.Domain.Contract.Queries.Role.GetAll;
using Diet.Domain.Contract.Queries.Role.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Role")]
public class RoleController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public RoleController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRole))]
    public async Task<IActionResult> CreateRole(CreateRoleDto request)
    {
        var createRoleCommand = _mapper.Map<CreateRoleCommand>(request);
         
        var createRoleResult =
            await _commandBus.Send<CreateRoleCommand, CreateRoleCommandResult>(createRoleCommand);

        return createRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateRole))]
    public async Task<IActionResult> UpdateRole(UpdateRoleDto request)
    {
        var updateRoleCommand = _mapper.Map<UpdateRoleCommand>(request);

        var updateRoleResult =
            await _commandBus.Send<UpdateRoleCommand, UpdateRoleCommandResult>(updateRoleCommand);

        return updateRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteRole))]
    public async Task<IActionResult> DeleteRole(DeleteRoleDto request)
    {

        var deleteRoleCommand = _mapper.Map<DeleteRoleCommand>(request);

        var deleteRoleResult =
            await _commandBus.Send<DeleteRoleCommand, DeleteRoleCommandResult>(deleteRoleCommand);

        return deleteRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetRole))]
    public async Task<IActionResult> GetRole([FromQuery] GetRoleDto request)
    {

        var getRoleQuery= _mapper.Map<GetByIdRoleQuery>(request);

        var createRoleResult =
            await _queryBus.Send<GetByIdRoleQuery, GetByIdRoleQueryResult>(getRoleQuery);

        return createRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllRole))]
    public async Task<IActionResult> GetAllRole([FromQuery] GetAllRoleDto request)
    {

        var getAllRoleQuery = _mapper.Map<GetAllRoleQuery>(request);

        var createRoleResult =
            await _queryBus.Send<GetAllRoleQuery, GetAllRoleQueryResult>(getAllRoleQuery);

        return createRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

