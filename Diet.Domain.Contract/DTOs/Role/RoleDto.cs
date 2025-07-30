namespace Diet.Domain.Contract.DTOs.Role
{
    public record GetItemRoleDto(Guid Id, string Name);

    public record CreateRoleDto(string Name);
    public record UpdateRoleDto(Guid Id, string Name);
    public record DeleteRoleDto(Guid Id);
    public record GetRoleDto(Guid Id);
    public record GetAllRoleDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
