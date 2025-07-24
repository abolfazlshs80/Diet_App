using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodFoodIntraction.Queries.GetAll;

public class GetAllFoodFoodIntractionQueryHandler : IQueryHandler<GetAllFoodFoodIntractionQuery,GetAllFoodFoodIntractionQueryResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetAllFoodFoodIntractionQueryHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }


    public async Task<ErrorOr<GetAllFoodFoodIntractionQueryResult>> Handle(GetAllFoodFoodIntractionQuery Query)
    {
        var result = await _FoodFoodIntractionRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodFoodIntractionQueryResult(result.Count, result.Select(_ => new GetFoodFoodIntractionItem(_.Id,_.FoodFistId,_.FoodSecondId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
