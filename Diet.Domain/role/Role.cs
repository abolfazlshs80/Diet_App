using Diet.Domain.common;
using ErrorOr;
using Diet.Domain.Contract.Commands.Role.Update;
using Diet.Domain.Contract.Commands.Role.Create;
using Diet.Domain.user.Entities;

namespace Diet.Domain.role;

/// <summary>
/// مقام کاربری
/// </summary>
public sealed class Role : BaseEntity
{

    private Role() { }

    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; private set; }

    private Role(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static ErrorOr<Role> Create(CreateRoleCommand command)
    {
        return new Role(
            Guid.NewGuid(),
            command.Name
        );
    }

    public static ErrorOr<Role> Update(Role existing, UpdateRoleCommand command)
    {
        return new Role(
            existing.Id,
            command.Name
        );
    }
}

