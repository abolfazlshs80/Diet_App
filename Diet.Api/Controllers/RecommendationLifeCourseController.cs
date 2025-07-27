using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Create;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Delete;
using Diet.Domain.Contract.Commands.RecommendationLifeCourse.Update;
using Diet.Domain.Contract.DTOs.RecommendationLifeCourse;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetAll;
using Diet.Domain.Contract.Queries.RecommendationLifeCourse.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("RecommendationLifeCourse")]
public class RecommendationLifeCourseController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public RecommendationLifeCourseController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRecommendationLifeCourse))]
    public async Task<IActionResult> CreateRecommendationLifeCourse(CreateRecommendationLifeCourseDto request)
    {
        var createRecommendationLifeCourseCommand = _mapper.Map<CreateRecommendationLifeCourseCommand>(request);
         
        var createRecommendationLifeCourseResult =
            await _commandBus.Send<CreateRecommendationLifeCourseCommand, CreateRecommendationLifeCourseCommandResult>(createRecommendationLifeCourseCommand);

        return createRecommendationLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateRecommendationLifeCourse))]
    public async Task<IActionResult> UpdateRecommendationLifeCourse(UpdateRecommendationLifeCourseDto request)
    {
        var updateRecommendationLifeCourseCommand = _mapper.Map<UpdateRecommendationLifeCourseCommand>(request);

        var updateRecommendationLifeCourseResult =
            await _commandBus.Send<UpdateRecommendationLifeCourseCommand, UpdateRecommendationLifeCourseCommandResult>(updateRecommendationLifeCourseCommand);

        return updateRecommendationLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteRecommendationLifeCourse))]
    public async Task<IActionResult> DeleteRecommendationLifeCourse(DeleteRecommendationLifeCourseDto request)
    {

        var deleteRecommendationLifeCourseCommand = _mapper.Map<DeleteRecommendationLifeCourseCommand>(request);

        var deleteRecommendationLifeCourseResult =
            await _commandBus.Send<DeleteRecommendationLifeCourseCommand, DeleteRecommendationLifeCourseCommandResult>(deleteRecommendationLifeCourseCommand);

        return deleteRecommendationLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetRecommendationLifeCourse))]
    public async Task<IActionResult> GetRecommendationLifeCourse([FromQuery] GetRecommendationLifeCourseDto request)
    {

        var getRecommendationLifeCourseQuery= _mapper.Map<GetByIdRecommendationLifeCourseQuery>(request);

        var createRecommendationLifeCourseResult =
            await _queryBus.Send<GetByIdRecommendationLifeCourseQuery, GetByIdRecommendationLifeCourseQueryResult>(getRecommendationLifeCourseQuery);

        return createRecommendationLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllRecommendationLifeCourse))]
    public async Task<IActionResult> GetAllRecommendationLifeCourse([FromQuery] GetAllRecommendationLifeCourseDto request)
    {

        var getAllRecommendationLifeCourseQuery = _mapper.Map<GetAllRecommendationLifeCourseQuery>(request);

        var createRecommendationLifeCourseResult =
            await _queryBus.Send<GetAllRecommendationLifeCourseQuery, GetAllRecommendationLifeCourseQueryResult>(getAllRecommendationLifeCourseQuery);

        return createRecommendationLifeCourseResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

