using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetById;

public record GetByIdCaseFoodStuffAllergyQueryResult(Guid Id, Guid CaseId, Guid FoodStuffId) : IQueryResult;
