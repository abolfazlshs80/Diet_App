using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CasePleasantFood
{
    public record CreateCasePleasantFoodDto(  Guid CaseId, Guid FoodId);
    public record UpdateCasePleasantFoodDto(Guid Id, Guid CaseId, Guid FoodId);
    public record DeleteCasePleasantFoodDto(Guid Id);
    public record GetCasePleasantFoodDto(Guid Id);
    public record GetAllCasePleasantFoodDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
