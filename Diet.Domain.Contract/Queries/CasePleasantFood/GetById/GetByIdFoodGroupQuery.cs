using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CasePleasantFood.GetById;

public record GetByIdCasePleasantFoodQuery(Guid Id) : IQuery;
 