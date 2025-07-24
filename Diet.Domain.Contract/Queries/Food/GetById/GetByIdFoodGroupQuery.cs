using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Food.GetById;

public record GetByIdFoodQuery(Guid Id) : IQuery;
 