using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.SupplementGroup.Create;
using Diet.Domain.Contract.Commands.SupplementGroup.Delete;
using Diet.Domain.Contract.Commands.SupplementGroup.Update;
using Diet.Domain.Contract.DTOs.SupplementGroup;
using Diet.Domain.Contract.Queries.SupplementGroup.GetAll;
using Diet.Domain.Contract.Queries.SupplementGroup.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("SupplementGroup")]
public class SupplementGroupController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SupplementGroupController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSupplementGroup))]
    public async Task<IActionResult> CreateSupplementGroup(CreateSupplementGroupDto request)
    {
        var createSupplementGroupCommand = _mapper.Map<CreateSupplementGroupCommand>(request);
         
        var createSupplementGroupResult =
            await _commandBus.Send<CreateSupplementGroupCommand, CreateSupplementGroupCommandResult>(createSupplementGroupCommand);

        return createSupplementGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSupplementGroup))]
    public async Task<IActionResult> UpdateSupplementGroup(UpdateSupplementGroupDto request)
    {
        var updateSupplementGroupCommand = _mapper.Map<UpdateSupplementGroupCommand>(request);

        var updateSupplementGroupResult =
            await _commandBus.Send<UpdateSupplementGroupCommand, UpdateSupplementGroupCommandResult>(updateSupplementGroupCommand);

        return updateSupplementGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSupplementGroup))]
    public async Task<IActionResult> DeleteSupplementGroup(DeleteSupplementGroupDto request)
    {

        var deleteSupplementGroupCommand = _mapper.Map<DeleteSupplementGroupCommand>(request);

        var deleteSupplementGroupResult =
            await _commandBus.Send<DeleteSupplementGroupCommand, DeleteSupplementGroupCommandResult>(deleteSupplementGroupCommand);

        return deleteSupplementGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSupplementGroup))]
    public async Task<IActionResult> GetSupplementGroup([FromQuery] GetSupplementGroupDto request)
    {

        var getSupplementGroupQuery= _mapper.Map<GetByIdSupplementGroupQuery>(request);

        var createSupplementGroupResult =
            await _queryBus.Send<GetByIdSupplementGroupQuery, GetByIdSupplementGroupQueryResult>(getSupplementGroupQuery);

        return createSupplementGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSupplementGroup))]
    public async Task<IActionResult> GetAllSupplementGroup([FromQuery] GetAllSupplementGroupDto request)
    {

        var getAllSupplementGroupQuery = _mapper.Map<GetAllSupplementGroupQuery>(request);

        var createSupplementGroupResult =
            await _queryBus.Send<GetAllSupplementGroupQuery, GetAllSupplementGroupQueryResult>(getAllSupplementGroupQuery);

        return createSupplementGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

