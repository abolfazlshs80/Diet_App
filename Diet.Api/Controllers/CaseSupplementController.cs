using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.CaseSupplement;
using Diet.Domain.Contract.Queries.CaseSupplement.GetAll;
using Diet.Domain.Contract.Queries.CaseSupplement.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("CaseSupplement")]
public class CaseSupplementController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CaseSupplementController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCaseSupplement))]
    public async Task<IActionResult> CreateCaseSupplement(CreateCaseSupplementDto request)
    {
        var createCaseSupplementCommand = _mapper.Map<CreateCaseSupplementCommand>(request);
         
        var createCaseSupplementResult =
            await _commandBus.Send<CreateCaseSupplementCommand, CreateCaseSupplementCommandResult>(createCaseSupplementCommand);

        return createCaseSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCaseSupplement))]
    public async Task<IActionResult> UpdateCaseSupplement(UpdateCaseSupplementDto request)
    {
        var updateCaseSupplementCommand = _mapper.Map<UpdateCaseSupplementCommand>(request);

        var updateCaseSupplementResult =
            await _commandBus.Send<UpdateCaseSupplementCommand, UpdateCaseSupplementCommandResult>(updateCaseSupplementCommand);

        return updateCaseSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCaseSupplement))]
    public async Task<IActionResult> DeleteCaseSupplement(DeleteCaseSupplementDto request)
    {

        var deleteCaseSupplementCommand = _mapper.Map<DeleteCaseSupplementCommand>(request);

        var deleteCaseSupplementResult =
            await _commandBus.Send<DeleteCaseSupplementCommand, DeleteCaseSupplementCommandResult>(deleteCaseSupplementCommand);

        return deleteCaseSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCaseSupplement))]
    public async Task<IActionResult> GetCaseSupplement([FromQuery] GetCaseSupplementDto request)
    {

        var getCaseSupplementQuery= _mapper.Map<GetByIdCaseSupplementQuery>(request);

        var createCaseSupplementResult =
            await _queryBus.Send<GetByIdCaseSupplementQuery, GetByIdCaseSupplementQueryResult>(getCaseSupplementQuery);

        return createCaseSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCaseSupplement))]
    public async Task<IActionResult> GetAllCaseSupplement([FromQuery] GetAllCaseSupplementDto request)
    {

        var getAllCaseSupplementQuery = _mapper.Map<GetAllCaseSupplementQuery>(request);

        var createCaseSupplementResult =
            await _queryBus.Send<GetAllCaseSupplementQuery, GetAllCaseSupplementQueryResult>(getAllCaseSupplementQuery);

        return createCaseSupplementResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

