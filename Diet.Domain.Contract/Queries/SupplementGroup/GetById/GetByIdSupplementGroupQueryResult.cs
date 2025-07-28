using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementGroup.GetById;

public record GetByIdSupplementGroupQueryResult(Guid Id, string Title) : IQueryResult;
