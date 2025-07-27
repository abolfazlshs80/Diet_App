using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseSupplement.GetById;

public record GetByIdCaseSupplementQuery(Guid Id) : IQuery;
 