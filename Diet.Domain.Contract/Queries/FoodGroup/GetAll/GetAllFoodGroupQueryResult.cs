using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodGroup.GetAll;

public record GetAllFoodGroupQueryResult(int TotalRecords, List<GetFoodGroupItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetFoodGroupItem(Guid Id,string Title);

