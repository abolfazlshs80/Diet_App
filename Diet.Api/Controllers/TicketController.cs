using Diet.Domain.Contract.Commands.Ticket.Create;
using Diet.Domain.Contract.Commands.Ticket.Delete;
using Diet.Domain.Contract.Commands.Ticket.Update;
using Diet.Domain.Contract.DTOs.Ticket;
using Diet.Domain.Contract.Queries.Ticket.GetAll;
using Diet.Domain.Contract.Queries.Ticket.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Ticket")]
public class TicketController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;

    public TicketController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateTicket))]
    public async Task<IActionResult> CreateTicket(CreateTicketDto request)
    {
        var command = _mapper.Map<CreateTicketCommand>(request);
        var result = await _commandBus.Send<CreateTicketCommand, CreateTicketCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpPut(nameof(UpdateTicket))]
    public async Task<IActionResult> UpdateTicket(UpdateTicketDto request)
    {
        var command = _mapper.Map<UpdateTicketCommand>(request);
        var result = await _commandBus.Send<UpdateTicketCommand, UpdateTicketCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpDelete(nameof(DeleteTicket))]
    public async Task<IActionResult> DeleteTicket(DeleteTicketDto request)
    {
        var command = _mapper.Map<DeleteTicketCommand>(request);
        var result = await _commandBus.Send<DeleteTicketCommand, DeleteTicketCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetTicket))]
    public async Task<IActionResult> GetTicket([FromQuery] GetTicketDto request)
    {
        var query = _mapper.Map<GetByIdTicketQuery>(request);
        var result = await _queryBus.Send<GetByIdTicketQuery, GetByIdTicketQueryResult>(query);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetAllTicket))]
    public async Task<IActionResult> GetAllTicket([FromQuery] GetAllTicketDto request)
    {
        var query = _mapper.Map<GetAllTicketQuery>(request);
        var result = await _queryBus.Send<GetAllTicketQuery, GetAllTicketQueryResult>(query);
        return result.Match(Ok, Problem);
    }
}
