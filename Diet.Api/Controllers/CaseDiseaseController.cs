using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.CaseDisease;
using Diet.Domain.Contract.Queries.CaseDisease.GetAll;
using Diet.Domain.Contract.Queries.CaseDisease.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("CaseDisease")]
public class CaseDiseaseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CaseDiseaseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCaseDisease))]
    public async Task<IActionResult> CreateCaseDisease(CreateCaseDiseaseDto request)
    {
        var createCaseDiseaseCommand = _mapper.Map<CreateCaseDiseaseCommand>(request);
         
        var createCaseDiseaseResult =
            await _commandBus.Send<CreateCaseDiseaseCommand, CreateCaseDiseaseCommandResult>(createCaseDiseaseCommand);

        return createCaseDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCaseDisease))]
    public async Task<IActionResult> UpdateCaseDisease(UpdateCaseDiseaseDto request)
    {
        var updateCaseDiseaseCommand = _mapper.Map<UpdateCaseDiseaseCommand>(request);

        var updateCaseDiseaseResult =
            await _commandBus.Send<UpdateCaseDiseaseCommand, UpdateCaseDiseaseCommandResult>(updateCaseDiseaseCommand);

        return updateCaseDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCaseDisease))]
    public async Task<IActionResult> DeleteCaseDisease(DeleteCaseDiseaseDto request)
    {

        var deleteCaseDiseaseCommand = _mapper.Map<DeleteCaseDiseaseCommand>(request);

        var deleteCaseDiseaseResult =
            await _commandBus.Send<DeleteCaseDiseaseCommand, DeleteCaseDiseaseCommandResult>(deleteCaseDiseaseCommand);

        return deleteCaseDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCaseDisease))]
    public async Task<IActionResult> GetCaseDisease([FromQuery] GetCaseDiseaseDto request)
    {

        var getCaseDiseaseQuery= _mapper.Map<GetByIdCaseDiseaseQuery>(request);

        var createCaseDiseaseResult =
            await _queryBus.Send<GetByIdCaseDiseaseQuery, GetByIdCaseDiseaseQueryResult>(getCaseDiseaseQuery);

        return createCaseDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCaseDisease))]
    public async Task<IActionResult> GetAllCaseDisease([FromQuery] GetAllCaseDiseaseDto request)
    {

        var getAllCaseDiseaseQuery = _mapper.Map<GetAllCaseDiseaseQuery>(request);

        var createCaseDiseaseResult =
            await _queryBus.Send<GetAllCaseDiseaseQuery, GetAllCaseDiseaseQueryResult>(getAllCaseDiseaseQuery);

        return createCaseDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

