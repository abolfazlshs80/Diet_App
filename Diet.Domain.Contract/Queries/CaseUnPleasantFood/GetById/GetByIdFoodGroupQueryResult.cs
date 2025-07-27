using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetById;

public record GetByIdCaseUnPleasantFoodQueryResult(Guid Id, Guid CaseId, Guid FoodId) : IQueryResult;
