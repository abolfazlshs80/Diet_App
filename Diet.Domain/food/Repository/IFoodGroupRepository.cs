



using Diet.Domain.food.Entities;

namespace Diet.Domain.user.Repository;

public interface IFoodGroupRepository
{
     Task<List<Domain.food.Entities. FoodGroup>>  AllAsync(string? searchText,int pageCount=8,int PageNumber=0);
    Task<Domain.food.Entities.FoodGroup> ByIdAsync(Guid Id);
  

    Task AddAsync(Domain.food.Entities.FoodGroup FoodGroup);
    Task UpdateAsync(Domain.food.Entities.FoodGroup FoodGroup);
    Task DeleteAsync(Domain.food.Entities.FoodGroup FoodGroup);
}
