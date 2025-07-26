using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodStuff.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using static FoodStuff.Domain.FoodStuff.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodStuff.Queries.GetAll;

public class GetAllFoodStuffQueryHandler : IQueryHandler<GetAllFoodStuffQuery,GetAllFoodStuffQueryResult>
{
    private readonly IFoodStuffRepository _FoodStuffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFoodStuffQueryHandler(IFoodStuffRepository FoodStuffRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodStuffRepository = FoodStuffRepository;
    }


    public async Task<ErrorOr<GetAllFoodStuffQueryResult>> Handle(GetAllFoodStuffQuery Query)
    {
        var result = await _FoodStuffRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodStuffQueryResult(result.Count, result.Select(_ => new GetFoodStuffItem(_.Id,_.Title)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
