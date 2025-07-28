using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementGroup.GetById;

public record GetByIdSupplementGroupQuery(Guid Id) : IQuery;
