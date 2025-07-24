using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.FoodStuff
{
    public record CreateFoodStuffDto(string Title);
    public record UpdateFoodStuffDto(Guid Id,string Title);
    public record DeleteFoodStuffDto(Guid Id);
    public record GetFoodStuffDto(Guid Id);
    public record GetAllFoodStuffDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
