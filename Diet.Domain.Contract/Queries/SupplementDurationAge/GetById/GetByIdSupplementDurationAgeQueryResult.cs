using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDurationAge.GetById;

public record GetByIdSupplementDurationAgeQueryResult(Guid Id, Guid SupplementId, Guid DurationAgeId) : IQueryResult;
