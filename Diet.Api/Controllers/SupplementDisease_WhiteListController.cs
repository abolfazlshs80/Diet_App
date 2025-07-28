using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Create;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Delete;
using Diet.Domain.Contract.Commands.SupplementDisease_WhiteList.Update;
using Diet.Domain.Contract.DTOs.SupplementDisease_WhiteList;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetAll;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("SupplementDisease_WhiteList")]
public class SupplementDisease_WhiteListController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SupplementDisease_WhiteListController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSupplementDisease_WhiteList))]
    public async Task<IActionResult> CreateSupplementDisease_WhiteList(CreateSupplementDisease_WhiteListDto request)
    {
        var createSupplementDisease_WhiteListCommand = _mapper.Map<CreateSupplementDisease_WhiteListCommand>(request);
         
        var createSupplementDisease_WhiteListResult =
            await _commandBus.Send<CreateSupplementDisease_WhiteListCommand, CreateSupplementDisease_WhiteListCommandResult>(createSupplementDisease_WhiteListCommand);

        return createSupplementDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSupplementDisease_WhiteList))]
    public async Task<IActionResult> UpdateSupplementDisease_WhiteList(UpdateSupplementDisease_WhiteListDto request)
    {
        var updateSupplementDisease_WhiteListCommand = _mapper.Map<UpdateSupplementDisease_WhiteListCommand>(request);

        var updateSupplementDisease_WhiteListResult =
            await _commandBus.Send<UpdateSupplementDisease_WhiteListCommand, UpdateSupplementDisease_WhiteListCommandResult>(updateSupplementDisease_WhiteListCommand);

        return updateSupplementDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSupplementDisease_WhiteList))]
    public async Task<IActionResult> DeleteSupplementDisease_WhiteList(DeleteSupplementDisease_WhiteListDto request)
    {

        var deleteSupplementDisease_WhiteListCommand = _mapper.Map<DeleteSupplementDisease_WhiteListCommand>(request);

        var deleteSupplementDisease_WhiteListResult =
            await _commandBus.Send<DeleteSupplementDisease_WhiteListCommand, DeleteSupplementDisease_WhiteListCommandResult>(deleteSupplementDisease_WhiteListCommand);

        return deleteSupplementDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSupplementDisease_WhiteList))]
    public async Task<IActionResult> GetSupplementDisease_WhiteList([FromQuery] GetSupplementDisease_WhiteListDto request)
    {

        var getSupplementDisease_WhiteListQuery= _mapper.Map<GetByIdSupplementDisease_WhiteListQuery>(request);

        var createSupplementDisease_WhiteListResult =
            await _queryBus.Send<GetByIdSupplementDisease_WhiteListQuery, GetByIdSupplementDisease_WhiteListQueryResult>(getSupplementDisease_WhiteListQuery);

        return createSupplementDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSupplementDisease_WhiteList))]
    public async Task<IActionResult> GetAllSupplementDisease_WhiteList([FromQuery] GetAllSupplementDisease_WhiteListDto request)
    {

        var getAllSupplementDisease_WhiteListQuery = _mapper.Map<GetAllSupplementDisease_WhiteListQuery>(request);

        var createSupplementDisease_WhiteListResult =
            await _queryBus.Send<GetAllSupplementDisease_WhiteListQuery, GetAllSupplementDisease_WhiteListQueryResult>(getAllSupplementDisease_WhiteListQuery);

        return createSupplementDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

