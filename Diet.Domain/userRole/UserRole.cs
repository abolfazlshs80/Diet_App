using Diet.Domain.common;
using Diet.Domain.role;
using ErrorOr;
using Diet.Domain.Contract.Commands.UserRole.Create;
using Diet.Domain.Contract.Commands.UserRole.Update;
using Diet.Domain.user;

namespace Diet.Domain.userRole;

/// <summary>
/// ارتباط کاربر با مقام کاربری
/// </summary>
public sealed class UserRole : BaseEntity
{

    private UserRole() { }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    private UserRole(Guid id, Guid roleId, Guid userId)
    {
        Id = id;
        RoleId = roleId;
        UserId = userId;
    }

    public static ErrorOr<UserRole> Create(CreateUserRoleCommand command)
    {
        return new UserRole(
            Guid.NewGuid(),
            command.RoleId,
            command.UserId
        );
    }

    public static ErrorOr<UserRole> Update(UserRole existing, UpdateUserRoleCommand command)
    {
        return new UserRole(
            existing.Id,
            command.RoleId,
            command.UserId
        );
    }
}

