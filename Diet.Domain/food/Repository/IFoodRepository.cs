



namespace Diet.Domain.user.Repository;

public interface IFoodRepository
{
    Task<List<Domain.food.Entities.Food>> AllAsync(string? searchText, int pageCount = 8, int PageNumber = 0);
    Task<Domain.food.Entities.Food> ByIdAsync(Guid Id);


    Task AddAsync(Domain.food.Entities.Food Food);
    Task UpdateAsync(Domain.food.Entities.Food Food);
    Task DeleteAsync(Domain.food.Entities.Food Food);
}
