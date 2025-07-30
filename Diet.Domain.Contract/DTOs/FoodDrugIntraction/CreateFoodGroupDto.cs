using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.FoodDrugIntraction
{
    public record CreateFoodDrugIntractionDto(Guid FoodId, Guid DrugId);
    public record UpdateFoodDrugIntractionDto(Guid Id, Guid FoodId, Guid DrugId);
    public record DeleteFoodDrugIntractionDto(Guid Id);
    public record GetFoodDrugIntractionDto(Guid Id);
    public record GetItemFood_Drug_IntractionDto(Guid Id, Guid FoodId, Guid DrugId);

    public record GetAllFoodDrugIntractionDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
