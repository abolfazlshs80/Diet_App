using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseDrug.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CaseDrug.Repository;

namespace Diet.Application.UseCase.CaseDrug.Queries.GetById;

public class GetByIdCaseDrugQueryHandler : IQueryHandler<GetByIdCaseDrugQuery, GetByIdCaseDrugQueryResult>
{
    private readonly ICaseDrugRepository _CaseDrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseDrugQueryHandler(ICaseDrugRepository CaseDrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
    }


    public async Task<ErrorOr<GetByIdCaseDrugQueryResult>> Handle(GetByIdCaseDrugQuery Query)
    {
        var result = await _CaseDrugRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCaseDrugQueryResult(result.Id,result.CaseId,result.DrugId);
    }
}
