using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDrug.GetById;

public record GetByIdCaseDrugQueryResult(Guid Id, Guid CaseId, Guid DrugId) : IQueryResult;
