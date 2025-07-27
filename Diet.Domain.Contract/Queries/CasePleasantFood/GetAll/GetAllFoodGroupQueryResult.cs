using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CasePleasantFood.GetAll;

public record GetAllCasePleasantFoodQueryResult(int TotalRecords, List<GetCasePleasantFoodItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCasePleasantFoodItem(Guid Id, Guid CaseId, Guid FoodId);

