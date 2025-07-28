using Diet.Framework.Core.Bus;
namespace Diet.Domain.Contract.Queries.SupplementLifeCourse.GetAll;

public record GetAllSupplementLifeCourseQuery(string? search, int CurrentPage = 0, int PageSize = 8) : IQuery;
