using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodStuff.GetById;

public record GetByIdFoodStuffQuery(Guid Id) : IQuery;
 