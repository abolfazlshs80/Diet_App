using Diet.Domain.Contract.Enums;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Transactions.Update;

public record UpdateTransactionsCommand(Guid Id, double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, TransactionType TransactionType) : ICommand;
