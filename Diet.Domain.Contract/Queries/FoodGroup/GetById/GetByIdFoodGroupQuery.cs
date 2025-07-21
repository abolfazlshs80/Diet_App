using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodGroup.GetById;

public record GetByIdFoodGroupQuery(Guid Id) : IQuery;
 