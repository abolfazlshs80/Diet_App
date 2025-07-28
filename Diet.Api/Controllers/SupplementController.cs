using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.Supplement.Create;
using Diet.Domain.Contract.Commands.Supplement.Delete;
using Diet.Domain.Contract.Commands.Supplement.Update;
using Diet.Domain.Contract.DTOs.Supplement;
using Diet.Domain.Contract.Queries.Supplement.GetAll;
using Diet.Domain.Contract.Queries.Supplement.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Supplement")]
public class SupplementController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SupplementController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSupplement))]
    public async Task<IActionResult> CreateSupplement(CreateSupplementDto request)
    {
        var createSupplementCommand = _mapper.Map<CreateSupplementCommand>(request);
         
        var createSupplementResult =
            await _commandBus.Send<CreateSupplementCommand, CreateSupplementCommandResult>(createSupplementCommand);

        return createSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSupplement))]
    public async Task<IActionResult> UpdateSupplement(UpdateSupplementDto request)
    {
        var updateSupplementCommand = _mapper.Map<UpdateSupplementCommand>(request);

        var updateSupplementResult =
            await _commandBus.Send<UpdateSupplementCommand, UpdateSupplementCommandResult>(updateSupplementCommand);

        return updateSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSupplement))]
    public async Task<IActionResult> DeleteSupplement(DeleteSupplementDto request)
    {

        var deleteSupplementCommand = _mapper.Map<DeleteSupplementCommand>(request);

        var deleteSupplementResult =
            await _commandBus.Send<DeleteSupplementCommand, DeleteSupplementCommandResult>(deleteSupplementCommand);

        return deleteSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSupplement))]
    public async Task<IActionResult> GetSupplement([FromQuery] GetSupplementDto request)
    {

        var getSupplementQuery= _mapper.Map<GetByIdSupplementQuery>(request);

        var createSupplementResult =
            await _queryBus.Send<GetByIdSupplementQuery, GetByIdSupplementQueryResult>(getSupplementQuery);

        return createSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSupplement))]
    public async Task<IActionResult> GetAllSupplement([FromQuery] GetAllSupplementDto request)
    {

        var getAllSupplementQuery = _mapper.Map<GetAllSupplementQuery>(request);

        var createSupplementResult =
            await _queryBus.Send<GetAllSupplementQuery, GetAllSupplementQueryResult>(getAllSupplementQuery);

        return createSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

