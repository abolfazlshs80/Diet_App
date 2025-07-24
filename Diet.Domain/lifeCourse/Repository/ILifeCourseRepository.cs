



namespace Diet.Domain.user.Repository;

public interface ILifeCourseRepository
{

    Task<List<Domain.lifeCourse.Entities.LifeCourse>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.lifeCourse.Entities.LifeCourse> ByIdAsync(Guid Id);


    Task AddAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
    Task UpdateAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
    Task DeleteAsync(Domain.lifeCourse.Entities.LifeCourse LifeCourse);
}
