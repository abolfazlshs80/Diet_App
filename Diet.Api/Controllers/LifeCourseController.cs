using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.DTOs.LifeCourse;
using Diet.Domain.Contract.Queries.LifeCourse.GetAll;
using Diet.Domain.Contract.Queries.LifeCourse.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("LifeCourse")]
public class LifeCourseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public LifeCourseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateLifeCourse))]
    public async Task<IActionResult> CreateLifeCourse(CreateLifeCourseDto request)
    {
        var createLifeCourseCommand = _mapper.Map<CreateLifeCourseCommand>(request);
         
        var createLifeCourseResult =
            await _commandBus.Send<CreateLifeCourseCommand, CreateLifeCourseCommandResult>(createLifeCourseCommand);

        return createLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateLifeCourse))]
    public async Task<IActionResult> UpdateLifeCourse(UpdateLifeCourseDto request)
    {
        var updateLifeCourseCommand = _mapper.Map<UpdateLifeCourseCommand>(request);

        var updateLifeCourseResult =
            await _commandBus.Send<UpdateLifeCourseCommand, UpdateLifeCourseCommandResult>(updateLifeCourseCommand);

        return updateLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteLifeCourse))]
    public async Task<IActionResult> DeleteLifeCourse(DeleteLifeCourseDto request)
    {

        var deleteLifeCourseCommand = _mapper.Map<DeleteLifeCourseCommand>(request);

        var deleteLifeCourseResult =
            await _commandBus.Send<DeleteLifeCourseCommand, DeleteLifeCourseCommandResult>(deleteLifeCourseCommand);

        return deleteLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetLifeCourse))]
    public async Task<IActionResult> GetLifeCourse([FromQuery] GetLifeCourseDto request)
    {

        var getLifeCourseQuery= _mapper.Map<GetByIdLifeCourseQuery>(request);

        var createLifeCourseResult =
            await _queryBus.Send<GetByIdLifeCourseQuery, GetByIdLifeCourseQueryResult>(getLifeCourseQuery);

        return createLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllLifeCourse))]
    public async Task<IActionResult> GetAllLifeCourse([FromQuery] GetAllLifeCourseDto request)
    {

        var getAllLifeCourseQuery = _mapper.Map<GetAllLifeCourseQuery>(request);

        var createLifeCourseResult =
            await _queryBus.Send<GetAllLifeCourseQuery, GetAllLifeCourseQueryResult>(getAllLifeCourseQuery);

        return createLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

