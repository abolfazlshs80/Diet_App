using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDisease.GetById;

public record GetByIdCaseDiseaseQueryResult(Guid Id, Guid CaseId, Guid DiseaseId) : IQueryResult;
