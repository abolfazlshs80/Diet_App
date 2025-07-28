using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Create;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Delete;
using Diet.Domain.Contract.Commands.SupplementLifeCourse.Update;
using Diet.Domain.Contract.DTOs.SupplementLifeCourse;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetAll;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("SupplementLifeCourse")]
public class SupplementLifeCourseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public SupplementLifeCourseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateSupplementLifeCourse))]
    public async Task<IActionResult> CreateSupplementLifeCourse(CreateSupplementLifeCourseDto request)
    {
        var createSupplementLifeCourseCommand = _mapper.Map<CreateSupplementLifeCourseCommand>(request);
         
        var createSupplementLifeCourseResult =
            await _commandBus.Send<CreateSupplementLifeCourseCommand, CreateSupplementLifeCourseCommandResult>(createSupplementLifeCourseCommand);

        return createSupplementLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateSupplementLifeCourse))]
    public async Task<IActionResult> UpdateSupplementLifeCourse(UpdateSupplementLifeCourseDto request)
    {
        var updateSupplementLifeCourseCommand = _mapper.Map<UpdateSupplementLifeCourseCommand>(request);

        var updateSupplementLifeCourseResult =
            await _commandBus.Send<UpdateSupplementLifeCourseCommand, UpdateSupplementLifeCourseCommandResult>(updateSupplementLifeCourseCommand);

        return updateSupplementLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteSupplementLifeCourse))]
    public async Task<IActionResult> DeleteSupplementLifeCourse(DeleteSupplementLifeCourseDto request)
    {

        var deleteSupplementLifeCourseCommand = _mapper.Map<DeleteSupplementLifeCourseCommand>(request);

        var deleteSupplementLifeCourseResult =
            await _commandBus.Send<DeleteSupplementLifeCourseCommand, DeleteSupplementLifeCourseCommandResult>(deleteSupplementLifeCourseCommand);

        return deleteSupplementLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetSupplementLifeCourse))]
    public async Task<IActionResult> GetSupplementLifeCourse([FromQuery] GetSupplementLifeCourseDto request)
    {

        var getSupplementLifeCourseQuery= _mapper.Map<GetByIdSupplementLifeCourseQuery>(request);

        var createSupplementLifeCourseResult =
            await _queryBus.Send<GetByIdSupplementLifeCourseQuery, GetByIdSupplementLifeCourseQueryResult>(getSupplementLifeCourseQuery);

        return createSupplementLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllSupplementLifeCourse))]
    public async Task<IActionResult> GetAllSupplementLifeCourse([FromQuery] GetAllSupplementLifeCourseDto request)
    {

        var getAllSupplementLifeCourseQuery = _mapper.Map<GetAllSupplementLifeCourseQuery>(request);

        var createSupplementLifeCourseResult =
            await _queryBus.Send<GetAllSupplementLifeCourseQuery, GetAllSupplementLifeCourseQueryResult>(getAllSupplementLifeCourseQuery);

        return createSupplementLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

