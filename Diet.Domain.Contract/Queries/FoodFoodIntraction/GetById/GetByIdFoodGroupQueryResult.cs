using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodFoodIntraction.GetById;

public record GetByIdFoodFoodIntractionQueryResult(Guid Id, Guid FoodFistId, Guid FoodSecondId) : IQueryResult;
