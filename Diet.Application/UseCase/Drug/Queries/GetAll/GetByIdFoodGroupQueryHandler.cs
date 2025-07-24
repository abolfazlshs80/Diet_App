using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Drug.GetAll;

using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Drug.Queries.GetAll;

public class GetAllDrugQueryHandler : IQueryHandler<GetAllDrugQuery,GetAllDrugQueryResult>
{
    private readonly IDrugRepository _DrugRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetAllDrugQueryHandler(IDrugRepository DrugRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _DrugRepository = DrugRepository;
    }


    public async Task<ErrorOr<GetAllDrugQueryResult>> Handle(GetAllDrugQuery Query)
    {
        var result = await _DrugRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllDrugQueryResult(result.Count, result.Select(_ => new GetDrugItem(_.Id,_.Title,_.Description)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
