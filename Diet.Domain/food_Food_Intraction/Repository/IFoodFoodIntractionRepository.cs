using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.FoodFoodIntraction;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IFoodFoodIntractionRepository : IRepository
{
    Task<List<GetItemFood_Food_IntractionDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food_Food_Intraction> ByIdAsync(Guid Id);
    Task<GetItemFood_Food_IntractionDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
    void Update(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
    void Delete(Domain.food.Entities.Food_Food_Intraction FoodFoodIntraction);
}