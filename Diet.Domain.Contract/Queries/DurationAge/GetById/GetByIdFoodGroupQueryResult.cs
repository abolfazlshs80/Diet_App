using Diet.Domain.Contract.DTOs.DurationAge;
using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.DurationAge.GetById;

public record GetByIdDurationAgeQueryResult(GetItemDurationAgeDto DurationAgeDto) : IQueryResult;
