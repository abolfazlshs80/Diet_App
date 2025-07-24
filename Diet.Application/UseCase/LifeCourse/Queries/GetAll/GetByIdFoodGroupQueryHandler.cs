using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.LifeCourse.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetAll;

public class GetAllLifeCourseQueryHandler : IQueryHandler<GetAllLifeCourseQuery,GetAllLifeCourseQueryResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetAllLifeCourseQueryHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _LifeCourseRepository = LifeCourseRepository;
    }


    public async Task<ErrorOr<GetAllLifeCourseQueryResult>> Handle(GetAllLifeCourseQuery Query)
    {
        var result = await _LifeCourseRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllLifeCourseQueryResult(result.Count, result.Select(_ => new GetLifeCourseItem(_.Id,_.Title,_.ParentId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
