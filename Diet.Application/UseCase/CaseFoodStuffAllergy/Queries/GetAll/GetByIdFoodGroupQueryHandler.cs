using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseFoodStuffAllergy.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CaseFoodStuffAllergy.Repository;
namespace Diet.Application.UseCase.CaseFoodStuffAllergy.Queries.GetAll;

public class GetAllCaseFoodStuffAllergyQueryHandler : IQueryHandler<GetAllCaseFoodStuffAllergyQuery,GetAllCaseFoodStuffAllergyQueryResult>
{
    private readonly ICaseFoodStuffAllergyRepository _CaseFoodStuffAllergyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseFoodStuffAllergyQueryHandler(ICaseFoodStuffAllergyRepository CaseFoodStuffAllergyRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseFoodStuffAllergyRepository = CaseFoodStuffAllergyRepository;
    }


    public async Task<ErrorOr<GetAllCaseFoodStuffAllergyQueryResult>> Handle(GetAllCaseFoodStuffAllergyQuery Query)
    {
        var result = await _CaseFoodStuffAllergyRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseFoodStuffAllergyQueryResult(result.Count, result.Select(_ => new GetCaseFoodStuffAllergyItem(_.Id,_.CaseId,_.FoodStuffId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
