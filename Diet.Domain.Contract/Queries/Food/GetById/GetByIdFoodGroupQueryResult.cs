using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Food.GetById;

public record GetByIdFoodQueryResult(Guid Id, string Title, string Description, double Value, Guid FoodGroupId) : IQueryResult;
