using Diet.Framework.Core.Bus;

namespace Diet.Domain.Contract.Commands.Users.Update;

public record UpdateUsersCommand(Guid Id, string FirstName, string LastName, string ImageName, string ReferenceCode, string VerifyCode, string CardNumber, string ShbaNumber, DateTime? VerifyExpire, bool Deleted, DateTime CreateDate, DateTime? BirthDay, int? Gender) : ICommand;
