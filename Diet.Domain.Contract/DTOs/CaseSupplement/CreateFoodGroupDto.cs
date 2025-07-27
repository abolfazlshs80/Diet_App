using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.CaseSupplement
{
    public record CreateCaseSupplementDto(  Guid CaseId, Guid SupplementId);
    public record UpdateCaseSupplementDto(Guid Id, Guid CaseId, Guid SupplementId);
    public record DeleteCaseSupplementDto(Guid Id);
    public record GetCaseSupplementDto(Guid Id);
    public record GetAllCaseSupplementDto(string? search, int CurrentPage = 0, int PageSize = 8);
}
