using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.Sport.Create;
using Diet.Domain.Contract.Commands.Sport.Delete;
using Diet.Domain.Contract.Commands.Sport.Update;
using Diet.Domain.Contract.DTOs.Sport;
using Diet.Domain.Contract.Queries.Sport.GetAll;
using Diet.Domain.Contract.Queries.Sport.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Sport")]
public class SportController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SportController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSport))]
    public async Task<IActionResult> CreateSport(CreateSportDto request)
    {
        var createSportCommand = _mapper.Map<CreateSportCommand>(request);
         
        var createSportResult =
            await _commandBus.Send<CreateSportCommand, CreateSportCommandResult>(createSportCommand);

        return createSportResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSport))]
    public async Task<IActionResult> UpdateSport(UpdateSportDto request)
    {
        var updateSportCommand = _mapper.Map<UpdateSportCommand>(request);

        var updateSportResult =
            await _commandBus.Send<UpdateSportCommand, UpdateSportCommandResult>(updateSportCommand);

        return updateSportResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSport))]
    public async Task<IActionResult> DeleteSport(DeleteSportDto request)
    {

        var deleteSportCommand = _mapper.Map<DeleteSportCommand>(request);

        var deleteSportResult =
            await _commandBus.Send<DeleteSportCommand, DeleteSportCommandResult>(deleteSportCommand);

        return deleteSportResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSport))]
    public async Task<IActionResult> GetSport([FromQuery] GetSportDto request)
    {

        var getSportQuery= _mapper.Map<GetByIdSportQuery>(request);

        var createSportResult =
            await _queryBus.Send<GetByIdSportQuery, GetByIdSportQueryResult>(getSportQuery);

        return createSportResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSport))]
    public async Task<IActionResult> GetAllSport([FromQuery] GetAllSportDto request)
    {

        var getAllSportQuery = _mapper.Map<GetAllSportQuery>(request);

        var createSportResult =
            await _queryBus.Send<GetAllSportQuery, GetAllSportQueryResult>(getAllSportQuery);

        return createSportResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

