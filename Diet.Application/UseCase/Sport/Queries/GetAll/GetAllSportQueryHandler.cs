using Diet.Domain.sport.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Sport.GetAll;
using System.Linq;

namespace Diet.Application.UseCase.Sport.Queries.GetAll;

public class GetAllSportQueryHandler : IQueryHandler<GetAllSportQuery, GetAllSportQueryResult>
{
    private readonly ISportRepository _sportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSportQueryHandler(ISportRepository sportRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _sportRepository = sportRepository;
    }

    public async Task<ErrorOr<GetAllSportQueryResult>> Handle(GetAllSportQuery query)
    {
        var result = await _sportRepository.AllAsync(query.search, query.PageSize, query.CurrentPage);
        return new GetAllSportQueryResult(
            result.Count,
            result.Select(_ => new GetSportItem(_.Id,_.Name,_.Low,_.Medium,_.High)).ToList(),
            query.CurrentPage,
            query.PageSize
        );
    }
}
