using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.DurationAge.GetById;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.DurationAge.Queries.GetById;

public class GetByIdDurationAgeQueryHandler : IQueryHandler<GetByIdDurationAgeQuery, GetByIdDurationAgeQueryResult>
{
    private readonly IDurationAgeRepository _DurationAgeRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdDurationAgeQueryHandler(IDurationAgeRepository DurationAgeRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DurationAgeRepository = DurationAgeRepository;
    }


    public async Task<ErrorOr<GetByIdDurationAgeQueryResult>> Handle(GetByIdDurationAgeQuery Query)
    {
        var result = await _DurationAgeRepository.ByIdAsync(Query.Id);
        if (result == null)
            return DurationAge_Error.DurationAge_NotFount;


        return new GetByIdDurationAgeQueryResult(result.Id,result.Title);
    }
}
