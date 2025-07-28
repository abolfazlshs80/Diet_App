using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementLifeCourse.GetById;

public record GetByIdSupplementLifeCourseQuery(Guid Id) : IQuery;
