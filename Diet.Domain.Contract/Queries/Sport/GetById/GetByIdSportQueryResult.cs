using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.Sport.GetById;

public record GetByIdSportQueryResult(Guid Id, string Name, int Low, int Medium, int High) : IQueryResult;
