using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.DurationAge;
using Diet.Domain.Contract.Queries.DurationAge.GetAll;
using Diet.Domain.Contract.Queries.DurationAge.GetById;
using Diet.Domain.Contract.ViewModels.DurationAge;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("DurationAge")]
public class DurationAgeController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public DurationAgeController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateDurationAge))]
    public async Task<IActionResult> CreateDurationAge(CreateDurationAgeViewModel request)
    {
        var createDurationAgeCommand = _mapper.Map<CreateDurationAgeCommand>(request);
         
        var createDurationAgeResult =
            await _commandBus.Send<CreateDurationAgeCommand, CreateDurationAgeCommandResult>(createDurationAgeCommand);

        return createDurationAgeResult.Match(
             result => Ok(result),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateDurationAge))]
    public async Task<IActionResult> UpdateDurationAge(UpdateDurationAgeDto request)
    {
        var updateDurationAgeCommand = _mapper.Map<UpdateDurationAgeCommand>(request);

        var updateDurationAgeResult =
            await _commandBus.Send<UpdateDurationAgeCommand, UpdateDurationAgeCommandResult>(updateDurationAgeCommand);

        return updateDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteDurationAge))]
    public async Task<IActionResult> DeleteDurationAge(DeleteDurationAgeDto request)
    {

        var deleteDurationAgeCommand = _mapper.Map<DeleteDurationAgeCommand>(request);

        var deleteDurationAgeResult =
            await _commandBus.Send<DeleteDurationAgeCommand, DeleteDurationAgeCommandResult>(deleteDurationAgeCommand);

        return deleteDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPost(nameof(GetDurationAge))]
    public async Task<IActionResult> GetDurationAge(GetItemDurationAgeViewModel request)
    {

        var getDurationAgeQuery= _mapper.Map<GetByIdDurationAgeQuery>(request);

        var createDurationAgeResult =
            await _queryBus.Send<GetByIdDurationAgeQuery, GetByIdDurationAgeQueryResult>(getDurationAgeQuery);

        return createDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPost(nameof(GetAllDurationAge))]
    public async Task<IActionResult> GetAllDurationAge( GetAllDurationAgeDto request)
    {

        var getAllDurationAgeQuery = _mapper.Map<GetAllDurationAgeQuery>(request);

        var createDurationAgeResult =
            await _queryBus.Send<GetAllDurationAgeQuery, GetAllDurationAgeQueryResult>(getAllDurationAgeQuery);

        return createDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

