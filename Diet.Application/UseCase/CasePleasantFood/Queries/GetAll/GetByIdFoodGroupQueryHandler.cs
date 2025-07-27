using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.CasePleasantFood.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;

using Diet.Application.Interface;
using Diet.Domain.CasePleasantFood.Repository;
namespace Diet.Application.UseCase.CasePleasantFood.Queries.GetAll;

public class GetAllCasePleasantFoodQueryHandler : IQueryHandler<GetAllCasePleasantFoodQuery,GetAllCasePleasantFoodQueryResult>
{
    private readonly ICasePleasantFoodRepository _CasePleasantFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCasePleasantFoodQueryHandler(ICasePleasantFoodRepository CasePleasantFoodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _CasePleasantFoodRepository = CasePleasantFoodRepository;
    }


    public async Task<ErrorOr<GetAllCasePleasantFoodQueryResult>> Handle(GetAllCasePleasantFoodQuery Query)
    {
        var result = await _CasePleasantFoodRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllCasePleasantFoodQueryResult(result.Count, result.Select(_ => new GetCasePleasantFoodItem(_.Id,_.CaseId,_.FoodId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
