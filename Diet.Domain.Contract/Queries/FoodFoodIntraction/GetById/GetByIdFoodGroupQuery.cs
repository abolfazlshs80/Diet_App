using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodFoodIntraction.GetById;

public record GetByIdFoodFoodIntractionQuery(Guid Id) : IQuery;
 