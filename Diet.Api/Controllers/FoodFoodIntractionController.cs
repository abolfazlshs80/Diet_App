using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.FoodFoodIntraction;
using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetAll;
using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodFoodIntraction")]
public class FoodFoodIntractionController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public FoodFoodIntractionController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateFoodFoodIntraction))]
    public async Task<IActionResult> CreateFoodFoodIntraction(CreateFoodFoodIntractionDto request)
    {
        var createFoodFoodIntractionCommand = _mapper.Map<CreateFoodFoodIntractionCommand>(request);
         
        var createFoodFoodIntractionResult =
            await _commandBus.Send<CreateFoodFoodIntractionCommand, CreateFoodFoodIntractionCommandResult>(createFoodFoodIntractionCommand);

        return createFoodFoodIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFoodFoodIntraction))]
    public async Task<IActionResult> UpdateFoodFoodIntraction(UpdateFoodFoodIntractionDto request)
    {
        var updateFoodFoodIntractionCommand = _mapper.Map<UpdateFoodFoodIntractionCommand>(request);

        var updateFoodFoodIntractionResult =
            await _commandBus.Send<UpdateFoodFoodIntractionCommand, UpdateFoodFoodIntractionCommandResult>(updateFoodFoodIntractionCommand);

        return updateFoodFoodIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFoodFoodIntraction))]
    public async Task<IActionResult> DeleteFoodFoodIntraction(DeleteFoodFoodIntractionDto request)
    {

        var deleteFoodFoodIntractionCommand = _mapper.Map<DeleteFoodFoodIntractionCommand>(request);

        var deleteFoodFoodIntractionResult =
            await _commandBus.Send<DeleteFoodFoodIntractionCommand, DeleteFoodFoodIntractionCommandResult>(deleteFoodFoodIntractionCommand);

        return deleteFoodFoodIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFoodFoodIntraction))]
    public async Task<IActionResult> GetFoodFoodIntraction([FromQuery] GetFoodFoodIntractionDto request)
    {

        var getFoodFoodIntractionQuery= _mapper.Map<GetByIdFoodFoodIntractionQuery>(request);

        var createFoodFoodIntractionResult =
            await _queryBus.Send<GetByIdFoodFoodIntractionQuery, GetByIdFoodFoodIntractionQueryResult>(getFoodFoodIntractionQuery);

        return createFoodFoodIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFoodFoodIntraction))]
    public async Task<IActionResult> GetAllFoodFoodIntraction([FromQuery] GetAllFoodFoodIntractionDto request)
    {

        var getAllFoodFoodIntractionQuery = _mapper.Map<GetAllFoodFoodIntractionQuery>(request);

        var createFoodFoodIntractionResult =
            await _queryBus.Send<GetAllFoodFoodIntractionQuery, GetAllFoodFoodIntractionQueryResult>(getAllFoodFoodIntractionQuery);

        return createFoodFoodIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

