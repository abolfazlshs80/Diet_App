using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.Case;
using Diet.Domain.Contract.Queries.Case.GetAll;
using Diet.Domain.Contract.Queries.Case.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Case")]
public class CaseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CaseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCase))]
    public async Task<IActionResult> CreateCase(CreateCaseDto request)
    {
        var createCaseCommand = _mapper.Map<CreateCaseCommand>(request);
         
        var createCaseResult =
            await _commandBus.Send<CreateCaseCommand, CreateCaseCommandResult>(createCaseCommand);

        return createCaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCase))]
    public async Task<IActionResult> UpdateCase(UpdateCaseDto request)
    {
        var updateCaseCommand = _mapper.Map<UpdateCaseCommand>(request);

        var updateCaseResult =
            await _commandBus.Send<UpdateCaseCommand, UpdateCaseCommandResult>(updateCaseCommand);

        return updateCaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCase))]
    public async Task<IActionResult> DeleteCase(DeleteCaseDto request)
    {

        var deleteCaseCommand = _mapper.Map<DeleteCaseCommand>(request);

        var deleteCaseResult =
            await _commandBus.Send<DeleteCaseCommand, DeleteCaseCommandResult>(deleteCaseCommand);

        return deleteCaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCase))]
    public async Task<IActionResult> GetCase([FromQuery] GetCaseDto request)
    {

        var getCaseQuery= _mapper.Map<GetByIdCaseQuery>(request);

        var createCaseResult =
            await _queryBus.Send<GetByIdCaseQuery, GetByIdCaseQueryResult>(getCaseQuery);

        return createCaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCase))]
    public async Task<IActionResult> GetAllCase([FromQuery] GetAllCaseDto request)
    {

        var getAllCaseQuery = _mapper.Map<GetAllCaseQuery>(request);

        var createCaseResult =
            await _queryBus.Send<GetAllCaseQuery, GetAllCaseQueryResult>(getAllCaseQuery);

        return createCaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

