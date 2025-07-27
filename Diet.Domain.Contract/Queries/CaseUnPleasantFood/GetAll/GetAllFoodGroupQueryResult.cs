using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetAll;

public record GetAllCaseUnPleasantFoodQueryResult(int TotalRecords, List<GetCaseUnPleasantFoodItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseUnPleasantFoodItem(Guid Id, Guid CaseId, Guid FoodId);

