using Diet.Domain.Contract;
using Diet.Application.Interface;
using Diet.Domain.Contract.Queries.DurationAge.GetAll;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

namespace Diet.Application.UseCase.DurationAge.Queries.GetAll;

public class GetAllDurationAgeQueryHandler : IQueryHandler<GetAllDurationAgeQuery,GetAllDurationAgeQueryResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDurationAgeQueryHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DurationAgeRepository = DurationAgeRepository;
    }


    public async Task<ErrorOr<GetAllDurationAgeQueryResult>> Handle(GetAllDurationAgeQuery Query)
    {
        var result = await _DurationAgeRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllDurationAgeQueryResult(result.Count, result.Select(_ => new GetDurationAgeItem(_.Id,_.Title)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
