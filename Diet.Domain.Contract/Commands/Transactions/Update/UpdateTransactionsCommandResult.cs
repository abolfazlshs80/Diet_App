using Diet.Domain.Contract.Commands.Transactions.Update;
using Order.Framework.Core.Bus;

public record UpdateTransactionsCommandResult(string state, string message) : ICommandResult;
