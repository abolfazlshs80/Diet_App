using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CaseDrug
{
    public record GetItemCaseDrugDto(Guid Id, Guid CaseId, Guid DrugId);

    public record CreateCaseDrugDto(  Guid CaseId, Guid DrugId);
    public record UpdateCaseDrugDto(Guid Id, Guid CaseId, Guid DrugId);
    public record DeleteCaseDrugDto(Guid Id);
    public record GetCaseDrugDto(Guid Id);
    public record GetAllCaseDrugDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
