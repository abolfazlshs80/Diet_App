using Diet.Domain.Contract.Commands.TicketMessage.Create;
using Diet.Domain.Contract.Commands.TicketMessage.Delete;
using Diet.Domain.Contract.Commands.TicketMessage.Update;
using Diet.Domain.Contract.DTOs.TicketMessage;
using Diet.Domain.Contract.Queries.TicketMessage.GetAll;
using Diet.Domain.Contract.Queries.TicketMessage.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("TicketMessage")]
public class TicketMessageController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;

    public TicketMessageController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateTicketMessage))]
    public async Task<IActionResult> CreateTicketMessage(CreateTicketMessageDto request)
    {
        var command = _mapper.Map<CreateTicketMessageCommand>(request);
        var result = await _commandBus.Send<CreateTicketMessageCommand, CreateTicketMessageCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpPut(nameof(UpdateTicketMessage))]
    public async Task<IActionResult> UpdateTicketMessage(UpdateTicketMessageDto request)
    {
        var command = _mapper.Map<UpdateTicketMessageCommand>(request);
        var result = await _commandBus.Send<UpdateTicketMessageCommand, UpdateTicketMessageCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpDelete(nameof(DeleteTicketMessage))]
    public async Task<IActionResult> DeleteTicketMessage(DeleteTicketMessageDto request)
    {
        var command = _mapper.Map<DeleteTicketMessageCommand>(request);
        var result = await _commandBus.Send<DeleteTicketMessageCommand, DeleteTicketMessageCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetTicketMessage))]
    public async Task<IActionResult> GetTicketMessage([FromQuery] GetTicketMessageDto request)
    {
        var query = _mapper.Map<GetByIdTicketMessageQuery>(request);
        var result = await _queryBus.Send<GetByIdTicketMessageQuery, GetByIdTicketMessageQueryResult>(query);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetAllTicketMessage))]
    public async Task<IActionResult> GetAllTicketMessage([FromQuery] GetAllTicketMessageDto request)
    {
        var query = _mapper.Map<GetAllTicketMessageQuery>(request);
        var result = await _queryBus.Send<GetAllTicketMessageQuery, GetAllTicketMessageQueryResult>(query);
        return result.Match(Ok, Problem);
    }
}
