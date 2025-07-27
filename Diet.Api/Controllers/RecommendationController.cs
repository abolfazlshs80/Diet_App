using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.Recommendation.Create;
using Diet.Domain.Contract.Commands.Recommendation.Delete;
using Diet.Domain.Contract.Commands.Recommendation.Update;
using Diet.Domain.Contract.DTOs.Recommendation;
using Diet.Domain.Contract.Queries.Recommendation.GetAll;
using Diet.Domain.Contract.Queries.Recommendation.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Recommendation")]
public class RecommendationController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public RecommendationController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRecommendation))]
    public async Task<IActionResult> CreateRecommendation(CreateRecommendationDto request)
    {
        var createRecommendationCommand = _mapper.Map<CreateRecommendationCommand>(request);
         
        var createRecommendationResult =
            await _commandBus.Send<CreateRecommendationCommand, CreateRecommendationCommandResult>(createRecommendationCommand);

        return createRecommendationResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateRecommendation))]
    public async Task<IActionResult> UpdateRecommendation(UpdateRecommendationDto request)
    {
        var updateRecommendationCommand = _mapper.Map<UpdateRecommendationCommand>(request);

        var updateRecommendationResult =
            await _commandBus.Send<UpdateRecommendationCommand, UpdateRecommendationCommandResult>(updateRecommendationCommand);

        return updateRecommendationResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteRecommendation))]
    public async Task<IActionResult> DeleteRecommendation(DeleteRecommendationDto request)
    {

        var deleteRecommendationCommand = _mapper.Map<DeleteRecommendationCommand>(request);

        var deleteRecommendationResult =
            await _commandBus.Send<DeleteRecommendationCommand, DeleteRecommendationCommandResult>(deleteRecommendationCommand);

        return deleteRecommendationResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetRecommendation))]
    public async Task<IActionResult> GetRecommendation([FromQuery] GetRecommendationDto request)
    {

        var getRecommendationQuery= _mapper.Map<GetByIdRecommendationQuery>(request);

        var createRecommendationResult =
            await _queryBus.Send<GetByIdRecommendationQuery, GetByIdRecommendationQueryResult>(getRecommendationQuery);

        return createRecommendationResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllRecommendation))]
    public async Task<IActionResult> GetAllRecommendation([FromQuery] GetAllRecommendationDto request)
    {

        var getAllRecommendationQuery = _mapper.Map<GetAllRecommendationQuery>(request);

        var createRecommendationResult =
            await _queryBus.Send<GetAllRecommendationQuery, GetAllRecommendationQueryResult>(getAllRecommendationQuery);

        return createRecommendationResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

