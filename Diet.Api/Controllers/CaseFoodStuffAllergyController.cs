using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.CaseFoodStuffAllergy;
using Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetAll;
using Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("CaseFoodStuffAllergy")]
public class CaseFoodStuffAllergyController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public CaseFoodStuffAllergyController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateCaseFoodStuffAllergy))]
    public async Task<IActionResult> CreateCaseFoodStuffAllergy(CreateCaseFoodStuffAllergyDto request)
    {
        var createCaseFoodStuffAllergyCommand = _mapper.Map<CreateCaseFoodStuffAllergyCommand>(request);
         
        var createCaseFoodStuffAllergyResult =
            await _commandBus.Send<CreateCaseFoodStuffAllergyCommand, CreateCaseFoodStuffAllergyCommandResult>(createCaseFoodStuffAllergyCommand);

        return createCaseFoodStuffAllergyResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateCaseFoodStuffAllergy))]
    public async Task<IActionResult> UpdateCaseFoodStuffAllergy(UpdateCaseFoodStuffAllergyDto request)
    {
        var updateCaseFoodStuffAllergyCommand = _mapper.Map<UpdateCaseFoodStuffAllergyCommand>(request);

        var updateCaseFoodStuffAllergyResult =
            await _commandBus.Send<UpdateCaseFoodStuffAllergyCommand, UpdateCaseFoodStuffAllergyCommandResult>(updateCaseFoodStuffAllergyCommand);

        return updateCaseFoodStuffAllergyResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteCaseFoodStuffAllergy))]
    public async Task<IActionResult> DeleteCaseFoodStuffAllergy(DeleteCaseFoodStuffAllergyDto request)
    {

        var deleteCaseFoodStuffAllergyCommand = _mapper.Map<DeleteCaseFoodStuffAllergyCommand>(request);

        var deleteCaseFoodStuffAllergyResult =
            await _commandBus.Send<DeleteCaseFoodStuffAllergyCommand, DeleteCaseFoodStuffAllergyCommandResult>(deleteCaseFoodStuffAllergyCommand);

        return deleteCaseFoodStuffAllergyResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetCaseFoodStuffAllergy))]
    public async Task<IActionResult> GetCaseFoodStuffAllergy([FromQuery] GetCaseFoodStuffAllergyDto request)
    {

        var getCaseFoodStuffAllergyQuery= _mapper.Map<GetByIdCaseFoodStuffAllergyQuery>(request);

        var createCaseFoodStuffAllergyResult =
            await _queryBus.Send<GetByIdCaseFoodStuffAllergyQuery, GetByIdCaseFoodStuffAllergyQueryResult>(getCaseFoodStuffAllergyQuery);

        return createCaseFoodStuffAllergyResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllCaseFoodStuffAllergy))]
    public async Task<IActionResult> GetAllCaseFoodStuffAllergy([FromQuery] GetAllCaseFoodStuffAllergyDto request)
    {

        var getAllCaseFoodStuffAllergyQuery = _mapper.Map<GetAllCaseFoodStuffAllergyQuery>(request);

        var createCaseFoodStuffAllergyResult =
            await _queryBus.Send<GetAllCaseFoodStuffAllergyQuery, GetAllCaseFoodStuffAllergyQueryResult>(getAllCaseFoodStuffAllergyQuery);

        return createCaseFoodStuffAllergyResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

