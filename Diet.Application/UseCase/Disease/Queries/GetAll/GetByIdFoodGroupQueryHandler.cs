using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Disease.GetAll;
using Diet.Domain.disease.Repository;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Application.Interface;
namespace Diet.Application.UseCase.Disease.Queries.GetAll;

public class GetAllDiseaseQueryHandler : IQueryHandler<GetAllDiseaseQuery,GetAllDiseaseQueryResult>
{
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDiseaseQueryHandler(IDiseaseRepository DiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DiseaseRepository = DiseaseRepository;
    }


    public async Task<ErrorOr<GetAllDiseaseQueryResult>> Handle(GetAllDiseaseQuery Query)
    {
        var result = await _DiseaseRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllDiseaseQueryResult(result.Count, result.Select(_ => new GetDiseaseItem(_.Id,_.Title,_.ParentId.Value)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
