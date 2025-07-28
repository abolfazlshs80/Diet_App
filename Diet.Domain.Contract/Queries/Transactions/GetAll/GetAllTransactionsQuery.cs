using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Transactions.GetAll;

public record GetAllTransactionsQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
