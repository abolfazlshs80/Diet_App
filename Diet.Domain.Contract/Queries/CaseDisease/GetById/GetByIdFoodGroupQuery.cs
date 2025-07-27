using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDisease.GetById;

public record GetByIdCaseDiseaseQuery(Guid Id) : IQuery;
 