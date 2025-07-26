using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;
using Diet.Domain.user.Repository;
using Diet.Application.Interface;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodDrugIntraction.Queries.GetById;

public class GetByIdFoodDrugIntractionQueryHandler : IQueryHandler<GetByIdFoodDrugIntractionQuery, GetByIdFoodDrugIntractionQueryResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdFoodDrugIntractionQueryHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _FoodDrugIntractionRepository = FoodDrugIntractionRepository;
    }


    public async Task<ErrorOr<GetByIdFoodDrugIntractionQueryResult>> Handle(GetByIdFoodDrugIntractionQuery Query)
    {
        var result = await _FoodDrugIntractionRepository.ByIdAsync(Query.Id);
        if (result == null)
            return FoodDrugIntraction_Error.FoodDrugIntraction_NotFount;


        return new GetByIdFoodDrugIntractionQueryResult(result.Id,result.FoodId,result.DrugId);
    }
}
