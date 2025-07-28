using Diet.Domain.supplementLifeCourse.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetById;

namespace Diet.Application.UseCase.SupplementLifeCourse.Queries.GetById;

public class GetByIdSupplementLifeCourseQueryHandler : IQueryHandler<GetByIdSupplementLifeCourseQuery, GetByIdSupplementLifeCourseQueryResult>
{
    private readonly ISupplementLifeCourseRepository _supplementLifeCourseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSupplementLifeCourseQueryHandler(ISupplementLifeCourseRepository supplementLifeCourseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementLifeCourseRepository = supplementLifeCourseRepository;
    }

    public async Task<ErrorOr<GetByIdSupplementLifeCourseQueryResult>> Handle(GetByIdSupplementLifeCourseQuery query)
    {
        var result = await _supplementLifeCourseRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "SupplementLifeCourse not found");

        return new GetByIdSupplementLifeCourseQueryResult(result.Id,result.SupplementId,result.LifeCourseId);
    }
}
