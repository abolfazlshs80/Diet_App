using Diet.Domain.Contract.Commands.RecommendationDurationAge.Create;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Delete;
using Diet.Domain.Contract.Commands.RecommendationDurationAge.Update;
using Diet.Domain.Contract.DTOs.RecommendationDurationAge;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetAll;
using Diet.Domain.Contract.Queries.RecommendationDurationAge.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("RecommendationDurationAge")]
public class RecommendationDurationAgeController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public RecommendationDurationAgeController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRecommendationDurationAge))]
    public async Task<IActionResult> CreateRecommendationDurationAge(CreateRecommendationDurationAgeDto request)
    {
        var createRecommendationDurationAgeCommand = _mapper.Map<CreateRecommendationDurationAgeCommand>(request);
         
        var createRecommendationDurationAgeResult =
            await _commandBus.Send<CreateRecommendationDurationAgeCommand, CreateRecommendationDurationAgeCommandResult>(createRecommendationDurationAgeCommand);

        return createRecommendationDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateRecommendationDurationAge))]
    public async Task<IActionResult> UpdateRecommendationDurationAge(UpdateRecommendationDurationAgeDto request)
    {
        var updateRecommendationDurationAgeCommand = _mapper.Map<UpdateRecommendationDurationAgeCommand>(request);

        var updateRecommendationDurationAgeResult =
            await _commandBus.Send<UpdateRecommendationDurationAgeCommand, UpdateRecommendationDurationAgeCommandResult>(updateRecommendationDurationAgeCommand);

        return updateRecommendationDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteRecommendationDurationAge))]
    public async Task<IActionResult> DeleteRecommendationDurationAge(DeleteRecommendationDurationAgeDto request)
    {

        var deleteRecommendationDurationAgeCommand = _mapper.Map<DeleteRecommendationDurationAgeCommand>(request);

        var deleteRecommendationDurationAgeResult =
            await _commandBus.Send<DeleteRecommendationDurationAgeCommand, DeleteRecommendationDurationAgeCommandResult>(deleteRecommendationDurationAgeCommand);

        return deleteRecommendationDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetRecommendationDurationAge))]
    public async Task<IActionResult> GetRecommendationDurationAge([FromQuery] GetRecommendationDurationAgeDto request)
    {

        var getRecommendationDurationAgeQuery= _mapper.Map<GetByIdRecommendationDurationAgeQuery>(request);

        var createRecommendationDurationAgeResult =
            await _queryBus.Send<GetByIdRecommendationDurationAgeQuery, GetByIdRecommendationDurationAgeQueryResult>(getRecommendationDurationAgeQuery);

        return createRecommendationDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllRecommendationDurationAge))]
    public async Task<IActionResult> GetAllRecommendationDurationAge([FromQuery] GetAllRecommendationDurationAgeDto request)
    {

        var getAllRecommendationDurationAgeQuery = _mapper.Map<GetAllRecommendationDurationAgeQuery>(request);

        var createRecommendationDurationAgeResult =
            await _queryBus.Send<GetAllRecommendationDurationAgeQuery, GetAllRecommendationDurationAgeQueryResult>(getAllRecommendationDurationAgeQuery);

        return createRecommendationDurationAgeResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

