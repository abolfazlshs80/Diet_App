using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetById;

public record GetByIdSupplementDisease_WhiteListQueryResult(Guid Id, Guid SupplementId, Guid DiseaseId) : IQueryResult;
