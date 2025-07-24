using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.FoodStuff.GetAll;

public record GetAllFoodStuffQueryResult(int TotalRecords, List<GetFoodStuffItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetFoodStuffItem(Guid Id,string Title);

