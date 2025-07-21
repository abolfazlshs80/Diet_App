



using Diet.Domain.food.Entities;

namespace Diet.Domain.user.Repository;

public interface IFoodGroupRepository
{
     Task<List<FoodGroup>>  All();
    Task<FoodGroup> ById(Guid Id);
  

    Task Save(FoodGroup FoodGroup);
    Task Update(FoodGroup FoodGroup);
    Task Delete(FoodGroup FoodGroup);
}
