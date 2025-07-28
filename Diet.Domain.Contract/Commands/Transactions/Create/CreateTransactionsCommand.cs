using Diet.Domain.Contract.Enums;
using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Transactions.Create;

public record CreateTransactionsCommand(double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, TransactionType TransactionType) : ICommand;
