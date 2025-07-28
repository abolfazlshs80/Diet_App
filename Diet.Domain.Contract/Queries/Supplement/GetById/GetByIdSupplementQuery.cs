using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Supplement.GetById;

public record GetByIdSupplementQuery(Guid Id) : IQuery;
