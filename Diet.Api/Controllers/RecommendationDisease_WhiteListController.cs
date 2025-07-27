using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Create;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Delete;
using Diet.Domain.Contract.Commands.RecommendationDisease_WhiteList.Update;
using Diet.Domain.Contract.DTOs.RecommendationDisease_WhiteList;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetAll;
using Diet.Domain.Contract.Queries.RecommendationDisease_WhiteList.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("RecommendationDisease_WhiteList")]
public class RecommendationDisease_WhiteListController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;


    public RecommendationDisease_WhiteListController(ICommandBus commandBus, IQueryBus queryBus,IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRecommendationDisease_WhiteList))]
    public async Task<IActionResult> CreateRecommendationDisease_WhiteList(CreateRecommendationDisease_WhiteListDto request)
    {
        var createRecommendationDisease_WhiteListCommand = _mapper.Map<CreateRecommendationDisease_WhiteListCommand>(request);
         
        var createRecommendationDisease_WhiteListResult =
            await _commandBus.Send<CreateRecommendationDisease_WhiteListCommand, CreateRecommendationDisease_WhiteListCommandResult>(createRecommendationDisease_WhiteListCommand);

        return createRecommendationDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpPut(nameof(UpdateRecommendationDisease_WhiteList))]
    public async Task<IActionResult> UpdateRecommendationDisease_WhiteList(UpdateRecommendationDisease_WhiteListDto request)
    {
        var updateRecommendationDisease_WhiteListCommand = _mapper.Map<UpdateRecommendationDisease_WhiteListCommand>(request);

        var updateRecommendationDisease_WhiteListResult =
            await _commandBus.Send<UpdateRecommendationDisease_WhiteListCommand, UpdateRecommendationDisease_WhiteListCommandResult>(updateRecommendationDisease_WhiteListCommand);

        return updateRecommendationDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpDelete(nameof(DeleteRecommendationDisease_WhiteList))]
    public async Task<IActionResult> DeleteRecommendationDisease_WhiteList(DeleteRecommendationDisease_WhiteListDto request)
    {

        var deleteRecommendationDisease_WhiteListCommand = _mapper.Map<DeleteRecommendationDisease_WhiteListCommand>(request);

        var deleteRecommendationDisease_WhiteListResult =
            await _commandBus.Send<DeleteRecommendationDisease_WhiteListCommand, DeleteRecommendationDisease_WhiteListCommandResult>(deleteRecommendationDisease_WhiteListCommand);

        return deleteRecommendationDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetRecommendationDisease_WhiteList))]
    public async Task<IActionResult> GetRecommendationDisease_WhiteList([FromQuery] GetRecommendationDisease_WhiteListDto request)
    {

        var getRecommendationDisease_WhiteListQuery= _mapper.Map<GetByIdRecommendationDisease_WhiteListQuery>(request);

        var createRecommendationDisease_WhiteListResult =
            await _queryBus.Send<GetByIdRecommendationDisease_WhiteListQuery, GetByIdRecommendationDisease_WhiteListQueryResult>(getRecommendationDisease_WhiteListQuery);

        return createRecommendationDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }

    [HttpGet(nameof(GetAllRecommendationDisease_WhiteList))]
    public async Task<IActionResult> GetAllRecommendationDisease_WhiteList([FromQuery] GetAllRecommendationDisease_WhiteListDto request)
    {

        var getAllRecommendationDisease_WhiteListQuery = _mapper.Map<GetAllRecommendationDisease_WhiteListQuery>(request);

        var createRecommendationDisease_WhiteListResult =
            await _queryBus.Send<GetAllRecommendationDisease_WhiteListQuery, GetAllRecommendationDisease_WhiteListQueryResult>(getAllRecommendationDisease_WhiteListQuery);

        return createRecommendationDisease_WhiteListResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}

