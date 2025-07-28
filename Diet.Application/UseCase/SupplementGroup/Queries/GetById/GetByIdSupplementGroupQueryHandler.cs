using Diet.Domain.supplementGroup.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementGroup.GetById;

namespace Diet.Application.UseCase.SupplementGroup.Queries.GetById;

public class GetByIdSupplementGroupQueryHandler : IQueryHandler<GetByIdSupplementGroupQuery, GetByIdSupplementGroupQueryResult>
{
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSupplementGroupQueryHandler(ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<GetByIdSupplementGroupQueryResult>> Handle(GetByIdSupplementGroupQuery query)
    {
        var result = await _supplementGroupRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "SupplementGroup not found");

        return new GetByIdSupplementGroupQueryResult(result.Id,result.Title);
    }
}
