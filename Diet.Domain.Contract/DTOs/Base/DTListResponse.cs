
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs
{

    public record ListResponseDto<T>(int TotalRecords, T Data, int CurrentPage, int PageSize);


    public record ListRequestDto(string? search, int CurrentPage, int PageSize);
}
