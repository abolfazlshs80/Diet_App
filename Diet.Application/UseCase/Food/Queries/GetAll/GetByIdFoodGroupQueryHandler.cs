using Diet.Domain.Contract;
using Diet.Domain.Contract.Queries.Food.GetAll;
using Diet.Domain.food.Entities;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Bus;
using Diet.Application.Interface;
using ErrorOr;
using static Food.Domain.Food.Errors.DomainErrors;

namespace Diet.Application.UseCase.Food.Queries.GetAll;

public class GetAllFoodQueryHandler : IQueryHandler<GetAllFoodQuery,GetAllFoodQueryResult>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFoodQueryHandler(IFoodRepository foodRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _foodRepository = foodRepository;
    }


    public async Task<ErrorOr<GetAllFoodQueryResult>> Handle(GetAllFoodQuery Query)
    {
        var result = await _foodRepository.AllAsync(Query.search,Query.PageSize,Query.CurrentPage);
        return new GetAllFoodQueryResult(result.Count, result.Select(_ => new GetFoodItem(_.Id,_.Title,_.Description,_.Value.Value,_.FoodGroupId)).ToList(), Query.CurrentPage, Query.PageSize);
    }

   
}
