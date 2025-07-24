using Diet.Domain.Contract.Queries.LifeCourse.GetById;
using FluentValidation;

namespace Diet.Application.UseCase.LifeCourse.Queries.GetById;

public class GetByIdLifeCourseQueryValidator : AbstractValidator<GetByIdLifeCourseQuery>
{
    public GetByIdLifeCourseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();

    }
}

