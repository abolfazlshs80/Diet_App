using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDurationAge.GetById;

public record GetByIdSupplementDurationAgeQuery(Guid Id) : IQuery;
