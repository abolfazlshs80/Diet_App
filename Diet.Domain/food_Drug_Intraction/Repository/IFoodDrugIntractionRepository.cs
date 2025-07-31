using Diet.Domain.Contract;
using Diet.Domain.Contract.DTOs.FoodDrugIntraction;
using Diet.Framework.Core.Interface;

namespace Diet.Domain.user.Repository;

public interface IFoodDrugIntractionRepository : IRepository
{
    Task<List<GetItemFood_Drug_IntractionDto>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food_Drug_Intraction> ByIdAsync(Guid Id);
    Task<GetItemFood_Drug_IntractionDto> ByIdDtoAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
    void Update(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
    void Delete(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
}
