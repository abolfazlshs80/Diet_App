using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;

public record GetByIdFoodDrugIntractionQueryResult(Guid Id, Guid foodId, Guid drugId) : IQueryResult;
