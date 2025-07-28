using Diet.Domain.supplementGroup.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementGroup.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.SupplementGroup.Queries.GetAll;

public class GetAllSupplementGroupQueryHandler : IQueryHandler<GetAllSupplementGroupQuery, GetAllSupplementGroupQueryResult>
{
    private readonly ISupplementGroupRepository _supplementGroupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSupplementGroupQueryHandler(ISupplementGroupRepository supplementGroupRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementGroupRepository = supplementGroupRepository;
    }

    public async Task<ErrorOr<GetAllSupplementGroupQueryResult>> Handle(GetAllSupplementGroupQuery query)
    {
        var result = await _supplementGroupRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSupplementGroupQueryResult(
            result.Count,
            result.Select(_ => new GetSupplementGroupItem(_.Id,_.Title)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
