using Diet.Domain.supplement.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Supplement.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.Supplement.Queries.GetAll;

public class GetAllSupplementQueryHandler : IQueryHandler<GetAllSupplementQuery, GetAllSupplementQueryResult>
{
    private readonly ISupplementRepository _supplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSupplementQueryHandler(ISupplementRepository supplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementRepository = supplementRepository;
    }

    public async Task<ErrorOr<GetAllSupplementQueryResult>> Handle(GetAllSupplementQuery query)
    {
        var result = await _supplementRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSupplementQueryResult(
            result.Count,
            result.Select(_ => new GetSupplementItem(_.Id,_.Title,_.EnglishTitle,_.Description,_.HowToUse,_.SupplementGroupId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
