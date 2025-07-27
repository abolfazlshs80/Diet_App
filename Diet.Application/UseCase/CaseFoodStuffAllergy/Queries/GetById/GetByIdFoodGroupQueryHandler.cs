using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Domain.CaseFoodStuffAllergy.Repository;

namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Queries.GetById;

public class GetByIdCaseFoodStuffAllergyQueryHandler : IQueryHandler<GetByIdCaseFoodStuffAllergyQuery, GetByIdCaseFoodStuffAllergyQueryResult>
{
    private readonly ICaseFoodStuffAllergyRepository _CaseFoodStuffAllergyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdCaseFoodStuffAllergyQueryHandler(ICaseFoodStuffAllergyRepository CaseFoodStuffAllergyRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseFoodStuffAllergyRepository = CaseFoodStuffAllergyRepository;
    }


    public async Task<ErrorOr<GetByIdCaseFoodStuffAllergyQueryResult>> Handle(GetByIdCaseFoodStuffAllergyQuery Query)
    {
        var result = await _CaseFoodStuffAllergyRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Error.NotFound("NotFound");


        return new GetByIdCaseFoodStuffAllergyQueryResult(result.Id,result.CaseId,result.FoodStuffId);
    }
}
