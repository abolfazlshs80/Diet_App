using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Transactions.GetById;

public record GetByIdTransactionsQuery(Guid Id) : IQuery;
