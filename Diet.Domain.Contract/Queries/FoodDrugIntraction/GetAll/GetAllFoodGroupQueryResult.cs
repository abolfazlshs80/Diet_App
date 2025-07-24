using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodDrugIntraction.GetAll;

public record GetAllFoodDrugIntractionQueryResult(int TotalRecords, List<GetFoodDrugIntractionItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetFoodDrugIntractionItem(Guid Id, Guid foodId, Guid drugId);

