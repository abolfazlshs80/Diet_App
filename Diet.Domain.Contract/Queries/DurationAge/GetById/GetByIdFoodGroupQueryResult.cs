using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetById;

public record GetByIdDurationAgeQueryResult(Guid Id,string Title) : IQueryResult;
