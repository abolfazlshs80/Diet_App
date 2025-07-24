using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodStuff.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Queries.GetAll;

public class GetAllFoodStuffQueryHandler : IQueryHandler<GetAllFoodStuffQuery,GetAllFoodStuffQueryResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetAllFoodStuffQueryHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodStuffRepository = FoodStuffRepository;
    }


    public async Task<ErrorOr<GetAllFoodStuffQueryResult>> Handle(GetAllFoodStuffQuery Query)
    {
        var result = await _FoodStuffRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodStuffQueryResult(result.Count, result.Select(_ => new GetFoodStuffItem(_.Id,_.Title)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
