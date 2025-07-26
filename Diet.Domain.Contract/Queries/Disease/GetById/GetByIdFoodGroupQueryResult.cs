using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Disease.GetById;

public record GetByIdDiseaseQueryResult(Guid Id,string Title,Guid ParentId) : IQueryResult;
