using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;

public record GetByIdFoodDrugIntractionQuery(Guid Id) : IQuery;
 