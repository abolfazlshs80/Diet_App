using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Disease.GetById;
using Diet.Domain.disease.Repository;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using Diet.Application.Interface;
using static Disease.Domain.Disease.Errors.DomainErrors;
using static Drug.Domain.Drug.Errors.DomainErrors;

namespace Diet.Application.UseCase.Disease.Queries.GetById;

public class GetByIdDiseaseQueryHandler : IQueryHandler<GetByIdDiseaseQuery, GetByIdDiseaseQueryResult>
{
    private readonly IDiseaseRepository _DiseaseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdDiseaseQueryHandler(IDiseaseRepository DiseaseRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _DiseaseRepository = DiseaseRepository;
    }


    public async Task<ErrorOr<GetByIdDiseaseQueryResult>> Handle(GetByIdDiseaseQuery Query)
    {
        var result = await _DiseaseRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Disease_Error.Disease_NotFount;


        return new GetByIdDiseaseQueryResult(result.Id,result.Title,result.ParentId.Value);
    }
}
