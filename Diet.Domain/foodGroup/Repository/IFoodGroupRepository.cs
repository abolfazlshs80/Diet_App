



using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.FoodGroup;
using Diet.Domain.food.Entities;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IFoodGroupRepository : IRepository
{
     Task<List<GetItemFoodGroupDto>>  AllAsync(string? searchText,int pageCount=8,int PageNumber=0);
    Task<Domain.food.Entities.FoodGroup> ByIdAsync(Guid Id);
    Task<GetItemFoodGroupDto> ByIdDtoAsync(Guid Id);


    Task<bool> IsExists(Guid Id);
    Task AddAsync(Domain.food.Entities.FoodGroup FoodGroup);
    void Update(Domain.food.Entities.FoodGroup FoodGroup);
    void Delete(Domain.food.Entities.FoodGroup FoodGroup);
}
