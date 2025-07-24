using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodDrugIntraction.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodDrugIntraction.Domain.FoodDrugIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodDrugIntraction.Queries.GetById;

public class GetByIdFoodDrugIntractionQueryHandler : IQueryHandler<GetByIdFoodDrugIntractionQuery, GetByIdFoodDrugIntractionQueryResult>
{
    private readonly IFoodDrugIntractionRepository _FoodDrugIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdFoodDrugIntractionQueryHandler(IFoodDrugIntractionRepository FoodDrugIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
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
