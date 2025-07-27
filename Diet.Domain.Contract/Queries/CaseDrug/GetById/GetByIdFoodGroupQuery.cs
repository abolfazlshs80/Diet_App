using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseDrug.GetById;

public record GetByIdCaseDrugQuery(Guid Id) : IQuery;
 