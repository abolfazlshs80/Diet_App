using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.FoodFoodIntraction.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static FoodFoodIntraction.Domain.FoodFoodIntraction.Errors.DomainErrors;

namespace Diet.Application.UseCase.FoodFoodIntraction.Queries.GetById;

public class GetByIdFoodFoodIntractionQueryHandler : IQueryHandler<GetByIdFoodFoodIntractionQuery, GetByIdFoodFoodIntractionQueryResult>
{
    private readonly IFoodFoodIntractionRepository _FoodFoodIntractionRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdFoodFoodIntractionQueryHandler(IFoodFoodIntractionRepository FoodFoodIntractionRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _FoodFoodIntractionRepository = FoodFoodIntractionRepository;
    }


    public async Task<ErrorOr<GetByIdFoodFoodIntractionQueryResult>> Handle(GetByIdFoodFoodIntractionQuery Query)
    {
        var result = await _FoodFoodIntractionRepository.ByIdAsync(Query.Id);
        if (result == null)
            return FoodFoodIntraction_Error.FoodFoodIntraction_NotFount;


        return new GetByIdFoodFoodIntractionQueryResult(result.Id,result.FoodFistId,result.FoodSecondId);
    }
}
