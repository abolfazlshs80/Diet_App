using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Diet.Framework.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("FoodGroup")]
public class FoodGroupController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
  


    public FoodGroupController(ICommandBus commandBus, IQueryBus queryBus)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
    }

    [HttpPost(nameof(CreateFoodGroup))]
    public async Task<IActionResult> CreateFoodGroup(CreateFoodGroupCommand request)
    {
       // var createFoodGroupCommand = _mapper.Map<CreateFoodGroupCommand>(request);
         
        var createFoodGroupResult =
            await _commandBus.Send<CreateFoodGroupCommand, CreateFoodGroupCommandResult>(request);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateFoodGroup))]
    public async Task<IActionResult> UpdateFoodGroup(UpdateFoodGroupCommand request)
    {
        var createFoodGroupResult =
            await _commandBus.Send<UpdateFoodGroupCommand, UpdateFoodGroupCommandResult>(request);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteFoodGroup))]
    public async Task<IActionResult> DeleteFoodGroup(DeleteFoodGroupCommand request)
    {

        var createFoodGroupResult =
            await _commandBus.Send<DeleteFoodGroupCommand, DeleteFoodGroupCommandResult>(request);

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetFoodGroup))]
    public async Task<IActionResult> GetFoodGroup(Guid Id)
    {

        var createFoodGroupResult =
            await _queryBus.Send<GetByIdFoodGroupQuery, GetByIdFoodGroupQueryResult>(new GetByIdFoodGroupQuery (Id));

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllFoodGroup))]
    public async Task<IActionResult> GetAllFoodGroup(string? search, int CurrentPage = 0, int PageSize = 8)
    {

        var createFoodGroupResult =
            await _queryBus.Send<GetAllFoodGroupQuery, GetAllFoodGroupQueryResult>(new GetAllFoodGroupQuery(search,CurrentPage,PageSize));

        return createFoodGroupResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

