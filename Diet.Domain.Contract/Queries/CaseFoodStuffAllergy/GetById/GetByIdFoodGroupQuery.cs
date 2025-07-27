using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetById;

public record GetByIdCaseFoodStuffAllergyQuery(Guid Id) : IQuery;
 