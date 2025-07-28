using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Create;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Delete;
using Diet.Domain.Contract.Commands.SupplementDurationAge.Update;
using Diet.Domain.Contract.DTOs.SupplementDurationAge;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetAll;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("SupplementDurationAge")]
public class SupplementDurationAgeController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SupplementDurationAgeController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSupplementDurationAge))]
    public async Task<IActionResult> CreateSupplementDurationAge(CreateSupplementDurationAgeDto request)
    {
        var createSupplementDurationAgeCommand = _mapper.Map<CreateSupplementDurationAgeCommand>(request);
         
        var createSupplementDurationAgeResult =
            await _commandBus.Send<CreateSupplementDurationAgeCommand, CreateSupplementDurationAgeCommandResult>(createSupplementDurationAgeCommand);

        return createSupplementDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSupplementDurationAge))]
    public async Task<IActionResult> UpdateSupplementDurationAge(UpdateSupplementDurationAgeDto request)
    {
        var updateSupplementDurationAgeCommand = _mapper.Map<UpdateSupplementDurationAgeCommand>(request);

        var updateSupplementDurationAgeResult =
            await _commandBus.Send<UpdateSupplementDurationAgeCommand, UpdateSupplementDurationAgeCommandResult>(updateSupplementDurationAgeCommand);

        return updateSupplementDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSupplementDurationAge))]
    public async Task<IActionResult> DeleteSupplementDurationAge(DeleteSupplementDurationAgeDto request)
    {

        var deleteSupplementDurationAgeCommand = _mapper.Map<DeleteSupplementDurationAgeCommand>(request);

        var deleteSupplementDurationAgeResult =
            await _commandBus.Send<DeleteSupplementDurationAgeCommand, DeleteSupplementDurationAgeCommandResult>(deleteSupplementDurationAgeCommand);

        return deleteSupplementDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSupplementDurationAge))]
    public async Task<IActionResult> GetSupplementDurationAge([FromQuery] GetSupplementDurationAgeDto request)
    {

        var getSupplementDurationAgeQuery= _mapper.Map<GetByIdSupplementDurationAgeQuery>(request);

        var createSupplementDurationAgeResult =
            await _queryBus.Send<GetByIdSupplementDurationAgeQuery, GetByIdSupplementDurationAgeQueryResult>(getSupplementDurationAgeQuery);

        return createSupplementDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSupplementDurationAge))]
    public async Task<IActionResult> GetAllSupplementDurationAge([FromQuery] GetAllSupplementDurationAgeDto request)
    {

        var getAllSupplementDurationAgeQuery = _mapper.Map<GetAllSupplementDurationAgeQuery>(request);

        var createSupplementDurationAgeResult =
            await _queryBus.Send<GetAllSupplementDurationAgeQuery, GetAllSupplementDurationAgeQueryResult>(getAllSupplementDurationAgeQuery);

        return createSupplementDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

