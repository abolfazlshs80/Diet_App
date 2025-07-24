using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.Drug
{
    public record CreateDrugDto(string Title, string Description);
    public record UpdateDrugDto(Guid Id, string Title, string Description);
    public record DeleteDrugDto(Guid Id);
    public record GetDrugDto(Guid Id);
    public record GetAllDrugDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
