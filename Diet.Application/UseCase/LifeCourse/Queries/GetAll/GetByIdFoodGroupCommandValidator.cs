
using Diet.Domain.Contract.Queries.LifeCourse.GetAll;
using FluentValidation;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetAll;

public class GetAllLifeCourseQueryValidator : AbstractValidator<GetAllLifeCourseQuery>
{
    public GetAllLifeCourseQueryValidator()
    {
     

    }
}

