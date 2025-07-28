namespace Diet.Domain.Contract.DTOs.UserRole
{
    public record CreateUserRoleDto(Guid RoleId, Guid UserId);
    public record UpdateUserRoleDto(Guid Id, Guid RoleId, Guid UserId);
    public record DeleteUserRoleDto(Guid Id);
    public record GetUserRoleDto(Guid Id);
    public record GetAllUserRoleDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
