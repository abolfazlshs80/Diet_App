using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.Disease
{
    public record CreateDiseaseDto(string Title, Guid ParentId);
    public record UpdateDiseaseDto(Guid Id,string Title, Guid ParentId);
    public record DeleteDiseaseDto(Guid Id);
    public record GetItemDiseaseDto(Guid Id, string Title, Guid? ParentId);

    public record GetDiseaseDto(Guid Id);
    public record GetAllDiseaseDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
