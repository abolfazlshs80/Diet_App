using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Drug.GetById;

public record GetByIdDrugQueryResult(Guid Id, string Title, string Description) : IQueryResult;
