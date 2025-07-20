using Diet.Domain.common;

namespace Diet.Domain.user.Entities;

/// <summary>
/// مقام کاربری
/// </summary>
public sealed class Role : BaseEntity
{

    private Role() { }

    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; private set; }
}

