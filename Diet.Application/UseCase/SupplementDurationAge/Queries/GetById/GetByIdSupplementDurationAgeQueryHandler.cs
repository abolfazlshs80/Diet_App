using Diet.Domain.supplementDurationAge.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Domain.Contract.Queries.SupplementDurationAge.GetById;

namespace Diet.Application.UseCase.SupplementDurationAge.Queries.GetById;

public class GetByIdSupplementDurationAgeQueryHandler : IQueryHandler<GetByIdSupplementDurationAgeQuery, GetByIdSupplementDurationAgeQueryResult>
{
    private readonly ISupplementDurationAgeRepository _supplementDurationAgeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdSupplementDurationAgeQueryHandler(ISupplementDurationAgeRepository supplementDurationAgeRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _supplementDurationAgeRepository = supplementDurationAgeRepository;
    }

    public async Task<ErrorOr<GetByIdSupplementDurationAgeQueryResult>> Handle(GetByIdSupplementDurationAgeQuery query)
    {
        var result = await _supplementDurationAgeRepository.ByIdAsync(query.Id);
        if (result == null)
           return Error.NotFound("NotFound", "SupplementDurationAge not found");

        return new GetByIdSupplementDurationAgeQueryResult(result.Id,result.SupplementId,result.DurationAgeId);
    }
}
