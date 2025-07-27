using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseDisease.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CaseDisease.Repository;

namespace Diet.Application.UseCase.CaseDisease.Queries.GetById;

public class GetByIdCaseDiseaseQueryHandler : IQueryHandler<GetByIdCaseDiseaseQuery, GetByIdCaseDiseaseQueryResult>
{
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseDiseaseQueryHandler(ICaseDiseaseRepository CaseDiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
    }


    public async Task<ErrorOr<GetByIdCaseDiseaseQueryResult>> Handle(GetByIdCaseDiseaseQuery Query)
    {
        var result = await _CaseDiseaseRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCaseDiseaseQueryResult(result.Id,result.CaseId,result.DiseaseId);
    }
}
