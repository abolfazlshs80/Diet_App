using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Case.GetById;

public record GetByIdCaseQuery(Guid Id) : IQuery;
 