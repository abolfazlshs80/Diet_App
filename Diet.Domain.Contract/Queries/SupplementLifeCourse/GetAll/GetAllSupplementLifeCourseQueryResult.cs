using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.SupplementLifeCourse.GetAll;

public record GetAllSupplementLifeCourseQueryResult(int TotalRecords, List<GetSupplementLifeCourseItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetSupplementLifeCourseItem(Guid Id, Guid SupplementId, Guid LifeCourseId);
