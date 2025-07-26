using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.Disease;
using Diet.Domain.Contract.Queries.Disease.GetAll;
using Diet.Domain.Contract.Queries.Disease.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Disease")]
public class DiseaseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public DiseaseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateDisease))]
    public async Task<IActionResult> CreateDisease(CreateDiseaseDto request)
    {
        var createDiseaseCommand = _mapper.Map<CreateDiseaseCommand>(request);
         
        var createDiseaseResult =
            await _commandBus.Send<CreateDiseaseCommand, CreateDiseaseCommandResult>(createDiseaseCommand);

        return createDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateDisease))]
    public async Task<IActionResult> UpdateDisease(UpdateDiseaseDto request)
    {
        var updateDiseaseCommand = _mapper.Map<UpdateDiseaseCommand>(request);

        var updateDiseaseResult =
            await _commandBus.Send<UpdateDiseaseCommand, UpdateDiseaseCommandResult>(updateDiseaseCommand);

        return updateDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteDisease))]
    public async Task<IActionResult> DeleteDisease(DeleteDiseaseDto request)
    {

        var deleteDiseaseCommand = _mapper.Map<DeleteDiseaseCommand>(request);

        var deleteDiseaseResult =
            await _commandBus.Send<DeleteDiseaseCommand, DeleteDiseaseCommandResult>(deleteDiseaseCommand);

        return deleteDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetDisease))]
    public async Task<IActionResult> GetDisease([FromQuery] GetDiseaseDto request)
    {

        var getDiseaseQuery= _mapper.Map<GetByIdDiseaseQuery>(request);

        var createDiseaseResult =
            await _queryBus.Send<GetByIdDiseaseQuery, GetByIdDiseaseQueryResult>(getDiseaseQuery);

        return createDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllDisease))]
    public async Task<IActionResult> GetAllDisease([FromQuery] GetAllDiseaseDto request)
    {

        var getAllDiseaseQuery = _mapper.Map<GetAllDiseaseQuery>(request);

        var createDiseaseResult =
            await _queryBus.Send<GetAllDiseaseQuery, GetAllDiseaseQueryResult>(getAllDiseaseQuery);

        return createDiseaseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

