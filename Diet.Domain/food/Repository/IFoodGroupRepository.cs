



using Diet.Domain.food.Entities;

namespace Diet.Domain.user.Repository;

public interface IFoodGroupRepository
{
     Task<List<Domain.food.Entities. FoodGroup>>  All(string? searchText,int pageCount=8,int PageNumber=0);
    Task<Domain.food.Entities.FoodGroup> ById(Guid Id);
  

    Task Save(Domain.food.Entities.FoodGroup FoodGroup);
    Task Update(Domain.food.Entities.FoodGroup FoodGroup);
    Task Delete(Domain.food.Entities.FoodGroup FoodGroup);
}
