using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.LifeCourse.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetById;

public class GetByIdLifeCourseQueryHandler : IQueryHandler<GetByIdLifeCourseQuery, GetByIdLifeCourseQueryResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdLifeCourseQueryHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _LifeCourseRepository = LifeCourseRepository;
    }


    public async Task<ErrorOr<GetByIdLifeCourseQueryResult>> Handle(GetByIdLifeCourseQuery Query)
    {
        var result = await _LifeCourseRepository.ByIdAsync(Query.Id);
        if (result == null)
            return LifeCourse_Error.LifeCourse_NotFount;


        return new GetByIdLifeCourseQueryResult(result.Id,result.Title,result.ParentId);
    }
}
