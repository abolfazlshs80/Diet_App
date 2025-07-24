using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.Contract.DTOs.LifeCourse
{
    public record CreateLifeCourseDto(string Title, Guid ParentId);
    public record UpdateLifeCourseDto(Guid Id,string Title, Guid ParentId);
    public record DeleteLifeCourseDto(Guid Id);
    public record GetLifeCourseDto(Guid Id);
    public record GetAllLifeCourseDto(string? search, int CurrentPage = 0, int PageSize = 8);


}
