using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodFoodIntraction.GetAll;

public record GetAllFoodFoodIntractionQueryResult(int TotalRecords, List<GetFoodFoodIntractionItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetFoodFoodIntractionItem(Guid Id, Guid FoodFistId, Guid FoodSecondId);

