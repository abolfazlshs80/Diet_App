using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Drug.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Drug.Queries.GetById;

public class GetByIdDrugQueryHandler : IQueryHandler<GetByIdDrugQuery, GetByIdDrugQueryResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdDrugQueryHandler(IDrugRepository DrugRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DrugRepository = DrugRepository;
    }


    public async Task<ErrorOr<GetByIdDrugQueryResult>> Handle(GetByIdDrugQuery Query)
    {
        var result = await _DrugRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Drug_Error.Drug_NotFount;


        return new GetByIdDrugQueryResult(result.Id,result.Title,result.Description);
    }
}
