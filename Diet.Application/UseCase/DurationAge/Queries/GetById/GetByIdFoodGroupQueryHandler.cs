using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.DurationAge.GetById;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.DurationAge.Queries.GetById;

public class GetByIdDurationAgeQueryHandler : IQueryHandler<GetByIdDurationAgeQuery, GetByIdDurationAgeQueryResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdDurationAgeQueryHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DurationAgeRepository = DurationAgeRepository;
    }


    public async Task<ErrorOr<GetByIdDurationAgeQueryResult>> Handle(GetByIdDurationAgeQuery Query)
    {
        var _domain = await _DurationAgeRepository.ByIdDtoAsync(Query.Id);
        return new GetByIdDurationAgeQueryResult(_domain);
    }
}
