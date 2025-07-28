using Order.Framework.Core.Bus;

namespace Diet.Domain.Contract.Queries.Users.GetAll;

public record GetAllUsersQueryResult(int TotalRecords, List<GetUsersItem> Data, int CurrentPage, int PageSize) : IQueryResult;
public record GetUsersItem(Guid Id, string FirstName, string LastName, string ImageName, string ReferenceCode, string VerifyCode, string CardNumber, string ShbaNumber, DateTime? VerifyExpire, bool Deleted, DateTime CreateDate, DateTime? BirthDay, int? Gender);
