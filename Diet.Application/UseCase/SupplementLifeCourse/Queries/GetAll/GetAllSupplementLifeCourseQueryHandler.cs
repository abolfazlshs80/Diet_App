using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.SupplementLifeCourse.Queries.GetAll;

public class GetAllSupplementLifeCourseQueryHandler : IQueryHandler<GetAllSupplementLifeCourseQuery, GetAllSupplementLifeCourseQueryResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSupplementLifeCourseQueryHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
    }

    public async Task<ErrorOr<GetAllSupplementLifeCourseQueryResult>> Handle(GetAllSupplementLifeCourseQuery query)
    {
        var result = await _supplementLifeCourseRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSupplementLifeCourseQueryResult(
            result.Count,
            result.Select(_ => new GetSupplementLifeCourseItem(_.Id,_.SupplementId,_.LifeCourseId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
