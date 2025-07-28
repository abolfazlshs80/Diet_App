using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Queries.GetAll;

public class GetAllSupplementDisease_WhiteListQueryHandler : IQueryHandler<GetAllSupplementDisease_WhiteListQuery, GetAllSupplementDisease_WhiteListQueryResult>
{
    private readonly ISupplementDisease_WhiteListRepository _supplementDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSupplementDisease_WhiteListQueryHandler(ISupplementDisease_WhiteListRepository supplementDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDisease_WhiteListRepository = supplementDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<GetAllSupplementDisease_WhiteListQueryResult>> Handle(GetAllSupplementDisease_WhiteListQuery query)
    {
        var result = await _supplementDisease_WhiteListRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSupplementDisease_WhiteListQueryResult(
            result.Count,
            result.Select(_ => new GetSupplementDisease_WhiteListItem(_.Id,_.SupplementId,_.DiseaseId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
