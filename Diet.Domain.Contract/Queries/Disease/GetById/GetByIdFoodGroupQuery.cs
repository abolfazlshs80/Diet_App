using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Disease.GetById;

public record GetByIdDiseaseQuery(Guid Id) : IQuery;
 