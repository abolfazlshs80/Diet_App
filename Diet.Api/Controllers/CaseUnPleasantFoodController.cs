using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.CaseUnPleasantFood;
using Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetAll;
using Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("CaseUnPleasantFood")]
public class CaseUnPleasantFoodController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CaseUnPleasantFoodController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCaseUnPleasantFood))]
    public async Task<IActionResult> CreateCaseUnPleasantFood(CreateCaseUnPleasantFoodDto request)
    {
        var createCaseUnPleasantFoodCommand = _mapper.Map<CreateCaseUnPleasantFoodCommand>(request);
         
        var createCaseUnPleasantFoodResult =
            await _commandBus.Send<CreateCaseUnPleasantFoodCommand, CreateCaseUnPleasantFoodCommandResult>(createCaseUnPleasantFoodCommand);

        return createCaseUnPleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCaseUnPleasantFood))]
    public async Task<IActionResult> UpdateCaseUnPleasantFood(UpdateCaseUnPleasantFoodDto request)
    {
        var updateCaseUnPleasantFoodCommand = _mapper.Map<UpdateCaseUnPleasantFoodCommand>(request);

        var updateCaseUnPleasantFoodResult =
            await _commandBus.Send<UpdateCaseUnPleasantFoodCommand, UpdateCaseUnPleasantFoodCommandResult>(updateCaseUnPleasantFoodCommand);

        return updateCaseUnPleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCaseUnPleasantFood))]
    public async Task<IActionResult> DeleteCaseUnPleasantFood(DeleteCaseUnPleasantFoodDto request)
    {

        var deleteCaseUnPleasantFoodCommand = _mapper.Map<DeleteCaseUnPleasantFoodCommand>(request);

        var deleteCaseUnPleasantFoodResult =
            await _commandBus.Send<DeleteCaseUnPleasantFoodCommand, DeleteCaseUnPleasantFoodCommandResult>(deleteCaseUnPleasantFoodCommand);

        return deleteCaseUnPleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCaseUnPleasantFood))]
    public async Task<IActionResult> GetCaseUnPleasantFood([FromQuery] GetCaseUnPleasantFoodDto request)
    {

        var getCaseUnPleasantFoodQuery= _mapper.Map<GetByIdCaseUnPleasantFoodQuery>(request);

        var createCaseUnPleasantFoodResult =
            await _queryBus.Send<GetByIdCaseUnPleasantFoodQuery, GetByIdCaseUnPleasantFoodQueryResult>(getCaseUnPleasantFoodQuery);

        return createCaseUnPleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCaseUnPleasantFood))]
    public async Task<IActionResult> GetAllCaseUnPleasantFood([FromQuery] GetAllCaseUnPleasantFoodDto request)
    {

        var getAllCaseUnPleasantFoodQuery = _mapper.Map<GetAllCaseUnPleasantFoodQuery>(request);

        var createCaseUnPleasantFoodResult =
            await _queryBus.Send<GetAllCaseUnPleasantFoodQuery, GetAllCaseUnPleasantFoodQueryResult>(getAllCaseUnPleasantFoodQuery);

        return createCaseUnPleasantFoodResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

