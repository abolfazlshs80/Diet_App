using Diet.Domain.supplementDisease_WhiteList.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementDisease_WhiteList.GetById;

namespace Diet.Application.UseCase.SupplementDisease_WhiteList.Queries.GetById;

public class GetByIdSupplementDisease_WhiteListQueryHandler : IQueryHandler<GetByIdSupplementDisease_WhiteListQuery, GetByIdSupplementDisease_WhiteListQueryResult>
{
    private readonly ISupplementDisease_WhiteListRepository _supplementDisease_WhiteListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSupplementDisease_WhiteListQueryHandler(ISupplementDisease_WhiteListRepository supplementDisease_WhiteListRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDisease_WhiteListRepository = supplementDisease_WhiteListRepository;
    }

    public async Task<ErrorOr<GetByIdSupplementDisease_WhiteListQueryResult>> Handle(GetByIdSupplementDisease_WhiteListQuery query)
    {
        var result = await _supplementDisease_WhiteListRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "SupplementDisease_WhiteList not found");

        return new GetByIdSupplementDisease_WhiteListQueryResult(result.Id,result.SupplementId,result.DiseaseId);
    }
}
