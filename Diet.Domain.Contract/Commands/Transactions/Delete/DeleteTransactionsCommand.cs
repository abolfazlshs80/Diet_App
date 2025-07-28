using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Transactions.Delete;

public record DeleteTransactionsCommand(Guid Id) : ICommand;
