using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetById;

public record GetByIdCaseUnPleasantFoodQuery(Guid Id) : IQuery;
 