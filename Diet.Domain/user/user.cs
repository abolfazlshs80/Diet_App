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
using Diet.Domain.Contract.Commands.Account.Register;

namespace Diet.Domain.user;
/// <summary>
/// کاربر سیستم
/// </summary>
public sealed class User : BaseEntity
{

    private User() { }


    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Password { get; private set; }
    public string? MobileNumber { get; private set; }
    public string? Salt { get; private set; }
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



    private User(Guid id, string firstName, string lastName, string imageName, string referenceCode, string verifyCode, string cardNumber, string shbaNumber, DateTime? verifyExpire, bool deleted, DateTime createDate, DateTime? birthDay, Gender? gender,string? password,string? salt,string mobileNumber)
    {
        MobileNumber=mobileNumber;
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
        Password = password;
        Salt = salt;
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
            ((Gender)command.Gender),null,null,null

        );
    }
    public static ErrorOr<Domain.user.User> Create(RegisterUserCommand command)
    {
        return new User(
            Guid.NewGuid(),
            command.Firstname,
            command.Lastname,
            null,
            null,
            null,
            null,
            null,
            null,
            false,
            DateTime.Now,
            null,
            null
            ,command.Password
            ,command.Salt
            ,command.MobileNumber

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
         ,null
         ,null
         ,null
        );
    }
}

