using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Transactions.GetAll;

public record GetAllTransactionsQueryResult(int TotalRecords, List<GetTransactionsItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetTransactionsItem(Guid Id, double TotalPrice, string ZarinPalAuthority, string ZarinPalRefNum, int TransactionType);
