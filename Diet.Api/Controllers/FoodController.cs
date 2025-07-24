using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.Food;
using Diet.Domain.Contract.Queries.Food.GetAll;
using Diet.Domain.Contract.Queries.Food.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Food")]
public class FoodController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public FoodController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateFood))]
    public async Task<IActionResult> CreateFood(CreateFoodDto request)
    {
        var createFoodCommand = _mapper.Map<CreateFoodCommand>(request);
         
        var createFoodResult =
            await _commandBus.Send<CreateFoodCommand, CreateFoodCommandResult>(createFoodCommand);

        return createFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFood))]
    public async Task<IActionResult> UpdateFood(UpdateFoodDto request)
    {
        var updateFoodCommand = _mapper.Map<UpdateFoodCommand>(request);

        var updateFoodResult =
            await _commandBus.Send<UpdateFoodCommand, UpdateFoodCommandResult>(updateFoodCommand);

        return updateFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFood))]
    public async Task<IActionResult> DeleteFood(DeleteFoodDto request)
    {

        var deleteFoodCommand = _mapper.Map<DeleteFoodCommand>(request);

        var deleteFoodResult =
            await _commandBus.Send<DeleteFoodCommand, DeleteFoodCommandResult>(deleteFoodCommand);

        return deleteFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFood))]
    public async Task<IActionResult> GetFood([FromQuery] GetFoodDto request)
    {

        var getFoodQuery= _mapper.Map<GetByIdFoodQuery>(request);

        var createFoodResult =
            await _queryBus.Send<GetByIdFoodQuery, GetByIdFoodQueryResult>(getFoodQuery);

        return createFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFood))]
    public async Task<IActionResult> GetAllFood([FromQuery] GetAllFoodDto request)
    {

        var getAllFoodQuery = _mapper.Map<GetAllFoodQuery>(request);

        var createFoodResult =
            await _queryBus.Send<GetAllFoodQuery, GetAllFoodQueryResult>(getAllFoodQuery);

        return createFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

