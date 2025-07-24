using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.FoodDrugIntraction;
using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetAll;
using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodDrugIntraction")]
public class FoodDrugIntractionController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public FoodDrugIntractionController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateFoodDrugIntraction))]
    public async Task<IActionResult> CreateFoodDrugIntraction(CreateFoodDrugIntractionDto request)
    {
        var createFoodDrugIntractionCommand = _mapper.Map<CreateFoodDrugIntractionCommand>(request);
         
        var createFoodDrugIntractionResult =
            await _commandBus.Send<CreateFoodDrugIntractionCommand, CreateFoodDrugIntractionCommandResult>(createFoodDrugIntractionCommand);

        return createFoodDrugIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFoodDrugIntraction))]
    public async Task<IActionResult> UpdateFoodDrugIntraction(UpdateFoodDrugIntractionDto request)
    {
        var updateFoodDrugIntractionCommand = _mapper.Map<UpdateFoodDrugIntractionCommand>(request);

        var updateFoodDrugIntractionResult =
            await _commandBus.Send<UpdateFoodDrugIntractionCommand, UpdateFoodDrugIntractionCommandResult>(updateFoodDrugIntractionCommand);

        return updateFoodDrugIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFoodDrugIntraction))]
    public async Task<IActionResult> DeleteFoodDrugIntraction(DeleteFoodDrugIntractionDto request)
    {

        var deleteFoodDrugIntractionCommand = _mapper.Map<DeleteFoodDrugIntractionCommand>(request);

        var deleteFoodDrugIntractionResult =
            await _commandBus.Send<DeleteFoodDrugIntractionCommand, DeleteFoodDrugIntractionCommandResult>(deleteFoodDrugIntractionCommand);

        return deleteFoodDrugIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFoodDrugIntraction))]
    public async Task<IActionResult> GetFoodDrugIntraction([FromQuery] GetFoodDrugIntractionDto request)
    {

        var getFoodDrugIntractionQuery= _mapper.Map<GetByIdFoodDrugIntractionQuery>(request);

        var createFoodDrugIntractionResult =
            await _queryBus.Send<GetByIdFoodDrugIntractionQuery, GetByIdFoodDrugIntractionQueryResult>(getFoodDrugIntractionQuery);

        return createFoodDrugIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFoodDrugIntraction))]
    public async Task<IActionResult> GetAllFoodDrugIntraction([FromQuery] GetAllFoodDrugIntractionDto request)
    {

        var getAllFoodDrugIntractionQuery = _mapper.Map<GetAllFoodDrugIntractionQuery>(request);

        var createFoodDrugIntractionResult =
            await _queryBus.Send<GetAllFoodDrugIntractionQuery, GetAllFoodDrugIntractionQueryResult>(getAllFoodDrugIntractionQuery);

        return createFoodDrugIntractionResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

