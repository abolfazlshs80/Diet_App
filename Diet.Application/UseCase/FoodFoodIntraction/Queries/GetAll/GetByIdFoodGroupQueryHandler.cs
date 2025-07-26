using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;
using Diet.Application.Interface;
namespace Diet.Application.UseCase.FoodFoodIntraction.Queries.GetAll;

public class GetAllFoodFoodIntractionQueryHandler : IQueryHandler<GetAllFoodFoodIntractionQuery,GetAllFoodFoodIntractionQueryResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFoodFoodIntractionQueryHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }


    public async Task<ErrorOr<GetAllFoodFoodIntractionQueryResult>> Handle(GetAllFoodFoodIntractionQuery Query)
    {
        var result = await _FoodFoodIntractionRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodFoodIntractionQueryResult(result.Count, result.Select(_ => new GetFoodFoodIntractionItem(_.Id,_.FoodFistId,_.FoodSecondId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
