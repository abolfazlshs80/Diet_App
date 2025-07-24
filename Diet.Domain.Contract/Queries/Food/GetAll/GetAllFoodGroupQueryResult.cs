using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Food.GetAll;

public record GetAllFoodQueryResult(int TotalRecords, List<GetFoodItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetFoodItem(Guid Id, string Title, string Description, double Value, Guid FoodGroupId);

