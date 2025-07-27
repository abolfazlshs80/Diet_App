using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetAll;

public record GetAllCaseFoodStuffAllergyQueryResult(int TotalRecords, List<GetCaseFoodStuffAllergyItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetCaseFoodStuffAllergyItem(Guid Id, Guid CaseId, Guid FoodStuffId);

