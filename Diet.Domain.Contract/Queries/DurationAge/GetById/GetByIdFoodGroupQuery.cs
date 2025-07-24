using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetById;

public record GetByIdDurationAgeQuery(Guid Id) : IQuery;
 