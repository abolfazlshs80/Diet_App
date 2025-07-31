



using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.Food;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IFoodRepository : IRepository
{
    Task<List<GetItemFoodDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food> ByIdAsync(Guid Id);
    Task<GetItemFoodDto> ByIdDtoAsync(Guid Id);

    Task<bool> IsExists(Guid Id);

    Task AddAsync(Domain.food.Entities.Food Food);
    void Update(Domain.food.Entities.Food Food);
    void Delete(Domain.food.Entities.Food Food);
}
