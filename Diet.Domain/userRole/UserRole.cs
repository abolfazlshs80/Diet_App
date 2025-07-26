using Diet.Domain.common;

namespace Diet.Domain.user.Entities;

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

}

