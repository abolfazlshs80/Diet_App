using Diet.Domain.Contract.DTOs.SupplementLifeCourse;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.supplementLifeCourse.Repository
{
    public interface ISupplementLifeCourseRepository : IRepository
    {
        Task<List<GetItemSupplementLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.supplementLifeCourse.SupplementLifeCourse> ByIdAsync(Guid id);
        Task<GetItemSupplementLifeCourseDto> ByIdDtoAsync(Guid id);

        Task AddAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse);
        Task UpdateAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse);
        Task DeleteAsync(Diet.Domain.supplementLifeCourse.SupplementLifeCourse supplementLifeCourse);
    }
}
