using Diet.Domain.Contract.Commands.Transactions.Delete;
using Order.Framework.Core.Bus;

public record DeleteTransactionsCommandResult(string state, string message) : ICommandResult;
