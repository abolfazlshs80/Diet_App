using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseDisease.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CaseDisease.Repository;
namespace Diet.Application.UseCase.CaseDisease.Queries.GetAll;

public class GetAllCaseDiseaseQueryHandler : IQueryHandler<GetAllCaseDiseaseQuery,GetAllCaseDiseaseQueryResult>
{
    private readonly ICaseDiseaseRepository _CaseDiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseDiseaseQueryHandler(ICaseDiseaseRepository CaseDiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseDiseaseRepository = CaseDiseaseRepository;
    }


    public async Task<ErrorOr<GetAllCaseDiseaseQueryResult>> Handle(GetAllCaseDiseaseQuery Query)
    {
        var result = await _CaseDiseaseRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseDiseaseQueryResult(result.Count, result.Select(_ => new GetCaseDiseaseItem(_.Id,_.CaseId,_.DiseaseId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
