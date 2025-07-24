using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Drug.GetById;

public record GetByIdDrugQuery(Guid Id) : IQuery;
 