using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CaseFoodStuffAllergy
{
    public record GetItemCaseFoodStuffAllergyDto(Guid Id, Guid FoodStuffId, Guid CaseId, Guid? FoodId);

    public record CreateCaseFoodStuffAllergyDto(  Guid CaseId, Guid FoodStuffId);
    public record UpdateCaseFoodStuffAllergyDto(Guid Id, Guid CaseId, Guid FoodStuffId);
    public record DeleteCaseFoodStuffAllergyDto(Guid Id);
    public record GetCaseFoodStuffAllergyDto(Guid Id);
    public record GetAllCaseFoodStuffAllergyDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
