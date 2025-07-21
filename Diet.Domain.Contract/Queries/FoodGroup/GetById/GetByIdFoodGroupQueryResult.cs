using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodGroup.GetById;

public record GetByIdFoodGroupQueryResult(Guid Id,string Title) : IQueryResult;
