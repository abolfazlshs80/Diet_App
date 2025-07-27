using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CaseUnPleasantFood.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CaseUnPleasantFood.Repository;
namespace Diet.Application.UseCase.CaseUnPleasantFood.Queries.GetAll;

public class GetAllCaseUnPleasantFoodQueryHandler : IQueryHandler<GetAllCaseUnPleasantFoodQuery,GetAllCaseUnPleasantFoodQueryResult>
{
    private readonly ICaseUnPleasantFoodRepository _CaseUnPleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCaseUnPleasantFoodQueryHandler(ICaseUnPleasantFoodRepository CaseUnPleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CaseUnPleasantFoodRepository = CaseUnPleasantFoodRepository;
    }


    public async Task<ErrorOr<GetAllCaseUnPleasantFoodQueryResult>> Handle(GetAllCaseUnPleasantFoodQuery Query)
    {
        var result = await _CaseUnPleasantFoodRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCaseUnPleasantFoodQueryResult(result.Count, result.Select(_ => new GetCaseUnPleasantFoodItem(_.Id,_.CaseId,_.FoodId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
