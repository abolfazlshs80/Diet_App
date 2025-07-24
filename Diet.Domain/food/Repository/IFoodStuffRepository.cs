namespace Diet.Domain.user.Repository;

public interface IFoodStuffRepository
{
    Task<List<Domain.food.Entities.FoodStuff>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.FoodStuff> ByIdAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.FoodStuff FoodStuff);
    Task UpdateAsync(Domain.food.Entities.FoodStuff FoodStuff);
    Task DeleteAsync(Domain.food.Entities.FoodStuff FoodStuff);
}
