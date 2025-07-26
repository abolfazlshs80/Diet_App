using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.LifeCourse.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetAll;

public class GetAllLifeCourseQueryHandler : IQueryHandler<GetAllLifeCourseQuery,GetAllLifeCourseQueryResult>
{
    private readonly ILifeCourseRepository _LifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLifeCourseQueryHandler(ILifeCourseRepository LifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _LifeCourseRepository = LifeCourseRepository;
    }


    public async Task<ErrorOr<GetAllLifeCourseQueryResult>> Handle(GetAllLifeCourseQuery Query)
    {
        var result = await _LifeCourseRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllLifeCourseQueryResult(result.Count, result.Select(_ => new GetLifeCourseItem(_.Id,_.Title,_.ParentId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
