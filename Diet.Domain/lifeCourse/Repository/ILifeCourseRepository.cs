



using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.LifeCourse;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface ILifeCourseRepository : IRepository
{

    Task<List<GetItemLifeCourseDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.lifeCourse.Entities.LifeCourse> ByIdAsync(Guid Id);
    Task<GetItemLifeCourseDto> ByIdDtoAsync(Guid Id);

    Task<bool> IsExists(Guid Id);
    Task AddAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
    void Update(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
    void Delete(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
}
