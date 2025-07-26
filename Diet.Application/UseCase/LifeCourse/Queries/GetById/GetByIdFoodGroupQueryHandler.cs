using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.LifeCourse.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetById;

public class GetByIdLifeCourseQueryHandler : IQueryHandler<GetByIdLifeCourseQuery, GetByIdLifeCourseQueryResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdLifeCourseQueryHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
