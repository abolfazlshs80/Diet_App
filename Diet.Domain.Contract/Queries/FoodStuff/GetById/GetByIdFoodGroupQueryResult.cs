using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodStuff.GetById;

public record GetByIdFoodStuffQueryResult(Guid Id,string Title) : IQueryResult;
