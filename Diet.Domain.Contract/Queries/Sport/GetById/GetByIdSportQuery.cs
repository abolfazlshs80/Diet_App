using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Sport.GetById;

public record GetByIdSportQuery(Guid Id) : IQuery;
