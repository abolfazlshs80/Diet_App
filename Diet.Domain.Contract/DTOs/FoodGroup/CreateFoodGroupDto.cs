using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.FoodGroup
{
    public record GetItemFoodGroupDto(Guid Id, string Title);

    public record CreateFoodGroupDto(string Title);
    public record UpdateFoodGroupDto(Guid Id,string Title);
    public record DeleteFoodGroupDto(Guid Id);
    public record GetFoodGroupDto(Guid Id);
    public record GetAllFoodGroupDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
