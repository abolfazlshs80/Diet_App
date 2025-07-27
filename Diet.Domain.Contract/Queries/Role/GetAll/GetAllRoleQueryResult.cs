using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Role.GetAll;

public record GetAllRoleQueryResult(int TotalRecords, List<GetRoleItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetRoleItem(Guid Id, string Name);
