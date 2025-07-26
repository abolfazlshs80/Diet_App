using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;
using Diet.Application.Interface;
namespace Diet.Application.UseCase.FoodDrugIntraction.Queries.GetAll;

public class GetAllFoodDrugIntractionQueryHandler : IQueryHandler<GetAllFoodDrugIntractionQuery,GetAllFoodDrugIntractionQueryResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFoodDrugIntractionQueryHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }


    public async Task<ErrorOr<GetAllFoodDrugIntractionQueryResult>> Handle(GetAllFoodDrugIntractionQuery Query)
    {
        var result = await _FoodDrugIntractionRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodDrugIntractionQueryResult(result.Count, result.Select(_ => new GetFoodDrugIntractionItem(_.Id,_.FoodId,_.DrugId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
