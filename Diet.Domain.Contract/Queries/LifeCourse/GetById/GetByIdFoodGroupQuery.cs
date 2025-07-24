using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.LifeCourse.GetById;

public record GetByIdLifeCourseQuery(Guid Id) : IQuery;
 