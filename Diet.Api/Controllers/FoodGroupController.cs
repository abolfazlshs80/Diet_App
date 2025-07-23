using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.FoodGroup;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodGroup")]
public class FoodGroupController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public FoodGroupController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateFoodGroup))]
    public async Task<IActionResult> CreateFoodGroup(CreateFoodGroupDto request)
    {
        var createFoodGroupCommand = _mapper.Map<CreateFoodGroupCommand>(request);
         
        var createFoodGroupResult =
            await _commandBus.Send<CreateFoodGroupCommand, CreateFoodGroupCommandResult>(createFoodGroupCommand);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFoodGroup))]
    public async Task<IActionResult> UpdateFoodGroup(UpdateFoodGroupDto request)
    {
        var updateFoodGroupCommand = _mapper.Map<UpdateFoodGroupCommand>(request);

        var updateFoodGroupResult =
            await _commandBus.Send<UpdateFoodGroupCommand, UpdateFoodGroupCommandResult>(updateFoodGroupCommand);

        return updateFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFoodGroup))]
    public async Task<IActionResult> DeleteFoodGroup(DeleteFoodGroupDto request)
    {

        var deleteFoodGroupCommand = _mapper.Map<DeleteFoodGroupCommand>(request);

        var deleteFoodGroupResult =
            await _commandBus.Send<DeleteFoodGroupCommand, DeleteFoodGroupCommandResult>(deleteFoodGroupCommand);

        return deleteFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFoodGroup))]
    public async Task<IActionResult> GetFoodGroup([FromQuery] GetFoodGroupDto request)
    {

        var getFoodGroupQuery= _mapper.Map<GetByIdFoodGroupQuery>(request);

        var createFoodGroupResult =
            await _queryBus.Send<GetByIdFoodGroupQuery, GetByIdFoodGroupQueryResult>(getFoodGroupQuery);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFoodGroup))]
    public async Task<IActionResult> GetAllFoodGroup([FromQuery] GetAllFoodGroupDto request)
    {

        var getAllFoodGroupQuery = _mapper.Map<GetAllFoodGroupQuery>(request);

        var createFoodGroupResult =
            await _queryBus.Send<GetAllFoodGroupQuery, GetAllFoodGroupQueryResult>(getAllFoodGroupQuery);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

