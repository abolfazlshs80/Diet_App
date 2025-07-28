using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetById;

public record GetByIdSupplementDisease_WhiteListQuery(Guid Id) : IQuery;
