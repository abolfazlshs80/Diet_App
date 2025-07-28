using Diet.Domain.Contract.Commands.Transactions.Create;
using Order.Framework.Core.Bus;

public record CreateTransactionsCommandResult(string state, string message) : ICommandResult;
