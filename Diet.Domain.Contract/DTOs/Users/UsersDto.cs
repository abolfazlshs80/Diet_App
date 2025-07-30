namespace Diet.Domain.Contract.DTOs.Users
{
    public record GetItemUsersDto(Guid Id, string FirstName, string LastName, string ImageName, string ReferenceCode, string VerifyCode, string CardNumber, string ShbaNumber, DateTime? VerifyExpire, bool Deleted, DateTime CreateDate, DateTime? BirthDay, int? Gender, string MobileNumber, string Password, string Salt);

    public record CreateUsersDto(string FirstName, string LastName, string ImageName, string ReferenceCode, string VerifyCode, string CardNumber, string ShbaNumber, DateTime? VerifyExpire, bool Deleted, DateTime CreateDate, DateTime? BirthDay, int? Gender);
    public record UpdateUsersDto(Guid Id, string FirstName, string LastName, string ImageName, string ReferenceCode, string VerifyCode, string CardNumber, string ShbaNumber, DateTime? VerifyExpire, bool Deleted, DateTime CreateDate, DateTime? BirthDay, int? Gender);
    public record DeleteUsersDto(Guid Id);
    public record GetUsersDto(Guid Id);
    public record GetAllUsersDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
