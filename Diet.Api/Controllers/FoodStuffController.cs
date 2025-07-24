using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.FoodStuff;
using Diet.Domain.Contract.Queries.FoodStuff.GetAll;
using Diet.Domain.Contract.Queries.FoodStuff.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodStuff")]
public class FoodStuffController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public FoodStuffController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateFoodStuff))]
    public async Task<IActionResult> CreateFoodStuff(CreateFoodStuffDto request)
    {
        var createFoodStuffCommand = _mapper.Map<CreateFoodStuffCommand>(request);
         
        var createFoodStuffResult =
            await _commandBus.Send<CreateFoodStuffCommand, CreateFoodStuffCommandResult>(createFoodStuffCommand);

        return createFoodStuffResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFoodStuff))]
    public async Task<IActionResult> UpdateFoodStuff(UpdateFoodStuffDto request)
    {
        var updateFoodStuffCommand = _mapper.Map<UpdateFoodStuffCommand>(request);

        var updateFoodStuffResult =
            await _commandBus.Send<UpdateFoodStuffCommand, UpdateFoodStuffCommandResult>(updateFoodStuffCommand);

        return updateFoodStuffResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFoodStuff))]
    public async Task<IActionResult> DeleteFoodStuff(DeleteFoodStuffDto request)
    {

        var deleteFoodStuffCommand = _mapper.Map<DeleteFoodStuffCommand>(request);

        var deleteFoodStuffResult =
            await _commandBus.Send<DeleteFoodStuffCommand, DeleteFoodStuffCommandResult>(deleteFoodStuffCommand);

        return deleteFoodStuffResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFoodStuff))]
    public async Task<IActionResult> GetFoodStuff([FromQuery] GetFoodStuffDto request)
    {

        var getFoodStuffQuery= _mapper.Map<GetByIdFoodStuffQuery>(request);

        var createFoodStuffResult =
            await _queryBus.Send<GetByIdFoodStuffQuery, GetByIdFoodStuffQueryResult>(getFoodStuffQuery);

        return createFoodStuffResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFoodStuff))]
    public async Task<IActionResult> GetAllFoodStuff([FromQuery] GetAllFoodStuffDto request)
    {

        var getAllFoodStuffQuery = _mapper.Map<GetAllFoodStuffQuery>(request);

        var createFoodStuffResult =
            await _queryBus.Send<GetAllFoodStuffQuery, GetAllFoodStuffQueryResult>(getAllFoodStuffQuery);

        return createFoodStuffResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

