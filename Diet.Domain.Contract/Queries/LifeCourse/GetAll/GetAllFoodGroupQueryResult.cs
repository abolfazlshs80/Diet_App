using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.LifeCourse.GetAll;

public record GetAllLifeCourseQueryResult(int TotalRecords, List<GetLifeCourseItem> Data, int CurrentPage, int PageSize): IQueryResult;
public record GetLifeCourseItem(Guid Id,string Title, Guid ParentId);

