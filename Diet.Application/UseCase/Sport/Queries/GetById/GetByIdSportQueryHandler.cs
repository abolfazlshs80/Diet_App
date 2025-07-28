using Diet.Domain.sport.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.Sport.GetById;

namespace Diet.Application.UseCase.Sport.Queries.GetById;

public class GetByIdSportQueryHandler : IQueryHandler<GetByIdSportQuery, GetByIdSportQueryResult>
{
    private readonly ISportRepository _sportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSportQueryHandler(ISportRepository sportRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _sportRepository = sportRepository;
    }

    public async Task<ErrorOr<GetByIdSportQueryResult>> Handle(GetByIdSportQuery query)
    {
        var result = await _sportRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "Sport not found");

        return new GetByIdSportQueryResult(result.Id,result.Name,result.Low,result.Medium,result.High);
    }
}
