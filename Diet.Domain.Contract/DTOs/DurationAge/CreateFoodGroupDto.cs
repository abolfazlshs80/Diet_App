using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.DurationAge
{
    public record CreateDurationAgeDto(string Title);
    public record UpdateDurationAgeDto(Guid Id,string Title);
    public record DeleteDurationAgeDto(Guid Id);
    public record GetDurationAgeDto(Guid Id);
    public record GetAllDurationAgeDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
