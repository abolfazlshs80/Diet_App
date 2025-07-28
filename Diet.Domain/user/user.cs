using Diet.Domain.Case;
using Diet.Domain.common;
using Diet.Domain.Contract.Enums;
using ErrorOr;
using System.Reflection;
using Diet.Domain.Contract.Commands.Users.Create;
using Diet.Domain.Contract.Commands.Users.Update;
using Diet.Domain.userRole;
using Diet.Domain.ticket;
using Diet.Domain.ticketMessage;

namespace Diet.Domain.user;
/// <summary>
/// کاربر سیستم
/// </summary>
public sealed class User : BaseEntity
{

    private User() { }


    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    //public bool? Female { get; private set; }
    public string? ImageName { get; private set; }
    public string? ReferenceCode { get; private set; }
    public string? VerifyCode { get; private set; }
    public string? CardNumber { get; private set; }
    public string? ShbaNumber { get; private set; }
    public DateTime? VerifyExpire { get; private set; }
    public bool Deleted { get; private set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? BirthDay { get; private set; }
    public Gender? Gender { get; private set; }
    public ICollection<UserRole> UserRoles { get; private set; }
    public ICollection<Ticket> Ticket { get; private set; }
    public ICollection<TicketMessage> FormTicketMessage { get; private set; }
    public ICollection<Case.Case> Case { get; private set; }



    private User(Guid id, string firstName, string lastName, string imageName, string referenceCode, string verifyCode, string cardNumber, string shbaNumber, DateTime? verifyExpire, bool deleted, DateTime createDate, DateTime? birthDay, Gender? gender)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ImageName = imageName;
        ReferenceCode = referenceCode;
        VerifyCode = verifyCode;
        CardNumber = cardNumber;
        ShbaNumber = shbaNumber;
        VerifyExpire = verifyExpire;
        Deleted = deleted;
        CreateDate = createDate;
        BirthDay = birthDay;
        Gender = gender;
    }

    public static ErrorOr<Domain.user.User> Create(CreateUsersCommand command)
    {
        return new User(
            Guid.NewGuid(),
            command.FirstName,
            command.LastName,
            command.ImageName,
            command.ReferenceCode,
            command.VerifyCode,
            command.CardNumber,
            command.ShbaNumber,
            command.VerifyExpire,
            command.Deleted,
            command.CreateDate,
            command.BirthDay,
            ((Gender)command.Gender)

        );
    }

    public static ErrorOr<Domain.user.User> Update(Domain.user.User existing, UpdateUsersCommand command)
    {
        return new User(
            existing.Id,
            command.FirstName,
            command.LastName,
            command.ImageName,
            command.ReferenceCode,
            command.VerifyCode,
            command.CardNumber,
            command.ShbaNumber,
            command.VerifyExpire,
            command.Deleted,
            command.CreateDate,
            command.BirthDay,
         ((Gender)command.Gender)
        );
    }
}

