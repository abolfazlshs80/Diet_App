using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseSupplement.GetById;

public record GetByIdCaseSupplementQueryResult(Guid Id, Guid CaseId, Guid SupplementId) : IQueryResult;
