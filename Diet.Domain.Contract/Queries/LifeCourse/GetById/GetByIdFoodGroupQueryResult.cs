using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.LifeCourse.GetById;

public record GetByIdLifeCourseQueryResult(Guid Id,string Title,Guid ParentId) : IQueryResult;
