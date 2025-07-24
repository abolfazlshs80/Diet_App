using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.Food
{
    public record CreateFoodDto(string Title, string Description, double Value, Guid FoodGroupId);
    public record UpdateFoodDto(Guid Id, string Title, string Description, double Value, Guid FoodGroupId);
    public record DeleteFoodDto(Guid Id);
    public record GetFoodDto(Guid Id);
    public record GetAllFoodDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
