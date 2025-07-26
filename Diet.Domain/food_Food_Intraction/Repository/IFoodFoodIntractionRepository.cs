using Diet.Domain.Contract;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IFoodFoodIntractionRepository : IRepository
{
    Task<List<Domain.food.Entities.Food_Food_Intraction>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food_Food_Intraction> ByIdAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
    Task UpdateAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
    Task DeleteAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
}