using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodGroup.Domain.FoodGroup.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodGroup.Queries.GetAll;

public class GetAllFoodGroupQueryHandler : IQueryHandler<GetAllFoodGroupQuery,GetAllFoodGroupQueryResult>
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetAllFoodGroupQueryHandler(IFoodGroupRepository foodGroupRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodGroupRepository = foodGroupRepository;
    }


    public async Task<ErrorOr<GetAllFoodGroupQueryResult>> Handle(GetAllFoodGroupQuery Query)
    {
        var result = await _foodGroupRepository.All(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodGroupQueryResult(result.Count, result.Select(_ => new GetFoodGroupItem(_.Id,_.Title)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
