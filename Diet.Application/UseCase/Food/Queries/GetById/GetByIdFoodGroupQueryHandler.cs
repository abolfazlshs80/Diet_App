using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Food.GetById;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using ErrorOr;
using static Food.Domain.Food.Errors.DomainErrors;

namespace Diet.Application.UseCase.Food.Queries.GetById;

public class GetByIdFoodQueryHandler : IQueryHandler<GetByIdFoodQuery, GetByIdFoodQueryResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWorkService _unitOfWorkService;

    public GetByIdFoodQueryHandler(IFoodRepository foodRepository, IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
        _foodRepository = foodRepository;
    }


    public async Task<ErrorOr<GetByIdFoodQueryResult>> Handle(GetByIdFoodQuery Query)
    {
        var result = await _foodRepository.ByIdAsync(Query.Id);
        if (result == null)
            return Food_Error.Food_NotFount;


        return new GetByIdFoodQueryResult(result.Id,result.Title,result.Description,result.Value.Value,result.FoodGroupId);
    }
}
