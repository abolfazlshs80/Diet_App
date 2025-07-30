using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CaseUnPleasantFood
{
    public record GetItemCaseUnPleasantFoodDto(Guid Id, Guid FoodId, Guid CaseId);

    public record CreateCaseUnPleasantFoodDto(  Guid CaseId, Guid FoodId);
    public record UpdateCaseUnPleasantFoodDto(Guid Id, Guid CaseId, Guid FoodId);
    public record DeleteCaseUnPleasantFoodDto(Guid Id);
    public record GetCaseUnPleasantFoodDto(Guid Id);
    public record GetAllCaseUnPleasantFoodDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
