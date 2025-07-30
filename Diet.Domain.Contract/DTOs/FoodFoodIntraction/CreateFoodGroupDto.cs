using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.FoodFoodIntraction
{
    public record GetItemFood_Food_IntractionDto(Guid Id, Guid FoodFistId, Guid FoodSecondId);

    public record CreateFoodFoodIntractionDto( Guid FoodFistId, Guid FoodSecondId);
    public record UpdateFoodFoodIntractionDto(Guid Id, Guid FoodFistId, Guid FoodSecondId);
    public record DeleteFoodFoodIntractionDto(Guid Id);
    public record GetFoodFoodIntractionDto(Guid Id);
    public record GetAllFoodFoodIntractionDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
