using Diet.Domain.supplementDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.SupplementDurationAge.Queries.GetAll;

public class GetAllSupplementDurationAgeQueryHandler : IQueryHandler<GetAllSupplementDurationAgeQuery, GetAllSupplementDurationAgeQueryResult>
{
    private readonly ISupplementDurationAgeRepository _supplementDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSupplementDurationAgeQueryHandler(ISupplementDurationAgeRepository supplementDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDurationAgeRepository = supplementDurationAgeRepository;
    }

    public async Task<ErrorOr<GetAllSupplementDurationAgeQueryResult>> Handle(GetAllSupplementDurationAgeQuery query)
    {
        var result = await _supplementDurationAgeRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSupplementDurationAgeQueryResult(
            result.Count,
            result.Select(_ => new GetSupplementDurationAgeItem(_.Id,_.SupplementId,_.DurationAgeId)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
