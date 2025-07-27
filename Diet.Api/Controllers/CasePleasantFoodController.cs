using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.CasePleasantFood;
using Diet.Domain.Contract.Queries.CasePleasantFood.GetAll;
using Diet.Domain.Contract.Queries.CasePleasantFood.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("CasePleasantFood")]
public class CasePleasantFoodController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CasePleasantFoodController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCasePleasantFood))]
    public async Task<IActionResult> CreateCasePleasantFood(CreateCasePleasantFoodDto request)
    {
        var createCasePleasantFoodCommand = _mapper.Map<CreateCasePleasantFoodCommand>(request);
         
        var createCasePleasantFoodResult =
            await _commandBus.Send<CreateCasePleasantFoodCommand, CreateCasePleasantFoodCommandResult>(createCasePleasantFoodCommand);

        return createCasePleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCasePleasantFood))]
    public async Task<IActionResult> UpdateCasePleasantFood(UpdateCasePleasantFoodDto request)
    {
        var updateCasePleasantFoodCommand = _mapper.Map<UpdateCasePleasantFoodCommand>(request);

        var updateCasePleasantFoodResult =
            await _commandBus.Send<UpdateCasePleasantFoodCommand, UpdateCasePleasantFoodCommandResult>(updateCasePleasantFoodCommand);

        return updateCasePleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCasePleasantFood))]
    public async Task<IActionResult> DeleteCasePleasantFood(DeleteCasePleasantFoodDto request)
    {

        var deleteCasePleasantFoodCommand = _mapper.Map<DeleteCasePleasantFoodCommand>(request);

        var deleteCasePleasantFoodResult =
            await _commandBus.Send<DeleteCasePleasantFoodCommand, DeleteCasePleasantFoodCommandResult>(deleteCasePleasantFoodCommand);

        return deleteCasePleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCasePleasantFood))]
    public async Task<IActionResult> GetCasePleasantFood([FromQuery] GetCasePleasantFoodDto request)
    {

        var getCasePleasantFoodQuery= _mapper.Map<GetByIdCasePleasantFoodQuery>(request);

        var createCasePleasantFoodResult =
            await _queryBus.Send<GetByIdCasePleasantFoodQuery, GetByIdCasePleasantFoodQueryResult>(getCasePleasantFoodQuery);

        return createCasePleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCasePleasantFood))]
    public async Task<IActionResult> GetAllCasePleasantFood([FromQuery] GetAllCasePleasantFoodDto request)
    {

        var getAllCasePleasantFoodQuery = _mapper.Map<GetAllCasePleasantFoodQuery>(request);

        var createCasePleasantFoodResult =
            await _queryBus.Send<GetAllCasePleasantFoodQuery, GetAllCasePleasantFoodQueryResult>(getAllCasePleasantFoodQuery);

        return createCasePleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

