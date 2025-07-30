namespace Diet.Domain.Contract.DTOs.SupplementLifeCourse
{
    public record GetItemSupplementLifeCourseDto(Guid Id, Guid SupplementId, Guid LifeCourseId);

    public record CreateSupplementLifeCourseDto(Guid SupplementId, Guid LifeCourseId);
    public record UpdateSupplementLifeCourseDto(Guid Id, Guid SupplementId, Guid LifeCourseId);
    public record DeleteSupplementLifeCourseDto(Guid Id);
    public record GetSupplementLifeCourseDto(Guid Id);
    public record GetAllSupplementLifeCourseDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
