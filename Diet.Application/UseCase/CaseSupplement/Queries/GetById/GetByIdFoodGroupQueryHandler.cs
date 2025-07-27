using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseSupplement.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CaseSupplement.Repository;

namespace Diet.Application.UseCase.CaseSupplement.Queries.GetById;

public class GetByIdCaseSupplementQueryHandler : IQueryHandler<GetByIdCaseSupplementQuery, GetByIdCaseSupplementQueryResult>
{
    private readonly ICaseSupplementRepository _CaseSupplementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseSupplementQueryHandler(ICaseSupplementRepository CaseSupplementRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseSupplementRepository = CaseSupplementRepository;
    }


    public async Task<ErrorOr<GetByIdCaseSupplementQueryResult>> Handle(GetByIdCaseSupplementQuery Query)
    {
        var result = await _CaseSupplementRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCaseSupplementQueryResult(result.Id,result.CaseId,result.SupplementId);
    }
}
