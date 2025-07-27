using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CasePleasantFood.GetById;

public record GetByIdCasePleasantFoodQueryResult(Guid Id, Guid CaseId, Guid FoodId) : IQueryResult;
