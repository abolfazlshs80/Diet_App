using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Transactions.GetById;

public record GetByIdTransactionsQueryResult(Guid Id, double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, int TransactionType) : IQueryResult;
