using Diet.Domain.Contract.Commands.Transactions.Create;
using Diet.Domain.Contract.Commands.Transactions.Delete;
using Diet.Domain.Contract.Commands.Transactions.Update;
using Diet.Domain.Contract.DTOs.Transactions;
using Diet.Domain.Contract.Queries.Transactions.GetAll;
using Diet.Domain.Contract.Queries.Transactions.GetById;
using Diet.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diet.Api.Controllers;

[Route("Transactions")]
public class TransactionsController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _queryBus;
    private readonly IMapper _mapper;

    public TransactionsController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateTransactions))]
    public async Task<IActionResult> CreateTransactions(CreateTransactionsDto request)
    {
        var command = _mapper.Map<CreateTransactionsCommand>(request);
        var result = await _commandBus.Send<CreateTransactionsCommand, CreateTransactionsCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpPut(nameof(UpdateTransactions))]
    public async Task<IActionResult> UpdateTransactions(UpdateTransactionsDto request)
    {
        var command = _mapper.Map<UpdateTransactionsCommand>(request);
        var result = await _commandBus.Send<UpdateTransactionsCommand, UpdateTransactionsCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpDelete(nameof(DeleteTransactions))]
    public async Task<IActionResult> DeleteTransactions(DeleteTransactionsDto request)
    {
        var command = _mapper.Map<DeleteTransactionsCommand>(request);
        var result = await _commandBus.Send<DeleteTransactionsCommand, DeleteTransactionsCommandResult>(command);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetTransactions))]
    public async Task<IActionResult> GetTransactions([FromQuery] GetTransactionsDto request)
    {
        var query = _mapper.Map<GetByIdTransactionsQuery>(request);
        var result = await _queryBus.Send<GetByIdTransactionsQuery, GetByIdTransactionsQueryResult>(query);
        return result.Match(Ok, Problem);
    }

    [HttpGet(nameof(GetAllTransactions))]
    public async Task<IActionResult> GetAllTransactions([FromQuery] GetAllTransactionsDto request)
    {
        var query = _mapper.Map<GetAllTransactionsQuery>(request);
        var result = await _queryBus.Send<GetAllTransactionsQuery, GetAllTransactionsQueryResult>(query);
        return result.Match(Ok, Problem);
    }
}
