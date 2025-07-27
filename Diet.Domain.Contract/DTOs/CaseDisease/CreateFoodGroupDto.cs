using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CaseDisease
{
    public record CreateCaseDiseaseDto(  Guid CaseId, Guid DiseaseId);
    public record UpdateCaseDiseaseDto(Guid Id, Guid CaseId, Guid DiseaseId);
    public record DeleteCaseDiseaseDto(Guid Id);
    public record GetCaseDiseaseDto(Guid Id);
    public record GetAllCaseDiseaseDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
