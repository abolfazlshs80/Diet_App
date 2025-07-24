using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.Drug;
using Diet.Domain.Contract.Queries.Drug.GetAll;
using Diet.Domain.Contract.Queries.Drug.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Drug")]
public class DrugController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public DrugController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateDrug))]
    public async Task<IActionResult> CreateDrug(CreateDrugDto request)
    {
        var createDrugCommand = _mapper.Map<CreateDrugCommand>(request);
         
        var createDrugResult =
            await _commandBus.Send<CreateDrugCommand, CreateDrugCommandResult>(createDrugCommand);

        return createDrugResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateDrug))]
    public async Task<IActionResult> UpdateDrug(UpdateDrugDto request)
    {
        var updateDrugCommand = _mapper.Map<UpdateDrugCommand>(request);

        var updateDrugResult =
            await _commandBus.Send<UpdateDrugCommand, UpdateDrugCommandResult>(updateDrugCommand);

        return updateDrugResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteDrug))]
    public async Task<IActionResult> DeleteDrug(DeleteDrugDto request)
    {

        var deleteDrugCommand = _mapper.Map<DeleteDrugCommand>(request);

        var deleteDrugResult =
            await _commandBus.Send<DeleteDrugCommand, DeleteDrugCommandResult>(deleteDrugCommand);

        return deleteDrugResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetDrug))]
    public async Task<IActionResult> GetDrug([FromQuery] GetDrugDto request)
    {

        var getDrugQuery= _mapper.Map<GetByIdDrugQuery>(request);

        var createDrugResult =
            await _queryBus.Send<GetByIdDrugQuery, GetByIdDrugQueryResult>(getDrugQuery);

        return createDrugResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllDrug))]
    public async Task<IActionResult> GetAllDrug([FromQuery] GetAllDrugDto request)
    {

        var getAllDrugQuery = _mapper.Map<GetAllDrugQuery>(request);

        var createDrugResult =
            await _queryBus.Send<GetAllDrugQuery, GetAllDrugQueryResult>(getAllDrugQuery);

        return createDrugResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

