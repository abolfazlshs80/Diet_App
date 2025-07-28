using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetAll;
namespace Diet.Application.UseCase.SupplementLifeCourse.Queries.GetAll;

public class GetAllSupplementLifeCourseQueryValidator : AbstractValidator<GetAllSupplementLifeCourseQuery>
{
    public GetAllSupplementLifeCourseQueryValidator()
    {
        
    }
}
