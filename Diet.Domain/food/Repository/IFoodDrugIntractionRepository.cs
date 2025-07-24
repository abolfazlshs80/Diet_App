namespace Diet.Domain.user.Repository;

public interface IFoodDrugIntractionRepository
{
    Task<List<Domain.food.Entities.Food_Drug_Intraction>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food_Drug_Intraction> ByIdAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
    Task UpdateAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
    Task DeleteAsync(Domain.food.Entities.Food_Drug_Intraction FoodDrugIntraction);
}
