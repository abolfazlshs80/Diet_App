using FluentValidation;
using Diet.Domain.Contract.Queries.SupplementLifeCourse.GetById;
namespace Diet.Application.UseCase.SupplementLifeCourse.Queries.GetById;

public class GetByIdSupplementLifeCourseQueryValidator : AbstractValidator<GetByIdSupplementLifeCourseQuery>
{
    public GetByIdSupplementLifeCourseQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
