using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseDrug.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CaseDrug.Repository;
namespace Diet.Application.UseCase.CaseDrug.Queries.GetAll;

public class GetAllCaseDrugQueryHandler : IQueryHandler<GetAllCaseDrugQuery,GetAllCaseDrugQueryResult>
{
    private readonly ICaseDrugRepository _CaseDrugRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseDrugQueryHandler(ICaseDrugRepository CaseDrugRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDrugRepository = CaseDrugRepository;
    }


    public async Task<ErrorOr<GetAllCaseDrugQueryResult>> Handle(GetAllCaseDrugQuery Query)
    {
        var result = await _CaseDrugRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseDrugQueryResult(result.Count, result.Select(_ => new GetCaseDrugItem(_.Id,_.CaseId,_.DrugId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
