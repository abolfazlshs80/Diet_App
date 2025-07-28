using Order.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementLifeCourse.GetById;

public record GetByIdSupplementLifeCourseQueryResult(Guid Id, Guid SupplementId, Guid LifeCourseId) : IQueryResult;
